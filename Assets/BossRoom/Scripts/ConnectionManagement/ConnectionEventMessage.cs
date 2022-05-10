using System;
using Unity.Netcode;

namespace Unity.Multiplayer.Samples.BossRoom
{
    public struct ConnectionEventMessage : INetworkSerializeByMemcpy
    {
        public ConnectStatus ConnectStatus;
        public FixedPlayerName PlayerName;
    }
}