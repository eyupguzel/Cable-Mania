
using UnityEngine;

public class Socket : MonoBehaviour,ISocket
{
    [SerializeField] private string color;
    [SerializeField] private CableType type;
    public bool connected { get;private set; }
    public string Color => color;
    public CableType SocketType => type;
    public bool CanAccept(ICable cable)
    {
        return connected == false && cable.CableType == type && cable.Color == Color;
    }

    public void AttachCable()
    {
        connected = true;
    }

    public void DetachCable()
    {
        connected = false;
    }
}
