using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace Init.InitSteps
{
    public class LaunchGameplayInitStep : IInitStep
    {
        public async UniTask Execute()
        {
            await SceneManager.LoadSceneAsync("Scenes/Gameplay");
        }
    }
}
