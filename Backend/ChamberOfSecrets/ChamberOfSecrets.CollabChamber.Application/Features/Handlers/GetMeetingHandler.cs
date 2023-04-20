using ChamberOfSecrets.CollabChamber.Application.DTOs.CodeEditor;
using ChamberOfSecrets.CollabChamber.Application.DTOs.Meeting;
using ChamberOfSecrets.CollabChamber.Application.Features.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChamberOfSecrets.CollabChamber.Application.Features.Handlers;

public class GetMeetingHandler : IRequestHandler<GetMeetingRequest, MeetingDto>
{
    public Task<MeetingDto> Handle(GetMeetingRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

