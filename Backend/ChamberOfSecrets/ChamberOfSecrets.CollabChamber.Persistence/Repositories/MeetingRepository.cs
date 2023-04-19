using ChamberOfSecrets.CollabChamber.Application.DTOs.CodeEditor;
using ChamberOfSecrets.CollabChamber.Application.DTOs.Participant;
using ChamberOfSecrets.CollabChamber.Domain;
using ChamberOfSecrets.CollabChamber.Persistence;
using ChamberOfSecrets.CollabChamber.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChamberOfSecrets.CollabChamber.Application.Contracts.Persistence;

public class MeetingRepository : GenericRepository<Meeting>, IMeetingRepository
{ 
    public MeetingRepository(CollabChamberDbContext dbContext)
        : base(dbContext)
    {

    }

    public Task<ParticipantDto> AddParticipant(int meetingId, CreateParticipantDto particpant)
    {
        throw new NotImplementedException();
    }

    public Task<CodeEditorDto> GetCodeEdtior()
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<ParticipantDto>> GetParticipants(int meetingId)
    {
        throw new NotImplementedException();
    }

    public Task<ParticipantDto> RemoveParticipant(int meetingId, int particpantId)
    {
        throw new NotImplementedException();
    }
}
