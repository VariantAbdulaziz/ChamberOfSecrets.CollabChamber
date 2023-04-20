using ChamberOfSecrets.CollabChamber.Domain.Common;

namespace ChamberOfSecrets.CollabChamber.Domain;

public class Connection : BaseDomainEntity
{
    public string ConnectionId { get; set; }

    public int ParticipantId { get; set; }
    public int ShadowId { get; set; }

    public Shadow? Shadow { get; set; }
    public Participant Participant { get; set; }
}
