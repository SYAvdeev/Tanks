using System;
using Moq;
using NUnit.Framework;
using Tanks.LevelObjects.Basic;
using UnityEngine;

namespace Tanks.Tests
{
    public class MovableTests
    {
        [Test]
        public void MovableService_MoveAlongDirection_ShouldThrowWhenDeltaTimeLessThanZero()
        {
            //Arrange
            ArrangeMovableService(
                0f,
                0f,
                Vector2.zero,
                out IMovableService movableService,
                out MovableModel movableModel);
            //Act
            void MoveAlongDirection() => movableService.MoveAlongDirection(-0.001f);
            //Assert
            Assert.Catch<ArgumentException>(MoveAlongDirection);
        }
        
        [Test]
        public void MovableService_MoveAlongDirection_ShouldSetCorrectValues()
        {
            //Arrange
            ArrangeMovableService(
                Mathf.Sqrt(2f),
                45f,
                Vector2.zero,
                out IMovableService movableService,
                out MovableModel movableModel);
            //Act
            void MoveAlongDirection() => movableService.MoveAlongDirection(1f);
            //Assert
            Assert.DoesNotThrow(MoveAlongDirection);
            Assert.True(Mathf.Approximately(movableModel.Position.x, 1f) &&
                        Mathf.Approximately(movableModel.Position.y, 1f));
        }
        
        [Test]
        public void MovableService_RotateTowards_ShouldSetCorrectValues()
        {
            //Arrange
            ArrangeMovableService(
                0f,
                0f,
                Vector2.zero,
                out IMovableService movableService,
                out MovableModel movableModel);
            //Act
            void RotateTowards() => movableService.RotateTowards(Vector2.one);
            //Assert
            Assert.DoesNotThrow(RotateTowards);
            Assert.True(Mathf.Approximately(movableModel.DirectionAngle, 45f));
        }
        
        [Test]
        public void MovableService_RotateWithVelocity_ShouldThrowWhenDeltaTimeLessThanZero()
        {
            //Arrange
            ArrangeMovableService(
                0f,
                0f,
                Vector2.zero,
                out IMovableService movableService,
                out MovableModel movableModel);
            //Act
            void RotateWithVelocity() => movableService.RotateWithVelocity(0f, true, -0.001f);
            //Assert
            Assert.Catch<ArgumentException>(RotateWithVelocity);
        }
        
        [Test]
        public void MovableService_RotateWithVelocity_ShouldThrowWhenRotationVelocityLessThanZero()
        {
            //Arrange
            ArrangeMovableService(
                0f,
                0f,
                Vector2.zero,
                out IMovableService movableService,
                out MovableModel movableModel);
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
                out MovableModel movableModel);
            //Act
            void RotateWithVelocity() => movableService.RotateWithVelocity(365f, false, 2f);
            //Assert
            Assert.DoesNotThrow(RotateWithVelocity);
            Assert.True(Mathf.Approximately(movableModel.DirectionAngle, -10f));
        }
        
        private static void ArrangeMovableService(
            float velocity,
            float directionAngle,
            Vector2 position,
            out IMovableService movableService,
            out MovableModel movableModel)
        {
            var movableConfig = new Mock<IMovableConfig>();
            movableConfig.Setup(mc => mc.Velocity).Returns(velocity);
            
            var movableData = new MovableData
            {
                Position = position,
                DirectionAngle = directionAngle
            };

            movableModel = new MovableModel(movableConfig.Object, movableData);
            movableService = new MovableService(movableModel);
        }
    }
}