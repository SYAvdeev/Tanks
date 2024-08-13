using Tanks.Utility;
using UnityEngine;

namespace Tanks.LevelObjects.Basic
{
    public class SpawnableConfig : ConfigBase, ISpawnableConfig
    {
        [SerializeField] private string _id;

        public string ID => _id;
    }
}