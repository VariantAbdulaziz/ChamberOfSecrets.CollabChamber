using AutoMapper;
using ChamberOfSecrets.CollabChamber.Application.DTOs.CodeEditor;
using ChamberOfSecrets.CollabChamber.Application.DTOs.Participant;
using ChamberOfSecrets.CollabChamber.Domain;
using ChamberOfSecrets.CollabChamber.Persistence;
using ChamberOfSecrets.CollabChamber.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChamberOfSecrets.CollabChamber.Application.Contracts.Persistence;

public class MeetingRepository : GenericRepository<Meeting>, IMeetingRepository
{
    private readonly CollabChamberDbContext _dbContext;
    private readonly IMapper _mapper;
    private readonly IParticipantRepository _participantRepository;
    private readonly IMeetingParticipantRepository _meetingParticipantRepository;

    public MeetingRepository(CollabChamberDbContext dbContext, IMapper mapper, IParticipantRepository participantRepository, IMeetingParticipantRepository meetingParticipantRepository)
        : base(dbContext)
    {
        _dbContext = dbContext;
        _mapper = mapper;
        _participantRepository = participantRepository;
        _meetingParticipantRepository = meetingParticipantRepository;
    }

    public async Task<ParticipantDto> AddParticipant(int meetingId, CreateParticipantDto particpantDto)
    {
        var participant = _mapper.Map<Participant>(particpantDto);
        _participantRepository.Add(participant);
        await _dbContext.SaveChangesAsync();
        var bridge = await _dbContext.MeetingParticipants.FirstOrDefaultAsync(q => q.MeetingId == meetingId && q.ParticipantId == participant.Id);
        if(bridge == null)
        {
            bridge = await _meetingParticipantRepository.Add(new MeetingParticipant { MeetingId = meetingId, ParticipantId = participant.Id });
        }
        bridge.ParticipantId = participant.Id;
        bridge.Participant = participant;
        _dbContext.Update(bridge);
        return _mapper.Map<ParticipantDto>(participant);
    }

    public async Task<CodeEditorDto> GetCodeEdtior(int meetingId)
    {
        var codeEditor = (await _dbContext.Meetings.FirstOrDefaultAsync(q => q.Id == meetingId)).CodeEditor;
        return _mapper.Map<CodeEditorDto>(codeEditor);
    }

    public async Task<IReadOnlyList<ParticipantDto>> GetParticipants(int meetingId)
    {
        var meetingParticipants = (await _dbContext.Meetings.FirstOrDefaultAsync(q => q.Id == meetingId)).MeetingParticipants;
        var participants = meetingParticipants.Select(bridge =>
        _mapper.Map<ParticipantDto>(bridge.Participant)).ToList();
        return participants;
    }

    public async Task<ParticipantDto> RemoveParticipant(int meetingId, int particpantId)
    {
        var participant = await _participantRepository.Get(particpantId);
        await _participantRepository.Delete(participant);
        return _mapper.Map<ParticipantDto>(participant);
    }
}
