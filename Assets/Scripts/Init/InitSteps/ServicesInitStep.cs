using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Init.InitSteps
{
    public class ServicesInitStep : IInitStep
    {
        public async UniTask Execute()
        {
            await BindServices();
            await InitServices();
        }

        private UniTask BindServices()
        {
            Debug.Log("Services bound");
            return UniTask.CompletedTask;
        }

        private UniTask InitServices()
        {
            Debug.Log("Services initialized");
            return UniTask.CompletedTask;
        }
    }
}