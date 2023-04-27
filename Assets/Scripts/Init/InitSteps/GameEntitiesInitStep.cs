using Core.Containers;
using Core.Models;
using Core.Services;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Init.InitSteps
{
    public class GameEntitiesInitStep : IInitStep
    {
        private readonly DiContainer _container;

        public GameEntitiesInitStep()
        {
            _container = ProjectContext.Instance.Container;
        }

        public async UniTask Execute()
        {
            await BindEntities();
            await InitServices();
        }

        private async UniTask BindEntities()
        {
            await BindContainers();
            await BindModels();
            await BindServices();
        }

        private UniTask BindServices()
        {
            _container.Bind<IBombsGeneratorService>().To<BombsGeneratorService>().AsSingle();
            return UniTask.CompletedTask;
        }

        private UniTask BindContainers()
        {
            _container.Bind<SpritesContainer>().FromInstance(Resources.Load<SpritesContainer>("SpritesContainer"))
                .AsSingle();
            _container.Bind<PrefabsContainer>().FromInstance(Resources.Load<PrefabsContainer>("PrefabsContainer"))
                .AsSingle();
            return UniTask.CompletedTask;
        }

        private UniTask BindModels()
        {
            _container.Bind<GameFieldModel>().AsSingle();
            return UniTask.CompletedTask;
        }

        private UniTask InitServices()
        {
            Debug.Log("Services initialized");
            return UniTask.CompletedTask;
        }
    }
}