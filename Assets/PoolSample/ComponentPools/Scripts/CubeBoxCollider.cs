using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using ZBase.Foundation.Pooling.UnityPools;

namespace Pooling.Sample
{
    /// <summary>
    /// A custom prefab definition.
    /// You can override the Instantiate and Release methods to customize the behavior. 
    /// </summary>
    public class CubeBoxCollider : ComponentPrefab<BoxCollider>
    {
        public CubeBoxCollider() : base(){}

        protected override UniTask<BoxCollider> Instantiate(BoxCollider source, Transform parent, CancellationToken cancelToken)
        {
            BoxCollider instance;

            if (parent)
                instance = UnityEngine.Object.Instantiate(source, parent);
            else
                instance = UnityEngine.Object.Instantiate(source);

            instance.size = 2 * Vector3.one;
            return UniTask.FromResult(instance);
        }

        public override void Release(BoxCollider instance)
        {
            if (instance)
                UnityEngine.Object.Destroy(instance.gameObject);
        }
    }
}