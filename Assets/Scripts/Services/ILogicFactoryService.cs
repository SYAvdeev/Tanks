using Configs.Logic;
using Domain;
using Domain.Logic.Damageable;
using Domain.Models;
using ReactiveTypes;

namespace Services
{
    public interface ILogicFactoryService
    {
        IDamageableLogic CreateLogicForEntity(IEntity entity, DamageableLogicConfig config);
    }

    public class LogicFactoryService : ILogicFactoryService
    {
        public IDamageableLogic CreateLogicForEntity(IEntity entity, DamageableLogicConfig config)
        {
            ReactiveProperty<float> healthProperty = entity.Model.GetProperty<float>(config.ModelHealthPropertyName);
            return new DamageableLogic(healthProperty, config.Protection);
        }
    }
}