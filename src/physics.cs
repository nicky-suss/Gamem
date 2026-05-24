namespace Gamem;

public static class Physics
{
    public static double ApplyGravity(double velocity, double gravity, double deltaTime) => velocity + gravity * deltaTime;
}
