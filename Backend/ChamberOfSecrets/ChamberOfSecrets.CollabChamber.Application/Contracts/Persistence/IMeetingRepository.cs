using ChamberOfSecrets.CollabChamber.Application.DTOs.CodeEditor;
using ChamberOfSecrets.CollabChamber.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChamberOfSecrets.CollabChamber.Application.Contracts.Persistence;

public interface IMeetingRepository : IGenericRepository<Meeting>
{
    Task<IReadOnlyList<Meeting>> GetParticipants();
    Task<CodeEditorDto> GetCodeEdtior();
}
