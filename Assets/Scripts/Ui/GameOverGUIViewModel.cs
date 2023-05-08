using System;

namespace Ui
{
    public class GameOverGUIViewModel : IGameOverGUIViewModel
    {
        public GameOverGUIViewModel(Action restartAction, Action quitAction)
        {
            RestartAction = restartAction;
            QuitAction = quitAction;
        }

        public Action RestartAction { get; }
        public Action QuitAction { get; }
    }
}