using MVVM;

namespace Ui
{
    public class GameOverGUIViewLogic : ViewLogic<IGameOverGUIViewModel, GameOverView>
    {
        public override void Initialize()
        {
            SubscriptionAggregator.ListenEvent(View.RestartButton.onClick, HandleRestartButtonClicked);
            SubscriptionAggregator.ListenEvent(View.QuitButton.onClick, HandleQuitButtonClicked);
        }

        private void HandleQuitButtonClicked()
        {
            ViewModel.QuitAction.Invoke();
        }

        private void HandleRestartButtonClicked()
        {
            ViewModel.RestartAction.Invoke();
        }
    }
}