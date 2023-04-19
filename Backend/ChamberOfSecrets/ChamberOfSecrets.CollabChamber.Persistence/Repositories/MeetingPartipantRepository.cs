using ChamberOfSecrets.CollabChamber.Application.DTOs.CodeEditor;
using ChamberOfSecrets.CollabChamber.Application.DTOs.Meeting;
using ChamberOfSecrets.CollabChamber.Domain;
using ChamberOfSecrets.CollabChamber.Persistence;
using ChamberOfSecrets.CollabChamber.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChamberOfSecrets.CollabChamber.Application.Contracts.Persistence;

public class MeetingPartipantRepository : GenericRepository<MeetingParticipant>, IMeetingPartipantRepository
{
    public MeetingPartipantRepository(CollabChamberDbContext dbContext)
        : base(dbContext)
    {
        
    }

    public Task<MeetingDto> GetMeeting()
    {
        throw new NotImplementedException();
    }

    public Task<Participant> GetParticipant()
    {
        throw new NotImplementedException();
    }
}

