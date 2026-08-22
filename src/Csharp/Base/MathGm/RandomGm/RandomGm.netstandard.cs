using System;
using System.Threading;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace Gamem
{
    /// <summary>
    /// Provides general-purpose static mathematical functions including interpolation and random number generation.
    /// </summary>
    public static class RandomGm
    {
        internal static class RandomSharedPolyfill
        {
            private static readonly ThreadLocal<Random> _localRandom = new ThreadLocal<Random>(() => new Random(Guid.NewGuid().GetHashCode()));
            public static Random Shared => _localRandom.Value;
        }
        /// <summary>
        /// Generates a random floating-point value within a specified inclusive range.
        /// </summary>
        /// <param name="min">The minimum bound of the range.</param>
        /// <param name="max">The maximum bound of the range.</param>
        /// <returns>A random value greater than or equal to min, and less than max.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double RandomRange(double min, double max)
        {
            if (min > max)
                (min, max) = (max, min);
            double randomF = RandomSharedPolyfill.Shared.NextDouble();
            return min + (randomF * (max - min));
        }
        /// <inheritdoc cref="RandomRange(double, double)"/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float RandomRange(float min, float max)
        {
            if (min > max)
                (min, max) = (max, min);
            float randomF = (float)RandomSharedPolyfill.Shared.NextDouble();
            return min + (randomF * (max - min));
        }
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
    }
}