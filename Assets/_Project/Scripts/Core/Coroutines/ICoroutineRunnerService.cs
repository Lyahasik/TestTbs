using System.Collections;
using _Project.Core.Services;
using UnityEngine;

namespace _Project.Core.Coroutines
{
    public interface ICoroutineRunnerService : IService
    {
        Coroutine StartCoroutine(IEnumerator coroutine);
    }
}