using ChamberOfSecrets.CollabChamber.Domain;
using ChamberOfSecrets.CollabChamber.Persistence;
using ChamberOfSecrets.CollabChamber.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChamberOfSecrets.CollabChamber.Application.Contracts.Persistence;

public class CodeEditorRepository : GenericRepository<CodeEditor>, ICodeEditorRepository
{
    public CodeEditorRepository(CollabChamberDbContext dbContext)
        : base(dbContext)
    {
        
    }
}
