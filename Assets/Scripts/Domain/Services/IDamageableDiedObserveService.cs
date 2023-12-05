using System;
using Domain.Logic.Damageable;

namespace Domain.Services
{
    public interface IDamageableDiedObserveService
    {
        event Action<IDamageableLogic> Died;
        void Subscribe(IDamageableLogic damageableLogic);
        void Unsubscribe(IDamageableLogic damageableLogic);
        void Clear();
    }
}