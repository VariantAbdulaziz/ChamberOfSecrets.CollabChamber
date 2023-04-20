using ChamberOfSecrets.CollabChamber.Demo.Contracts;
using ChamberOfSecrets.CollabChamber.Demo.DTOs;
using DiffMatchPatch;
using Microsoft.AspNetCore.SignalR;

namespace ChamberOfSecrets.CollabChamber.Demo.Controllers;

public class CollabChamber : Hub<ICollabChamberClient>, ICollabChamber
{
    public static string State { get; set; } = "";
    private static readonly Dictionary<string, string> shadows =
        new Dictionary<string, string>();

    public async Task SendEdit(Edit edit)
    {
        var connectionId = Context.ConnectionId;
        var shadow = shadows[connectionId];
        diff_match_patch dmp = new diff_match_patch();
        var patches = dmp.patch_fromText(edit.Patches);
        var result = dmp.patch_apply(patches, shadow);
        if (result[0] is string)
            shadow = result[0] as string;

        result = dmp.patch_apply(patches, State);
        if (result[0] is string)
            State = result[0] as string;

        var diffs = dmp.diff_main(shadow, State);
        patches = dmp.patch_make(diffs);

        result = dmp.patch_apply(patches, shadow);
        if (result[0] is string)
            shadow = result[0] as string;

        shadows[connectionId] = shadow;
        Edit propagatedEdit = new Edit { Patches = dmp.patch_toText(patches) };

        await Clients.Client(connectionId).EditReceived(propagatedEdit);
        foreach (var item in shadows)
        {
            if (item.Key != connectionId && !edit.Dirty)
                await Clients.Client(item.Key).Dirty();
        }
    }

    public override Task OnConnectedAsync()
    {
        var connectionId = Context.ConnectionId;
        shadows[connectionId] = "";
        return base.OnConnectedAsync();
    }

    public override Task OnDisconnectedAsync(Exception? exception)
    {
        var connectionId = Context.ConnectionId;
        shadows.Remove(connectionId);
        return base.OnDisconnectedAsync(exception);
    }
}
