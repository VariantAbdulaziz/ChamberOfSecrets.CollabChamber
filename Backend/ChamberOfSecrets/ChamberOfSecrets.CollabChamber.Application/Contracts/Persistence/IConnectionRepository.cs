using ChamberOfSecrets.CollabChamber.Application.Contracts.Persistence;
using ChamberOfSecrets.CollabChamber.Application.DTOs.Participant;
using ChamberOfSecrets.CollabChamber.Domain;

namespace ChamberOfSecrets.CollabChamber.Infrastructure.RPC;

public interface IConnectionRepository : IGenericRepository<Connection>
{
    Task<ParticipantDto> GetParticipant(string ConnectionId);
}
