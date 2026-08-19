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
}