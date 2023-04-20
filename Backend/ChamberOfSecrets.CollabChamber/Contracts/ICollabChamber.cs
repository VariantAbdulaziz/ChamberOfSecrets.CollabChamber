using ChamberOfSecrets.CollabChamber.Demo.DTOs;

namespace ChamberOfSecrets.CollabChamber.Demo.Contracts;

public interface ICollabChamber
{
    public Task SendEdit(Edit edit);
}
