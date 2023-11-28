using Configs.Logic;
using Domain.Logic;
using Domain.Logic.Damageable;

namespace Services
{
    public interface ILogicInvoker
    {
        void AddLogic(ILogic logic);
        void Invoke(IDamageableLogic damageableLogic, DamageableLogicConfig config);
        void InvokeTickable();
        void InvokeStartable();
    }
}