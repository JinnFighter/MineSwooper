using MVVM;
using Reactivity;

namespace Ui
{
    public class BombCountGUIViewLogic : ViewLogic<IBombCountGUIViewModel, BombCountView>
    {
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