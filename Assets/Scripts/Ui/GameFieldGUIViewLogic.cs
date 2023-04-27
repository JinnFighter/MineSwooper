using Core.Containers;
using MVVM;
using UnityEngine;
using Zenject;

namespace Ui
{
    public class GameFieldGUIViewLogic : ViewLogic<IGameFieldGUIViewModel, GameFieldView>
    {
        private PrefabsContainer _prefabsContainer;

        public GameFieldGUIViewLogic(IGameFieldGUIViewModel viewModel, GameFieldView view) : base(viewModel, view)
        {
        }

        protected override void InitializeInternal()
        {
            _prefabsContainer = ProjectContext.Instance.Container.Resolve<PrefabsContainer>();
        }

        protected override void AssembleSubViewLogics()
        {
            foreach (var cellViewModel in ViewModel.Cells)
                RegisterSubViewLogic(cellViewModel,
                    new CellGUIViewLogic(cellViewModel,
                        Object.Instantiate(_prefabsContainer.CellView, View.transform).GetComponent<CellView>()));
        }
    }
}