using Gamem;
using Xunit;
using System.Numerics;

namespace Gamem.Tests;

public class PhysicsGmTests
{
    [Theory]
    [InlineData(0.0, -9.81, 0.016, -0.15696)]

    [InlineData(-10.0, -9.81, 0.016, -10.15696)]

    [InlineData(15.0, -9.81, 0.016, 14.84304)]

    [InlineData(0.0, 5.0, 0.1, 0.5)]

    [InlineData(4.2, 0.0, 0.016, 4.2)]
    public void ApplyGravityTest(double velocity, double gravity, double deltaTime, double expected) => Assert.Equal(expected, PhysicsGm.ApplyGravity(velocity, gravity, deltaTime), 5);
    [Theory]
    [InlineData(10.0, 2.0, 0.016, 9.968)]

    [InlineData(-5.0, 3.0, 0.02, -4.94)]

    [InlineData(0.02, 5.0, 0.016, 0.0)]

    [InlineData(0.0000005, 1.0, 0.016, 0.0)]

    [InlineData(10.0, -2.0, 0.016, 9.968)]
    public void ApplyFrictionTest(double velocity, double frictionCoeff, double deltaTime, double expected) => Assert.Equal(expected, PhysicsGm.ApplyFriction(velocity, frictionCoeff, deltaTime), 5);
    [Theory]
    [InlineData(10.0, 20.0, 3.0, 13.0)]

    [InlineData(20.0, 10.0, 4.0, 16.0)]

    [InlineData(18.5, 20.0, 5.0, 20.0)]

    [InlineData(10.0, 20.0, 0.0, 10.0)]
    [InlineData(10.0, 20.0, -2.5, 10.0)]
    public void MoveTowardsTest(double current, double target, double maxDelta, double expected) => Assert.Equal(expected, PhysicsGm.MoveTowards(current, target, maxDelta), 5);
    [Theory]
    [InlineData(-10.0, 0.7, 0.5, 7.0)]

    [InlineData(-0.5, 0.5, 0.5, 0.0)]

    [InlineData(-5.0, 1.0, 0.1, 5.0)]
    [InlineData(-5.0, 0.0, 0.1, 0.0)]

    [InlineData(-10.0, 1.5, 0.1, 10.0)]
    [InlineData(-10.0, -0.5, 0.1, 0.0)]
    public void BounceTest(double vOld, double bounciness, double minBounceThreshold, double expected) => Assert.Equal(expected, PhysicsGm.Bounce(vOld, bounciness, minBounceThreshold), 5);
    [Theory]
    [InlineData(-5.0, 0.5, 2.5)]

    [InlineData(-0.15, 0.5, 0.0)]

    [InlineData(-0.2, 0.5, 0.1)]

    [InlineData(-10.0, 2.0, 10.0)]
    [InlineData(-10.0, -1.0, 0.0)]
    public void BounceminBounceThresholdTest(double vOld, double bounciness, double expected) => Assert.Equal(expected, PhysicsGm.Bounce(vOld, bounciness), 5);
    [Theory]
    [InlineData(3.0, 5.0, 3.0)]
    [InlineData(-3.0, 5.0, -3.0)]

    [InlineData(12.5, 5.0, 5.0)]
    [InlineData(-12.5, 5.0, -5.0)]

    [InlineData(10.0, -5.0, 5.0)]

    [InlineData(4.2, 0.0, 0.0)]
    public void ClampVelocityTest(double v, double max, double expected) => Assert.Equal(expected, PhysicsGm.ClampVelocity(v, max), 5);
    [Theory]
    [InlineData(10.0, 5.0, 4.0, 2.0, 20.0)]

    [InlineData(15.0, -3.0, 2.0, 1.0, 9.0)]

    [InlineData(5.5, 100.0, 1.0, 0.0, 5.5)]
    [InlineData(5.5, 100.0, 1.0, 0.0000005, 5.5)]

    [InlineData(4.0, 50.0, 2.0, 0.000001, 4.0)]
    public void AddForceTest(double v, double F, double t, double m, double expected) => Assert.Equal(expected, PhysicsGm.AddForce(v, F, t, m), 5);
    [Theory]
    [InlineData(0.0, 10.0, 2.0, 5.0)]

    [InlineData(15.0, -20.0, 4.0, 10.0)]

    [InlineData(4.2, 500.0, 0.0, 4.2)]
    [InlineData(4.2, 500.0, 0.0000005, 4.2)]

    [InlineData(7.0, 100.0, 0.000001, 7.0)]
    public void AddImpulseTest(double vOld, double J, double m, double expected) => Assert.Equal(expected, PhysicsGm.AddImpulse(vOld, J, m), 5);
    [Theory]
    [InlineData(10.0, 0.5, 5.0)]

