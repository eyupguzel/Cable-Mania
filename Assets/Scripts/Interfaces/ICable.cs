using UnityEngine;
public enum CableType
{
    Normal,
    HighVoltage,
    Ethernet
}
public interface ICable
{
    bool IsConnected { get; }
   
    CableType CableType { get; }
    string Color { get; }
    void Connect(ISocket socket);
    void Disconnect();
}
