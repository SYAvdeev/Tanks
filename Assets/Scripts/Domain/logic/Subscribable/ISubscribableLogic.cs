namespace Domain.Logic.Subscribable
{
    public interface ISubscribableLogic : ILogic
    {
        void Subscribe(bool isSubscribe);
    }
}