using System;
using System.Numerics;

namespace Gamem;

/// <summary>
/// Cache for floating point values
/// </summary>
/// <typeparam name="T"></typeparam>
internal static class Cache<T> where T : IFloatingPointIeee754<T>
{
    /// <summary>
    /// T.CreateChecked 360
    /// </summary>
    internal static readonly T T360 = T.CreateChecked(360);
    /// <summary>
    /// T.CreateChecked 180
    /// </summary>
    internal static readonly T T180 = T.CreateChecked(180);
    /// <summary>
    /// T.CreateChecked 90
    /// </summary>
    internal static readonly T T90 = T.CreateChecked(90);
    /// <summary>
    /// T.CreateChecked 2
    /// </summary>
    internal static readonly T T2 = T.CreateChecked(2);
    /// <summary>
    /// T.CreateChecked 0.48
    /// </summary>
    internal static readonly T T048 = T.CreateChecked(0.48);
    /// <summary>
    /// T.CreateChecked 0.235
    /// </summary>
    internal static readonly T T0235 = T.CreateChecked(0.235);
    /// <summary>
    /// T.CreateChecked 0.0001
    /// </summary>
    internal static readonly T T00001 = T.CreateChecked(0.0001);
    /// <summary>
    /// T.CreateChecked 540
    /// </summary>
    internal static readonly T T540 = T.CreateChecked(540);
    /// <summary>
    /// T.CreateChecked 1e-5
    /// </summary>
    internal static readonly T T1e5 = T.CreateChecked(1e-5);
    /// <summary>
    /// T.CreateChecked 3
    /// </summary>
    internal static readonly T T3 = T.CreateChecked(3);
}