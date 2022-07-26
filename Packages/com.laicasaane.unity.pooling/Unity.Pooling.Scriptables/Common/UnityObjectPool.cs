using System;
using UnityEngine;

namespace Unity.Pooling.Scriptables
{
    [Serializable]
    public class UnityObjectPool : UnityPool<UnityEngine.Object, ScriptableSource, UnityObjectPrefab>
    {
        protected override void ReturnPreprocess(UnityEngine.Object instance)
        {
            if (instance is GameObject gameObject && gameObject.activeSelf)
            {
                gameObject.SetActive(false);
            }
            else if (instance is Component component && component.gameObject
                     && component.gameObject.activeSelf)
            {
                component.gameObject.SetActive(false);
            }
        }
    }
}
