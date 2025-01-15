using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Project.Network
{
    public class NetworkMessenger
    {
        protected Dictionary<Type, Action<INetworkMessage>> _messageHandlers;

        public void ReceiveMessage<TMessage>(TMessage message) where TMessage : struct, INetworkMessage
        {
            if (_messageHandlers.TryGetValue(typeof(TMessage), out var handler))
            {
                handler(message);
                return;
            }
            
            Debug.LogWarning("Server: not found message type");
        }

        protected void RegisterHandler<TMessage>(Action<INetworkMessage> handler) where TMessage : struct, INetworkMessage
        {
            _messageHandlers.Add(typeof(TMessage), handler);
        }
    }
}