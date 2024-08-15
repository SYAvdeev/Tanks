using System;
using Moq;
using NUnit.Framework;
using Tanks.LevelObjects.Basic;

namespace Tanks.UnitTests
{
    public class DamageableServiceTests
    {
        [Test]
        public void DamageableService_ConsumeDamageNegative_ShouldThrow()
        {
            //Arrange
            var damageableModelMock = new Mock<IDamageableModel>();
            var damageableService = new DamageableService(damageableModelMock.Object);
            float negativeDamage = -10f;
            
            //Act
            void ConsumeNegativeDamage() => damageableService.ConsumeDamage(negativeDamage);

            //Assert
            Assert.Catch<ArgumentException>(ConsumeNegativeDamage);
        }
        
        [Test]
        public void DamageableService_ConsumeMediumDamage_ShouldChangeCurrentHealthCorrectly()
        {
            //Arrange
            var damageableModelMock = new Mock<IDamageableModel>();
            var damageableConfigMock = new Mock<IDamageableConfig>();
            var damageableService = new DamageableService(damageableModelMock.Object);

            float damage = 10f;
            float protection = 0.3f;
            float currentHealth = 10f;
            float resultHealth = 3f;

            damageableConfigMock.Setup(dc => dc.Protection).Returns(protection);
            damageableModelMock.Setup(dm => dm.GetCurrentHealth()).Returns(currentHealth);
            damageableModelMock.Setup(dm => dm.Config).Returns(damageableConfigMock.Object);

            //Act
            void ConsumeDamage() => damageableService.ConsumeDamage(damage);

            //Assert
            Assert.DoesNotThrow(ConsumeDamage);
            damageableModelMock.Verify(dm => dm.SetCurrentHealth(resultHealth), Times.Once);
        }
        
        [Test]
        public void DamageableService_ConsumeDamage_ShouldFireOutOfHealth()
        {
            //Arrange
            var damageableModelMock = new Mock<IDamageableModel>();
            var damageableConfigMock = new Mock<IDamageableConfig>();
            var damageableService = new DamageableService(damageableModelMock.Object);

            float damage = 10f;
            float protection = 0.3f;
            float currentHealth = 0f;
            bool isOutOfHealth = false;

            damageableService.OutOfHealth += () => isOutOfHealth = true;
            damageableConfigMock.Setup(dc => dc.Protection).Returns(protection);
            damageableModelMock.Setup(dm => dm.GetCurrentHealth()).Returns(currentHealth);
            damageableModelMock.Setup(dm => dm.Config).Returns(damageableConfigMock.Object);

            //Act
            void ConsumeDamage() => damageableService.ConsumeDamage(damage);

            //Assert
            Assert.DoesNotThrow(ConsumeDamage);
            Assert.True(isOutOfHealth);
        }
        
        [Test]
        public void DamageableService_RestoreHealth_ShouldThrowWhenNegativeHealth()
        {
            //Arrange
            var damageableModelMock = new Mock<IDamageableModel>();
            var damageableService = new DamageableService(damageableModelMock.Object);
            float negativeHealth = -10f;
            
            //Act
            void RestoreNegativeHealth() => damageableService.RestoreHealth(negativeHealth);

            //Assert
            Assert.Catch<ArgumentException>(RestoreNegativeHealth);
        }
        
        [Test]
        public void DamageableService_RestoreHealth_ShouldSetCorrectValues()
        {
            //Arrange
            var damageableModelMock = new Mock<IDamageableModel>();
            var damageableService = new DamageableService(damageableModelMock.Object);
            
            float health = 10f;
            float currentHealth = 10f;
            float resultHealth = 20f;
            
            damageableModelMock.Setup(dm => dm.GetCurrentHealth()).Returns(currentHealth);
            
            //Act
            damageableService.RestoreHealth(health);

            //Assert
            damageableModelMock.Verify(dm => dm.SetCurrentHealth(resultHealth), Times.Once);
        }
    }
}