using Core.Models;
using Reactivity;

namespace Ui
{
    public class GameplayGUIViewModel : IGameplayGUIViewModel
    {
        public GameplayGUIViewModel(IBombCountGUIViewModel bombCountViewModel,
            IGameFieldGUIViewModel gameFieldViewModel, IReactiveProperty<EGameplayState> gameplayState)
        {
            BombCountViewModel = bombCountViewModel;
            GameFieldViewModel = gameFieldViewModel;
            GameplayState = gameplayState;
        }

        public IReactiveProperty<EGameplayState> GameplayState { get; }
        public IBombCountGUIViewModel BombCountViewModel { get; }
        public IGameFieldGUIViewModel GameFieldViewModel { get; }
    }
}