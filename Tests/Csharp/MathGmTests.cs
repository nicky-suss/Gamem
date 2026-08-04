using Gamem;
using Xunit;

namespace Gamem.Tests;

public class MathGmTests
{
    [Theory]
    [InlineData(10.0, 20.0, 0.0, 10.0)]
    [InlineData(10.0, 20.0, -5.5, 10.0)]
    [InlineData(10.0, 20.0, 1.0, 20.0)]
    [InlineData(10.0, 20.0, 99.0, 20.0)]
    public void SmoothStepTest(double start, double end, double t, double expected) => Assert.Equal(expected, MathGm.SmoothStep(start, end, t), 5);
    [Theory]
    [InlineData(10.0, 20.0, 0.0, 10.0)]
    [InlineData(10.0, 20.0, 0.25, 12.5)]
    [InlineData(10.0, 20.0, 0.5, 15.0)]
    [InlineData(10.0, 20.0, 0.75, 17.5)]
    [InlineData(10.0, 20.0, 1.0, 20.0)]
    [InlineData(100.0, 0.0, 0.25, 75.0)]
    public void LerpTest(double start, double end, double t, double expected) => Assert.Equal(expected, MathGm.Lerp(start, end, t), 5);
    [Theory]
    [InlineData(10.0, 20.0, -0.5, 5.0)]
    [InlineData(10.0, 20.0, -1.0, 0.0)]
    [InlineData(10.0, 20.0, 1.5, 25.0)]
    [InlineData(10.0, 20.0, 2.0, 30.0)]

    [InlineData(10.0, 20.0, 0.0, 10.0)]
    [InlineData(10.0, 20.0, 0.5, 15.0)]
    [InlineData(10.0, 20.0, 1.0, 20.0)]

    [InlineData(100.0, 0.0, -0.5, 150.0)]
    [InlineData(100.0, 0.0, 1.5, -50.0)]
    public void LerpUnclampedTest(double start, double end, double t, double expected) => Assert.Equal(expected, MathGm.LerpUnclamped(start, end, t), 5);
    [Theory]
    [InlineData(10.0, 10.0, 20.0, 0.0)]
    [InlineData(12.5, 10.0, 20.0, 0.25)]
    [InlineData(15.0, 10.0, 20.0, 0.5)]
    [InlineData(17.5, 10.0, 20.0, 0.75)]
    [InlineData(20.0, 10.0, 20.0, 1.0)]

    [InlineData(5.0, 10.0, 20.0, 0.0)]
    [InlineData(99.0, 10.0, 20.0, 1.0)]

    [InlineData(45.0, 50.0, 30.0, 0.25)]
    [InlineData(60.0, 50.0, 30.0, 0.0)]

    [InlineData(10.0, 10.0, 10.0, 0.0)]
    [InlineData(10.0, 10.0, 10.000009, 0.0)]
    public void InverseLerpTest(double value, double start, double end, double expected) => Assert.Equal(expected, MathGm.InverseLerp(value, start, end), 5);
    [Theory]
    [InlineData(10.0, 50.0, 0.5, 1.0, 30.0)]
    [InlineData(10.0, 50.0, 2.0, 0.1, 18.0)]
    [InlineData(10.0, 50.0, 0.0, 5.0, 10.0)]

    [InlineData(100.0, 20.0, 0.25, 2.0, 60.0)]

    [InlineData(10.0, 50.0, 2.0, 1.0, 90.0)]
    [InlineData(10.0, 50.0, -0.5, 1.0, -10.0)]
    public void AccelerateTest(double Vcurrent, double Vtarget, double a, double t, double expected) => Assert.Equal(expected, MathGm.Accelerate(Vcurrent, Vtarget, a, t), 5);
    [Theory]
    [InlineData(100.0, 0.0, 0.0, 200.0, 10.0, 100.0)]
    [InlineData(100.0, 5.0, 0.0, 200.0, 10.0, 150.0)]
    [InlineData(100.0, 10.0, 0.0, 200.0, 10.0, 200.0)]

    [InlineData(100.0, -2.0, 0.0, 200.0, 10.0, 80.0)]
    [InlineData(100.0, 12.0, 0.0, 200.0, 10.0, 220.0)]

    [InlineData(50.0, 5.0, 0.0, 0.0, 10.0, 25.0)]

    [InlineData(100.0, 5.0, 10.0, 200.0, 10.000009, 0.0)]
    public void MapTest(double toMin, double v, double fromMin, double toMax, double fromMax, double expected) => Assert.Equal(expected, MathGm.Map(toMin, v, fromMin, toMax, fromMax), 5);
    [Theory]
    [InlineData(10.0, 20.0, 2.0, 1.0, 12.0)]

    [InlineData(20.0, 10.0, 3.0, 1.0, 17.0)]

    [InlineData(18.5, 20.0, 5.0, 1.0, 20.0)]

    [InlineData(15.0, 20.0, 5.0, 1.0, 20.0)]

    [InlineData(20.0, 20.0, 5.0, 1.0, 20.0)]

