using System;
using Common.Collections;
using ReactiveTypes;

namespace Domain.Logic.Level
{
    public class SpawnPositionLogic : ISpawnPositionLogic
    {
        private readonly IReactiveProperty<float> _cameraPositionXProperty;
        private readonly IReactiveProperty<float> _cameraPositionYProperty;
        private readonly IReactiveProperty<float> _cameraSizeXProperty;
        private readonly IReactiveProperty<float> _cameraSizeYProperty;
        private readonly Random _random;
        private readonly RandomUniqueCollection<LevelBorderType> _borderIndices;

        public SpawnPositionLogic(
            IReactiveProperty<float> cameraSizeXProperty,
            IReactiveProperty<float> cameraSizeYProperty,
            Random random)
        {
            _cameraSizeXProperty = cameraSizeXProperty;
            _cameraSizeYProperty = cameraSizeYProperty;
            _random = random;
            _borderIndices = new RandomUniqueCollection<LevelBorderType>(new []
            {
                LevelBorderType.Top, LevelBorderType.Bottom, LevelBorderType.Left, LevelBorderType.Right
            },
                random);
        }

        public (float, float) GetRandomOffScreenSpawnPosition()
        {
            LevelBorderType borderIndex = GetBorderIndex();
            float positionNormalized = GetPositionNormalized();

            return borderIndex switch
            {
                LevelBorderType.Top => (_cameraSizeXProperty.Value * positionNormalized,
                    _cameraPositionYProperty.Value + (_cameraSizeYProperty.Value / 2f)),
                LevelBorderType.Bottom => (_cameraSizeXProperty.Value * positionNormalized,
                    _cameraPositionYProperty.Value - (_cameraSizeYProperty.Value / 2f)),
                LevelBorderType.Left => (_cameraPositionXProperty.Value - (_cameraSizeXProperty.Value / 2f),
                    _cameraSizeYProperty.Value * positionNormalized),
                LevelBorderType.Right => (_cameraPositionXProperty.Value + (_cameraSizeXProperty.Value / 2f),
                    _cameraSizeYProperty.Value * positionNormalized),
                _ => throw new ArgumentOutOfRangeException()
            };
        }
        
        private LevelBorderType GetBorderIndex() => _borderIndices.Next();
        private float GetPositionNormalized() => (float)_random.NextDouble();
        
    }
}