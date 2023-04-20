using ChamberOfSecrets.CollabChamber.Application.DTOs.Meeting;
using ChamberOfSecrets.CollabChamber.Application.Features.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChamberOfSecrets.CollabChamber.Application.Features.Handlers;

public class CreateMeetingHandler : IRequestHandler<CreateMeetingRequest, MeetingDto>
{
    public Task<MeetingDto> Handle(CreateMeetingRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
