using Reactivity;

namespace Ui
{
    public class BombCountGUIViewModel : IBombCountGUIViewModel
    {
        private readonly ReactiveProperty<int> _bombCount;

        public BombCountGUIViewModel(int bombCount)
        {
            _bombCount = new ReactiveProperty<int>(bombCount);
        }

        public IReactiveProperty<int> BombCount => _bombCount;
    }
}