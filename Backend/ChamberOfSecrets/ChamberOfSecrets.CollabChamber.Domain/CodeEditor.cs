using ChamberOfSecrets.CollabChamber.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChamberOfSecrets.CollabChamber.Domain;

public class CodeEditor : BaseDomainEntity
{
    public string Code { get; set; }

    public int MeetingId { get; set; }

    public Meeting Meeting { get; set; }
}
