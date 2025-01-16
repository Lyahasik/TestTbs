using _Project.Client.Gameplay.Battle;
using _Project.Network;

namespace _Project.Client.Core.Network.Messages
{
    public struct UpdateStatsDataMessage : INetworkMessage
    {
        public ParticipantData Player;
        public ParticipantData Enemy;
    }
}