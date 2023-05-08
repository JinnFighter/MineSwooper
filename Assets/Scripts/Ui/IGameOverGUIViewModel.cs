using System;
using MVVM;

namespace Ui
{
    public interface IGameOverGUIViewModel : IViewModel
    {
        Action RestartAction { get; }
        Action QuitAction { get; }
    }
}