using _Project.Client.Gameplay.Battle;
using _Project.Network;

namespace _Project.Client.Core.Network.Messages
{
    public struct ParticipantsDataMessage : INetworkMessage
    {
        public ParticipantData ParticipantPlayer;
        public ParticipantData ParticipantEnemy;
    }
}