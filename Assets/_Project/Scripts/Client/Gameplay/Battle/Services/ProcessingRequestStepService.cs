﻿using _Project.Client.Core.Network.Messages;
using _Project.Server.Core.Network;

namespace _Project.Client.Gameplay.Battle.Services
{
    public class ProcessingRequestStepService : IProcessingRequestStepService
    {
        private readonly NetworkMessengerServer _networkMessengerServer;

        public ProcessingRequestStepService(NetworkMessengerServer networkMessengerServer)
        {
            _networkMessengerServer = networkMessengerServer;
        }

        public void RequestAttack()
        {
            _networkMessengerServer.ReceiveMessage(new StepDataMessage { SkillType = SkillType.Attack });
        }
    }
}