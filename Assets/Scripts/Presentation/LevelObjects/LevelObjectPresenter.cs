using Domain.Models;
using UnityEngine;

namespace Presentation.LevelObjects
{
    public abstract class LevelObjectPresenter : MonoBehaviour
    {
        protected TransformableModel TransformableModel;
        protected SceneObjectsSpawner _sceneObjectsSpawner;
        private float _positionScale = 50f;

        public void Initialize(SceneObjectsSpawner sceneObjectsSpawner, float positionScale)
        {
            _sceneObjectsSpawner = sceneObjectsSpawner;
            _positionScale = positionScale;
        }

        public virtual void SetLevelObject(TransformableModel transformableModel)
        {
            if (TransformableModel != null)
            {
                TransformableModel.OnPositionUpdate -= OnPositionUpdate;
                TransformableModel.OnRotationUpdate -= OnRotationUpdate;
            }
            
            TransformableModel = transformableModel;
            TransformableModel.OnPositionUpdate += OnPositionUpdate;
            TransformableModel.OnRotationUpdate += OnRotationUpdate;
            
            
            OnPositionUpdate(transformableModel.PositionX, transformableModel.PositionY);
            OnRotationUpdate(transformableModel.DirectionAngle);
        }
        protected virtual void OnRotationUpdate(float angle)
        {
            transform.localRotation = Quaternion.Euler(0f, 0f, -Mathf.Rad2Deg * angle);
        }
        protected void OnPositionUpdate(float x, float y)
        {
            transform.localPosition = _positionScale * new Vector3(x, y);
        }
    }
    
    public abstract class LevelObjectPresenter<T> : LevelObjectPresenter where T : TransformableModel
    {
        public T LevelObjectModel => (T)TransformableModel;
    }
}