using System;
using Cysharp.Threading.Tasks;

namespace Tanks.UI
{
    public interface IUIScreen
    {
        event Action<IUIScreen> ShowStarted;
        event Action<IUIScreen> ShowFinished;
        event Action<IUIScreen> HideStarted;
        event Action<IUIScreen> HideFinished;
        UniTask Show(bool isImmediate);
        UniTask Hide(bool isImmediate);
    }
}