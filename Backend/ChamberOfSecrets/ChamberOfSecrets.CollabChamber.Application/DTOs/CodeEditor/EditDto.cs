using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChamberOfSecrets.CollabChamber.Application.DTOs.CodeEditor;
public class EditDto
{
    public string Patches { get; set; }
    public bool Dirty { get; set; }
}

