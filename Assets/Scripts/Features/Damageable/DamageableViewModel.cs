using Domain.Logic;
using Domain.Logic.Damageable;
using Domain.Models;
using ReactiveTypes;

namespace Features.Damageable
{
    public class DamageableViewModel : BaseViewModel
    {
        public IReactiveProperty<float> HealthNormalized { get; }
        public IDamageableLogic DamageableLogic { get; }

        private readonly IReactiveProperty<float> _healthProperty;
        private readonly IReactiveProperty<float> _maxHealthProperty;

        public DamageableViewModel(IModel model, ILogicCollection logicCollection) : base(model, logicCollection)
        {
            HealthNormalized = new ReactiveProperty<float>(CalculateHealthNormalized());
            DamageableLogic = logicCollection.Get<IDamageableLogic>();
            
            _healthProperty = model.GetProperty<float>(ModelPropertyName.Health);
            _maxHealthProperty = model.GetProperty<float>(ModelPropertyName.MaxHealth);

            _healthProperty.OnValueChanged += HealthPropertyOnOnValueChanged;
        }

        private void HealthPropertyOnOnValueChanged(float health)
        {
            HealthNormalized.Value = CalculateHealthNormalized();
        }

        private float CalculateHealthNormalized()
        {
            return _healthProperty.Value / _maxHealthProperty.Value;
        }
    }
}