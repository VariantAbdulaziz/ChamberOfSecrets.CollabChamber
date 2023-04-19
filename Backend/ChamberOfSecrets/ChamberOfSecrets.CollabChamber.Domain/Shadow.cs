using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChamberOfSecrets.CollabChamber.Domain;

public class Shadow
{
    public Connection Connection { get; set; }
    public int ConnectionId { get; set; }
    public string Code { get; set; }
}
