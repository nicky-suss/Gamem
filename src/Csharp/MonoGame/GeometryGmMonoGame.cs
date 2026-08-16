using Gamem;
using Microsoft.Xna.Framework;
using System;
using System.Runtime.CompilerServices;

namespace Gamem.MonoGame;

/// <summary>
/// Provides static methods for Geometry calculations for MonoGame
/// </summary>
public static class GeometryGmMonoGame
{
    /// <summary>
    /// Reflects a 2D vector off a surface defined by a normal vector.
    /// </summary>
    /// <param name="vector">The incident vector.</param>
    /// <param name="normal">The surface normal (should be normalized).</param>
    /// <returns>The X and Y components of the reflected vector.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector2 Reflect(Vector2 vector, Vector2 normal)
    {
        var res = GeometryGm.Reflect(vector.X, vector.Y, normal.X, normal.Y);
        return new Vector2(res.x, res.y);
    }
    /// <summary>
    /// Reflects a 3D vector off a surface defined by a normal vector.
    /// </summary>
    /// <param name="vector">The incident vector.</param>
    /// <param name="normal">The surface normal (should be normalized).</param>
    /// <returns>The X, Y, and Z components of the reflected vector.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector3 Reflect3D(Vector3 vector, Vector3 normal)
    {
        var res = GeometryGm.Reflect3D(vector.X, vector.Y, vector.Z, normal.X, normal.Y, normal.Z);
        return new Vector3(res.x, res.y, res.z);
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
        return GeometryGm.GetDistance(point1.X, point1.Y, point2.X, point2.Y);
    }
    /// <summary>
    /// Calculates the squared distance between two 2D points.
    /// </summary>
    /// <param name="point1">The first point.</param>
    /// <param name="point2">The second point.</param>
    /// <returns>The squared distance between the two points, avoiding an expensive square root operation.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float GetDistanceSquared(Vector2 point1, Vector2 point2)
    {
        float dx = point2.X - point1.X;
        float dy = point2.Y - point1.Y;
        return (dx * dx) + (dy * dy);
    }
    /// <summary>
    /// Calculates the Euclidean distance between two points in 3D space.
    /// </summary>
    /// <param name="point1">The first point.</param>
    /// <param name="point2">Thesecond point.</param>
    /// <returns>The distance between the two points in 3D space.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float GetDistance3D(Vector3 point1, Vector3 point2)
    {
        float dx = point2.X - point1.X;
        float dy = point2.Y - point1.Y;
        float dz = point2.Z - point1.Z;
        return MathF.Sqrt((dx * dx) + (dy * dy) + (dz * dz));
    }
}