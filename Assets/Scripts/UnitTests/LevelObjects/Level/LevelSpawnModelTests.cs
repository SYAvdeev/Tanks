using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using Tanks.LevelObjects.Basic;
using Tanks.LevelObjects.Level;
using Tanks.LevelObjects.Level.Spawn;

namespace Tanks.UnitTests
{
    public class LevelSpawnModelTests
    {
        [Test]
        public void LevelSpawnModel_IsCurrentLevelIDEmpty_ShouldReturnCorrectValue()
        {
            //Arrange
            var levelSpawnData = new LevelSpawnData();
            var levelSpawnConfigMock = new Mock<ILevelSpawnConfig>();
            var levelSpawnModel = new LevelSpawnModel(levelSpawnData, levelSpawnConfigMock.Object);
            
            //Act
            //Assert
            Assert.True(levelSpawnModel.IsCurrentLevelIDEmpty);
            levelSpawnData.CurrentLevelID = "test-level-id";
            Assert.False(levelSpawnModel.IsCurrentLevelIDEmpty);
        }
        
        [Test]
        public void LevelSpawnModel_CurrentLevelConfig_ShouldReturnCorrectValue()
        {
            //Arrange
            var levelSpawnData = new LevelSpawnData();
            var levelSpawnConfigMock = new Mock<ILevelSpawnConfig>();
            var levelConfigMock = new Mock<ILevelConfig>();
            var spawnableConfigMock = new Mock<ISpawnableConfig>();

            levelSpawnConfigMock.Setup(lsc => lsc.LevelConfigs).Returns(new List<ILevelConfig> { levelConfigMock.Object });
            levelConfigMock.Setup(lc => lc.SpawnableConfig).Returns(spawnableConfigMock.Object);
            spawnableConfigMock.Setup(sc => sc.ID).Returns("test-level-id");
            
            var levelSpawnModel = new LevelSpawnModel(levelSpawnData, levelSpawnConfigMock.Object);
            
            //Act
            //Assert
            Assert.True(levelSpawnModel.CurrentLevelConfig == null);
            levelSpawnData.CurrentLevelID = "test-level-id";
            Assert.True(levelSpawnModel.CurrentLevelConfig == levelConfigMock.Object);
        }
        
        [Test]
        public void LevelSpawnModel_SetCurrentLevel_ShouldSetLevelCorrectly()
        {
            //Arrange
            int currentLevelChangedFireCounter = 0;
            string level1Key = "test-level-1";
            string level2Key = "test-level-2";

            var levelSpawnData = new LevelSpawnData();
            var levelSpawnConfigMock = new Mock<ILevelSpawnConfig>();

            var levelModelMock1 = new Mock<ILevelModel>();
            var spawnableModelMock1 = new Mock<ISpawnableModel>();
            var spawnableConfigMock1 = new Mock<ISpawnableConfig>();

            var levelModelMock2 = new Mock<ILevelModel>();
            var spawnableModelMock2 = new Mock<ISpawnableModel>();
            var spawnableConfigMock2 = new Mock<ISpawnableConfig>();

            levelModelMock1.Setup(lm => lm.Spawnable).Returns(spawnableModelMock1.Object);
            spawnableModelMock1.Setup(sm => sm.Config).Returns(spawnableConfigMock1.Object);
            spawnableConfigMock1.Setup(sc => sc.ID).Returns(level1Key);

            levelModelMock2.Setup(lm => lm.Spawnable).Returns(spawnableModelMock2.Object);
            spawnableModelMock2.Setup(sm => sm.Config).Returns(spawnableConfigMock2.Object);
            spawnableConfigMock2.Setup(sc => sc.ID).Returns(level2Key);

            var levelSpawnModel = new LevelSpawnModel(levelSpawnData, levelSpawnConfigMock.Object);
            levelSpawnModel.CurrentLevelChanged += _ => ++currentLevelChangedFireCounter;

            //Act
            
            void SetLevel1() => ((ILevelSpawnModel)levelSpawnModel).SetCurrentLevel(levelModelMock1.Object);
            void SetLevel2() => ((ILevelSpawnModel)levelSpawnModel).SetCurrentLevel(levelModelMock2.Object);
            
            //Assert
            Assert.DoesNotThrow(SetLevel1);
            Assert.True(levelSpawnModel.CurrentLevelModel == levelModelMock1.Object);
            Assert.True(currentLevelChangedFireCounter == 1);
            
            Assert.DoesNotThrow(SetLevel2);
            Assert.True(levelSpawnModel.CurrentLevelModel == levelModelMock2.Object);
            Assert.True(currentLevelChangedFireCounter == 2);
            Assert.True(levelSpawnModel.LevelsPool.ContainsKey(level1Key));
            
            Assert.DoesNotThrow(SetLevel2);
            Assert.True(currentLevelChangedFireCounter == 2);
        }
    }
}