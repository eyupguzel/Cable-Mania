using UnityEngine;
using System.Collections.Generic;

public class GameManager : Singleton<GameManager>
{
    private List<ICable> cables = new List<ICable>();
    private List<ISocket> sockets = new List<ISocket>();

    public void AddCable(ICable cable)
    {
        cables.Add(cable);
    }

    public void AddSocket(ISocket socket)
    {
        sockets.Add(socket);
    }

    public bool TryConnect(ICable cable, ISocket socket)
    {
        if (socket.CanAccept(cable))
        {
            cable.Connect(socket);
            return true;
        }
        return false;
    }

    public void ResetConnections()
    {
        foreach (var cable in cables)
        {
            cable.Disconnect();
        }
    }
}
