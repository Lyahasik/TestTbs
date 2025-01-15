using _Project.Client.Core.Coroutines;
using _Project.Client.Core.Network;
using _Project.Client.UI.Loading;
using _Project.Server.Core.Network;
using UnityEngine;

namespace _Project.Client.Core.Initialize
{
    public class CoreData : MonoBehaviour
    {
        private LoadingCurtain _curtain;
        private CoroutinesContainer _coroutinesContainer;
        private NetworkMessengerServer _networkMessengerServer;
        private NetworkMessengerClient _networkMessengerClient;
        public CoroutinesContainer CoroutinesContainer => _coroutinesContainer;
        public LoadingCurtain Curtain => _curtain;
        public NetworkMessengerServer NetworkMessengerServer => _networkMessengerServer;
        public NetworkMessengerClient NetworkMessengerClient => _networkMessengerClient;

        public void Construct(LoadingCurtain curtain,
            CoroutinesContainer coroutinesContainer,
            NetworkMessengerServer networkMessengerServer,
            NetworkMessengerClient networkMessengerClient)
        {
            _curtain = curtain;
            _coroutinesContainer = coroutinesContainer;
            _networkMessengerServer = networkMessengerServer;
            _networkMessengerClient = networkMessengerClient;
        }
    }
}