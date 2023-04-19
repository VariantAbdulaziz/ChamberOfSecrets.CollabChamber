using ChamberOfSecrets.CollabChamber.Domain.Common;

namespace ChamberOfSecrets.CollabChamber.Domain;

public class Connection : BaseDomainEntity
{
    public string ConnectionId { get; set; }
    public Participant Participant { get; set; }
    public int ParticipantId { get; set; }
}
