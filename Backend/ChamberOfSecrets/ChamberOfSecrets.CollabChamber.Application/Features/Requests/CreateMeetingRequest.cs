using ChamberOfSecrets.CollabChamber.Application.DTOs.Meeting;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChamberOfSecrets.CollabChamber.Application.Features.Requests;

public class CreateMeetingRequest : IRequest<MeetingDto>
{
    public CreateMeetingDto MeetingDto { get; set; }
}
