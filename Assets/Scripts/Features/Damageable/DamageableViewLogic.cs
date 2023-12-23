using UnityEngine;

namespace Features.Damageable
{
    public class DamageableViewLogic : BaseViewLogic<DamageableViewModel, DamageableViewFacade>
    {
        public DamageableViewLogic(DamageableViewModel damageableViewModel, DamageableViewFacade damageableViewFacade) : 
            base(damageableViewModel, damageableViewFacade)
        {
            _viewModel.HealthNormalized.OnValueChanged += HealthScaleOnOnValueChanged;
        }

        private void HealthScaleOnOnValueChanged(float healthScale)
        {
            Transform healthTransform = _viewFacade.HealthTransform;
            _viewFacade.HealthTransform.localScale = new Vector3(healthScale, healthTransform.localScale.y);
        }
    }
}