﻿using _Project.Client.Core.Services;

namespace _Project.Client.Gameplay.Battle.Services
{
    public interface IProcessingRequestStepService : IService
    {
        public void RequestAttack();
    }
}