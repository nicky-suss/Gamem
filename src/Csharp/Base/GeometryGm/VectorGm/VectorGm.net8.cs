using System;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace Gamem;

/// <summary>
/// Provides static methods for vector mathematics in 2D and 3D spaces.
/// </summary>
public static partial class VectorGm
{

    //! ====================================
    //! THIS PART OF THE CODE SUPPORTS .NET 8, 9, 10 AND MORE
    //! ====================================

    /// <summary>
    /// Calculates the dot product of two 2D vectors.
    /// </summary>
    /// <param name="x1">The X-component of the first vector.</param>
    /// <param name="y1">The Y-component of the first vector.</param>
    /// <param name="x2">The X-component of the second vector.</param>
    /// <param name="y2">The Y-component of the second vector.</param>
    /// <returns>The scalar dot product of the two 2D vectors.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T GetDotProduct<T>(T x1, T y1, T x2, T y2) where T : IFloatingPointIeee754<T> => (x1 * x2) + (y1 * y2);
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
    /// <param name="x1">The X-component of the first vector.</param>
    /// <param name="y1">The Y-component of the first vector.</param>
    /// <param name="z1">The Z-component of the first vector.</param>
    /// <param name="x2">The X-component of the second vector.</param>
    /// <param name="y2">The Y-component of the second vector.</param>
    /// <param name="z2">The Z-component of the second vector.</param>
    /// <returns>The scalar dot product of the two 3D vectors.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T GetDotProduct3D<T>(T x1, T y1, T z1, T x2, T y2, T z2) where T : IFloatingPointIeee754<T> => (x1 * x2) + (y1 * y2) + (z1 * z2);
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
    /// <typeparam name="T">A floating-point type that implements <see cref="IFloatingPointIeee754{T}"/>.</typeparam>
    /// <param name="x">The X-component of the vector.</param>
    /// <param name="y">The Y-component of the vector.</param>
    /// <returns>The magnitude of the 2D vector.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T GetMagnitude<T>(T x, T y) where T : IFloatingPointIeee754<T> => T.Sqrt((x * x) + (y * y));
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
    /// <typeparam name="T">A floating-point type that implements <see cref="IFloatingPointIeee754{T}"/>.</typeparam>
    /// <param name="x">The X-component of the vector.</param>
    /// <param name="y">The Y-component of the vector.</param>
    /// <param name="z">The Z-component of the vector.</param>
    /// <returns>The magnitude of the 3D vector.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T GetMagnitude3D<T>(T x, T y, T z) where T : IFloatingPointIeee754<T> => T.Sqrt((x * x) + (y * y) + (z * z));
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
    /// <typeparam name="T">A floating-point type that implements <see cref="IFloatingPointIeee754{T}"/>.</typeparam>
    /// <param name="x1">The X-component of the first vector.</param>
    /// <param name="y1">The Y-component of the first vector.</param>
    /// <param name="z1">The Z-component of the first vector.</param>
    /// <param name="x2">The X-component of the second vector.</param>
    /// <param name="y2">The Y-component of the second vector.</param>
    /// <param name="z2">The Z-component of the second vector.</param>
    /// <returns>A tuple representing the resulting 3D vector perpendicular to both input vectors</returns>
    public static (T x, T y, T z) GetCrossProduct<T>(T x1, T y1, T z1, T x2, T y2, T z2) where T : IFloatingPointIeee754<T>
    {
        return (
            (y1 * z2) - (z1 * y2),
            (z1 * x2) - (x1 * z2),
            (x1 * y2) - (y1 * x2)
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
            (vector1.Y * vector2.Z) - (vector1.Z * vector2.Y),
            (vector1.Z * vector2.X) - (vector1.X * vector2.Z),
            (vector1.X * vector2.Y) - (vector1.Y * vector2.X)
        );
    }
    /// <summary>
    /// Calculates the angle between two vectors in radians using their dot product and magnitudes.
    /// </summary>
    /// <typeparam name="T">A floating-point type that implements <see cref="IFloatingPointIeee754{T}"/>.</typeparam>
    /// <param name="dotProduct">The dot product of the two vectors.</param>
    /// <param name="lengthA">The magnitude (length) of the first vector.</param>
    /// <param name="lengthB">The magnitude (length) of the second vector.</param>
    /// <returns>The angle between the vectors in radians.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T GetAngleBetween<T>(T dotProduct, T lengthA, T lengthB) where T : IFloatingPointIeee754<T>
    {
        if (T.IsZero(lengthA) || T.IsNaN(lengthA) || T.IsZero(lengthB) || T.IsNaN(lengthB))
            return T.Zero;
        T A = dotProduct / (lengthA * lengthB);
        A = T.Clamp(A, -T.One, T.One);
        return T.Acos(A);
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
    /// Calculates the angle in radians from a starting point to a target point in 2D space.
    /// </summary>
    /// <typeparam name="T">A floating-point type that implements <see cref="IFloatingPointIeee754{T}"/>.</typeparam>
    /// <param name="fromX">The X-coordinate of the starting position.</param>
    /// <param name="fromY">The Y-coordinate of the starting position.</param>
    /// <param name="toX">The X-coordinate of the target position.</param>
    /// <param name="toY">The Y-coordinate of the target position.</param>
    /// <returns>The angle in radians in the range (-π, π].</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T GetAngleToTarget<T>(T fromX, T fromY, T toX, T toY) where T : IFloatingPointIeee754<T> => T.Atan2(toY - fromY, toX - fromX);
    /// <summary>
    /// Calculates the angle in radians from a starting vector to a target vector in 2D space.
    /// </summary>
    /// <param name="from">The starting position vector.</param>
    /// <param name="to">The target position vector.</param>
    /// <returns>The angle in radians in the range (-π, π].</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float GetAngleToTarget(Vector2 from, Vector2 to) => float.Atan2(to.Y - from.Y, to.X - from.X);
}