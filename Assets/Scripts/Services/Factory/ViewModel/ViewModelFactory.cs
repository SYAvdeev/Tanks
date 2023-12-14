using System;
using Configs.ViewModel;
using Domain.Features;
using Domain.Logic.Damageable;
using Domain.Logic.Damager;
using Domain.Logic.Destroyable;
using Features;
using Features.Damageable;
using Features.Damager;
using Features.DelayedDamager;
using Features.Movable;
using Features.Destroyable;
using Features.WeaponsInventory;

namespace Services.Factory.ViewModel
{
    public class ViewModelFactory
    {
        public BaseViewModel CreateViewModel(ViewModelFactoryType viewModelFactoryType, IFeature feature)
        {
            switch (viewModelFactoryType)
            {
                case ViewModelFactoryType.Damageable:

                    return new DamageableViewModel(feature.Model, feature.LogicCollection.Get<IDamageableLogic>());

                case ViewModelFactoryType.Damager:
                    
                    
                    return new DamagerViewModel(feature.Model, feature.LogicCollection.Get<IDamagerLogic>());

                case ViewModelFactoryType.DelayedDamager:
                    
                    return new DelayedDamagerViewModel(feature.Model, feature.LogicCollection.Get<IDelayedDamageLogic>());
                
                case ViewModelFactoryType.Movable:
                    
                    return new MovableViewModel(feature.Model);
                
                case ViewModelFactoryType.Destroyable:

                    return new DestroyableViewModel(feature.Model, feature.LogicCollection.Get<IDestroyableFeatureLogic>());

                case ViewModelFactoryType.WeaponsInventory:

                    return new WeaponsInventoryViewModel(feature.Model);
                
                default:
                    throw new ArgumentOutOfRangeException(nameof(viewModelFactoryType), viewModelFactoryType, null);
            }
        }
    }
}