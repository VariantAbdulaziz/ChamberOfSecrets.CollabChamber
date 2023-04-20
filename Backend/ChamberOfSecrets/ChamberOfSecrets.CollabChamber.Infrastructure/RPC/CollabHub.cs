using AutoMapper;
using ChamberOfSecrets.CollabChamber.Application.Contracts.Infrastructure;
using ChamberOfSecrets.CollabChamber.Application.Contracts.Persistence;
using ChamberOfSecrets.CollabChamber.Application.DTOs.CodeEditor;
using ChamberOfSecrets.CollabChamber.Domain;
using DiffMatchPatch;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChamberOfSecrets.CollabChamber.Infrastructure.RPC;

public class CollabHub : Hub<ICollabHubClient>, ICollabHub
{
    private readonly IMeetingRepository _meetingRepository;
    private readonly IShadowRepository _shadowRepository;
    private readonly IMapper _mapper;

    public CollabHub(IMeetingRepository meetingRepository, IShadowRepository shadowRepository, IMapper mapper)
    {
        _meetingRepository = meetingRepository;
        _shadowRepository = shadowRepository;
        _mapper = mapper;
    }
    public async Task SendEdit(int meetingId, EditDto edit)
    {
        var connectionId = Context.ConnectionId;
        var State = (await _meetingRepository.GetCodeEdtior(meetingId)).Code;
        var shadowbulk = await _shadowRepository.GetOrCreate(connectionId);
        var shadow = shadowbulk.Code;
        diff_match_patch dmp = new diff_match_patch();
        var patches = dmp.patch_fromText(edit.Patches);
        var result = dmp.patch_apply(patches, shadow);
        if (result[0] is string)
            shadow = result[0] as string;

        result = dmp.patch_apply(patches, State);
        if (result[0] is string)
            State = result[0] as string;

        var diffs = dmp.diff_main(shadow, State);
        patches = dmp.patch_make(diffs);

        result = dmp.patch_apply(patches, shadow);
        if (result[0] is string)
            shadow = result[0] as string;

        shadowbulk.Code = shadow;
        
        await _shadowRepository.Update(_mapper.Map<Shadow>(shadowbulk) );
        var propagatedEdit = new EditDto { Patches = dmp.patch_toText(patches) };

        await Clients.Client(connectionId).EditReceived(propagatedEdit);
        var peers = await _meetingRepository.GetParticipants(meetingId);
        foreach (var peer in peers)
        {
            if (peer.ConnectionId == Context.ConnectionId) continue;
            await Clients.Client(connectionId).EditReceived(propagatedEdit);
        }
    }
}
