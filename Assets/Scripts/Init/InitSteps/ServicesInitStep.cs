using Core.Containers;
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
            BindContainers();
            BindModels();
            return UniTask.CompletedTask;
        }

        private void BindContainers()
        {
            _container.Bind<SpritesContainer>().FromInstance(Resources.Load<SpritesContainer>("SpritesContainer"))
                .AsSingle();
            _container.Bind<PrefabsContainer>().FromInstance(Resources.Load<PrefabsContainer>("PrefabsContainer"))
                .AsSingle();
        }

        private void BindModels()
        {
            _container.Bind<GameFieldModel>().AsSingle();
        }

        private UniTask InitServices()
        {
            Debug.Log("Services initialized");
            return UniTask.CompletedTask;
        }
    }
}