using System;
using UnityEngine;

namespace Core.Containers
{
    [Serializable]
    [CreateAssetMenu(menuName = "Containers/PrefabsContainer", fileName = "PrefabsContainer")]
    public class PrefabsContainer : ScriptableObject
    {
        public GameObject CellView;
    }
}
