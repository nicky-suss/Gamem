using System;
using System.Runtime.CompilerServices;
using System.Numerics;

namespace Gamem;

/// <summary>
/// Provides static methods for Geometry calculations
/// </summary>
public static partial class GeometryGm
{

    //! ====================================
    //! THIS PART OF THE CODE SUPPORTS .NET 8, 9, 10 AND MORE
    //! ====================================

    /// <summary>
    /// Reflects a 2D vector off a surface defined by a normal vector.
    /// </summary>
    /// <typeparam name="T">A floating-point type that implements <see cref="IFloatingPointIeee754{T}"/>.</typeparam>
    /// <param name="x">The X component of the incident vector.</param>
    /// <param name="y">The Y component of the incident vector.</param>
    /// <param name="normalX">The X component of the surface normal (should be normalized).</param>
    /// <param name="normalY">The Y component of the surface normal (should be normalized).</param>
    /// <returns>A tuple containing the X and Y components of the reflected vector.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static (T x, T y) Reflect<T>(T x, T y, T normalX, T normalY) where T : IFloatingPointIeee754<T>
    {
        T dot = VectorGm.GetDotProduct(x, y, normalX, normalY);
        T two = Cache<T>.T2;
        return (x - two * dot * normalX, y - two * dot * normalY);
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
        var result = Reflect(vector.X, vector.Y, normal.X, normal.Y);
        return new Vector2(result.x, result.y);
    }
    /// <summary>
    /// Reflects a 3D vector off a surface defined by a normal vector.
    /// </summary>
    /// <typeparam name="T">A floating-point type that implements <see cref="IFloatingPointIeee754{T}"/>.</typeparam>
    /// <param name="x">The X component of the incident vector.</param>
    /// <param name="y">The Y component of the incident vector.</param>
    /// <param name="z">The Z component of the incident vector.</param>
    /// <param name="normalX">The X component of the surface normal (should be normalized).</param>
    /// <param name="normalY">The Y component of the surface normal (should be normalized).</param>
    /// <param name="normalZ">The Z component of the surface normal (should be normalized).</param>
    /// <returns>A tuple containing the X, Y, and Z components of the reflected vector.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static (T x, T y, T z) Reflect3D<T>(T x, T y, T z, T normalX, T normalY, T normalZ) where T : IFloatingPointIeee754<T>
    {
        T dot = VectorGm.GetDotProduct3D(x, y, z, normalX, normalY, normalZ);
        T two = Cache<T>.T2;
        return (x - two * dot * normalX, y - two * dot * normalY, z - two * dot * normalZ);
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
        float dot = VectorGm.GetDotProduct3D(vector.X, vector.Y, vector.Z, normal.X, normal.Y, normal.Z);
        return new Vector3(vector.X - 2 * dot * normal.X, vector.Y - 2 * dot * normal.Y, vector.Z - 2 * dot * normal.Z);
    }
    /// <summary>
    /// Converts an angle from degrees to radians.
    /// </summary>
    /// <typeparam name="T">A floating-point type that implements <see cref="IFloatingPointIeee754{T}"/>.</typeparam>
    /// <param name="degrees">The angle in degrees.</param>
    /// <returns>The angle in radians.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T ToRadians<T>(T degrees) where T : IFloatingPointIeee754<T> => degrees * (T.Pi / Cache<T>.T180);
    /// <summary>
    /// Converts an angle from radians to degrees.
    /// </summary>
    /// <typeparam name="T">A floating-point type that implements <see cref="IFloatingPointIeee754{T}"/>.</typeparam>
    /// <param name="radians">The angle in radians.</param>
    /// <returns>The angle in degrees.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T ToDegrees<T>(T radians) where T : IFloatingPointIeee754<T> => radians * (Cache<T>.T180 / T.Pi);
    /// <summary>
    /// Calculates the Euclidean distance between two points in a 2D plane.
    /// </summary>
    /// <typeparam name="T">A floating-point type that implements <see cref="IFloatingPointIeee754{T}"/>.</typeparam>
    /// <param name="x1">The X-coordinate of the first point.</param>
    /// <param name="y1">The Y-coordinate of the first point.</param>
    /// <param name="x2">The X-coordinate of the second point.</param>
    /// <param name="y2">The Y-coordinate of the second point.</param>
    /// <returns>The distance between the two points in 2D space.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T GetDistance<T>(T x1, T y1, T x2, T y2) where T : IFloatingPointIeee754<T>
    {
        T dx = x2 - x1;
        T dy = y2 - y1;
        T xy = (dx * dx) + (dy * dy);
        return T.Sqrt(xy);
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
        return GetDistance(point1.X, point1.Y, point2.X, point2.Y);
    }
    /// <summary>
    /// Calculates the squared distance between two 2D points.
    /// </summary>
    /// <typeparam name="T">A floating-point type that implements <see cref="IFloatingPointIeee754{T}"/>.</typeparam>
    /// <param name="x1">The X coordinate of the first point.</param>
    /// <param name="y1">The Y coordinate of the first point.</param>
    /// <param name="x2">The X coordinate of the second point.</param>
    /// <param name="y2">The Y coordinate of the second point.</param>
    /// <returns>The squared distance between the two points, avoiding an expensive square root operation.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T GetDistanceSquared<T>(T x1, T y1, T x2, T y2) where T : IFloatingPointIeee754<T>
    {
        T dx = x2 - x1;
        T dy = y2 - y1;
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
        float dx = point2.X - point1.X;
        float dy = point2.Y - point1.Y;
        return (dx * dx) + (dy * dy);
    }
    /// <summary>
    /// Calculates the Euclidean distance between two points in 3D space.
    /// </summary>
    /// <typeparam name="T">A floating-point type that implements <see cref="IFloatingPointIeee754{T}"/>.</typeparam>
    /// <param name="x1">The X-coordinate of the first point.</param>
    /// <param name="y1">The Y-coordinate of the first point.</param>
    /// <param name="z1">The Z-coordinate of the first point.</param>
    /// <param name="x2">The X-coordinate of the second point.</param>
    /// <param name="y2">The Y-coordinate of the second point.</param>
    /// <param name="z2">The Z-coordinate of the second point.</param>
    /// <returns>The distance between the two points in 3D space.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T GetDistance3D<T>(T x1, T y1, T z1, T x2, T y2, T z2) where T : IFloatingPointIeee754<T>
    {
        T dx = x2 - x1;
        T dy = y2 - y1;
        T dz = z2 - z1;
        return T.Sqrt((dx * dx) + (dy * dy) + (dz * dz));
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
    /// <summary>
    /// Normalizes an angle in degrees into the range [0, 360).
    /// </summary>
    /// <typeparam name="T">A floating-point type that implements <see cref="IFloatingPointIeee754{T}"/>.</typeparam>
    /// <param name="angle">The input angle in degrees to normalize.</param>
    /// <returns>The equivalent angle wrapped within the range of 0 (inclusive) to 360 (exclusive) degrees.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T NormalizeAngle<T>(T angle) where T : IFloatingPointIeee754<T> => (angle % Cache<T>.T360 + T.CreateChecked(360)) % T.CreateChecked(360);
}