using System;
using Godot;
using Gamem;
using System.Runtime.CompilerServices;

namespace Gamem.Godot;

/// <summary>
/// Provides static methods for vector mathematics in 2D and 3D spaces for Godot
/// </summary>
public static class VectorGmGodot
{
    /// <summary>
    /// Calculates the dot product of two 2D vectors.
    /// </summary>
    /// <param name="vector1">The first vector.</param>
    /// <param name="vector2">The second vector.</param>
    /// <returns>The scalar dot product of the two 2D vectors.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float GetDotProduct(Vector2 vector1, Vector2 vector2) => (vector1.X * vector2.X) + (vector1.Y * vector2.Y);
    /// <summary>
    /// Calculates the dot product of two 3D vectors.
    /// </summary>
    /// <param name="vector1">The first vector.</param>
    /// <param name="vector2">The second vector.</param>
    /// <returns>The scalar dot product of the two 3D vectors.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float GetDotProduct3D(Vector3 vector1, Vector3 vector2) => (vector1.X * vector2.X) + (vector1.Y * vector2.Y) + (vector1.Z * vector2.Z);
    /// <summary>
    /// Calculates the magnitude (length) of a 2D vector.
    /// </summary>
    /// <param name="vector">The vector.</param>
    /// <returns>The magnitude of the 2D vector.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float GetMagnitude(Vector2 vector) => MathF.Sqrt((vector.X * vector.X) + (vector.Y * vector.Y));
    /// <summary>
    /// Calculates the magnitude (length) of a 3D vector.
    /// </summary>
    /// <param name="vector">The vector.</param>
    /// <returns>The magnitude of the 3D vector.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float GetMagnitude3D(Vector3 vector) => MathF.Sqrt((vector.X * vector.X) + (vector.Y * vector.Y) + (vector.Z * vector.Z));
    /// <summary>
    /// Calculates the cross product of two 3D vectors.
    /// </summary>
    /// <param name="vector1">The first vector.</param>
    /// <param name="vector2">The second vector.</param>
    /// <returns>A vector representing the resulting 3D vector perpendicular to both input vectors</returns>
    public static Vector3 GetCrossProduct(Vector3 vector1, Vector3 vector2)
    {
        return new Vector3(
            (vector1.Y * vector2.Z) - (vector1.Z * vector2.Y),
            (vector1.Z * vector2.X) - (vector1.X * vector2.Z),
            (vector1.X * vector2.Y) - (vector1.Y * vector2.X)
        );
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
    /// <returns>A <see cref="Vector2"/> representing the intersection point, or a vector of <see cref="float.NaN"/> values if the lines are parallel or coincident.</returns>
    public static Vector2 LineIntersection(Vector2 vector1, Vector2 vector2, Vector2 vector3, Vector2 vector4)
    {
        float div = (vector1.X - vector2.X) * (vector3.Y - vector4.Y) - (vector1.Y - vector2.Y) * (vector3.X - vector4.X);
        if (Math.Abs(div) <= 1e-5)
        {
            return new Vector2(float.NaN, float.NaN);
        }
        float d1 = vector1.X * vector2.Y - vector1.Y * vector2.X;
        float d2 = vector3.X * vector4.Y - vector3.Y * vector4.X;

        float Px = d1 * (vector3.X - vector4.X) - (vector1.X - vector2.X) * d2;
        float Py = d1 * (vector3.Y - vector4.Y) - (vector1.Y - vector2.Y) * d2;

        return new Vector2(Px / div, Py / div);
    }
    /// <summary>
    /// Calculates the angle in radians from a starting vector to a target vector in 2D space.
    /// </summary>
    /// <param name="from">The starting position vector.</param>
    /// <param name="to">The target position vector.</param>
    /// <returns>The angle in radians in the range (-π, π].</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float GetAngleToTarget(Vector2 from, Vector2 to) => float.Atan2(to.Y - from.Y, to.X - from.X);
}