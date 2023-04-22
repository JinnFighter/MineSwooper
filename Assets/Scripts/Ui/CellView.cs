using MVVM;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Ui
{
    public class CellView : View
    {
        [field: SerializeField] public Button CellButton { get; private set; }
        [field: SerializeField] public TextMeshProUGUI BombCountText { get; private set; }
        [field: SerializeField] public Image EmptyImage { get; private set; }
        [field: SerializeField] public Image OpenedImage { get; private set; }
    }
}