    [InlineData(10.0, 20.0, -2.0, 1.0, 8.0)]
    public void MoveTowardsTest(double current, double target, double speed, double dt, double expected) => Assert.Equal(expected, MathGm.MoveTowards(current, target, speed, dt), 5);
    [Theory]
    [InlineData(10.0, 2.0, 5.0)]
    [InlineData(10.0, 0.0, 0.0)]
    [InlineData(5.0, 0.000009, 0.0)]
    [InlineData(-10.0, -0.000009, 0.0)]
    public void SafeDivideGenericTest(double a, double b, double expected) => Assert.Equal(expected, MathGm.SafeDivide(a, b), 5);
    [Theory]
    [InlineData(10, 2, 0, 5)]
    [InlineData(10, 0, 0, 0)]
    [InlineData(10, 0, -999, -999)]
    [InlineData(5, 2, 0, 2)]
    public void SafeDivideIntTest(int a, int b, int fallback, int expected) => Assert.Equal(expected, MathGm.SafeDivide(a, b, fallback));
    [Theory]
    [InlineData(10.0, 4.0, -1.0, 2.5)]
    [InlineData(10.0, 0.0, -1.0, -1.0)]
    [InlineData(10.0, 0.000005, 99.0, 99.0)]
    public void SafeDivideGenericFallbackTest(double a, double b, double fallback, double expected) => Assert.Equal(expected, MathGm.SafeDivide(a, b, fallback), 5);
    [Theory]
    [InlineData(0.001, 0.001, true)]
    [InlineData(0.0, 0.00001, true)]
    [InlineData(0.000004, 0.000009, true)]
    [InlineData(0.0, 0.000011, false)]

    [InlineData(100000.0, 100001.0, true)]
    [InlineData(100000.0, 100002.0, false)]

    [InlineData(-10.0, -10.00005, true)]

    [InlineData(0.0, 1.0, false)]
    public void ApproximatelyTest(double a, double b, bool expected) => Assert.Equal(expected, MathGm.Approximately(a, b));
    [Theory]
    [InlineData(0.0, 1000.0, 0.0, 0.1, 10.0, 0.016, 4.64828, 0.04129)]
    public void SmoothDampTest(double current, double target, double currentVelocityStart, double smoothTime, double maxSpeed, double deltaTime, double currentVelocityChanged, double returned)
    {
        double currentVelocity = currentVelocityStart;

        double result = MathGm.SmoothDamp(current, target, ref currentVelocity, smoothTime, maxSpeed, deltaTime);

        Assert.Equal(returned, result, 4);
        Assert.Equal(currentVelocityChanged, currentVelocity, 4);
    }
    [Theory]
    [InlineData(350.0, 10.0, 0.0, 0.2, 0.016, -27.27467, 9.77414)]
    public void SmoothDampAngleTest(double current, double target, double currentVelocity, double smoothTime, double deltaTime, double velocityChanged, double returned)
    {
        double currentChanged = current;

        double currentVelocityChanged = currentVelocity;

        double result = MathGm.SmoothDampAngle(ref currentChanged, target, ref currentVelocityChanged, smoothTime, deltaTime);

        Assert.Equal(returned, result, 4);
        Assert.Equal(returned, currentChanged, 4);
        Assert.Equal(velocityChanged, currentVelocityChanged, 4);
    }
    [Theory]
    [InlineData(0.0, 10.0, 0.0)]
    [InlineData(5.0, 10.0, 5.0)]
    [InlineData(10.0, 10.0, 10.0)]

    [InlineData(12.0, 10.0, 8.0)]
    [InlineData(20.0, 10.0, 0.0)]

    [InlineData(-5.0, 10.0, 5.0)]
    [InlineData(-10.0, 10.0, 10.0)]

    [InlineData(5.0, 0.0, 0.0)]
    public void PingPongTest(double t, double length, double expected) => Assert.Equal(expected, MathGm.PingPong(t, length), 5);
    [Theory]
    [InlineData(350.0, 10.0, 0.0, 350.0)]
    [InlineData(350.0, 10.0, 0.5, 360.0)]
    [InlineData(350.0, 10.0, 0.75, 365.0)]
    [InlineData(350.0, 10.0, 1.0, 370.0)]

    [InlineData(10.0, 350.0, 0.5, 0.0)]
    [InlineData(10.0, 350.0, 1.0, -10.0)]

    [InlineData(90.0, 180.0, 0.5, 135.0)]

    [InlineData(90.0, 180.0, -2.0, 90.0)]
    [InlineData(90.0, 180.0, 5.0, 180.0)]
    public void LerpAngleTest(double start, double end, double t, double expected) => Assert.Equal(expected, MathGm.LerpAngle(start, end, t), 5);
    [Theory]
    [InlineData(0.0, 10.0, 0.0)]
    [InlineData(5.5, 10.0, 5.5)]
    [InlineData(9.99, 10.0, 9.99)]

    [InlineData(10.0, 10.0, 0.0)]
    [InlineData(13.5, 10.0, 3.5)]
    [InlineData(20.0, 10.0, 0.0)]

    [InlineData(-1.0, 10.0, 9.0)]
    [InlineData(-5.0, 10.0, 5.0)]
    [InlineData(-10.0, 10.0, 0.0)]

    [InlineData(5.0, 0.0, 0.0)]
    public void RepeatTest(double t, double length, double expected) => Assert.Equal(expected, MathGm.Repeat(t, length), 5);
}
