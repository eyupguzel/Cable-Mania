using UnityEngine;

public interface ISocket
{
    CableType SocketType { get; }
    bool connected { get; }
    bool CanAccept(ICable cable);
    string Color { get; }
    void AttachCable();
    void DetachCable();
}
