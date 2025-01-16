using _Project.Network;

namespace _Project.Client.Core.Network.Messages
{
    public struct StepDataMessage : INetworkMessage
    {
        public SkillType SkillType;
    }
}