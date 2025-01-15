using UnityEngine;

namespace _Project.Helpers.Camera
{
    public class LookAtCamera : MonoBehaviour
    {
        [SerializeField] private bool isInverse;
    
        private UnityEngine.Camera _mainCamera;

        private void Start()
        {
            _mainCamera = UnityEngine.Camera.main;
        }

        private void Update()
        {
            transform.LookAt(_mainCamera.transform, isInverse ? -Vector3.up : Vector3.up);
        }
    }
}
