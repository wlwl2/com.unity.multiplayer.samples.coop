using System;
using Unity.Netcode;

namespace Unity.Multiplayer.Samples.BossRoom
{
    public struct DoorStateChangedEventMessage : INetworkSerializeByMemcpy
    {
        public bool IsDoorOpen;
    }
}