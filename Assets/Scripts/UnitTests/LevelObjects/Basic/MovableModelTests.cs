using Moq;
using NUnit.Framework;
using Tanks.LevelObjects.Basic;
using UnityEngine;

namespace Tanks.UnitTests
{
    public class MovableModelTests
    {
        [Test]
        public void MovableService_DirectionAngle_ShouldReturnDataDirectionAngle()
        {
            //Arrange
            float directionAngle = 45f;
            
            var movableConfigMock = new Mock<IMovableConfig>();
            var movableData = new MovableData
            {
                DirectionAngle = directionAngle
            };
            var movableModel = new MovableModel(movableConfigMock.Object, movableData);
            
            //Act
            //Assert
            Assert.True(Mathf.Approximately(movableModel.DirectionAngle, directionAngle));
        }
        
        [Test]
        public void MovableService_Position_ShouldReturnDataDirectionAngle()
        {
            //Arrange
            float x = 1f, y = 2f;
            Vector2 position = new Vector2(x, y);
            
            var movableConfigMock = new Mock<IMovableConfig>();
            var movableData = new MovableData
            {
                Position = position
            };
            var movableModel = new MovableModel(movableConfigMock.Object, movableData);
            
            //Act
            //Assert
            Assert.True(Mathf.Approximately(movableModel.Position.x, x) &&
                        Mathf.Approximately(movableModel.Position.y, y));
        }
        
        [Test]
        public void MovableService_SetDirectionAngle_ShouldClampExcessiveAngle()
        {
            //Arrange
            float initialAngle = 15f;
            float excessiveAngle = 380f;
            float resultAngle = 20f;
            
            var movableConfigMock = new Mock<IMovableConfig>();
            var movableData = new MovableData
            {
                DirectionAngle = initialAngle
            };
            var movableModel = new MovableModel(movableConfigMock.Object, movableData);
            
            //Act
            
            void SetExcessiveAngle() => ((IMovableModel)movableModel).SetDirectionAngle(excessiveAngle);
            
            //Assert
            Assert.DoesNotThrow(SetExcessiveAngle);
            Assert.True(Mathf.Approximately(movableModel.DirectionAngle, resultAngle));
        }
        
        [Test]
        public void MovableService_SetDirectionAngle_ShouldClampNegativeAngle()
        {
            //Arrange
            float initialAngle = 15f;
            float negativeAngle = -380f;
            float resultAngle = 340f;
            
            var movableConfigMock = new Mock<IMovableConfig>();
            var movableData = new MovableData
            {
                DirectionAngle = initialAngle
            };
            var movableModel = new MovableModel(movableConfigMock.Object, movableData);
            
            //Act
            
            void SetNegativeAngle() => ((IMovableModel)movableModel).SetDirectionAngle(negativeAngle);
            
            //Assert
            Assert.DoesNotThrow(SetNegativeAngle);
            Assert.True(Mathf.Approximately(movableModel.DirectionAngle, resultAngle));
        }
        
        [Test]
        public void MovableService_SetDirectionAngle_ShouldReturnIfSameAngle()
        {
            //Arrange
            float initialAngle = 15f;
            bool angleUpdated = false;
            
            var movableConfigMock = new Mock<IMovableConfig>();
            var movableData = new MovableData
            {
                DirectionAngle = initialAngle
            };
            var movableModel = new MovableModel(movableConfigMock.Object, movableData);
            movableModel.DirectionAngleUpdated += _ => angleUpdated = true;
            
            //Act
            
            void SetSameAngle() => ((IMovableModel)movableModel).SetDirectionAngle(initialAngle);
            
            //Assert
            Assert.DoesNotThrow(SetSameAngle);
            Assert.True(Mathf.Approximately(movableModel.DirectionAngle, initialAngle));
            Assert.False(angleUpdated);
        }
        
        [Test]
        public void MovableService_SetDirectionAngle_ShouldFireAngleUpdated()
        {
            //Arrange
            float initialAngle = 15f;
            float newAngle = 20f;
            bool angleUpdated = false;
            
            var movableConfigMock = new Mock<IMovableConfig>();
            var movableData = new MovableData
            {
                DirectionAngle = initialAngle
            };
            var movableModel = new MovableModel(movableConfigMock.Object, movableData);
            movableModel.DirectionAngleUpdated += _ => angleUpdated = true;
            
            //Act
            
            void SetAngle() => ((IMovableModel)movableModel).SetDirectionAngle(newAngle);
            
            //Assert
            Assert.DoesNotThrow(SetAngle);
            Assert.True(Mathf.Approximately(movableModel.DirectionAngle, newAngle));
            Assert.True(angleUpdated);
        }
        
        [Test]
        public void MovableService_SetPosition_ShouldReturnIfSamePosition()
        {
            //Arrange
            Vector2 initialPosition = Vector2.one;
            bool positionUpdated = false;
            
            var movableConfigMock = new Mock<IMovableConfig>();
            var movableData = new MovableData
            {
                Position = initialPosition
            };
            var movableModel = new MovableModel(movableConfigMock.Object, movableData);
            movableModel.PositionUpdated += _ => positionUpdated = true;
            
            //Act
            void SetPosition() => ((IMovableModel)movableModel).SetPosition(initialPosition);
            
            //Assert
            Assert.DoesNotThrow(SetPosition);
            Assert.True(Mathf.Approximately(movableModel.Position.x, initialPosition.x) &&
                        Mathf.Approximately(movableModel.Position.y, initialPosition.y));
            Assert.False(positionUpdated);
        }
        
        [Test]
        public void MovableService_SetPosition_ShouldFirePositionUpdated()
        {
            //Arrange
            Vector2 initialPosition = Vector2.one;
            Vector2 newPosition = Vector2.up;
            bool positionUpdated = false;
            
            var movableConfigMock = new Mock<IMovableConfig>();
            var movableData = new MovableData
            {
                Position = initialPosition
            };
            var movableModel = new MovableModel(movableConfigMock.Object, movableData);
            movableModel.PositionUpdated += _ => positionUpdated = true;
            
            //Act
            void SetPosition() => ((IMovableModel)movableModel).SetPosition(newPosition);
            
            //Assert
            Assert.DoesNotThrow(SetPosition);
            Assert.True(Mathf.Approximately(movableModel.Position.x, newPosition.x) &&
                        Mathf.Approximately(movableModel.Position.y, newPosition.y));
            Assert.True(positionUpdated);
        }
    }
}