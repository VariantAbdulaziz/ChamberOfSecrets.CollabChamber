using ChamberOfSecrets.CollabChamber.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChamberOfSecrets.CollabChamber.Domain;
public class Meeting : BaseDomainEntity
{
    public int CodeEditorId { get; set; }

    public List<MeetingParticipant> MeetingParticipants { get; set; }
    public CodeEditor? CodeEditor { get; set; }
}
