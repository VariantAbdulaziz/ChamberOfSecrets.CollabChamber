using ChamberOfSecrets.CollabChamber.Application.DTOs.Participant;
using ChamberOfSecrets.CollabChamber.Application.Features.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChamberOfSecrets.CollabChamber.Application.Features.Requests;

public class GetMeetingParticpantsRequest : IRequest<List<ParticipantDto>>
{
    public int Id { get; set; }
}
