using System.Collections;
using UnityEngine;

namespace Common.Extensions
{
    public static class MonoBehaviourExtensions
    {
        public static Coroutine StopAndRestartCoroutine(this MonoBehaviour monoBehaviour, Coroutine coroutine, IEnumerator enumerator)
        {
            StopCoroutineIfExists(monoBehaviour, coroutine);
            return monoBehaviour.StartCoroutine(enumerator);
        }
        
        public static void StopCoroutineIfExists(this MonoBehaviour monoBehaviour, Coroutine coroutine)
        {
            if (coroutine != null)
            {
                monoBehaviour.StopCoroutine(coroutine);
            }
        }
    }
}