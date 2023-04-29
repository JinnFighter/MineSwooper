using MVVM;
using UnityEngine;

namespace Ui
{
    public class GameplayView : View
    {
        [field: SerializeField] public BombCountView BombCountView { get; private set; }
        [field: SerializeField] public GameFieldView GameFieldView { get; private set; }
    }
}