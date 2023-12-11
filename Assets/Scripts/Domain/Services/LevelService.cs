using ReactiveTypes;

namespace Domain.Services
{
    public class LevelService : ILevelService
    {
        private IReactivePropertyReadonly<float> _sizeXProperty;
        private IReactivePropertyReadonly<float> _sizeYProperty;

        public void SetLevelProperties(
            IReactivePropertyReadonly<float> sizeXProperty,
            IReactivePropertyReadonly<float> sizeYProperty)
        {
            _sizeXProperty = sizeXProperty;
            _sizeYProperty = sizeYProperty;
        }

        public (float, float) CurrentSize => (_sizeXProperty.Value, _sizeYProperty.Value);
    }
}