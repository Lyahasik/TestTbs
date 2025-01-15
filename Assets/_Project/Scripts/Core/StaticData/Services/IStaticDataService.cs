using _Project.Core.Services;
using _Project.Meta.StaticData;

namespace _Project.Core.StaticData.Services
{
    public interface IStaticDataService : IService
    {
        public CoreStaticData Core { get; }
        public GameplayStaticData Gameplay { get; }

        public void Load();
    }
}