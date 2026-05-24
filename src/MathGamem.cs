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
}