using ChamberOfSecrets.CollabChamber.Application.DTOs.Participant;
using ChamberOfSecrets.CollabChamber.Application.Features.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChamberOfSecrets.CollabChamber.Application.Features.Handlers;

public class GetMeetingParticpantsHandler : IRequestHandler<GetMeetingParticpantsRequest, List<ParticipantDto>>
{
    public Task<List<ParticipantDto>> Handle(GetMeetingParticpantsRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
