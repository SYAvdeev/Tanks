namespace Model.LevelObjects.Behaviour
{
    public abstract class TickBehaviour
    {
        public bool IsActive = false;

        public void Tick(float deltaTime)
        {
            if (IsActive)
            {
                TickInternal(deltaTime);
            }
        }
        
        protected abstract void TickInternal(float deltaTime);
    }
}