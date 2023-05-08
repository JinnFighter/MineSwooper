using MVVM;
using UnityEngine;
using UnityEngine.UI;

namespace Ui
{
    public class GameOverView : View
    {
        [field: SerializeField] public Button RestartButton { get; private set; }
        [field: SerializeField] public Button QuitButton { get; private set; }
    }
}