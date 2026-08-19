using System;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace Gamem;

/// <summary>
/// Represents a 2D integer range or coordinate pair.
/// </summary>
/// <param name="x">The initial X-coordinate or start value.</param>
/// <param name="y">The initial Y-coordinate or end value.</param>
public struct RangeGm(int x, int y)
{
    /// <summary>
    /// The X-coordinate or start value.
    /// </summary>
    public int X { get; set; } = x;
    /// <summary>
    /// 
    /// </summary>
    public int Y { get; set; } = y;
    /// <summary>
    /// Returns a string representation of the current range.
    /// </summary>
    /// <returns>A string formatted as "(X, Y)".</returns>
    public override string ToString() => $"({X}, {Y})";
    /// <summary>
    /// Returns the smaller of two 32-bit signed integers.
    /// </summary>
    /// <param name="X">The first integer to compare.</param>
    /// <param name="Y">The second integer to compare.</param>
    /// <returns>The smaller of the two parameters.</returns>
    public int Min(int X, int Y) => Math.Min(X, Y);
    /// <summary>
    /// Returns the larger of two 32-bit signed integers.
    /// </summary>
    /// <param name="X">The first integer to compare.</param>
    /// <param name="Y">The second integer to compare.</param>
    /// <returns>The larger of the two parameters.</returns>
    public int Max(int X, int Y) => Math.Max(X, Y);
}