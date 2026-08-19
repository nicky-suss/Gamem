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
    /// Reflects a 2D vector off a surface defined by a normal vector.
    /// </summary>
    /// <param name="vector">The incident vector.</param>
    /// <param name="normal">The surface normal (should be normalized).</param>
    /// <returns>The X and Y components of the reflected vector.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float2 Reflect(float2 vector, float2 normal)
    {
        var res = GeometryGm.Reflect(vector.x, vector.y, normal.x, normal.y);
        return new float2(res.x, res.y);
    }
    /// <summary>
    /// Reflects a 2D vector off a surface defined by a normal vector.
    /// </summary>
    /// <param name="vector">The incident vector.</param>
    /// <param name="normal">The surface normal (should be normalized).</param>
    /// <returns>The X and Y components of the reflected vector.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector2 Reflect(Vector2 vector, Vector2 normal)
    {
        var res = GeometryGm.Reflect(vector.x, vector.y, normal.x, normal.y);
        return new Vector2(res.x, res.y);
    }
    /// <summary>
    /// Reflects a 3D vector off a surface defined by a normal vector.
    /// </summary>
    /// <param name="vector">The incident vector.</param>
    /// <param name="normal">The surface normal (should be normalized).</param>
    /// <returns>The X, Y, and Z components of the reflected vector.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float3 Reflect3D(float3 vector, float3 normal)
    {
        var res = GeometryGm.Reflect3D(vector.x, vector.y, vector.z, normal.x, normal.y, normal.z);
        return new float3(res.x, res.y, res.z);
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
        var res = GeometryGm.Reflect3D(vector.x, vector.y, vector.z, normal.x, normal.y, normal.z);
        return new Vector3(res.x, res.y, res.z);
    }
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
    /// <summary>
    /// Calculates the squared distance between two 2D points.
    /// </summary>
    /// <param name="point1">The first point.</param>
    /// <param name="point2">The second point.</param>
    /// <returns>The squared distance between the two points, avoiding an expensive square root operation.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float GetDistanceSquared(float2 point1, float2 point2)
    {
        float dx = point2.x - point1.x;
        float dy = point2.y - point1.y;
        return (dx * dx) + (dy * dy);
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
        float dx = point2.x - point1.x;
        float dy = point2.y - point1.y;
        return (dx * dx) + (dy * dy);
    }
    /// <summary>
    /// Calculates the Euclidean distance between two points in 3D space.
    /// </summary>
    /// <param name="point1">The first point.</param>
    /// <param name="point2">Thesecond point.</param>
    /// <returns>The distance between the two points in 3D space.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float GetDistance3D(float3 point1, float3 point2)
    {
        float dx = point2.x - point1.x;
        float dy = point2.y - point1.y;
        float dz = point2.z - point1.z;
        return MathF.Sqrt((dx * dx) + (dy * dy) + (dz * dz));
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
        float dx = point2.x - point1.x;
        float dy = point2.y - point1.y;
        float dz = point2.z - point1.z;
        return MathF.Sqrt((dx * dx) + (dy * dy) + (dz * dz));
    }
}