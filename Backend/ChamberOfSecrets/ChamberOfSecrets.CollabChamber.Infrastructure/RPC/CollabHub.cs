using ChamberOfSecrets.CollabChamber.Application.Contracts.Infrastructure;
using ChamberOfSecrets.CollabChamber.Application.DTOs.CodeEditor;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChamberOfSecrets.CollabChamber.Infrastructure.RPC;

public class CollabHub : Hub<ICollabHubClient>, ICollabHub
{
    public Task SendEdit(EditDto edit)
    {
        throw new NotImplementedException();
    }
}
