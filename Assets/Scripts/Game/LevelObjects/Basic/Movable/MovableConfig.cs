using Tanks.Utility;
using UnityEngine;

namespace Tanks.Game.LevelObjects.Basic
{
    [CreateAssetMenu(
        fileName = nameof(MovableConfig), 
        menuName = "Custom/Game/LevelObjects/Basic/" + nameof(MovableConfig),
        order = 2)]
    public class MovableConfig : ConfigBase, IMovableConfig
    {
        [SerializeField] private float _velocity;

        public float Velocity => _velocity;
    }
}