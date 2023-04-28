using MVVM;
using Reactivity;

namespace Ui
{
    public class BombCountGUIViewLogic : ViewLogic<IBombCountGUIViewModel, BombCountView>
    {
        public BombCountGUIViewLogic(IBombCountGUIViewModel viewModel, BombCountView view) : base(viewModel, view)
        {
        }

        protected override void InitializeInternal()
        {
            SubscriptionAggregator.ListenEvent(ViewModel.BombCount, HandleBombCountChanged, true);
        }

        private void HandleBombCountChanged(object sender, GenericEventArg<int> e)
        {
            View.TextBombCount.text = $"{e.Value:00}";
        }
    }
}