using System;
using System.Runtime.CompilerServices;
using System.Numerics;

namespace Gamem
{
    /// <summary>
    /// Provides static mathematical methods for basic physics calculations like gravity, friction, and movement interpolation.
    /// </summary>
    public static partial class PhysicsGm
    {

        //! ========================
        //! THIS PART OF THE CODE SUPPORTS OLDER VERSIONS OF .NET
        //! =========================

        /// <summary>
        /// Applies gravity to the current vertical velocity over a specified time step.
        /// </summary>
        /// <param name="velocity">The current velocity.</param>
        /// <param name="gravity">The acceleration due to gravity.</param>
        /// <param name="deltaTime">The time elapsed since the last frame in seconds.</param>
        /// <returns>The updated velocity after applying gravity.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ApplyGravity(double velocity, double gravity, double deltaTime) => velocity + gravity * deltaTime;
        /// <inheritdoc cref="ApplyGravity(double, double, double)"/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ApplyGravity(float velocity, float gravity, float deltaTime) => velocity + gravity * deltaTime;
        /// <summary>
        /// Applies friction to reduce velocity towards zero over a specified time step.
        /// </summary>
        /// <param name="velocity">The current velocity.</param>
        /// <param name="frictionCoeff">The friction coefficient representing deceleration per second.</param>
        /// <param name="deltaTime">The time elapsed since the last frame in seconds.</param>
        /// <returns>The updated velocity after friction is applied, clamping to 0.0 if it changes direction.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ApplyFriction(double velocity, double frictionCoeff, double deltaTime)
        {
            if (Math.Abs(velocity) <= 1e-6)
                return 0.0;
            double frictionCoeffAbs = Math.Abs(frictionCoeff);
            double reduction = frictionCoeffAbs * Math.Abs(deltaTime);
            if (Math.Abs(velocity) <= reduction)
                return 0.0;
            return velocity - Math.Sign(velocity) * reduction;
        }
        /// <inheritdoc cref="ApplyFriction(double, double, double)"/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ApplyFriction(float velocity, float frictionCoeff, float deltaTime)
        {
            if (Math.Abs(velocity) <= 1e-6)
                return 0.0f;
            float frictionCoeffAbs = Math.Abs(frictionCoeff);
            float reduction = frictionCoeffAbs * Math.Abs(deltaTime);
            if (Math.Abs(velocity) <= reduction)
                return 0.0f;
            return velocity - Math.Sign(velocity) * reduction;
        }
        /// <summary>
        /// Moves a value toward a target value by a maximum specified delta.
        /// </summary>
        /// <param name="current">The current value.</param>
        /// <param name="target">The value to move towards.</param>
        /// <param name="maxDelta">The maximum amount by which the value can change.</param>
        /// <returns>The new value closer to the target, or the target itself if it is within range.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double MoveTowards(double current, double target, double maxDelta)
        {
            if (maxDelta <= 0.0) return current;

            double dist = target - current;
            if (Math.Abs(dist) <= maxDelta)
                return target;
            return current + Math.Sign(dist) * maxDelta;
        }
        /// <inheritdoc cref="MoveTowards(double, double, double)"/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float MoveTowards(float current, float target, float maxDelta)
        {
            if (maxDelta <= 0.0f) return current;

            float dist = target - current;
            if (Math.Abs(dist) <= maxDelta)
                return target;
            return current + Math.Sign(dist) * maxDelta;
        }
        /// <summary>
        /// Calculates the velocity after a bounce collision, reversing direction and applying a coefficient of restitution.
        /// </summary>
        /// <param name="vOld">The pre-collision velocity.</param>
        /// <param name="bounciness">The bounciness coefficient (restitution), clamped between 0.0 and 1.0.</param>
        /// <param name="minBounceThreshold">The minimum velocity required to sustain a bounce. Below this magnitude, the velocity is clamped to zero to prevent endless micro-bouncing.</param>
        /// <returns>The updated velocity after the bounce, or 0.0 if the resulting speed falls below the threshold.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Bounce(double vOld, double bounciness, double minBounceThreshold = 0.1)
        {
            double vNew = -vOld * Math.Max(0.0, Math.Min(bounciness, 1.0));
            if (Math.Abs(vNew) < minBounceThreshold)
                vNew = 0.0;
            return vNew;
        }
        /// <inheritdoc cref="Bounce(double, double, double)"/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Bounce(float vOld, float bounciness, float minBounceThreshold = 0.1f)
        {
            float vNew = -vOld * Math.Max(0.0f, Math.Min(bounciness, 1.0f));
            if (Math.Abs(vNew) < minBounceThreshold)
                vNew = 0.0f;
            return vNew;
        }
        /// <summary>
        /// Clamps a velocity value to be within a symmetric range defined by a maximum speed limit.
        /// </summary>
        /// <param name="v">The current velocity to clamp.</param>
        /// <param name="max">The maximum allowed speed (magnitude), which will be used to define both upper and lower bounds.</param>
        /// <returns>The clamped velocity, constrained between -abs(max) and abs(max).</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ClampVelocity(double v, double max)
        {
            double limit = Math.Abs(max);
            return Math.Max(-limit, Math.Min(v, limit));
        }
        /// <inheritdoc cref="ClampVelocity(double, double)"/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ClampVelocity(float v, float max)
        {
            float limit = Math.Abs(max);
            return Math.Max(-limit, Math.Min(v, limit));
        }
        /// <summary>
        /// Applies a continuous force over a specified time duration to update the velocity, based on Newton's second law.
        /// </summary>
        /// <param name="v">The initial velocity before the force is applied.</param>
        /// <param name="F">The force magnitude.</param>
        /// <param name="t">The duration of time over which the force acts.</param>
        /// <param name="m">The mass of the object. If mass is 0, the velocity remains unchanged to avoid division by zero.</param>
        /// <returns>The updated velocity after applying the force.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double AddForce(double v, double F, double t, double m) => m <= 1e-6 ? v : v + (F * t / m);
        /// <inheritdoc cref="AddForce(double, double, double, double)"/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float AddForce(float v, float F, float t, float m) => m <= 1e-6 ? v : v + (F * t / m);
        /// <summary>
        /// Applies an instantaneous impulse to update the velocity.
        /// </summary>
        /// <param name="vOld">The pre-impulse velocity.</param>
        /// <param name="J">The impulse magnitude (change in momentum).</param>
        /// <param name="m">The mass of the object. If mass is 0, the velocity remains unchanged to avoid division by zero.</param>
        /// <returns>The updated velocity after the impulse is applied.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double AddImpulse(double vOld, double J, double m) => m <= 1e-6 ? vOld : vOld + (J / m);
        /// <inheritdoc cref="AddImpulse(double, double, double)"/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float AddImpulse(float vOld, float J, float m) => m <= 1e-6f ? vOld : vOld + (J / m);
        /// <summary>
        /// Reduces upward velocity when a jump button is released early, commonly used for variable jump heights in platformers.
        /// </summary>
        /// <param name="v">The current vertical velocity.</param>
        /// <param name="multiplier">The factor by which to multiply the velocity (usually between 0.0 and 1.0).</param>
        /// <returns>The modified velocity if moving upward (greater than 0), otherwise the original velocity.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double JumpCut(double v, double multiplier) => v > 0.0 ? v * multiplier : v;
        /// <inheritdoc cref="JumpCut(double, double)"/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float JumpCut(float v, float multiplier) => v > 0.0f ? v * multiplier : v;
        /// <summary>
        /// Caps falling velocity to prevent an object from exceeding a maximum downward terminal velocity limit.
        /// </summary>
        /// <param name="v">The current vertical velocity (negative values represent falling).</param>
        /// <param name="vlimit">The maximum allowed falling speed magnitude (should be positive).</param>
        /// <returns>The clamped velocity, restricted so that it does not drop below -vlimit.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double TerminalVelocity(double v, double vlimit) => v < -Math.Abs(vlimit) ? -Math.Abs(vlimit) : v;
        /// <inheritdoc cref="TerminalVelocity(double, double)"/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float TerminalVelocity(float v, float vlimit) => v < -Math.Abs(vlimit) ? -Math.Abs(vlimit) : v;
        /// <summary>
        /// Applies linear drag to a 3D velocity vector over a given time step, stopping the object completely if its speed drops below a small threshold.
        /// </summary>
        /// <param name="velocity">The current velocity vector.</param>
        /// <param name="drag">The drag coefficient (typically negative to slow the object down, or positive depending on the expected math convention).</param>
        /// <param name="deltaTime">The time elapsed since the last frame in seconds.</param>
        /// <returns>The updated velocity vector after drag has been applied, or <see cref="Vector3.Zero"/> if the squared velocity is below 0.0001f.</returns>
        public static Vector3 Drag(Vector3 velocity, float drag, float deltaTime)
        {
            velocity *= (float)Math.Exp(drag * deltaTime);

            if (velocity.LengthSquared() < 0.0001f)
                return Vector3.Zero;

            return velocity;
        }
        /// <summary>
        /// Calculates the initial upward velocity required to reach a specific jump height under a given gravity.
        /// </summary>
        /// <param name="h">The target maximum jump height.</param>
        /// <param name="g">The gravity value. Its absolute value is used to ensure mathematical stability.</param>
        /// <returns>The calculated initial jump velocity required to reach the target height.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double CalculateJumpVelocity(double h, double g) => Math.Sqrt(2.0 * Math.Abs(g) * h);
        /// <summary>
        /// Calculates the initial upward velocity required to reach a specific jump height under a given gravity.
        /// </summary>
        /// <param name="h">The target maximum jump height.</param>
        /// <param name="g">The gravity value. Its absolute value is used to ensure mathematical stability.</param>
        /// <returns>The calculated initial jump velocity required to reach the target height.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float CalculateJumpVelocity(float h, float g) => (float)Math.Sqrt(2.0f * Math.Abs(g) * h);
    }
}