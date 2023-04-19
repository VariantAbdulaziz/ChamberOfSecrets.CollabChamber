using ChamberOfSecrets.CollabChamber.Application.DTOs.Participant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChamberOfSecrets.CollabChamber.Application.DTOs.Meeting;

public class Message
{
    public string Content { get; set; }
    public ParticipantDto Participant { get; set; }
}
