using ChamberOfSecrets.CollabChamber.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChamberOfSecrets.CollabChamber.Application.DTOs.Participant;

public class ParticipantDto : BaseDto
{
    public string Name { get; set; }
    public string ConnectionId { get; set; }
}