using System;
using Moq;
using NUnit.Framework;
using Tanks.Game.LevelObjects.Basic;
using UnityEngine;

namespace Tanks.UnitTests
{
    public class MovableServiceTests
    {
        [Test]
        public void MovableService_MoveAlongDirection_ShouldThrowWhenDeltaTimeLessThanZero()
        {
            //Arrange
            ArrangeMovableService(0f, 0f, Vector2.zero, out var movableService, out _);
            //Act
            void MoveAlongDirection() => movableService.MoveAlongDirection(-0.001f);
            //Assert
            Assert.Catch<ArgumentException>(MoveAlongDirection);
        }
        
        [Test]
        public void MovableService_MoveAlongDirection_ShouldSetCorrectValues()
        {
            //Arrange
            ArrangeMovableService(1f, 0f, Vector2.zero, out var movableService, out var movableModelMock);
            //Act
            void MoveAlongDirection() => movableService.MoveAlongDirection(1f);
            //Assert
            Assert.DoesNotThrow(MoveAlongDirection);
            movableModelMock.Verify(mm => mm.SetPosition(It.IsAny<Vector2>()), Times.Once);
        }
        
        [Test]
        public void MovableService_RotateTowards_ShouldSetCorrectValues()
        {
            //Arrange
            ArrangeMovableService(0f, 0f, Vector2.zero, out var movableService, out var movableModelMock);
            //Act
            void RotateTowards() => movableService.RotateTowards(Vector2.one);
            //Assert
            Assert.DoesNotThrow(RotateTowards);
            movableModelMock.Verify(mm => mm.SetDirectionAngle(45f), Times.Once);
        }
        
        [Test]
        public void MovableService_RotateWithVelocity_ShouldThrowWhenDeltaTimeLessThanZero()
        {
            //Arrange
            ArrangeMovableService(0f, 0f, Vector2.zero, out var movableService, out _);
            //Act
            void RotateWithVelocity() => movableService.RotateWithVelocity(0f, true, -0.001f);
            //Assert
            Assert.Catch<ArgumentException>(RotateWithVelocity);
        }
        
        [Test]
        public void MovableService_RotateWithVelocity_ShouldThrowWhenRotationVelocityLessThanZero()
        {
            //Arrange
            ArrangeMovableService(0f, 0f, Vector2.zero, out var movableService, out _);
            //Act
            void RotateWithVelocity() => movableService.RotateWithVelocity(-0.001f, true, 1f);
            //Assert
            Assert.Catch<ArgumentException>(RotateWithVelocity);
        }
        
        [Test]
        public void MovableService_RotateWithVelocity_ShouldSetCorrectValues()
        {
            //Arrange
            ArrangeMovableService(
                0f,
                0f,
                Vector2.zero,
                out IMovableService movableService,
                out var movableModelMock);
            //Act
            void RotateWithVelocity() => movableService.RotateWithVelocity(3f, false, 2f);
            //Assert
            Assert.DoesNotThrow(RotateWithVelocity);
            movableModelMock.Verify(mm => mm.SetDirectionAngle(-6f), Times.Once);
        }
        
        private static void ArrangeMovableService(
            float velocity,
            float directionAngle,
            Vector2 position,
            out IMovableService movableService,
            out Mock<IMovableModel> movableModelMock)
        {
            var movableConfigMock = new Mock<IMovableConfig>();
            movableConfigMock.Setup(mc => mc.Velocity).Returns(velocity);

            movableModelMock = new Mock<IMovableModel>();
            movableModelMock.Setup(mm => mm.Config).Returns(movableConfigMock.Object);
            movableModelMock.Setup(mm => mm.DirectionAngle).Returns(directionAngle);
            movableModelMock.Setup(mm => mm.Position).Returns(position);
            
            movableService = new MovableService(movableModelMock.Object);
        }
    }
}