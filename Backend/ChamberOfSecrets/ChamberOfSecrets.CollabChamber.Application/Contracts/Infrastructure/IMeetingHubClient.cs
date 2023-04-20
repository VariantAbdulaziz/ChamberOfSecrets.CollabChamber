using ChamberOfSecrets.CollabChamber.Application.DTOs.Meeting;
using ChamberOfSecrets.CollabChamber.Application.DTOs.Participant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChamberOfSecrets.CollabChamber.Application.Contracts.Infrastructure;

public interface IMeetingHubClient
{
    Task ParticipantLeft(ParticipantDto participantDto);
    Task ParticipantJoined(ParticipantDto participantDto);
    Task MessageRecieved(Message message);
}
