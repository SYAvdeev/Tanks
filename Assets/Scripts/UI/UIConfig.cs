using System.Linq;
using Tanks.Utility;
using UnityEngine;

namespace Tanks.UI
{
    [CreateAssetMenu(fileName = nameof(UIConfig), menuName = "Custom/UI/" + nameof(UIConfig), order = 1)]
    public class UIConfig : ConfigBase, IUIConfig
    {
        [SerializeField] private UIScreen[] _uiScreenPrefabs;

        public TScreen GetUIPrefabByType<TScreen>() where TScreen : UIScreen =>
            (TScreen)_uiScreenPrefabs.FirstOrDefault(s => s is TScreen);
    }
}