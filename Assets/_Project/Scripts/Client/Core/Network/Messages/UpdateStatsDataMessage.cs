using System.Collections.Generic;
using _Project.Client.Gameplay.Battle;
using _Project.Client.Gameplay.Character;
using _Project.Network;

namespace _Project.Client.Core.Network.Messages
{
    public struct UpdateStatsDataMessage : INetworkMessage
    {
        public ParticipantData ParticipantPlayer;
        public List<SkillValueData> SkillsPlayer;
        
        public ParticipantData ParticipantEnemy;
        public List<SkillValueData> SkillsEnemy;
    }
}