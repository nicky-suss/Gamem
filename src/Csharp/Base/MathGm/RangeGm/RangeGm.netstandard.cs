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
    /// Checks if the range is valid: X > Y returns true, if not returns false
    /// </summary>
    public readonly bool IsValid
    {
        get
        {
            return IsValidCheck(X, Y);
        }
    }
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
    /// IsValid check method
    /// </summary>
    public static bool IsValidCheck(int X, int Y)
    {
        return X < Y;
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
    /// <summary>
    /// Returns the length of the range.
    /// </summary>
    /// <returns>The range's length</returns>
    public int Length() => Y - X;
    /// <summary>
    /// Returns the center of the range.
    /// </summary>
    /// <returns>The range's center</returns>
    public int Center() => (X + Y) / 2;
    /// <summary>
    /// Checks if the range contains the specified value.
    /// </summary>
    /// <param name="Value">Value to check</param>
    /// <returns>True if the range contains the value, if not false</returns>
    /// <example>
    /// <code>
    /// RangeGm range = new(0, 100);
    /// Console.WriteLine(range.Contains(35)); // true
    /// Console.WriteLine(range.Contains(101)); // false
    /// </code>
    /// </example>
    public bool Contains(int Value) => Value >= X && Value <= Y;
    /// <summary>
    /// Checks if the range contains the specified range.
    /// </summary>
    /// <param name="Other">Value to check</param>
    /// <returns>True if the range contains the value, if not false</returns>
    /// <example>
    /// <code>
    /// RangeGm range = new(0, 100);
    /// Console.WriteLine(range.Contains(35)); // true
    /// Console.WriteLine(range.Contains(101)); // false
    /// </code>
    /// </example>
    public bool Contains(RangeGm Other) => Other.X >= X && Other.Y <= Y;
    /// <summary>
    /// Checks if the range overlaps with the specified range.
    /// </summary>
    /// <param name="Other">Range to check</param>
    /// <returns>True if the ranges overlap, if not false</returns>
    public bool Overlaps(RangeGm Other) => X <= Other.Y && Other.X <= Y;
    /// <summary>
    /// Returns the union of two ranges.
    /// </summary>
    /// <param name="range1">The first range</param>
    /// <param name="range2">The second range</param>
    /// <returns>The union of two ranges</returns>
    public RangeGm Union(RangeGm range1, RangeGm range2) => new(Math.Min(range1.Min(), range2.Min()), Math.Max(range1.Max(), range2.Max()));
    /// <summary>
    /// Expands the range to include the specified value.
    /// </summary>
    /// <param name="Value">Value to include</param>
    /// <returns>The expanded range</returns>
    public RangeGm Expand(int Value)
    {
        if (Value >= Y)
            return new(X, Value);
        else if (Value <= X)
            return new(Value, Y);
        return this;
    }
    public static RangeGm operator +(RangeGm range, int num)
    {
        return new RangeGm
        {
            X = range.X + num,
            Y = range.Y + num
        };
    }
    public static RangeGm operator +(int num, RangeGm range) => range + num;
    public static RangeGm operator -(RangeGm range, int num)
    {
        return new RangeGm
        {
            X = range.X - num,
            Y = range.Y - num
        };
    }
    public static RangeGm operator -(int num, RangeGm range)
    {
        return new RangeGm
        {
            X = num - range.X,
            Y = num - range.Y
        };
    }
    public static RangeGm operator *(RangeGm range, int num)
    {
        return new RangeGm
        {
            X = range.X * num,
            Y = range.Y * num
        };
    }
    public static RangeGm operator *(int num, RangeGm range) => range * num;
    public static RangeGm operator /(RangeGm range, int num)
    {
        return new RangeGm
        {
            X = range.X / num,
            Y = range.Y / num
        };
    }
    public static RangeGm operator /(int num, RangeGm range)
    {
        return new RangeGm
        {
            X = num / range.X,
            Y = num / range.Y
        };
    }
}