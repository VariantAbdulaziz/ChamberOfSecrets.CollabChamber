using AutoMapper;
using ChamberOfSecrets.CollabChamber.Application.Contracts.Persistence;
using ChamberOfSecrets.CollabChamber.Application.DTOs.Shadow;
using ChamberOfSecrets.CollabChamber.Domain;
using ChamberOfSecrets.CollabChamber.Infrastructure.RPC;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChamberOfSecrets.CollabChamber.Persistence.Repositories;

public class ShadowRepository : GenericRepository<Shadow>, IShadowRepository
{
    private readonly CollabChamberDbContext _dbContext;
    private readonly IMapper _mapper;

    public ShadowRepository(CollabChamberDbContext dbContext, IMapper mapper)
        : base(dbContext)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<ShadowDto> GetOrCreate(string connectionId)
    {
        var shadow = await _dbContext.Shadows.FirstOrDefaultAsync(q => q.Connection.ConnectionId == connectionId);
        return _mapper.Map<ShadowDto>(shadow);
    }
}
