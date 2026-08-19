using System;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace Gamem;

/// <summary>
/// Represents a 2D integer range or coordinate pair.
/// </summary>
public struct RangeGm
{
    /// <summary>
    /// The X-coordinate or start value.
    /// </summary>
    public int X { get; set; }
    /// <summary>
    /// The Y-coordinate or start value.
    /// </summary>
    public int Y { get; set; }
    /// <summary>
    /// Initializes a new instance of the <see cref="RangeGm"/> struct.
    /// </summary>
    /// <param name="x">The initial X-coordinate or start value.</param>
    /// <param name="y">The initial Y-coordinate or end value.</param>
    public RangeGm(int x, int y)
    {
        X = x;
        Y = y;
    }
    /// <summary>
    /// Returns a string representation of the current range.
    /// </summary>
    /// <returns>A string formatted as "(X, Y)".</returns>
    public override string ToString() => $"({X}, {Y})";
    /// <summary>
    /// Returns the smaller of two 32-bit signed integers.
    /// </summary>
    /// <returns>The smaller of the two parameters.</returns>
    public int Min() => Math.Min(X, Y);
    /// <summary>
    /// Returns the larger of two 32-bit signed integers.
    /// </summary>
    /// <returns>The larger of the two parameters.</returns>
    public int Max() => Math.Max(X, Y);
}