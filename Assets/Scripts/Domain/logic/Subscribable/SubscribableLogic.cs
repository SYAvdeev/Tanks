namespace Domain.Logic.Subscribable
{
    public abstract class SubscribableLogic : ISubscribableLogic
    {
        private bool _isSubscribed;

        public void Subscribe(bool isSubscribe)
        {
            if (isSubscribe == _isSubscribed)
            {
                return;
            }
            
            if (isSubscribe)
            {
                Subscribe();
            }
            else
            {
                Unsubscribe();
            }

            _isSubscribed = isSubscribe;
        }

        protected abstract void Subscribe();
        protected abstract void Unsubscribe();
    }
}