using UnityEngine;

namespace _Project.Core.Factory
{
    public abstract class Factory
    {
        public T PrefabInstantiate<T>(T prefab) where T : Behaviour
        {
            T newObject = Object.Instantiate(prefab);
            newObject.name = prefab.name;
            
            return newObject;
        }

        public T PrefabInstantiate<T>(T prefab, Transform parent) where T : Behaviour
        {
            T newObject = Object.Instantiate(prefab, parent);
            newObject.name = prefab.name;
            
            return newObject;
        }

        public T PrefabInstantiate<T>(T prefab, Vector3 position, Quaternion rotation) where T : Behaviour
        {
            T newObject = Object.Instantiate(prefab, position, rotation);
            newObject.name = prefab.name;
            
            return newObject;
        }

        public T PrefabInstantiate<T>(T prefab, Vector3 position, Quaternion rotation, Transform parent) where T : Behaviour
        {
            T newObject = Object.Instantiate(prefab, position, rotation, parent);
            newObject.name = prefab.name;
            
            return newObject;
        }
    }
}