using ChamberOfSecrets.CollabChamber.Application.DTOs.Common;
using ChamberOfSecrets.CollabChamber.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChamberOfSecrets.CollabChamber.Application.DTOs.Shadow;

public class ShadowDto : BaseDto
{
    public Connection Connection { get; set; }
    public string Code { get; set; }
}

