namespace Ui
{
    public class GameplayGUIViewModel : IGameplayGUIViewModel
    {
        public GameplayGUIViewModel(IBombCountGUIViewModel bombCountViewModel,
            IGameFieldGUIViewModel gameFieldViewModel)
        {
            BombCountViewModel = bombCountViewModel;
            GameFieldViewModel = gameFieldViewModel;
        }

        public IBombCountGUIViewModel BombCountViewModel { get; }
        public IGameFieldGUIViewModel GameFieldViewModel { get; }
    }
}