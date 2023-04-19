using ChamberOfSecrets.CollabChamber.Application.Contracts.Infrastructure;
using ChamberOfSecrets.CollabChamber.Application.Contracts.Persistence;
using ChamberOfSecrets.CollabChamber.Application.DTOs.Meeting;
using ChamberOfSecrets.CollabChamber.Application.DTOs.Participant;
using ChamberOfSecrets.CollabChamber.Domain;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ChamberOfSecrets.CollabChamber.Infrastructure.RPC;

public class MeetingHub : Hub<IMeetingHubClient>, IMeetingHub
{
    private IMeetingRepository _meetingRepository;
    private IConnectionRepository _connectionRepository;

    public MeetingHub(IMeetingRepository meetingsRepositoroy, IConnectionRepository connectionRepository)
    {
        _meetingRepository = meetingsRepositoroy;
        _connectionRepository = connectionRepository;
    }

    public async Task<ParticipantDto> JoinMeeting(int meetingId, CreateParticipantDto participantDto)
    {
        var participant = await _meetingRepository.AddParticipant(meetingId, participantDto);
        var peers = await _meetingRepository.GetParticipants(meetingId);
        foreach(var peer in peers)
        {
            if(peer.ConnectionId == Context.ConnectionId) continue;
            await Clients.Client(peer.ConnectionId).ParticipantJoined(participant);
        }
        return participant;
    }

    public async Task LeaveMeeting(int meetingId, int particpantId)
    {
        var participant = await _meetingRepository.RemoveParticipant(meetingId, particpantId);
        var peers = await _meetingRepository.GetParticipants(meetingId);
        foreach (var peer in peers)
        {
            await Clients.Client(peer.ConnectionId).ParticipantLeft(participant);
        }
    }

    public async Task SendMessage(int meetingId, string content)
    {
        Message message = new Message { Content = content, Participant = await _connectionRepository.GetParticipant(Context.ConnectionId) };
        var peers = await _meetingRepository.GetParticipants(meetingId);
        foreach (var peer in peers)
        {
            await Clients.Client(peer.ConnectionId).MessageRecieved(message);
        }
    }
}

