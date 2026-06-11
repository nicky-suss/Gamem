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
        T dot = VectorMath.GetDotProduct(x, y, normalX, normalY);
        T two = T.CreateChecked(2);
        return (x - two * dot * normalX, y - two * dot * normalY);
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
        T dot = VectorMath.GetDotProduct3D(x, y, z, normalX, normalY, normalZ);
        T two = T.CreateChecked(2);
        return (x - two * dot * normalX, y - two * dot * normalY, z - two * dot * normalZ);
    }
    /// <summary>
    /// Converts an angle from degrees to radians.
    /// </summary>
    /// <typeparam name="T">A floating-point type that implements <see cref="IFloatingPointIeee754{T}"/>.</typeparam>
    /// <param name="degrees">The angle in degrees.</param>
    /// <returns>The angle in radians.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T ToRadians<T>(T degrees) where T : IFloatingPointIeee754<T> => degrees * (T.Pi / T.CreateChecked(180));
    /// <summary>
    /// Converts an angle from radians to degrees.
    /// </summary>
    /// <typeparam name="T">A floating-point type that implements <see cref="IFloatingPointIeee754{T}"/>.</typeparam>
    /// <param name="radians">The angle in radians.</param>
    /// <returns>The angle in degrees.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T ToDegrees<T>(T radians) where T : IFloatingPointIeee754<T> => radians * (T.CreateChecked(180) / T.Pi);
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
    /// Provides static methods for basic 2D intersection and collision detection.
    /// </summary>
    public static class Collision
    {
        /// <summary>
        /// Checks for an intersection between two circles.
        /// </summary>
        /// <typeparam name="T">A floating-point type that implements <see cref="IFloatingPointIeee754{T}"/>.</typeparam>
        /// <param name="x1">The X-coordinate of the first circle's center.</param>
        /// <param name="y1">The Y-coordinate of the first circle's center.</param>
        /// <param name="radius1">The radius of the first circle.</param>
        /// <param name="x2">The X-coordinate of the second circle's center.</param>
        /// <param name="y2">The Y-coordinate of the second circle's center.</param>
        /// <param name="radius2">The radius of the second circle.</param>
        /// <returns>True if the circles intersect or touch; otherwise, false.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool CheckCircleVsCircle<T>(T x1, T y1, T radius1, T x2, T y2, T radius2) where T : IFloatingPointIeee754<T>
        {
            return GetDistanceSquared(x1, y1, x2, y2) <= (radius1 + radius2) * (radius1 + radius2);
        }
        /// <summary>
        /// Checks for an intersection between two Axis-Aligned Bounding Boxes (AABB).
        /// </summary>
        /// <typeparam name="T">A floating-point type that implements <see cref="IFloatingPointIeee754{T}"/>.</typeparam>
        /// <param name="x1">The minimum X-coordinate (left edge) of the first box.</param>
        /// <param name="y1">The minimum Y-coordinate (top/bottom edge) of the first box.</param>
        /// <param name="width1">The total width of the first box.</param>
        /// <param name="height1">The total height of the first box.</param>
        /// <param name="x2">The minimum X-coordinate (left edge) of the second box.</param>
        /// <param name="y2">The minimum Y-coordinate (top/bottom edge) of the second box.</param>
        /// <param name="width2">The total width of the second box.</param>
        /// <param name="height2">The total height of the second box.</param>
        /// <returns>True if the bounding boxes overlap or touch; otherwise, false.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool CheckAABBVsAABB<T>(T x1, T y1, T width1, T height1, T x2, T y2, T width2, T height2) where T : IFloatingPointIeee754<T>
        {
            return (x1 + width1) >= x2 && x1 <= (x2 + width2) && (y1 + height1) >= y2 && y1 <= (y2 + height2);
        }
        /// <summary>
        /// Checks for an intersection between a circle and an Axis-Aligned Bounding Box (AABB).
        /// </summary>
        /// <typeparam name="T">A floating-point type that implements <see cref="IFloatingPointIeee754{T}"/>.</typeparam>
        /// <param name="circleX">The X-coordinate of the circle's center.</param>
        /// <param name="circleY">The Y-coordinate of the circle's center.</param>
        /// <param name="radius">The radius of the circle.</param>
        /// <param name="aabbX">The minimum X-coordinate (left edge) of the box.</param>
        /// <param name="aabbY">The minimum Y-coordinate (top/bottom edge) of the box.</param>
        /// <param name="width">The total width of the box.</param>
        /// <param name="height">The total height of the box.</param>
        /// <returns>True if the circle intersects or touches the bounding box; otherwise, false.</returns>
        public static bool CheckCircleVsAABB<T>(T circleX, T circleY, T radius, T aabbX, T aabbY, T width, T height) where T : IFloatingPointIeee754<T>
        {
            T closestX = T.Clamp(circleX, aabbX, aabbX + width);
            T closestY = T.Clamp(circleY, aabbY, aabbY + height);

            T deltaX = circleX - closestX;
            T deltaY = circleY - closestY;

            T distanceSquare = (deltaX * deltaX) + (deltaY * deltaY);

            return distanceSquare <= (radius * radius);
        }
    }
    /// <summary>
    /// Provides static methods for vector mathematics in 2D and 3D spaces.
    /// </summary>
    public static class VectorMath
    {
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
        /// Calculates the magnitude (length) of a 2D vector.
        /// </summary>
        /// <typeparam name="T">A floating-point type that implements <see cref="IFloatingPointIeee754{T}"/>.</typeparam>
        /// <param name="x">The X-component of the vector.</param>
        /// <param name="y">The Y-component of the vector.</param>
        /// <returns>The magnitude of the 2D vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T GetMagnitude<T>(T x, T y) where T : IFloatingPointIeee754<T> => T.Sqrt((x * x) + (y * y));
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
            if (lengthA <= T.CreateChecked(1e-5) || lengthB <= T.CreateChecked(1e-5))
                return T.Zero;
            T A = dotProduct / (lengthA * lengthB);
            A = T.Clamp(A, -T.One, T.One);
            return T.Acos(A);
        }
        //TODO CLOSEST POINTS ON TWO LINES
    }
}