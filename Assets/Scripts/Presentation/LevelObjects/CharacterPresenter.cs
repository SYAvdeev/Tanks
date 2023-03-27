using Domain.LevelObjects;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.LevelObjects
{
    public class CharacterPresenter : LevelObjectPresenter<CharacterModel>
    {
        [SerializeField] private Transform _rotateTransform;
        [SerializeField] private Image _health;

        public override void SetLevelObject(LevelObjectModel levelObjectModel)
        {
            base.SetLevelObject(levelObjectModel);
            LevelObjectModel.OnHealthChanged += OnHealthChanged;
            OnHealthChanged(LevelObjectModel.Health);
        }

        protected override void OnRotationUpdate(float angle)
        {
            _rotateTransform.localRotation = Quaternion.Euler(0f, 0f, -Mathf.Rad2Deg * angle);
        }

        private void OnHealthChanged(float health)
        {
            _health.fillAmount = LevelObjectModel.Health / LevelObjectModel.MaxHealth;
        }
    }
}