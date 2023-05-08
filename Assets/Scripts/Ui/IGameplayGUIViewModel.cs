using Core.Models;
using MVVM;
using Reactivity;

namespace Ui
{
    public interface IGameplayGUIViewModel : IViewModel
    {
        IReactiveProperty<EGameplayState> GameplayState { get; }
        IBombCountGUIViewModel BombCountViewModel { get; }
        IGameFieldGUIViewModel GameFieldViewModel { get; }
    }
}