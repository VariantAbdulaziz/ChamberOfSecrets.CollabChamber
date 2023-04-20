using AutoMapper;
using ChamberOfSecrets.CollabChamber.Application.DTOs.Participant;
using ChamberOfSecrets.CollabChamber.Domain;
using ChamberOfSecrets.CollabChamber.Infrastructure.RPC;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChamberOfSecrets.CollabChamber.Persistence.Repositories;

public class ConnectionRepository : GenericRepository<Connection>, IConnectionRepository
{
    private readonly CollabChamberDbContext _dbContext;
    private readonly IMapper _mapper;

    public ConnectionRepository(CollabChamberDbContext dbContext, IMapper mapper)
        : base(dbContext)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<ParticipantDto> GetParticipant(string connectionId)
    {
        var connection = await _dbContext.Connections.FirstOrDefaultAsync(q => q.ConnectionId == connectionId);
        return _mapper.Map<ParticipantDto>(connection.Participant);
    }
}
