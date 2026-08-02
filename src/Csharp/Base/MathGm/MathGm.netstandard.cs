using System;
using System.Threading;
using System.Runtime.CompilerServices;
using System.Numerics;

namespace Gamem
{
    /// <summary>
    /// Provides general-purpose static mathematical functions including interpolation and random number generation.
    /// </summary>
    public static partial class MathGm
    {
        internal static class RandomSharedPolyfill
        {
            private static readonly ThreadLocal<Random> _localRandom = new ThreadLocal<Random>(() => new Random(Guid.NewGuid().GetHashCode()));
            public static Random Shared => _localRandom.Value;
        }

        //! ========================
        //! THIS PART OF THE CODE SUPPORTS OLDER VERSIONS OF .NET
        //! =========================

        /// <summary>
        /// Performs a smooth cubic interpolation between two values based on a given percentage.
        /// </summary>
        /// <param name="start">The start value.</param>
        /// <param name="end">The end value.</param>
        /// <param name="t">The interpolation value, clamped between 0.0 and 1.0.</param>
        /// <returns>The smoothly interpolated value between start and end.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double SmoothStep(double start, double end, double t)
        {
            double c = Math.Max(0.0, Math.Min(t, 1.0));
            double tt = c * c * (3 - 2 * c);
            return start + (end - start) * tt;
        }
        /// <inheritdoc cref="SmoothStep(double, double, double)"/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float SmoothStep(float start, float end, float t)
        {
            float c = Math.Max(0.0f, Math.Min(t, 1.0f));
            float tt = c * c * (3 - 2 * c);
            return start + (end - start) * tt;
        }
        /// <summary>
        /// Generates a random floating-point value within a specified inclusive range.
        /// </summary>
        /// <param name="min">The minimum bound of the range.</param>
        /// <param name="max">The maximum bound of the range.</param>
        /// <returns>A random value greater than or equal to min, and less than max.</returns>
        /// <exception cref="ArgumentException">Thrown when min is greater than max.</exception>
        public static double RandomRange(double min, double max)
        {
            if (min > max)
                throw new ArgumentException($"{nameof(min)} must be <= {nameof(max)}");
            double randomF = RandomSharedPolyfill.Shared.NextDouble();
            return min + (randomF * (max - min));
        }
        /// <inheritdoc cref="RandomRange(double, double)"/>
        public static float RandomRange(float min, float max)
        {
            if (min > max)
                throw new ArgumentException($"{nameof(min)} must be <= {nameof(max)}");
            float randomF = (float)RandomSharedPolyfill.Shared.NextDouble();
            return min + (randomF * (max - min));
        }
        /// <summary>
        /// Linearly interpolates between start and end values, clamping the interpolation percentage between 0.0 and 1.0.
        /// </summary>
        /// <param name="start">The start value.</param>
        /// <param name="end">The end value.</param>
        /// <param name="t">The interpolation value, clamped between 0.0 and 1.0.</param>
        /// <returns>The interpolated value between start and end.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Lerp(double start, double end, double t) => start + (end - start) * Math.Max(0.0, Math.Min(t, 1.0));
        /// <inheritdoc cref="Lerp(double, double, double)"/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Lerp(float start, float end, float t) => start + (end - start) * Math.Max(0.0f, Math.Min(t, 1.0f));
        /// <summary>
        /// Linearly interpolates between start and end values without clamping the interpolation percentage.
        /// </summary>
        /// <param name="start">The start value.</param>
        /// <param name="end">The end value.</param>
        /// <param name="t">The interpolation value, allowing extrapolation outside the start and end range.</param>
        /// <returns>The interpolated or extrapolated value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double LerpUnclamped(double start, double end, double t) => start + (end - start) * t;
        /// <inheritdoc cref="LerpUnclamped(double, double, double)"/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float LerpUnclamped(float start, float end, float t) => start + (end - start) * t;
        /// <summary>
        /// Calculates the linear parameter t that produces the given value within a specific range, clamped between 0.0 and 1.0.
        /// </summary>
        /// <param name="value">The value to find the interpolation factor for.</param>
        /// <param name="start">The start value of the range.</param>
        /// <param name="end">The end value of the range.</param>
        /// <returns>The normalized linear parameter t between 0.0 and 1.0, or 0.0 if the range is zero.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double InverseLerp(double value, double start, double end)
        {
            if (Math.Abs(end - start) <= 1e-5)
                return 0.0;
            return Math.Max(0.0, Math.Min((value - start) / (end - start), 1.0));
        }
        /// <inheritdoc cref="InverseLerp(double, double, double)"/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float InverseLerp(float value, float start, float end)
        {
            if (Math.Abs(end - start) <= 1e-5)
                return 0.0f;
            return Math.Max(0.0f, Math.Min((value - start) / (end - start), 1.0f));
        }
        /// <summary>
        /// Smoothly accelerates current velocity toward a target velocity using an acceleration rate over a given time step.
        /// </summary>
        /// <param name="Vcurrent">The current velocity.</param>
        /// <param name="Vtarget">The desired target velocity.</param>
        /// <param name="a">The acceleration rate multiplier.</param>
        /// <param name="t">The time elapsed since the last frame in seconds.</param>
        /// <returns>The updated velocity approaching the target value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Accelerate(double Vcurrent, double Vtarget, double a, double t) => Vcurrent + (Vtarget - Vcurrent) * (a * t);
        /// <inheritdoc cref="Accelerate(double, double, double, double)"/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Accelerate(float Vcurrent, float Vtarget, float a, float t) => Vcurrent + (Vtarget - Vcurrent) * (a * t);
        /// <summary>
        /// Maps a value from an input range to an output range without clamping.
        /// </summary>
        /// <param name="toMin">The lower bound of the output range.</param>
        /// <param name="v">The value to be mapped.</param>
        /// <param name="fromMin">The lower bound of the input range.</param>
        /// <param name="toMax">The upper bound of the output range.</param>
        /// <param name="fromMax">The upper bound of the input range.</param>
        /// <returns>The mapped value in the output range, or 0.0 if the input range size is zero.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Map(double toMin, double v, double fromMin, double toMax, double fromMax) => Math.Abs(fromMax - fromMin) <= 1e-6 ? 0.0 : toMin + (v - fromMin) * ((toMax - toMin) / (fromMax - fromMin));
        /// <inheritdoc cref="Map(double, double, double, double, double)"/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Map(float toMin, float v, float fromMin, float toMax, float fromMax) => Math.Abs(fromMax - fromMin) <= 1e-6 ? 0.0f : toMin + (v - fromMin) * ((toMax - toMin) / (fromMax - fromMin));
        /// <summary>
        /// Remaps a value from an input range to an output range, behaving identically to Map method.
        /// </summary>
        /// <param name="toMin">The lower bound of the output range.</param>
        /// <param name="v">The value to be remapped.</param>
        /// <param name="fromMin">The lower bound of the input range.</param>
        /// <param name="toMax">The upper bound of the output range.</param>
        /// <param name="fromMax">The upper bound of the input range.</param>
        /// <returns>The remapped value in the output range.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Remap(double toMin, double v, double fromMin, double toMax, double fromMax) => Map(toMin, v, fromMin, toMax, fromMax);
        /// <inheritdoc cref="Remap(double, double, double, double, double)"/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Remap(float toMin, float v, float fromMin, float toMax, float fromMax) => Map(toMin, v, fromMin, toMax, fromMax);
        /// <summary>
        /// Evaluates a percentage-based chance to determine a success outcome using an integer value.
        /// </summary>
        /// <param name="chance">The success probability as an integer percentage (e.g., 50 for a 50% chance).</param>
        /// <returns><see langword="true"/> if the random roll succeeds; otherwise, <see langword="false"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool RollChance(int chance) => RandomSharedPolyfill.Shared.Next(0, 100) < Math.Max(0, Math.Min(chance, 100));
        /// <summary>
        /// Evaluates a percentage-based chance to determine a success outcome using a double-precision floating-point value.
        /// </summary>
        /// <param name="chance">The success probability as a percentage (e.g., 75.5 for a 75.5% chance).</param>
        /// <returns><see langword="true"/> if the random roll succeeds; otherwise, <see langword="false"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool RollChance(double chance) => RandomSharedPolyfill.Shared.NextDouble() * 100.0 < Math.Max(0.0, Math.Min(chance, 100.0));
        /// <summary>
        /// Evaluates a percentage-based chance to determine a success outcome using a single-precision floating-point value.
        /// </summary>
        /// <param name="chance">The success probability as a percentage (e.g., 12.3f for a 12.3% chance).</param>
        /// <returns><see langword="true"/> if the random roll succeeds; otherwise, <see langword="false"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool RollChance(float chance) => RandomSharedPolyfill.Shared.NextDouble() * 100.0f < Math.Max(0.0f, Math.Min(chance, 100.0f));
        /// <summary>
        /// Moves a value toward a target value at a specified speed over a given time step.
        /// </summary>
        /// <param name="current">The current value.</param>
        /// <param name="target">The target value to move towards.</param>
        /// <param name="speed">The rate of movement per second.</param>
        /// <param name="dt">The time elapsed since the last frame in seconds.</param>
        /// <returns>The updated value closer to the target, or the target itself if it is within reaching distance.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double MoveTowards(double current, double target, double speed, double dt)
        {
            if (Math.Abs(target - current) <= speed * dt)
                return target;
            return current + Math.Sign(target - current) * speed * dt;
        }
        /// <inheritdoc cref="MoveTowards(double, double, double, double)"/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float MoveTowards(float current, float target, float speed, float dt)
        {
            if (Math.Abs(target - current) <= speed * dt)
                return target;
            return current + Math.Sign(target - current) * speed * dt;
        }
        /// <summary>
        /// Divides one double-precision floating-point number by another, returning a fallback value if the denominator is zero.
        /// </summary>
        /// <param name="a">The dividend (numerator).</param>
        /// <param name="b">The divisor (denominator).</param>
        /// <param name="fallback">The value to return if <paramref name="b"/> is zero.</param>
        /// <returns>The result of <paramref name="a"/> / <paramref name="b"/>, or the fallback value if <paramref name="b"/> is 0.0.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double SafeDivide(double a, double b, double fallback = 0.0) => Math.Abs(b) < 1e-5 ? fallback : a / b;
        /// <summary>
        /// Divides one integer by another, returning a fallback value if the denominator is zero to prevent a division-by-zero exception.
        /// </summary>
        /// <param name="a">The dividend (numerator).</param>
        /// <param name="b">The divisor (denominator).</param>
        /// <param name="fallback">The value to return if <paramref name="b"/> is zero.</param>
        /// <returns>The result of <paramref name="a"/> / <paramref name="b"/>, or the fallback value if <paramref name="b"/> is 0.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SafeDivide(int a, int b, int fallback = 0) => b == 0 ? fallback : a / b;
        /// <summary>
        /// Divides one single-precision floating-point number by another, returning a fallback value if the denominator is zero.
        /// </summary>
        /// <param name="a">The dividend (numerator).</param>
        /// <param name="b">The divisor (denominator).</param>
        /// <param name="fallback">The value to return if <paramref name="b"/> is zero.</param>
        /// <returns>The result of <paramref name="a"/> / <paramref name="b"/>, or the fallback value if <paramref name="b"/> is 0.0f.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float SafeDivide(float a, float b, float fallback = 0.0f) => Math.Abs(b) < 1e-5 ? fallback : a / b;
        /// <summary>
        /// Compares two floating-point values and determines if they are approximately equal within a small tolerance.
        /// </summary>
        /// <param name="a">The first value to compare.</param>
        /// <param name="b">The second value to compare.</param>
        /// <returns><see langword="true"/> if the values are approximately equal; otherwise, <see langword="false"/>.</returns>
        public static bool Approximately(double a, double b)
        {
            double diff = Math.Abs(a - b);
            if (diff <= 1e-5)
                return true;
            return diff <= Math.Max(Math.Abs(a), Math.Abs(b)) * 1e-5;
        }
        /// <inheritdoc cref="Approximately(double, double)"/>
        public static bool Approximately(float a, float b)
        {
            double diff = Math.Abs(a - b);
            if (diff <= 1e-5)
                return true;
            return diff <= Math.Max(Math.Abs(a), Math.Abs(b)) * 1e-5;
        }
        /// <summary>
        /// Smoothly damps a value toward a target destination over time using a critically damped spring-like function.
        /// </summary>
        /// <param name="current">The current position or value.</param>
        /// <param name="target">The target position or value to reach.</param>
        /// <param name="currentVelocity">A reference to the tracking velocity, which is updated internally by the function.</param>
        /// <param name="smoothTime">The approximate time it will take to reach the target. Shorter values reach the target faster.</param>
        /// <param name="maxSpeed">The maximum speed allowed during the movement transition.</param>
        /// <param name="deltaTime">The time elapsed since the last frame in seconds.</param>
        /// <returns>The newly smoothed value approaching the target.</returns>
        public static double SmoothDamp(double current, double target, ref double currentVelocity, double smoothTime, double maxSpeed, double deltaTime)
        {
            smoothTime = Math.Max(0.0001, smoothTime);

            double omega = 2.0 / smoothTime;
            double x = omega * deltaTime;
            double denominator = 1.0 + x + 0.48 * (x * x) + 0.235 * (x * x * x);
            double exp = 1.0 / denominator;

            double change = current - target;
            double maxChange = maxSpeed * smoothTime;
            change = Math.Max(-maxChange, Math.Min(change, maxChange));
            double targetReal = current - change;

            double temp = (currentVelocity + omega * change) * deltaTime;
            currentVelocity = (currentVelocity - omega * temp) * exp;
            double result = targetReal + (change + temp) * exp;

            if (target - current > 0.0 && result > target)
            {
                currentVelocity = 0.0;
                return target;
            }
            if (target - current < 0.0 && result < target)
            {
                currentVelocity = 0.0;
                return target;
            }
            return result;
        }
        /// <inheritdoc cref="SmoothDamp(double, double, ref double, double, double, double)"/>
        public static float SmoothDamp(float current, float target, ref float currentVelocity, float smoothTime, float maxSpeed, float deltaTime)
        {
            smoothTime = (float)Math.Max(0.0001f, smoothTime);

            float omega = 2.0f / smoothTime;
            float x = omega * deltaTime;
            float denominator = 1.0f + x + 0.48f * (x * x) + 0.235f * (x * x * x);
            float exp = 1.0f / denominator;

            float change = current - target;
            float maxChange = maxSpeed * smoothTime;
            change = Math.Max(-maxChange, Math.Min(change, maxChange));
            float targetReal = current - change;

            float temp = (currentVelocity + omega * change) * deltaTime;
            currentVelocity = (currentVelocity - omega * temp) * exp;
            float result = targetReal + (change + temp) * exp;

            if (target - current > 0.0f && result > target)
            {
                currentVelocity = 0.0f;
                return target;
            }
            if (target - current < 0.0f && result < target)
            {
                currentVelocity = 0.0f;
                return target;
            }
            return result;
        }
        /// <summary>
        /// Smoothly damps an angle toward a target angle over time in degrees, handling wrapping around 360 degrees.
        /// </summary>
        /// <param name="current">A reference to the current angle in degrees, which is updated internally by the function.</param>
        /// <param name="target">The target angle to reach in degrees.</param>
        /// <param name="currentVelocity">A reference to the tracking angular velocity, which is updated internally by the function.</param>
        /// <param name="smoothTime">The approximate time it will take to reach the target. Shorter values reach the target faster.</param>
        /// <param name="deltaTime">The time elapsed since the last frame in seconds.</param>
        /// <returns>The newly smoothed angle in degrees, clamped between 0 and 360.</returns>
        public static double SmoothDampAngle(ref double current, double target, ref double currentVelocity, double smoothTime, double deltaTime)
        {
            smoothTime = Math.Max(0.0001, smoothTime);

            double w = 2.0 / smoothTime;
            double x = w * deltaTime;

            double F = 1.0 / (1 + x + 0.48 * (x * x) + 0.235 * (x * x * x));

            double deltaAngle = target - current;
            double period = 360;
            deltaAngle = ((deltaAngle % period) + 540.0) % period - 180.0;

            double temp = (currentVelocity + w * deltaAngle) * deltaTime;

            currentVelocity = (currentVelocity - w * temp) * F;

            double newAngle = (target - deltaAngle) + (deltaAngle + temp) * F;
            current = ((newAngle % period) + period) % period;
            return current;
        }
        /// <inheritdoc cref="SmoothDampAngle(ref double, double, ref double, double, double)"/>
        public static float SmoothDampAngle(ref float current, float target, ref float currentVelocity, float smoothTime, float deltaTime)
        {
            smoothTime = Math.Max(0.0001f, smoothTime);

            float w = 2.0f / smoothTime;
            float x = w * deltaTime;

            float F = 1.0f / (1 + x + 0.48f * (x * x) + 0.235f * (x * x * x));

            float deltaAngle = target - current;
            float period = 360;
            deltaAngle = ((deltaAngle % period) + 540.0f) % period - 180.0f;

            float temp = (currentVelocity + w * deltaAngle) * deltaTime;

            currentVelocity = (currentVelocity - w * temp) * F;

            float newAngle = (target - deltaAngle) + (deltaAngle + temp) * F;
            current = ((newAngle % period) + period) % period;
            return current;
        }
        /// <summary>
        /// Ping-pongs the value <paramref name="t"/>, causing it to bounce back and forth between 0 and <paramref name="length"/>.
        /// </summary>
        /// <param name="t">The incoming value (typically an accumulating time variable).</param>
        /// <param name="length">The maximum value the result can reach at its peak before bouncing back.</param>
        /// <returns>A value between 0 and <paramref name="length"/> that oscillates continuously back and forth.</returns>
        public static double PingPong(double t, double length)
        {
            if (length == 0.0)
                return 0.0;
            return length - Math.Abs(Math.Abs(t) % (2.0 * length) - length);
        }
        /// <inheritdoc cref="PingPong(double, double)"/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float PingPong(float t, float length)
        {
            if (length == 0.0f)
                return 0.0f;
            return length - Math.Abs(Math.Abs(t) % (2.0f * length) - length);
        }
        /// <summary>
        /// Linearly interpolates between two angles in degrees, properly handling wrapping around 360 degrees.
        /// </summary>
        /// <param name="start">The starting angle in degrees.</param>
        /// <param name="end">The target angle in degrees.</param>
        /// <param name="t">The interpolation factor, which will be clamped between 0.0 and 1.0.</param>
        /// <returns>The interpolated angle in degrees, adjusted to take the shortest path around the circle.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double LerpAngle(double start, double end, double t)
        {
            double delta = end - start;
            double deltta = (delta % 360.0 + 360.0) % 360.0;
            if (deltta > 180.0)
                deltta -= 360.0;
            return start + deltta * Math.Max(0.0, Math.Min(t, 1.0));
        }
        /// <inheritdoc cref="LerpAngle(double, double, double)"/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float LerpAngle(float start, float end, float t)
        {
            float delta = end - start;
            float deltta = (delta % 360.0f + 360.0f) % 360.0f;
            if (deltta > 180.0f)
                deltta -= 360.0f;
            return start + deltta * (float)Math.Max(0.0f, (float)Math.Min(t, 1.0f));
        }
        /// <summary>
        /// Loops the value <paramref name="t"/> so that it is never larger than <paramref name="length"/> and never smaller than 0.
        /// </summary>
        /// <param name="t">The input value to loop.</param>
        /// <param name="length">The length of the loop (period).</param>
        /// <returns>The looped value wrapped within the range [0, <paramref name="length"/>).</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Repeat(double t, double length)
        {
            if (length == 0.0)
                return 0.0;
            return t - Math.Floor(t / length) * length;
        }
        /// <summary>
        /// Loops the value <paramref name="t"/> so that it is never larger than <paramref name="length"/> and never smaller than 0.
        /// </summary>
        /// <param name="t">The input value to loop.</param>
        /// <param name="length">The length of the loop (period).</param>
        /// <returns>The looped value wrapped within the range [0, <paramref name="length"/>).</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Repeat(float t, float length)
        {
            if (length == 0.0f)
                return 0.0f;
            return t - (float)Math.Floor(t / length) * length;
        }
    }
}