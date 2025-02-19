using UnityEngine;

public class EmptySocket : MonoBehaviour, ISocket
{
    [SerializeField] private CableType socketType;
    public CableType SocketType => socketType;

    public bool connected { get; private set; }

    public string Color => "None";

    public void AttachCable()
    {
        connected = true;
    }

    public bool CanAccept(ICable cable)
    {
       return cable.CableType == socketType;
    }

    public void DetachCable()
    {
        connected = false;
    }
}
