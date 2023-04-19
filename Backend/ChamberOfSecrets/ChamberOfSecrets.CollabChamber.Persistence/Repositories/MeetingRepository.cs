using ChamberOfSecrets.CollabChamber.Application.DTOs.CodeEditor;
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

    public Task<CodeEditorDto> GetCodeEdtior()
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<Meeting>> GetParticipants()
    {
        throw new NotImplementedException();
    }
}
