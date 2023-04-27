using MVVM;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Ui
{
    public class CellView : View, IPointerClickHandler
    {
        public UnityEvent<PointerEventData> CellClicked { get; } = new();
        [field: SerializeField] public TextMeshProUGUI BombCountText { get; private set; }
        [field: SerializeField] public Image ClickableImage { get; private set; }
        [field: SerializeField] public Image OpenedImage { get; private set; }
        public void OnPointerClick(PointerEventData eventData)
        {
            CellClicked?.Invoke(eventData);
        }
    }
}