using ChamberOfSecrets.CollabChamber.Demo.DTOs;

namespace ChamberOfSecrets.CollabChamber.Demo.Contracts;


public interface ICollabChamberClient
{
    Task EditReceived(Edit message);
    Task Dirty();
}

