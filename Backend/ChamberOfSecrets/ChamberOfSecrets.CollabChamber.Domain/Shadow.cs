using ChamberOfSecrets.CollabChamber.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChamberOfSecrets.CollabChamber.Domain;

public class Shadow : BaseDomainEntity
{
    public string Code { get; set; }

    public int ConnectionId { get; set; }

    public Connection Connection { get; set; }
}
