using ChamberOfSecrets.CollabChamber.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChamberOfSecrets.CollabChamber.Domain;

public class Participant : BaseDomainEntity
{
    public string Name { get; set; }
}

