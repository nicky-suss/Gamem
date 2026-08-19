using Unity.Mathematics;
using Gamem;
using System.Runtime.CompilerServices;
using System;
using UnityEngine;

namespace Gamem.Unity;

/// <summary>
/// GeometryGm Unity test class
/// </summary>
public static class GeometryGmUnity
{
    /// <summary>
    /// Calculates the Euclidean distance between two points in a 2D plane.
    /// </summary>
    /// <param name="point1">The first 2D point.</param>
    /// <param name="point2">The second 2D point.</param>
    /// <returns>The distance between the two points in 2D space.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float GetDistance(float2 point1, float2 point2)
    {
        return GeometryGm.GetDistance(point1.x, point1.y, point2.x, point2.y);
    }
    /// <summary>
    /// Calculates the Euclidean distance between two points in a 2D plane.
    /// </summary>
    /// <param name="point1">The first 2D point.</param>
    /// <param name="point2">The second 2D point.</param>
    /// <returns>The distance between the two points in 2D space.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float GetDistance(int2 point1, int2 point2)
    {
        return GeometryGm.GetDistance(point1.x, point1.y, point2.x, point2.y);
    }
    /// <summary>
    /// Calculates the Euclidean distance between two points in a 2D plane.
    /// </summary>
    /// <param name="point1">The first 2D point.</param>
    /// <param name="point2">The second 2D point.</param>
    /// <returns>The distance between the two points in 2D space.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float GetDistance(Vector2 point1, Vector2 point2)
    {
        return GeometryGm.GetDistance(point1.x, point1.y, point2.x, point2.y);
    }
    /// <summary>
    /// Calculates the Euclidean distance between two points in a 2D plane.
    /// </summary>
    /// <param name="point1">The first 2D point.</param>
    /// <param name="point2">The second 2D point.</param>
    /// <returns>The distance between the two points in 2D space.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float GetDistance(Vector2Int point1, Vector2Int point2)
    {
        return GeometryGm.GetDistance(point1.x, point1.y, point2.x, point2.y);
    }
}