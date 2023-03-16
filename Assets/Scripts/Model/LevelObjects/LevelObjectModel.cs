using System;
using System.Collections.Generic;
using Model.LevelObjects.Behaviour;

namespace Model.LevelObjects
{
    public class LevelObjectModel
    {
        protected readonly List<TickBehaviour> _currentBehaviours = new(4);
        private float _directionAngle;
        
        public float PositionX { get; protected set; }
        public float PositionY { get; protected set; }
        public float DirectionAngle 
        { 
            get => _directionAngle;
            set
            {
                _directionAngle = value;
                OnRotationUpdate?.Invoke(value);
            }
        }
        
        public event Action<float, float> OnPositionUpdate;
        public event Action<float> OnRotationUpdate;
        public event Action<LevelObjectModel> OnDestroy;

        protected LevelObjectModel(float positionX, float positionY, float directionAngle)
        {
            PositionX = positionX;
            PositionY = positionY;
            _directionAngle = directionAngle;
        }

        public virtual void SetPosition(float positionX, float positionY)
        {
            PositionX = positionX;
            PositionY = positionY;
            CallOnPositionUpdate(positionX, positionY);
        }

        protected void CallOnPositionUpdate(float positionX, float positionY)
        {
            OnPositionUpdate?.Invoke(positionX, positionY);
        }

        public virtual void Destroy(bool clearDestroyEvent = false)
        {
            for (int i = 0; i < _currentBehaviours.Count; i++)
            {
                _currentBehaviours[i].IsActive = false;
            }
            OnPositionUpdate = null;
            OnRotationUpdate = null;
            OnDestroy?.Invoke(this);
            
            if(clearDestroyEvent)
            {
                ClearDestroyEvent();
            }
        }

        public void ClearDestroyEvent()
        {
            OnDestroy = null;
        }

        public void TickBehaviours(float deltaTime)
        {
            for (int i = 0; i < _currentBehaviours.Count; i++)
            {
                _currentBehaviours[i].Tick(deltaTime);
            }
        }
    }
}