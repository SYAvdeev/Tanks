using Tanks.Utility;
using UnityEngine;

namespace Tanks.LevelObjects.Basic
{
    [CreateAssetMenu(
        fileName = nameof(SpawnableConfig), 
        menuName = "Custom/LevelObjects/Basic/" + nameof(SpawnableConfig),
        order = 3)]
    public class SpawnableConfig : ConfigBase, ISpawnableConfig
    {
        [SerializeField] private string _id;

        public string ID => _id;
    }
}