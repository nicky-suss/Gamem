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
}