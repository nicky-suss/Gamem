namespace Gamem;

/// <summary>
/// Provides static mathematical methods for basic physics calculations like gravity, friction, and movement interpolation.
/// </summary>
public static class Physics
{
    /// <summary>
    /// Applies gravity to the current vertical velocity over a specified time step.
    /// </summary>
    /// <param name="velocity">The current velocity.</param>
    /// <param name="gravity">The acceleration due to gravity.</param>
    /// <param name="deltaTime">The time elapsed since the last frame in seconds.</param>
    /// <returns>The updated velocity after applying gravity.</returns>
    public static double ApplyGravity(double velocity, double gravity, double deltaTime) => velocity + gravity * deltaTime;
    /// <summary>
    /// Applies gravity to the current vertical velocity over a specified time step.
    /// </summary>
    /// <param name="velocity">The current velocity.</param>
    /// <param name="gravity">The acceleration due to gravity.</param>
    /// <param name="deltaTime">The time elapsed since the last frame in seconds.</param>
    /// <returns>The updated velocity after applying gravity.</returns>
    public static float ApplyGravity(float velocity, float gravity, float deltaTime) => velocity + gravity * deltaTime;
    /// <summary>
    /// Applies friction to reduce velocity towards zero over a specified time step.
    /// </summary>
    /// <param name="velocity">The current velocity.</param>
    /// <param name="frictionCoeff">The friction coefficient representing deceleration per second.</param>
    /// <param name="deltaTime">The time elapsed since the last frame in seconds.</param>
    /// <returns>The updated velocity after friction is applied, clamping to 0.0 if it changes direction.</returns>
    public static double ApplyFriction(double velocity, double frictionCoeff, double deltaTime)
    {
        if (velocity == 0)
            return 0.0;
        double frictionCoeffAbs = Math.Abs(frictionCoeff);
        double reduction = frictionCoeffAbs * deltaTime;
        if (Math.Abs(velocity) <= reduction)
            return 0.0;
        return velocity - Math.Sign(velocity) * reduction;
    }
    /// <summary>
    /// Applies friction to reduce velocity towards zero over a specified time step.
    /// </summary>
    /// <param name="velocity">The current velocity.</param>
    /// <param name="frictionCoeff">The friction coefficient representing deceleration per second.</param>
    /// <param name="deltaTime">The time elapsed since the last frame in seconds.</param>
    /// <returns>The updated velocity after friction is applied, clamping to 0.0f if it changes direction.</returns>
    public static float ApplyFriction(float velocity, float frictionCoeff, float deltaTime)
    {
        if (velocity == 0)
            return 0.0f;
        float frictionCoeffAbs = Math.Abs(frictionCoeff);
        float reduction = frictionCoeffAbs * deltaTime;
        if (MathF.Abs(velocity) <= reduction)
            return 0.0f;
        return velocity - MathF.Sign(velocity) * reduction;
    }
    /// <summary>
    /// Moves a value toward a target value by a maximum specified delta.
    /// </summary>
    /// <param name="current">The current value.</param>
    /// <param name="target">The value to move towards.</param>
    /// <param name="maxDelta">The maximum amount by which the value can change.</param>
    /// <returns>The new value closer to the target, or the target itself if it is within range.</returns>
    public static double MoveTowards(double current, double target, double maxDelta)
    {
        if (maxDelta <= 0.0) return current;

        double dist = target - current;
        if (Math.Abs(dist) <= maxDelta)
            return target;
        return current + Math.Sign(dist) * maxDelta;
    }
    /// <summary>
    /// Moves a value toward a target value by a maximum specified delta.
    /// </summary>
    /// <param name="current">The current value.</param>
    /// <param name="target">The value to move towards.</param>
    /// <param name="maxDelta">The maximum amount by which the value can change.</param>
    /// <returns>The new value closer to the target, or the target itself if it is within range.</returns>
    public static float MoveTowards(float current, float target, float maxDelta)
    {
        if (maxDelta <= 0.0f) return current;

        float dist = target - current;
        if (MathF.Abs(dist) <= maxDelta)
            return target;
        return current + MathF.Sign(dist) * maxDelta;
    }
}