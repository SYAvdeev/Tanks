using System.Collections.Generic;
using Tanks.Utility;

namespace Tanks.UI
{
    public class UIModel : IUIModel
    {
        Pool<string, IUIScreen> IUIModel.ScreenPool { get; }

        Dictionary<string, IUIScreen> IUIModel.CurrentOpenedScreens { get; set; }
    }
}