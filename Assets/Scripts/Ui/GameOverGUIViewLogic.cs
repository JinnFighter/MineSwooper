using MVVM;
using UnityEngine;

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
            Debug.Log("Quick Clicked");
        }

        private void HandleRestartButtonClicked()
        {
            Debug.Log("Restart Clicked");
        }
    }
}