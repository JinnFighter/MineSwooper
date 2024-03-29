using System;
using UnityEngine;

namespace MVVM
{
    [Serializable]
    [CreateAssetMenu(menuName = "Containers/PrefabsContainer", fileName = "PrefabsContainer")]
    public class PrefabsContainer : ScriptableObject
    {
        public View CellView;
        public View GameOverView;

        public View GetView(string key)
        {
            return key switch
            {
                "CellView" => CellView,
                "GameOverView" => GameOverView,
                _ => null
            };
        }
    }
}