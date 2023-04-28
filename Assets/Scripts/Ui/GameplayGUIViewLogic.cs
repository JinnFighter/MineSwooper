using MVVM;

namespace Ui
{
    public class GameplayGUIViewLogic : ViewLogic<IGameplayGUIViewModel, GameplayView>
    {
        public GameplayGUIViewLogic(IGameplayGUIViewModel viewModel, GameplayView view) : base(viewModel, view)
        {
        }

        protected override void AssembleSubViewLogics()
        {
            RegisterSubViewLogic(ViewModel.GameFieldViewModel,
                new GameFieldGUIViewLogic(ViewModel.GameFieldViewModel, View.GameFieldView));
            RegisterSubViewLogic(ViewModel.BombCountViewModel,
                new BombCountGUIViewLogic(ViewModel.BombCountViewModel, View.BombCountView));
        }
    }
}