﻿using System.Collections.Generic;
using Tanks.Utility;

namespace Tanks.UI
{
    public interface IUIModel
    {
        internal Pool<string, IUIScreen> ScreenPool { get; }
        internal Dictionary<string, IUIScreen> CurrentOpenedScreens { get; set; }
    }
}