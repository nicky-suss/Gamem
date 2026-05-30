using System;
using System.Runtime.CompilerServices;
using System.Numerics;

namespace Gamem;

/// <summary>
/// Provides general-purpose static mathematical functions including interpolation and random number generation.
/// </summary>
public static class MathGamem
{
    /// <summary>
    /// Performs a smooth cubic interpolation between two values based on a given percentage.
    /// </summary>
    /// <typeparam name="T">A floating-point type that implements <see cref="IFloatingPointIeee754{T}"/>.</typeparam>
    /// <param name="start">The start value.</param>
    /// <param name="end">The end value.</param>
    /// <param name="t">The interpolation value, clamped between 0.0 and 1.0.</param>
    /// <returns>The smoothly interpolated value between start and end.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T SmoothStep<T>(T start, T end, T t) where T : IFloatingPointIeee754<T>
    {
        T c = T.Clamp(t, T.Zero, T.One);
        T tt = c * c * (T.CreateChecked(3) - T.CreateChecked(2) * c);
        return start + (end - start) * tt;
    }
    /// <summary>
    /// Generates a random floating-point value within a specified inclusive range.
    /// </summary>
    /// <typeparam name="T">A floating-point type that implements <see cref="IFloatingPointIeee754{T}"/>.</typeparam>
    /// <param name="min">The minimum bound of the range.</param>
    /// <param name="max">The maximum bound of the range.</param>
    /// <returns>A random value greater than or equal to min, and less than or equal to max.</returns>
    /// <exception cref="ArgumentException">Thrown when min is greater than max.</exception>
    public static T RandomRange<T>(T min, T max) where T : IFloatingPointIeee754<T>
    {
        if (min > max)
            throw new ArgumentException($"{nameof(min)} must be <= {nameof(max)}");
        T randomF = T.CreateChecked(Random.Shared.NextDouble());
        return min + (randomF * (max - min));
    }
    /// <summary>
    /// Linearly interpolates between start and end values, clamping the interpolation percentage between 0.0 and 1.0.
    /// </summary>
    /// <typeparam name="T">A floating-point type that implements <see cref="IFloatingPointIeee754{T}"/>.</typeparam>
    /// <param name="start">The start value.</param>
    /// <param name="end">The end value.</param>
    /// <param name="t">The interpolation value, clamped between 0.0 and 1.0.</param>
    /// <returns>The interpolated value between start and end.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T Lerp<T>(T start, T end, T t) where T : IFloatingPointIeee754<T> => start + (end - start) * T.Clamp(t, T.Zero, T.One);
    /// <summary>
    /// Linearly interpolates between start and end values without clamping the interpolation percentage.
    /// </summary>
    /// <typeparam name="T">A floating-point type that implements <see cref="IFloatingPointIeee754{T}"/>.</typeparam>
    /// <param name="start">The start value.</param>
    /// <param name="end">The end value.</param>
    /// <param name="t">The interpolation value, allowing extrapolation outside the start and end range.</param>
    /// <returns>The interpolated or extrapolated value.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T LerpUnclamped<T>(T start, T end, T t) where T : IFloatingPointIeee754<T> => start + (end - start) * t;
    /// <summary>
    /// Calculates the linear parameter t that produces the given value within a specific range, clamped between 0.0 and 1.0.
    /// </summary>
    /// <typeparam name="T">A floating-point type that implements <see cref="IFloatingPointIeee754{T}"/>.</typeparam>
    /// <param name="value">The value to find the interpolation factor for.</param>
    /// <param name="start">The start value of the range.</param>
    /// <param name="end">The end value of the range.</param>
    /// <returns>The normalized linear parameter t between 0.0 and 1.0, or 0.0 if the range is zero.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T InverseLerp<T>(T value, T start, T end) where T : IFloatingPointIeee754<T>
    {
        if (T.Abs(end - start) <= T.Epsilon)
            return T.Zero;
        return T.Clamp((value - start) / (end - start), T.Zero, T.One);
    }
    /// <summary>
    /// Smoothly accelerates current velocity toward a target velocity using an acceleration rate over a given time step.
    /// </summary>
    /// <typeparam name="T">A floating-point type that implements <see cref="IFloatingPointIeee754{T}"/>.</typeparam>
    /// <param name="Vcurrent">The current velocity.</param>
    /// <param name="Vtarget">The desired target velocity.</param>
    /// <param name="a">The acceleration rate multiplier.</param>
    /// <param name="t">The time elapsed since the last frame in seconds.</param>
    /// <returns>The updated velocity approaching the target value.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T Accelerate<T>(T Vcurrent, T Vtarget, T a, T t) where T : IFloatingPointIeee754<T> => Vcurrent + (Vtarget - Vcurrent) * (a * t);
    /// <summary>
    /// Maps a value from an input range to an output range without clamping.
    /// </summary>
    /// <typeparam name="T">A floating-point type that implements <see cref="IFloatingPointIeee754{T}"/>.</typeparam>
    /// <param name="toMin">The lower bound of the output range.</param>
    /// <param name="v">The value to be mapped.</param>
    /// <param name="fromMin">The lower bound of the input range.</param>
    /// <param name="toMax">The upper bound of the output range.</param>
    /// <param name="fromMax">The upper bound of the input range.</param>
    /// <returns>The mapped value in the output range, or 0.0 if the input range size is zero.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T Map<T>(T toMin, T v, T fromMin, T toMax, T fromMax) where T : IFloatingPointIeee754<T> => fromMax - fromMin == T.Zero ? T.Zero : toMin + (v - fromMin) * ((toMax - toMin) / (fromMax - fromMin));
    /// <summary>
    /// Remaps a value from an input range to an output range, behaving identically to Map method.
    /// </summary>
    /// <typeparam name="T">A floating-point type that implements <see cref="IFloatingPointIeee754{T}"/>.</typeparam>
    /// <param name="toMin">The lower bound of the output range.</param>
    /// <param name="v">The value to be remapped.</param>
    /// <param name="fromMin">The lower bound of the input range.</param>
    /// <param name="toMax">The upper bound of the output range.</param>
    /// <param name="fromMax">The upper bound of the input range.</param>
    /// <returns>The remapped value in the output range.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T Remap<T>(T toMin, T v, T fromMin, T toMax, T fromMax) where T : IFloatingPointIeee754<T> => Map(toMin, v, fromMin, toMax, fromMax);
    /// <summary>
    /// Evaluates a percentage-based chance to determine a success outcome using an integer value.
    /// </summary>
    /// <param name="chance">The success probability as an integer percentage (e.g., 50 for a 50% chance).</param>
    /// <returns><see langword="true"/> if the random roll succeeds; otherwise, <see langword="false"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool RollChance(int chance) => Random.Shared.Next(0, 100) < Math.Clamp(chance, 0, 100);
    /// <summary>
    /// Evaluates a percentage-based chance to determine a success outcome using a double-precision floating-point value.
    /// </summary>
    /// <param name="chance">The success probability as a percentage (e.g., 75.5 for a 75.5% chance).</param>
    /// <returns><see langword="true"/> if the random roll succeeds; otherwise, <see langword="false"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool RollChance(double chance) => Random.Shared.NextDouble() * 100.0 < Math.Clamp(chance, 0.0, 100.0);
    /// <summary>
    /// Evaluates a percentage-based chance to determine a success outcome using a single-precision floating-point value.
    /// </summary>
    /// <param name="chance">The success probability as a percentage (e.g., 12.3f for a 12.3% chance).</param>
    /// <returns><see langword="true"/> if the random roll succeeds; otherwise, <see langword="false"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool RollChance(float chance) => Random.Shared.NextSingle() * 100.0f < Math.Clamp(chance, 0.0f, 100.0f);
    /// <summary>
    /// Moves a value toward a target value at a specified speed over a given time step.
    /// </summary>
    /// <typeparam name="T">A floating-point type that implements <see cref="IFloatingPointIeee754{T}"/>.</typeparam>
    /// <param name="target">The target value to move towards.</param>
    /// <param name="current">The current value.</param>
    /// <param name="speed">The rate of movement per second.</param>
    /// <param name="dt">The time elapsed since the last frame in seconds.</param>
    /// <returns>The updated value closer to the target, or the target itself if it is within reaching distance.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T MoveTowards<T>(T target, T current, T speed, T dt) where T : IFloatingPointIeee754<T>
    {
        if (T.Abs(target - current) <= speed * dt)
            return target;
        return current + T.CopySign(T.One, target - current) * speed * dt;
    }
    /// <summary>
    /// Divides one double-precision floating-point number by another, returning a fallback value if the denominator is zero.
    /// </summary>
    /// <param name="a">The dividend (numerator).</param>
    /// <param name="b">The divisor (denominator).</param>
    /// <param name="fallback">The value to return if <paramref name="b"/> is zero.</param>
    /// <returns>The result of <paramref name="a"/> / <paramref name="b"/>, or the fallback value if <paramref name="b"/> is 0.0.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static double SafeDivide(double a, double b, double fallback = 0.0) => Math.Abs(b) < double.Epsilon ? fallback : a / b;
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
    public static float SafeDivide(float a, float b, float fallback = 0.0f) => Math.Abs(b) < float.Epsilon ? fallback : a / b;
}