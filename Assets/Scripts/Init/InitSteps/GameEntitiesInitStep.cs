using Core.Containers;
using Core.Models;
using Core.Services;
using Cysharp.Threading.Tasks;
using MVVM;
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
            _container.Bind<IViewLogicService>().To<ViewLogicService>()
                .AsSingle();
            _container.Bind<IGameFieldGeneratorService>().To<GameFieldGeneratorService>().AsSingle();
            return UniTask.CompletedTask;
        }

        private UniTask BindContainers()
        {
            _container.Bind<SpritesContainer>().FromInstance(Resources.Load<SpritesContainer>("SpritesContainer"))
                .AsSingle();
            return UniTask.CompletedTask;
        }

        private UniTask BindModels()
        {
            _container.Bind<GameplayModel>().AsSingle();
            _container.Bind<GameFieldModel>().AsSingle();
            return UniTask.CompletedTask;
        }

        private async UniTask InitServices()
        {
            await _container.Resolve<IViewLogicService>().Initialize();
        }
    }
}