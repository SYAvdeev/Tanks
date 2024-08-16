using Tanks.Utility;
using UnityEngine;

namespace Tanks.LevelObjects.Basic
{
    [CreateAssetMenu(
        fileName = nameof(MovableConfig), 
        menuName = "Custom/LevelObjects/Basic/" + nameof(MovableConfig),
        order = 2)]
    public class MovableConfig : ConfigBase, IMovableConfig
    {
        [SerializeField] private float _velocity;

        public float Velocity => _velocity;
    }
}