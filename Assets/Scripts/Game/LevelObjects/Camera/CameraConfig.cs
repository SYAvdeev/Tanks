using Tanks.Game.LevelObjects.Basic;
using Tanks.Utility;
using UnityEngine;

namespace Tanks.Game.LevelObjects.Camera
{
    [CreateAssetMenu(
        fileName = nameof(CameraConfig), 
        menuName = "Custom/Game/" + nameof(CameraConfig),
        order = 0)]
    public class CameraConfig : ConfigBase, ICameraConfig
    {
        [SerializeField] private MovableConfig _movableConfig;
        [SerializeField] private float _sizeX;
        [SerializeField] private float _sizeY;

        public IMovableConfig MovableConfig => _movableConfig;
        public float SizeX => _sizeX;
        public float SizeY => _sizeY;
    }
}