using ChamberOfSecrets.CollabChamber.Application.DTOs.CodeEditor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChamberOfSecrets.CollabChamber.Application.Contracts.Infrastructure;

public interface ICollabHubClient
{
    Task EditReceived(EditDto message);
    Task Dirty();
}
