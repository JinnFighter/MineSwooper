using MVVM;

namespace Ui
{
    public interface IGameFieldGUIViewModel : IViewModel
    {
        ICellGUIViewModel[,] Cells { get; }
    }
}