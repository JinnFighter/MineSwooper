using Cysharp.Threading.Tasks;

namespace Init.InitSteps
{
    public interface IInitStep
    {
        UniTask Execute();
    }
}