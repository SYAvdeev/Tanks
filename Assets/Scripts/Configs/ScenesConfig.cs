using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName ="Scenes Config", menuName = "Assets/Config/Scenes Config", order = 0)]
    public class ScenesConfig : ScriptableObject
    {
        [SerializeField]
        private int _gameSceneIndex;

        public int GameSceneIndex => _gameSceneIndex;
    }
}