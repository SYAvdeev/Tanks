using Model.LevelObjects;
using UnityEngine;

namespace Presentation.LevelObjects
{
    public abstract class LevelObjectPresenter : MonoBehaviour
    {
        protected LevelObjectModel _levelObjectModel;
        protected SceneObjectsSpawner _sceneObjectsSpawner;
        private float _positionScale = 50f;

        public void Initialize(SceneObjectsSpawner sceneObjectsSpawner, float positionScale)
        {
            _sceneObjectsSpawner = sceneObjectsSpawner;
            _positionScale = positionScale;
        }

        public virtual void SetLevelObject(LevelObjectModel levelObjectModel)
        {
            if (_levelObjectModel != null)
            {
                _levelObjectModel.OnPositionUpdate -= OnPositionUpdate;
                _levelObjectModel.OnRotationUpdate -= OnRotationUpdate;
                _levelObjectModel.OnDestroy -= Destroy;
            }
            
            _levelObjectModel = levelObjectModel;
            _levelObjectModel.OnPositionUpdate += OnPositionUpdate;
            _levelObjectModel.OnRotationUpdate += OnRotationUpdate;
            _levelObjectModel.OnDestroy += Destroy;

            OnPositionUpdate(levelObjectModel.PositionX, levelObjectModel.PositionY);
            OnRotationUpdate(levelObjectModel.DirectionAngle);
        }
        protected virtual void OnRotationUpdate(float angle)
        {
            transform.localRotation = Quaternion.Euler(0f, 0f, -Mathf.Rad2Deg * angle);
        }
        protected void OnPositionUpdate(float x, float y)
        {
            transform.localPosition = _positionScale * new Vector3(x, y);
        }
        protected virtual void Destroy(LevelObjectModel levelObjectModel)
        {
            gameObject.SetActive(false);
        }
    }
    
    public abstract class LevelObjectPresenter<T> : LevelObjectPresenter where T : LevelObjectModel
    {
        public T LevelObjectModel => (T)_levelObjectModel;
    }
}