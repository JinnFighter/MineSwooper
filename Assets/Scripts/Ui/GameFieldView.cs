using MVVM;
using UnityEngine;

namespace Ui
{
    public class GameFieldView : View
    {
        [field: SerializeField] public FlexibleGridLayout CellsParent { get; private set; }
    }
}