using MVVM;

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
    }
}