using System.Collections.Generic;
using Init.InitSteps;
using UnityEngine;

namespace Init
{
    public class InitPoint : MonoBehaviour
    {
        private async void Awake()
        {
            var initSteps = new List<IInitStep>
            {
                new GameEntitiesInitStep(),
                new LaunchGameplayInitStep(),
            };
            foreach (var initStep in initSteps) await initStep.Execute();
        }
    }
}