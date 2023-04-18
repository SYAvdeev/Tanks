using Domain.LevelObjects;
using UnityEngine;

namespace Presentation.LevelObjects
{
    public class CharacterPresenter : LevelObjectPresenter<CharacterModel>
    {
        [SerializeField] private Transform _rotateTransform;
        [SerializeField] private Transform _health;

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
            _health.localScale = new Vector3(LevelObjectModel.Health / LevelObjectModel.MaxHealth, _health.localScale.y);
        }
    }
}