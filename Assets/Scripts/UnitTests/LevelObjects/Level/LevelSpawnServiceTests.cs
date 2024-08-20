using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using Tanks.Game.LevelObjects.Basic;
using Tanks.Game.LevelObjects.Level;
using Tanks.Game.Spawn.LevelSpawn;

namespace Tanks.UnitTests
{
    public class LevelSpawnServiceTests
    {
        [Test]
        public void LevelSpawnService_Initialize_ShouldWorkCorrectlyWhenCurrentLevelIdIsEmpty()
        {
            //Arrange
            var levelSpawnModelMock = new Mock<ILevelSpawnModel>();
            var levelSpawnConfigMock = new Mock<ILevelSpawnConfig>();
            var levelConfigMock = new Mock<ILevelConfig>();
            var spawnableConfigMock = new Mock<ISpawnableConfig>();
            
            levelSpawnModelMock.Setup(lsm => lsm.IsCurrentLevelIDEmpty).Returns(true);
            levelSpawnModelMock.Setup(lsm => lsm.Config).Returns(levelSpawnConfigMock.Object);
            levelSpawnModelMock.Setup(lsm => lsm.LevelsPool).Returns(new Dictionary<string, ILevelModel>());

            levelSpawnConfigMock.Setup(lsc => lsc.FirstLevelConfig).Returns(levelConfigMock.Object);

            levelConfigMock.Setup(lc => lc.SpawnableConfig).Returns(spawnableConfigMock.Object);

            spawnableConfigMock.Setup(sc => sc.ID).Returns("test-level");

            var levelSpawnService = new LevelSpawnService(levelSpawnModelMock.Object);
            
            //Act

            void Initialize() => levelSpawnService.SpawnCurrentLevel();

            //Assert
            Assert.DoesNotThrow(Initialize);
            levelSpawnModelMock.Verify(lsm => lsm.SetCurrentLevel(It.IsAny<ILevelModel>()), Times.Once);
        }
        
        [Test]
        public void LevelSpawnService_Initialize_ShouldWorkCorrectlyWhenCurrentLevelIdIsNotEmpty()
        {
            //Arrange
            string levelId = "test-level";
            
            var levelSpawnModelMock = new Mock<ILevelSpawnModel>();
            var levelConfigMock = new Mock<ILevelConfig>();
            var spawnableConfigMock = new Mock<ISpawnableConfig>();
            var levelModelMock = new Mock<ILevelModel>();

            levelSpawnModelMock.Setup(lsm => lsm.IsCurrentLevelIDEmpty).Returns(false);
            levelSpawnModelMock.Setup(lsm => lsm.CurrentLevelConfig).Returns(levelConfigMock.Object);
            levelSpawnModelMock.Setup(lsm => lsm.LevelsPool).Returns(new Dictionary<string, ILevelModel>
            {
                {levelId, levelModelMock.Object}
            });

            levelConfigMock.Setup(lc => lc.SpawnableConfig).Returns(spawnableConfigMock.Object);

            spawnableConfigMock.Setup(sc => sc.ID).Returns(levelId);

            var levelSpawnService = new LevelSpawnService(levelSpawnModelMock.Object);
            
            //Act

            void Initialize() => levelSpawnService.SpawnCurrentLevel();

            //Assert
            Assert.DoesNotThrow(Initialize);
            levelSpawnModelMock.Verify(lsm => lsm.SetCurrentLevel(levelModelMock.Object), Times.Once);
        }
    }
}