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
        [SerializeField] private bool _isRestricted;

        public float Velocity => _velocity;
        public bool IsRestricted => _isRestricted;
    }
}