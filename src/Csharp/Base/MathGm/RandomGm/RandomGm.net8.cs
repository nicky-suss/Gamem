using System;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace Gamem;

/// <summary>
/// Provides general-purpose static mathematical functions including interpolation and random number generation.
/// </summary>
public static partial class RandomGm
{
    /// <summary>
    /// Generates a random floating-point value within a specified inclusive range.
    /// </summary>
    /// <typeparam name="T">A floating-point type that implements <see cref="IFloatingPointIeee754{T}"/>.</typeparam>
    /// <param name="min">The minimum bound of the range.</param>
    /// <param name="max">The maximum bound of the range.</param>
    /// <returns>A random value greater than or equal to min, and less than max.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T RandomRange<T>(T min, T max) where T : IFloatingPointIeee754<T>
    {
        if (min > max)
            (min, max) = (max, min);
        T randomF = T.CreateChecked(Random.Shared.NextDouble());
        return min + (randomF * (max - min));
    }
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
    /// Generates a random angle number in degrees (0 - 360)
    /// </summary>
    /// <returns>A random angle number in degrees (0 - 360)</returns>
    public static int RandomAngleDegrees() => Random.Shared.Next(0, 361);
    /// <summary>
    /// Generates a random angle number in degrees (0.0 - 360.0)
    /// </summary>
    /// <returns>A random angle number in degrees (0.0 - 360.0)</returns>
    public static T RandomAngleDegrees<T>() where T : IFloatingPointIeee754<T> => T.CreateChecked(Random.Shared.Next(0, 361));
    /// <summary>
    /// Generates a random angle number in radians (0.0 - 6.28)
    /// </summary>
    /// <returns>A random angle number in degrees (0.0 - 6.28)</returns>
    public static T RandomAngleRadians<T>() where T : IFloatingPointIeee754<T> => T.CreateChecked(Random.Shared.NextDouble()) * Cache<T>.T2PI;
    /// <summary>
    /// Generates a random sign (-1 or 1) so your number can turn into positive or negative
    /// </summary>
    /// <returns>A random sign (-1 or 1)</returns>
    public static int RandomSign() => Random.Shared.Next(0, 2) * 2 - 1;
    /// <summary>
    /// Generates random bool value (true or false)
    /// </summary>
    /// <returns>Randomly true or false</returns>
    public static bool RandomBool() => Random.Shared.Next(0, 2) == 1;
}