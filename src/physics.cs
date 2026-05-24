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
    public static float ApplyFriction(float velocity, float frictionCoeff, float deltaTime)
    {
        if (velocity == 0)
            return 0.0f;
        float reduction = frictionCoeff * deltaTime;
        if (MathF.Abs(velocity) <= reduction)
            return 0.0f;
        return velocity - MathF.Sign(velocity) * reduction;
    }
    public static double MoveTowards(double current, double target, double maxDelta)
    {
        if (maxDelta <= 0.0) return current;

        double dist = target - current;
        if (Math.Abs(dist) <= maxDelta)
            return target;
        return current + Math.Sign(dist) * maxDelta;
    }
    public static float MoveTowards(float current, float target, float maxDelta)
    {
        if (maxDelta <= 0.0f) return current;

        float dist = target - current;
        if (MathF.Abs(dist) <= maxDelta)
            return target;
        return current + MathF.Sign(dist) * maxDelta;
    }
}