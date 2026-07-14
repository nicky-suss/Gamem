using System;
using System.Runtime.CompilerServices;
using System.Numerics;

namespace Gamem;

/// <summary>
/// Provides static mathematical methods for basic physics calculations like gravity, friction, and movement interpolation.
/// </summary>
public static partial class PhysicsGm
{

    //! ====================================
    //! THIS PART OF THE CODE SUPPORTS .NET 8, 9, 10 AND MORE
    //! ====================================

    /// <summary>
    /// Applies gravity to the current vertical velocity over a specified time step.
    /// </summary>
    /// <typeparam name="T">A floating-point type that implements <see cref="IFloatingPointIeee754{T}"/>.</typeparam>
    /// <param name="velocity">The current velocity.</param>
    /// <param name="gravity">The acceleration due to gravity.</param>
    /// <param name="deltaTime">The time elapsed since the last frame in seconds.</param>
    /// <returns>The updated velocity after applying gravity.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T ApplyGravity<T>(T velocity, T gravity, T deltaTime) where T : IFloatingPointIeee754<T> => velocity + gravity * deltaTime;
    /// <summary>
    /// Applies friction to reduce velocity towards zero over a specified time step.
    /// </summary>
    /// <typeparam name="T">A floating-point type that implements <see cref="IFloatingPointIeee754{T}"/>.</typeparam>
    /// <param name="velocity">The current velocity.</param>
    /// <param name="frictionCoeff">The friction coefficient representing deceleration per second.</param>
    /// <param name="deltaTime">The time elapsed since the last frame in seconds.</param>
    /// <returns>The updated velocity after friction is applied, clamping to 0.0 if it changes direction.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T ApplyFriction<T>(T velocity, T frictionCoeff, T deltaTime) where T : IFloatingPointIeee754<T>
    {
        if (T.Abs(velocity) <= T.CreateChecked(1e-6))
            return T.Zero;
        T frictionCoeffAbs = T.Abs(frictionCoeff);
        T reduction = frictionCoeffAbs * T.Abs(deltaTime);
        if (T.Abs(velocity) <= reduction)
            return T.Zero;
        return velocity - T.CopySign(T.One, velocity) * reduction;
    }
    /// <summary>
    /// Moves a value toward a target value by a maximum specified delta.
    /// </summary>
    /// <typeparam name="T">A floating-point type that implements <see cref="IFloatingPointIeee754{T}"/>.</typeparam>
    /// <param name="current">The current value.</param>
    /// <param name="target">The value to move towards.</param>
    /// <param name="maxDelta">The maximum amount by which the value can change.</param>
    /// <returns>The new value closer to the target, or the target itself if it is within range.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T MoveTowards<T>(T current, T target, T maxDelta) where T : IFloatingPointIeee754<T>
    {
        if (maxDelta <= T.Zero) return current;
        T dist = target - current;
        if (T.Abs(dist) <= maxDelta)
            return target;
        return current + T.CopySign(T.One, dist) * maxDelta;
    }
    /// <summary>
    /// Calculates the velocity after a bounce collision, reversing direction and applying a coefficient of restitution.
    /// </summary>
    /// <typeparam name="T">A floating-point type that implements <see cref="IFloatingPointIeee754{T}"/>.</typeparam>
    /// <param name="vOld">The pre-collision velocity.</param>
    /// <param name="bounciness">The bounciness coefficient (restitution), clamped between 0.0 and 1.0.</param>
    /// <param name="minBounceThreshold">The minimum velocity required to sustain a bounce. Below this magnitude, the velocity is clamped to zero to prevent endless micro-bouncing.</param>
    /// <returns>The updated velocity after the bounce, or 0.0 if the resulting speed falls below the threshold.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T Bounce<T>(T vOld, T bounciness, T minBounceThreshold) where T : IFloatingPointIeee754<T>
    {
        T vNew = -vOld * T.Clamp(bounciness, T.Zero, T.One);
        if (T.Abs(vNew) < minBounceThreshold)
            vNew = T.Zero;
        return vNew;
    }
    /// <summary>
    /// Calculates the velocity after a bounce collision, reversing direction and applying a coefficient of restitution.
    /// </summary>
    /// <typeparam name="T">A floating-point type that implements <see cref="IFloatingPointIeee754{T}"/>.</typeparam>
    /// <param name="vOld">The pre-collision velocity.</param>
    /// <param name="bounciness">The bounciness coefficient (restitution), clamped between 0.0 and 1.0.</param>
    /// <returns>The updated velocity after the bounce, or 0.0 if the resulting speed falls below the threshold.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T Bounce<T>(T vOld, T bounciness) where T : IFloatingPointIeee754<T>
    {
        T minBounceThreshold = T.CreateChecked(0.1);
        return Bounce(vOld, bounciness, minBounceThreshold);
    }
    /// <summary>
    /// Clamps a velocity value to be within a symmetric range defined by a maximum speed limit.
    /// </summary>
    /// <typeparam name="T">A floating-point type that implements <see cref="IFloatingPointIeee754{T}"/>.</typeparam>
    /// <param name="v">The current velocity to clamp.</param>
    /// <param name="max">The maximum allowed speed (magnitude), which will be used to define both upper and lower bounds.</param>
    /// <returns>The clamped velocity, constrained between -abs(max) and abs(max).</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T ClampVelocity<T>(T v, T max) where T : IFloatingPointIeee754<T>
    {
        T limit = T.Abs(max);
        return T.Clamp(v, -limit, limit);
    }
    /// <summary>
    /// Applies a continuous force over a specified time duration to update the velocity, based on Newton's second law.
    /// </summary>
    /// <typeparam name="T">A floating-point type that implements <see cref="IFloatingPointIeee754{T}"/>.</typeparam>
    /// <param name="v">The initial velocity before the force is applied.</param>
    /// <param name="F">The force magnitude.</param>
    /// <param name="t">The duration of time over which the force acts.</param>
    /// <param name="m">The mass of the object. If mass is 0, the velocity remains unchanged to avoid division by zero.</param>
    /// <returns>The updated velocity after applying the force.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T AddForce<T>(T v, T F, T t, T m) where T : IFloatingPointIeee754<T> => m <= T.CreateChecked(1e-6) ? v : v + (F * t / m);
    /// <summary>
    /// Applies an instantaneous impulse to update the velocity.
    /// </summary>
    /// <typeparam name="T">A floating-point type that implements <see cref="IFloatingPointIeee754{T}"/>.</typeparam>
    /// <param name="vOld">The pre-impulse velocity.</param>
    /// <param name="J">The impulse magnitude (change in momentum).</param>
    /// <param name="m">The mass of the object. If mass is 0, the velocity remains unchanged to avoid division by zero.</param>
    /// <returns>The updated velocity after the impulse is applied.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T AddImpulse<T>(T vOld, T J, T m) where T : IFloatingPointIeee754<T> => m <= T.CreateChecked(1e-6) ? vOld : vOld + (J / m);
    /// <summary>
    /// Reduces upward velocity when a jump button is released early, commonly used for variable jump heights in platformers.
    /// </summary>
    /// <typeparam name="T">A floating-point type that implements <see cref="IFloatingPointIeee754{T}"/>.</typeparam>
    /// <param name="v">The current vertical velocity (positive = upward).</param>
    /// <param name="multiplier">The factor by which to multiply the velocity (usually between 0.0 and 1.0).</param>
    /// <returns>The modified velocity if moving upward (greater than 0), otherwise the original velocity.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T JumpCut<T>(T v, T multiplier) where T : IFloatingPointIeee754<T> => v > T.Zero ? v * multiplier : v;
    /// <summary>
    /// Caps falling velocity to prevent an object from exceeding a maximum downward terminal velocity limit.
    /// </summary>
    /// <typeparam name="T">A floating-point type that implements <see cref="IFloatingPointIeee754{T}"/>.</typeparam>
    /// <param name="v">The current vertical velocity (negative values represent falling).</param>
    /// <param name="vlimit">The maximum allowed falling speed magnitude (should be positive).</param>
    /// <returns>The clamped velocity, restricted so that it does not drop below -vlimit.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T TerminalVelocity<T>(T v, T vlimit) where T : IFloatingPointIeee754<T> => v < -T.Abs(vlimit) ? -T.Abs(vlimit) : v;
    /// <summary>
    /// Applies linear drag to a 3D velocity vector over a given time step, stopping the object completely if its speed drops below a small threshold.
    /// </summary>
    /// <param name="velocity">The current velocity vector.</param>
    /// <param name="drag">The drag coefficient (typically negative to slow the object down, or positive depending on the expected math convention).</param>
    /// <param name="deltaTime">The time elapsed since the last frame in seconds.</param>
    /// <returns>The updated velocity vector after drag has been applied, or <see cref="Vector3.Zero"/> if the squared velocity is below 0.0001f.</returns>
    public static Vector3 Drag(Vector3 velocity, float drag, float deltaTime)
    {
        velocity *= MathF.Exp(drag * deltaTime);

        if (velocity.LengthSquared() < 0.0001f)
            return Vector3.Zero;

        return velocity;
    }
    /// <summary>
    /// Calculates the initial upward velocity required to reach a specific jump height under a given gravity.
    /// </summary>
    /// <typeparam name="T">A floating-point type that implements <see cref="IFloatingPointIeee754{T}"/>.</typeparam>
    /// <param name="h">The target maximum jump height.</param>
    /// <param name="g">The gravity value. Its absolute value is used to ensure mathematical stability.</param>
    /// <returns>The calculated initial jump velocity required to reach the target height.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T CalculateJumpVelocity<T>(T h, T g) where T : IFloatingPointIeee754<T> => T.Sqrt(T.CreateChecked(2) * T.Abs(g) * h);
}