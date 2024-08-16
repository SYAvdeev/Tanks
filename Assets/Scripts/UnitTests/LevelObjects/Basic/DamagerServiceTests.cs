using Moq;
using NUnit.Framework;
using Tanks.Game.LevelObjects.Basic;

namespace Tanks.UnitTests
{
    public class DamagerServiceTests
    {
        [Test]
        public void DamagerService_MakeDamage_ShouldCallDamageableServiceConsumeDamageOnce()
        {
            //Arrange
            var damageableService = new Mock<IDamageableService>();
            
            var damagerConfig = new Mock<IDamagerConfig>();
            float damage = 5f;
            damagerConfig.Setup(dc => dc.Damage).Returns(damage);
            var damagerModel = new Mock<IDamagerModel>();
            damagerModel.Setup(dm => dm.Config).Returns(damagerConfig.Object);
            var damagerService = new DamagerService(damagerModel.Object);
            
            //Act
            damagerService.MakeDamage(damageableService.Object);

            //Assert
            damageableService.Verify(ds => ds.ConsumeDamage(damage), Times.Once);
        }
    }
}