using ChamberOfSecrets.CollabChamber.Application.DTOs.Shadow;
using ChamberOfSecrets.CollabChamber.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChamberOfSecrets.CollabChamber.Application.Contracts.Persistence;

public interface IShadowRepository : IGenericRepository<Shadow>
{
    Task<ShadowDto> GetOrCreate(string connectionId);
}
