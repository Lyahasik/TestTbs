using System.Collections;
using _Project.Client.Core.Services;
using UnityEngine;

namespace _Project.Client.Core.Coroutines
{
    public interface ICoroutineRunnerService : IService
    {
        public Coroutine StartCoroutine(IEnumerator coroutine);
        public void StopAllCoroutines();
    }
}