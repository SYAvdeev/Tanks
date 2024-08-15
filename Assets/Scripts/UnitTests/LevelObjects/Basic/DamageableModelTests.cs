using Moq;
using NUnit.Framework;
using Tanks.LevelObjects.Basic;
using UnityEngine;

namespace Tanks.UnitTests
{
    public class DamageableModelTests
    {
        [Test]
        public void DamageableModel_GetCurrentHealth_ShouldReturnDataValue()
        {
            //Arrange
            float currentHealth = 5f;
            ArrangeDamageableModel(currentHealth, 0f, out _, out _, out var damageableModel);

            //Act
            //Assert
            Assert.True(Mathf.Approximately(damageableModel.GetCurrentHealth(), currentHealth));
        }
        
        [Test]
        public void DamageableModel_SetCurrentHealth_ShouldClamp()
        {
            //Arrange
            float currentHealth = 10f;
            float negativeHealth = -currentHealth;
            float excessiveHealth = 30f;
            float maxHealth = 20f;
            
            ArrangeDamageableModel(currentHealth, maxHealth, out _, out _, out var damageableModel);

            //Act
            void SetCurrentHealthNegative() => ((IDamageableModel)damageableModel).SetCurrentHealth(negativeHealth);
            void SetCurrentHealthExcessive() => ((IDamageableModel)damageableModel).SetCurrentHealth(excessiveHealth);

            //Assert
            SetCurrentHealthNegative();
            Assert.True(Mathf.Approximately(damageableModel.GetCurrentHealth(), 0f));
            SetCurrentHealthExcessive();
            Assert.True(Mathf.Approximately(damageableModel.GetCurrentHealth(), maxHealth));
        }

        [Test]
        public void DamageableModel_SetCurrentHealth_ShouldReturnIfHealthDidntChange()
        {
            //Arrange
            float currentHealth = 5f;
            float maxHealth = 10f;
            bool healthChanged = false;
            ArrangeDamageableModel(currentHealth, maxHealth, out _, out _, out var damageableModel);
            damageableModel.HealthChanged += _ => healthChanged = true;

            //Act
            ((IDamageableModel)damageableModel).SetCurrentHealth(currentHealth);
            //Assert
            Assert.False(healthChanged);
        }

        [Test]
        public void DamageableModel_SetCurrentHealth_ShouldSetHealthCorrectly()
        {
            //Arrange

            float currentHealth = 5f;
            float maxHealth = 20f;
            float newHealth = 10f;
            bool healthChanged = false;
            ArrangeDamageableModel(currentHealth, maxHealth, out _, out _, out var damageableModel);
            damageableModel.HealthChanged += _ => healthChanged = true;

            //Act
            ((IDamageableModel)damageableModel).SetCurrentHealth(newHealth);
            //Assert
            Assert.True(healthChanged);
            Assert.True(Mathf.Approximately(damageableModel.GetCurrentHealth(), newHealth));
        }

        private static void ArrangeDamageableModel(
            float currentHealth, 
            float maxHealth, 
            out Mock<IDamageableConfig> damageableConfig,
            out DamageableData damageableData,
            out DamageableModel damageableModel)
        {
            damageableConfig = new Mock<IDamageableConfig>();
            damageableConfig.Setup(dc => dc.MaxHealth).Returns(maxHealth);
            damageableData = new DamageableData
            {
                CurrentHealth = currentHealth
            };
            damageableModel = new DamageableModel(damageableData, damageableConfig.Object);
        }
    }
}