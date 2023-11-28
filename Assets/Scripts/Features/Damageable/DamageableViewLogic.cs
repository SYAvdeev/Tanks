using UnityEngine;

namespace Features.Damageable
{
    public class DamageableViewLogic
    {
        private readonly DamageableViewFacade _damageableViewFacade;
        private readonly DamageableViewModel _damageableViewModel;

        public DamageableViewLogic(DamageableViewFacade damageableViewFacade, DamageableViewModel damageableViewModel)
        {
            _damageableViewFacade = damageableViewFacade;
            _damageableViewModel = damageableViewModel;
            
            _damageableViewModel.HealthNormalized.OnValueChanged += HealthScaleOnOnValueChanged;
        }

        private void HealthScaleOnOnValueChanged(float healthScale)
        {
            Transform healthTransform = _damageableViewFacade.HealthTransform;
            _damageableViewFacade.HealthTransform.localScale = new Vector3(healthScale, healthTransform.localScale.y);
        }
    }
}