using Core.Models;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Init.InitSteps
{
    public class ServicesInitStep : IInitStep
    {
        private readonly DiContainer _container;

        public ServicesInitStep()
        {
            _container = ProjectContext.Instance.Container;
        }

        public async UniTask Execute()
        {
            await BindServices();
            await InitServices();
        }

        private UniTask BindServices()
        {
            BindModels();
            return UniTask.CompletedTask;
        }

        private void BindModels()
        {
            _container.Bind<GameFieldModel>();
        }

        private UniTask InitServices()
        {
            Debug.Log("Services initialized");
            return UniTask.CompletedTask;
        }
    }
}