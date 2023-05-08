using Core.Models;
using MVVM;
using Reactivity;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Ui
{
    public class GameplayGUIViewLogic : ViewLogic<IGameplayGUIViewModel, GameplayView>
    {
        protected override void AssembleSubViewLogics()
        {
            RegisterSubViewLogic<GameFieldGUIViewLogic, GameFieldView>(ViewModel.GameFieldViewModel,
                View.GameFieldView);
            RegisterSubViewLogic<BombCountGUIViewLogic, BombCountView>(ViewModel.BombCountViewModel,
                View.BombCountView);
        }

        protected override void InitializeInternal()
        {
            SubscriptionAggregator.ListenEvent(ViewModel.GameplayState, HandleGameplayStateChanged);
        }

        private void HandleGameplayStateChanged(object sender, GenericEventArg<EGameplayState> e)
        {
            switch (e.Value)
            {
                case EGameplayState.GameOver:
                    CreateSubViewLogic<GameOverGUIViewLogic, GameOverView>(new GameOverGUIViewModel(() =>
                        {
                            SceneManager.LoadScene("Scenes/Gameplay");
                        }, Application.Quit),
                        "GameOverView", View.transform);
                    break;
            }
        }
    }
}