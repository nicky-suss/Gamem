using Gamem;
using UnityEngine;
using Unity.Mathematics;
using System.Runtime.CompilerServices;
using System;

namespace Gamem.Unity;

/// <summary>
/// Provides static methods for vector mathematics in 2D and 3D spaces for Unity
/// </summary>
public static class VectorGmUnity
{
    /// <summary>
    /// Returns the squared length of a 3D vector
    /// </summary>
    /// <param name="vector">The vector</param>
    /// <returns>The squared length of the vector</returns>
    public static float MagnitudeSquared(float3 vector)
    {
        float num = vector.x * vector.x;
        float num2 = vector.y * vector.y;
        float num3 = vector.z * vector.z;
        return num + num2 + num3;
    }
    /// <summary>
    /// Returns the squared length of a 3D vector
    /// </summary>
    /// <param name="vector">The vector</param>
    /// <returns>The squared length of the vector</returns>
    public static float MagnitudeSquared(Vector3 vector)
    {
        float num = vector.x * vector.x;
        float num2 = vector.y * vector.y;
        float num3 = vector.z * vector.z;
        return num + num2 + num3;
    }
    /// <summary>
    /// Calculates the dot product of two 2D vectors.
    /// </summary>
    /// <param name="vector1">The first vector.</param>
    /// <param name="vector2">The second vector.</param>
    /// <returns>The scalar dot product of the two 2D vectors.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float GetDotProduct(Vector2 vector1, Vector2 vector2) => (vector1.x * vector2.x) + (vector1.y * vector2.y);
    /// <summary>
    /// Calculates the dot product of two 2D vectors.
    /// </summary>
    /// <param name="vector1">The first vector.</param>
    /// <param name="vector2">The second vector.</param>
    /// <returns>The scalar dot product of the two 2D vectors.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float GetDotProduct(float2 vector1, float2 vector2) => (vector1.x * vector2.x) + (vector1.y * vector2.y);
    /// <summary>
    /// Calculates the dot product of two 3D vectors.
    /// </summary>
    /// <param name="vector1">The first vector.</param>
    /// <param name="vector2">The second vector.</param>
    /// <returns>The scalar dot product of the two 3D vectors.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float GetDotProduct3D(float3 vector1, float3 vector2) => (vector1.x * vector2.x) + (vector1.y * vector2.y) + (vector1.z * vector2.z);
    /// <summary>
    /// Calculates the dot product of two 3D vectors.
    /// </summary>
    /// <param name="vector1">The first vector.</param>
    /// <param name="vector2">The second vector.</param>
    /// <returns>The scalar dot product of the two 3D vectors.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float GetDotProduct3D(Vector3 vector1, Vector3 vector2) => (vector1.x * vector2.x) + (vector1.y * vector2.y) + (vector1.z * vector2.z);
    /// <summary>
    /// Calculates the magnitude (length) of a 2D vector.
    /// </summary>
    /// <param name="vector">The vector.</param>
    /// <returns>The magnitude of the 2D vector.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float GetMagnitude(Vector2 vector) => MathF.Sqrt((vector.x * vector.x) + (vector.y * vector.y));
    /// <summary>
    /// Calculates the magnitude (length) of a 2D vector.
    /// </summary>
    /// <param name="vector">The vector.</param>
    /// <returns>The magnitude of the 2D vector.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float GetMagnitude(float2 vector) => MathF.Sqrt((vector.x * vector.x) + (vector.y * vector.y));
    /// <summary>
    /// Calculates the cross product of two 3D vectors.
    /// </summary>
    /// <param name="vector1">The first vector.</param>
    /// <param name="vector2">The second vector.</param>
    /// <returns>A vector representing the resulting 3D vector perpendicular to both input vectors</returns>
    public static float3 GetCrossProduct(float3 vector1, float3 vector2)
    {
        return new float3(
            (vector1.y * vector2.z) - (vector1.z * vector2.y),
            (vector1.z * vector2.x) - (vector1.x * vector2.z),
            (vector1.x * vector2.y) - (vector1.y * vector2.x)
        );
    }
    /// <summary>
    /// Calculates the cross product of two 3D vectors.
    /// </summary>
    /// <param name="vector1">The first vector.</param>
    /// <param name="vector2">The second vector.</param>
    /// <returns>A vector representing the resulting 3D vector perpendicular to both input vectors</returns>
    public static Vector3 GetCrossProduct(Vector3 vector1, Vector3 vector2)
    {
        return new Vector3(
            (vector1.y * vector2.z) - (vector1.z * vector2.y),
            (vector1.z * vector2.x) - (vector1.x * vector2.z),
            (vector1.x * vector2.y) - (vector1.y * vector2.x)
        );
    }
    /// <summary>
    /// Finds the closest point on a 3D line segment AB to a given point P, clamping the result to the segment bounds.
    /// </summary>
    /// <param name="A">The start point of the line segment.</param>
    /// <param name="B">The end point of the line segment.</param>
    /// <param name="P">The target point in 3D space.</param>
    /// <returns>The position on the segment AB that is nearest to point P.</returns>
    public static float3 ClosestPointOnLine(float3 A, float3 B, float3 P)
    {
        float3 AB = B - A;
        float3 AP = P - A;
        if (GetDotProduct3D(AB, AB) <= 1e-5)
            return A;
        float t = GetDotProduct3D(AP, AB) / GetDotProduct3D(AB, AB);
        if (t <= 0)
            return A;
        if (t >= 1)
            return B;
        return A + t * AB;
    }
    /// <summary>
    /// Finds the closest point on a 3D line segment AB to a given point P, clamping the result to the segment bounds.
    /// </summary>
    /// <param name="A">The start point of the line segment.</param>
    /// <param name="B">The end point of the line segment.</param>
    /// <param name="P">The target point in 3D space.</param>
    /// <returns>The position on the segment AB that is nearest to point P.</returns>
    public static Vector3 ClosestPointOnLine(Vector3 A, Vector3 B, Vector3 P)
    {
        Vector3 AB = B - A;
        Vector3 AP = P - A;
        if (GetDotProduct3D(AB, AB) <= 1e-5)
            return A;
        float t = GetDotProduct3D(AP, AB) / GetDotProduct3D(AB, AB);
        if (t <= 0)
            return A;
        if (t >= 1)
            return B;
        return A + t * AB;
    }
    /// <summary>
    /// Calculates the 2D intersection point of two infinitely long lines.
    /// </summary>
    /// <param name="vector1">The first point on the first line.</param>
    /// <param name="vector2">The second point on the first line.</param>
    /// <param name="vector3">The first point on the second line.</param>
    /// <param name="vector4">The second point on the second line.</param>
    /// <returns>A <see cref="float2"/> representing the intersection point, or a vector of <see cref="float.NaN"/> values if the lines are parallel or coincident.</returns>
    public static float2 LineIntersection(float2 vector1, float2 vector2, float2 vector3, float2 vector4)
    {
        float div = (vector1.x - vector2.x) * (vector3.y - vector4.y) - (vector1.y - vector2.y) * (vector3.x - vector4.x);
        if (Math.Abs(div) <= 1e-5)
        {
            return new float2(float.NaN, float.NaN);
        }
        float d1 = vector1.x * vector2.y - vector1.y * vector2.x;
        float d2 = vector3.x * vector4.y - vector3.y * vector4.x;

        float Px = d1 * (vector3.x - vector4.x) - (vector1.x - vector2.x) * d2;
        float Py = d1 * (vector3.y - vector4.y) - (vector1.y - vector2.y) * d2;

        return new float2(Px / div, Py / div);
    }
    /// <summary>
    /// Calculates the 2D intersection point of two infinitely long lines.
    /// </summary>
    /// <param name="vector1">The first point on the first line.</param>
    /// <param name="vector2">The second point on the first line.</param>
    /// <param name="vector3">The first point on the second line.</param>
    /// <param name="vector4">The second point on the second line.</param>
    /// <returns>A <see cref="Vector2"/> representing the intersection point, or a vector of <see cref="float.NaN"/> values if the lines are parallel or coincident.</returns>
    public static Vector2 LineIntersection(Vector2 vector1, Vector2 vector2, Vector2 vector3, Vector2 vector4)
    {
        float div = (vector1.x - vector2.x) * (vector3.y - vector4.y) - (vector1.y - vector2.y) * (vector3.x - vector4.x);
        if (Math.Abs(div) <= 1e-5)
        {
            return new Vector2(float.NaN, float.NaN);
        }
        float d1 = vector1.x * vector2.y - vector1.y * vector2.x;
        float d2 = vector3.x * vector4.y - vector3.y * vector4.x;

        float Px = d1 * (vector3.x - vector4.x) - (vector1.x - vector2.x) * d2;
        float Py = d1 * (vector3.y - vector4.y) - (vector1.y - vector2.y) * d2;

        return new Vector2(Px / div, Py / div);
    }
    /// <summary>
    /// Calculates the angle in radians from a starting vector to a target vector in 2D space.
    /// </summary>
    /// <param name="from">The starting position vector.</param>
    /// <param name="to">The target position vector.</param>
    /// <returns>The angle in radians in the range (-π, π].</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float GetAngleToTarget(float2 from, float2 to) => Mathf.Atan2(to.y - from.y, to.x - from.x);
    /// <summary>
    /// Calculates the angle in radians from a starting vector to a target vector in 2D space.
    /// </summary>
    /// <param name="from">The starting position vector.</param>
    /// <param name="to">The target position vector.</param>
    /// <returns>The angle in radians in the range (-π, π].</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float GetAngleToTarget(Vector2 from, Vector2 to) => Mathf.Atan2(to.y - from.y, to.x - from.x);
}