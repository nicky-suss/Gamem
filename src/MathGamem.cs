using System;
using System.Runtime.CompilerServices;

namespace Gamem;

/// <summary>
/// Provides general-purpose static mathematical functions including interpolation and random number generation.
/// </summary>
public static class MathGamem
{
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
        double c = Math.Clamp(t, 0.0, 1.0);
        double T = c * c * (3.0 - 2.0 * c);
        return start + (end - start) * T;
    }
    /// <summary>
    /// Performs a smooth cubic interpolation between two values based on a given percentage.
    /// </summary>
    /// <param name="start">The start value.</param>
    /// <param name="end">The end value.</param>
    /// <param name="t">The interpolation value, clamped between 0.0f and 1.0f.</param>
    /// <returns>The smoothly interpolated value between start and end.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float SmoothStep(float start, float end, float t)
    {
        float c = Math.Clamp(t, 0.0f, 1.0f);
        float T = c * c * (3.0f - 2.0f * c);
        return start + (end - start) * T;
    }
    /// <summary>
    /// Generates a random floating-point value within a specified inclusive range.
    /// </summary>
    /// <param name="min">The minimum bound of the range.</param>
    /// <param name="max">The maximum bound of the range.</param>
    /// <returns>A random value greater than or equal to min, and less than or equal to max.</returns>
    /// <exception cref="ArgumentException">Thrown when min is greater than max.</exception>
    public static double RandomRange(double min, double max)
    {
        if (min > max)
            throw new ArgumentException($"{nameof(min)} must be <= {nameof(max)}");
        return min + (Random.Shared.NextDouble() * (max - min));
    }
    /// <summary>
    /// Generates a random floating-point value within a specified inclusive range.
    /// </summary>
    /// <param name="min">The minimum bound of the range.</param>
    /// <param name="max">The maximum bound of the range.</param>
    /// <returns>A random value greater than or equal to min, and less than or equal to max.</returns>
    /// <exception cref="ArgumentException">Thrown when min is greater than max.</exception>
    public static float RandomRange(float min, float max)
    {
        if (min > max)
            throw new ArgumentException($"{nameof(min)} must be <= {nameof(max)}");
        return min + (Random.Shared.NextSingle() * (max - min));
    }
    /// <summary>
    /// Linearly interpolates between start and end values, clamping the interpolation percentage between 0.0 and 1.0.
    /// </summary>
    /// <param name="start">The start value.</param>
    /// <param name="end">The end value.</param>
    /// <param name="t">The interpolation value, clamped between 0.0 and 1.0.</param>
    /// <returns>The interpolated value between start and end.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static double Lerp(double start, double end, double t) => start + (end - start) * Math.Clamp(t, 0.0, 1.0);
    /// <summary>
    /// Linearly interpolates between start and end values, clamping the interpolation percentage between 0.0f and 1.0f.
    /// </summary>
    /// <param name="start">The start value.</param>
    /// <param name="end">The end value.</param>
    /// <param name="t">The interpolation value, clamped between 0.0f and 1.0f.</param>
    /// <returns>The interpolated value between start and end.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float Lerp(float start, float end, float t) => start + (end - start) * Math.Clamp(t, 0.0f, 1.0f);
    /// <summary>
    /// Linearly interpolates between start and end values without clamping the interpolation percentage.
    /// </summary>
    /// <param name="start">The start value.</param>
    /// <param name="end">The end value.</param>
    /// <param name="t">The interpolation value, allowing extrapolation outside the start and end range.</param>
    /// <returns>The interpolated or extrapolated value.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static double LerpUnclamped(double start, double end, double t) => start + (end - start) * t;
    /// <summary>
    /// Linearly interpolates between start and end values without clamping the interpolation percentage.
    /// </summary>
    /// <param name="start">The start value.</param>
    /// <param name="end">The end value.</param>
    /// <param name="t">The interpolation value, allowing extrapolation outside the start and end range.</param>
    /// <returns>The interpolated or extrapolated value.</returns>
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
        if (end - start == 0.0)
            return 0.0;
        return Math.Clamp((value - start) / (end - start), 0.0, 1.0);
    }
    /// <summary>
    /// Calculates the linear parameter t that produces the given value within a specific range, clamped between 0.0f and 1.0f.
    /// </summary>
    /// <param name="value">The value to find the interpolation factor for.</param>
    /// <param name="start">The start value of the range.</param>
    /// <param name="end">The end value of the range.</param>
    /// <returns>The normalized linear parameter t between 0.0f and 1.0f, or 0.0f if the range is zero.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float InverseLerp(float value, float start, float end)
    {
        if (end - start == 0.0f)
            return 0.0f;
        return Math.Clamp((value - start) / (end - start), 0.0f, 1.0f);
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
    /// <summary>
    /// Smoothly accelerates current velocity toward a target velocity using an acceleration rate over a given time step.
    /// </summary>
    /// <param name="Vcurrent">The current velocity.</param>
    /// <param name="Vtarget">The desired target velocity.</param>
    /// <param name="a">The acceleration rate multiplier.</param>
    /// <param name="t">The time elapsed since the last frame in seconds.</param>
    /// <returns>The updated velocity approaching the target value.</returns>
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
    public static double Map(double toMin, double v, double fromMin, double toMax, double fromMax) => fromMax - fromMin == 0 ? 0.0 : toMin + (v - fromMin) * ((toMax - toMin) / (fromMax - fromMin));
    /// <summary>
    /// Maps a value from an input range to an output range without clamping.
    /// </summary>
    /// <param name="toMin">The lower bound of the output range.</param>
    /// <param name="v">The value to be mapped.</param>
    /// <param name="fromMin">The lower bound of the input range.</param>
    /// <param name="toMax">The upper bound of the output range.</param>
    /// <param name="fromMax">The upper bound of the input range.</param>
    /// <returns>The mapped value in the output range, or 0.0f if the input range size is zero.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float Map(float toMin, float v, float fromMin, float toMax, float fromMax) => fromMax - fromMin == 0 ? 0.0f : toMin + (v - fromMin) * ((toMax - toMin) / (fromMax - fromMin));
    /// <summary>
    /// Remaps a value from an input range to an output range, behaving identically to <see cref="Map(double, double, double, double, double)"/>.
    /// </summary>
    /// <param name="toMin">The lower bound of the output range.</param>
    /// <param name="v">The value to be remapped.</param>
    /// <param name="fromMin">The lower bound of the input range.</param>
    /// <param name="toMax">The upper bound of the output range.</param>
    /// <param name="fromMax">The upper bound of the input range.</param>
    /// <returns>The remapped value in the output range.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static double Remap(double toMin, double v, double fromMin, double toMax, double fromMax) => Map(toMin, v, fromMin, toMax, fromMax);
    /// <summary>
    /// Remaps a value from an input range to an output range, behaving identically to <see cref="Map(float, float, float, float, float)"/>.
    /// </summary>
    /// <param name="toMin">The lower bound of the output range.</param>
    /// <param name="v">The value to be remapped.</param>
    /// <param name="fromMin">The lower bound of the input range.</param>
    /// <param name="toMax">The upper bound of the output range.</param>
    /// <param name="fromMax">The upper bound of the input range.</param>
    /// <returns>The remapped value in the output range.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float Remap(float toMin, float v, float fromMin, float toMax, float fromMax) => Map(toMin, v, fromMin, toMax, fromMax);
    /// <summary>
    /// Evaluates a percentage-based chance to determine a success outcome using an integer value.
    /// </summary>
    /// <param name="chance">The success probability as an integer percentage (e.g., 50 for a 50% chance).</param>
    /// <returns><see langword="true"/> if the random roll succeeds; otherwise, <see langword="false"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool RollChance(int chance) => Random.Shared.Next(0, 101) < chance;
    /// <summary>
    /// Evaluates a percentage-based chance to determine a success outcome using a double-precision floating-point value.
    /// </summary>
    /// <param name="chance">The success probability as a percentage (e.g., 75.5 for a 75.5% chance).</param>
    /// <returns><see langword="true"/> if the random roll succeeds; otherwise, <see langword="false"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool RollChance(double chance) => Random.Shared.NextDouble() * 100.0 < chance;
    /// <summary>
    /// Evaluates a percentage-based chance to determine a success outcome using a single-precision floating-point value.
    /// </summary>
    /// <param name="chance">The success probability as a percentage (e.g., 12.3f for a 12.3% chance).</param>
    /// <returns><see langword="true"/> if the random roll succeeds; otherwise, <see langword="false"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool RollChance(float chance) => Random.Shared.NextSingle() * 100.0f < chance;
    /// <summary>
    /// Moves a value toward a target value at a specified speed over a given time step.
    /// </summary>
    /// <param name="target">The target value to move towards.</param>
    /// <param name="current">The current value.</param>
    /// <param name="speed">The rate of movement per second.</param>
    /// <param name="dt">The time elapsed since the last frame in seconds.</param>
    /// <returns>The updated value closer to the target, or the target itself if it is within reaching distance.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static double MoveTowards(double target, double current, double speed, double dt)
    {
        if (Math.Abs(target - current) <= speed * dt)
            return target;
        return current + Math.Sign(target - current) * speed * dt;
    }
    /// <summary>
    /// Moves a value toward a target value at a specified speed over a given time step.
    /// </summary>
    /// <param name="target">The target value to move towards.</param>
    /// <param name="current">The current value.</param>
    /// <param name="speed">The rate of movement per second.</param>
    /// <param name="dt">The time elapsed since the last frame in seconds.</param>
    /// <returns>The updated value closer to the target, or the target itself if it is within reaching distance.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float MoveTowards(float target, float current, float speed, float dt)
    {
        if (MathF.Abs(target - current) <= speed * dt)
            return target;
        return current + MathF.Sign(target - current) * speed * dt;
    }
    /// <summary>
    /// Divides one double-precision floating-point number by another, returning a fallback value if the denominator is zero.
    /// </summary>
    /// <param name="a">The dividend (numerator).</param>
    /// <param name="b">The divisor (denominator).</param>
    /// <param name="fallback">The value to return if <paramref name="b"/> is zero.</param>
    /// <returns>The result of <paramref name="a"/> / <paramref name="b"/>, or the fallback value if <paramref name="b"/> is 0.0.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static double SafeDivide(double a, double b, double fallback = 0.0) => b == 0.0 ? fallback : a / b;
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
    public static float SafeDivide(float a, float b, float fallback = 0.0f) => b == 0.0f ? fallback : a / b;
}