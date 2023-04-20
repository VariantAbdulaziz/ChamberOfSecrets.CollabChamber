using ChamberOfSecrets.CollabChamber.Application.DTOs.Meeting;
using ChamberOfSecrets.CollabChamber.Application.DTOs.Participant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChamberOfSecrets.CollabChamber.Application.Contracts.Infrastructure;

public interface IMeetingHub
{
    Task<ParticipantDto> JoinMeeting(int meetingId, CreateParticipantDto participantDto);
    Task LeaveMeeting(int meetingId, int particpantId);
    Task SendMessage(int meetingId, string message);
}
