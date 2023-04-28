using MVVM;
using Reactivity;

namespace Ui
{
    public interface IBombCountGUIViewModel : IViewModel
    {
        IReactiveProperty<int> BombCount { get; }
    }
}