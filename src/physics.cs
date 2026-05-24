namespace Gamem;

public static class Physics
{
    public static double ApplyGravity(double velocity, double gravity, double deltaTime) => velocity + gravity * deltaTime;
    public static float ApplyGravity(float velocity, float gravity, float deltaTime) => velocity + gravity * deltaTime;
    public static double ApplyFriction(double velocity, double frictionCoeff, double deltaTime)
    {
        if (velocity == 0)
            return 0.0;
        double reduction = frictionCoeff * deltaTime;
        if (Math.Abs(velocity) <= reduction)
            return 0.0;
        return velocity - Math.Sign(velocity) * reduction;
    }
    public static double MoveTowards(double current, double target, double maxDelta)
    {
        double dist = target - current;
        if (Math.Abs(dist) <= maxDelta)
            return target;
        return current + Math.Sign(dist) * maxDelta;
    }
}