using System.Collections.Generic;
using Init.InitSteps;
using UnityEngine;

namespace Init
{
    public class InitPoint : MonoBehaviour
    {
        private readonly List<IInitStep> _initSteps = new()
        {
            new ServicesInitStep()
        };

        private async void Awake()
        {
            foreach (var initStep in _initSteps) await initStep.Execute();
        }
    }
}