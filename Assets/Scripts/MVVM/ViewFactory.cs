using UnityEngine;

namespace MVVM
{
    public class ViewFactory
    {
        private readonly PrefabsContainer _prefabsContainer;

        public ViewFactory(PrefabsContainer prefabsContainer)
        {
            _prefabsContainer = prefabsContainer;
        }

        public T GetView<T>(string key) where T : View
        {
            return Object.Instantiate(_prefabsContainer.GetView(key)) as T;
        }
    }
}