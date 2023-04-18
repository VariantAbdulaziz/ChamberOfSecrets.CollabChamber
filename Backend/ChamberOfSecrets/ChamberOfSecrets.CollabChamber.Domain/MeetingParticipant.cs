using ChamberOfSecrets.CollabChamber.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChamberOfSecrets.CollabChamber.Domain;

public class MeetingParticipant : BaseDomainEntity
{
    public int MeetingId { get; set; }
    public int ParticipantId { get; set; }
    public Meeting Meeting { get; set; }
    public Participant Participant { get; set; }
}
