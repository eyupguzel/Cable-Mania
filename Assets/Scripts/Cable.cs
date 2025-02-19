using System.Drawing;
using UnityEngine.UI;
using UnityEngine;

public class Cable : MonoBehaviour, ICable
{
    private ISocket connectedSocket;
    [SerializeField] private string color;
    [SerializeField] private CableType cableType;
    public bool IsConnected { get; private set; }

    public string Color => color;

    public CableType CableType => cableType;

    public void Connect(ISocket socket)
    {
        Debug.Log("Priz takýldý!");

        if (socket.CanAccept(this))
        {

            connectedSocket = socket;
            socket.AttachCable();
            IsConnected = true;
        }
    }

    public void Disconnect()
    {
        Debug.Log("Priz çýkarýldý!");
        if (connectedSocket != null)
        {
            connectedSocket.DetachCable();
            connectedSocket = null;
            IsConnected = false;
        }
    }
}
