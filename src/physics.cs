namespace Gamem;

public static class Physics
{
    public static double ApplyGravity(double velocity, double gravity, double deltaTime) => velocity + gravity * deltaTime;
    public static float ApplyGravity(float velocity, float gravity, float deltaTime) => velocity + gravity * deltaTime;
    public static double ApplyFriction(double velocity, double friction, double deltaTime)
    {
        double v = friction * Math.Abs(velocity) * deltaTime;
        if (v >= Math.Abs(velocity))
            return 0.0f;
        return velocity - Math.Sign(velocity) * v;
    }
    public static double MoveTowards(double current, double target, double maxDelta)
    {
        double dist = target - current;
        if (Math.Abs(dist) <= maxDelta)
            return target;
        return current + Math.Sign(dist) * maxDelta;
    }
}