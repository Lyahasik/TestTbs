using UnityEngine;

namespace _Project.Client.Core.Scene
{
    public class ToDontDestroyOnLoad : MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
