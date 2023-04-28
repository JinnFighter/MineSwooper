using MVVM;

namespace Ui
{
    public interface IGameplayGUIViewModel : IViewModel
    {
        IBombCountGUIViewModel BombCountViewModel { get; }
        IGameFieldGUIViewModel GameFieldViewModel { get; }
    }
}