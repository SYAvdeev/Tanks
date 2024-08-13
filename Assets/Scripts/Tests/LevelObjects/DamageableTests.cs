using System;
using Moq;
using NUnit.Framework;
using Tanks.LevelObjects.Basic;

namespace Tanks.Tests
{
    public class DamageableTests
    {
        [Test]
        public void DamageableService_ConsumeDamageNegative_ShouldThrow()
        {
            //Arrange
            ArrangeDamageableService(
                10f,
                10f,
                0.3f,
                out var damageableService,
                out var damageableModel);

            //Act
            void ConsumeNegativeDamage() => damageableService.ConsumeDamage(-10f);

            //Assert
            Assert.Catch<ArgumentException>(ConsumeNegativeDamage);
        }
        
        [Test]
        public void DamageableService_ConsumeDamage_10_ShouldChangeCurrentHealthCorrectly()
        {
            //Arrange
            ArrangeDamageableService(
                10f,
                10f,
                0.3f,
                out var damageableService,
                out var damageableModel);

            //Act
            void ConsumeDamage() => damageableService.ConsumeDamage(10f);

            //Assert
            Assert.DoesNotThrow(ConsumeDamage);
            Assert.AreEqual(damageableModel.GetCurrentHealth(), 3f);
        }
        
        [Test]
        public void DamageableService_ConsumeDamage_20_ShouldChangeCurrentHealthCorrectly()
        {
            //Arrange
            ArrangeDamageableService(
                10f,
                10f,
                0.3f,
                out var damageableService,
                out var damageableModel);
            bool isOutOfHealth = false;
            damageableService.OutOfHealth += () => isOutOfHealth = true;
            
            //Act
            void ConsumeDamage() => damageableService.ConsumeDamage(20f);

            //Assert
            Assert.DoesNotThrow(ConsumeDamage);
            Assert.AreEqual(damageableModel.GetCurrentHealth(), 0f);
            Assert.AreEqual(isOutOfHealth, true);
        }
        
        [Test]
        public void DamageableService_RestoreHealthNegative_ShouldThrow()
        {
            //Arrange
            ArrangeDamageableService(
                10f,
                1f,
                0f,
                out var damageableService,
                out var damageableModel);

            //Act
            void RestoreNegativeHealth() => damageableService.RestoreHealth(-10f);

            //Assert
            Assert.Catch<ArgumentException>(RestoreNegativeHealth);
        }
        
        [Test]
        public void DamageableService_RestoreHealth_4_ShouldChangeCurrentHealthCorrectly()
        {
            //Arrange
            ArrangeDamageableService(
                10f,
                1f,
                0f,
                out var damageableService,
                out var damageableModel);

            //Act
            void RestoreHealth() => damageableService.RestoreHealth(4f);

            //Assert
            Assert.DoesNotThrow(RestoreHealth);
            Assert.AreEqual(damageableModel.GetCurrentHealth(), 5f);
        }
        
        [Test]
        public void DamageableService_RestoreHealth_20_ShouldChangeCurrentHealthCorrectly()
        {
            //Arrange
            ArrangeDamageableService(
                10f,
                1f,
                0f,
                out var damageableService,
                out var damageableModel);
            
            //Act
            void RestoreHealth() => damageableService.RestoreHealth(20f);

            //Assert
            Assert.DoesNotThrow(RestoreHealth);
            Assert.AreEqual(damageableModel.GetCurrentHealth(), damageableModel.Config.MaxHealth);
        }

        private static void ArrangeDamageableService(
            float maxHealth,
            float currentHealth,
            float protection,
            out IDamageableService damageableService,
            out IDamageableModel damageableModel)
        {
            var damageableConfig = new Mock<IDamageableConfig>();
            damageableConfig.Setup(dc => dc.MaxHealth).Returns(maxHealth);
            damageableConfig.Setup(dc => dc.Protection).Returns(protection);
            
            var damageableData = new DamageableData
            {
                CurrentHealth = currentHealth
            };

            damageableModel = new DamageableModel(damageableData, damageableConfig.Object);
            damageableService = new DamageableService(damageableModel);
        }
    }
}