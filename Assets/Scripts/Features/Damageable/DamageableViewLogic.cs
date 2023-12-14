using UnityEngine;

namespace Features.Damageable
{
    public class DamageableViewLogic : BaseViewLogic<DamageableViewModel, DamageableViewFacade>
    {
        public DamageableViewModel DamageableViewModel => _viewModel;
        
        public DamageableViewLogic(DamageableViewModel damageableViewModel, DamageableViewFacade damageableViewFacade) : 
            base(damageableViewModel, damageableViewFacade)
        {
            _viewModel.HealthNormalized.OnValueChanged += HealthScaleOnOnValueChanged;
            _viewFacade.DamageablePhysics.Initialize(this);
        }

        private void HealthScaleOnOnValueChanged(float healthScale)
        {
            Transform healthTransform = _viewFacade.HealthTransform;
            _viewFacade.HealthTransform.localScale = new Vector3(healthScale, healthTransform.localScale.y);
        }
    }
}