    [InlineData(-10.0, 0.5, -10.0)]

    [InlineData(0.0, 0.5, 0.0)]

    [InlineData(15.0, 0.0, 0.0)]
    public void JumpCutTest(double v, double multiplier, double expected) => Assert.Equal(expected, PhysicsGm.JumpCut(v, multiplier), 5);
    [Theory]
    [InlineData(-50.0, 30.0, -30.0)]

    [InlineData(-15.0, 30.0, -15.0)]
    [InlineData(0.0, 30.0, 0.0)]

    [InlineData(25.0, 30.0, 25.0)]

    [InlineData(-40.0, -30.0, -30.0)]
    public void TerminalVelocityTest(double v, double vlimit, double expected) => Assert.Equal(expected, PhysicsGm.TerminalVelocity(v, vlimit), 5);
    [Theory]
    [InlineData(10.0f, -5.0f, 20.0f, 2.0f, 0.016f, 9.685066f, -4.842533f, 19.370132f)]
    [InlineData(0.0f, 0.0f, 0.0f, 5.0f, 0.016f, 0.0f, 0.0f, 0.0f)]
    [InlineData(3.0f, 4.0f, 5.0f, 0.0f, 0.016f, 3.0f, 4.0f, 5.0f)]
    public void DragTest(float vX, float vY, float vZ, float drag, float deltaTime, float eX, float eY, float eZ)
    {
        Vector3 velocity = new(vX, vY, vZ);

        Vector3 actual = PhysicsGm.Drag(velocity, drag, deltaTime);

        Assert.Equal(eX, actual.X, 4);
        Assert.Equal(eY, actual.Y, 4);
        Assert.Equal(eZ, actual.Z, 4);
    }
    [Theory]
    [InlineData(2.0, -9.81, 6.26418)]

    [InlineData(5.0, -1.62, 4.02492)]

    [InlineData(0.0, -9.81, 0.0)]

    [InlineData(2.0, 9.81, 6.26418)]
    public void CalculateJumpVelocityTest(double h, double g, double expected) => Assert.Equal(expected, PhysicsGm.CalculateJumpVelocity(h, g), 5);
    [Theory]
    [InlineData(20.0, 4.0, 50.0)]

    [InlineData(-10.0, 2.0, 25.0)]

    [InlineData(10.0, -5.0, 10.0)]

    [InlineData(15.0, 0.0, 0.0)]
    public void GetStoppingDistanceTest(double v, double a, double expected) => Assert.Equal(expected, PhysicsGm.GetStoppingDistance(v, a), 5);
    [Theory]
    [InlineData(20.0, 0.01, 0.016, 19.9362)]

    [InlineData(-20.0, 0.01, 0.016, -19.9362)]

    [InlineData(100.0, 0.1, 0.2, 33.33333333)]

    [InlineData(0.0, 0.5, 0.016, 0.0)]
    public void ApplyQuadraticDragTest(double v, double k, double t, double expected) => Assert.Equal(expected, PhysicsGm.ApplyQuadraticDrag(v, k, t), 5);
    [Theory]
    [InlineData(10.0, 0.0, -9.81, 1.0, 14.905)]

    [InlineData(10.0, 50.0, -10.0, 2.0, -10.0)]

    [InlineData(30.0, 0.0, 0.0, 1.5, 20.0)]

    [InlineData(10.0, 0.0, -9.81, 0.0, 0.0)]
    public void CalculateLaunchVelocityTest(double target, double start, double g, double t, double expected) => Assert.Equal(expected, PhysicsGm.CalculateLaunchVelocity(target, start, g, t), 5);
    [Theory]
    [InlineData(0.0f, 0.0f, 10.0f, 15.0f, 0.0f, -9.81f, 2.0f, 20.0f, 10.38f)]

    [InlineData(10.0f, 20.0f, -5.0f, 0.0f, 2.0f, -5.0f, 3.0f, 4.0f, -2.5f)]
    public void PredictTrajectoryTest(float startPosX, float startPosY, float startVelocityX, float startVelocityY, float gravityX, float gravityY, float t, float expectedX, float expectedY)
    {
        Vector2 startPos = new(startPosX, startPosY);
        Vector2 startVelocity = new(startVelocityX, startVelocityY);
        Vector2 gravity = new(gravityX, gravityY);
        Vector2 actual = PhysicsGm.PredictTrajectory(startPos, startVelocity, gravity, t);
        Assert.Equal(expectedX, actual.X, 4);
        Assert.Equal(expectedY, actual.Y, 4);
    }
}