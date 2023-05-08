using Reactivity;

namespace Ui
{
    public class BombCountGUIViewModel : IBombCountGUIViewModel
    {
        public BombCountGUIViewModel(IReactiveProperty<int> bombCount)
        {
            BombCount = bombCount;
        }

        public IReactiveProperty<int> BombCount { get; }
    }
}