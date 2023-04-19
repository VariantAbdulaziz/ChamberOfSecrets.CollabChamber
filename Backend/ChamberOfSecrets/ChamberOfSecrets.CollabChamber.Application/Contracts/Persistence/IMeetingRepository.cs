using ChamberOfSecrets.CollabChamber.Application.DTOs.CodeEditor;
using ChamberOfSecrets.CollabChamber.Application.DTOs.Participant;
using ChamberOfSecrets.CollabChamber.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChamberOfSecrets.CollabChamber.Application.Contracts.Persistence;

public interface IMeetingRepository : IGenericRepository<Meeting>
{
    Task<IReadOnlyList<ParticipantDto>> GetParticipants(int meetingId);
    Task<CodeEditorDto> GetCodeEdtior();
    Task<ParticipantDto> AddParticipant(int meetingId, CreateParticipantDto particpant);
    Task<ParticipantDto> RemoveParticipant(int meetingId, int particpantId);
}
