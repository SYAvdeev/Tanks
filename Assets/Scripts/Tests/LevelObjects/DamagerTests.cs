﻿using Moq;
using NUnit.Framework;
using Tanks.LevelObjects.Basic;

namespace Tanks.Tests
{
    public class DamagerTests
    {
        [Test]
        public void DamagerService_MakeDamage_ShouldCallDamageableServiceConsumeDamageOnce()
        {
            //Arrange
            var damageableService = new Mock<IDamageableService>();
            
            var damagerConfig = new Mock<IDamagerConfig>();
            float damage = 5f;
            damagerConfig.Setup(dc => dc.Damage).Returns(damage);
            var damagerModel = new DamagerModel(damagerConfig.Object);

            var damagerService = new DamagerService(damagerModel);
            
            //Act
            damagerService.MakeDamage(damageableService.Object);

            //Assert
            damageableService.Verify(ds => ds.ConsumeDamage(damage), Times.Once);
        }
    }
}