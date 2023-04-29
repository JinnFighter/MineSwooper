using MVVM;
using TMPro;
using UnityEngine;

namespace Ui
{
    public class BombCountView : View
    {
        [field: SerializeField] public TextMeshProUGUI TextBombCount { get; private set; }
    }
}