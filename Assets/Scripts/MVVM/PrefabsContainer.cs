using System;
using UnityEngine;

namespace MVVM
{
    [Serializable]
    [CreateAssetMenu(menuName = "Containers/PrefabsContainer", fileName = "PrefabsContainer")]
    public class PrefabsContainer : ScriptableObject
    {
        public View CellView;
    }
}
