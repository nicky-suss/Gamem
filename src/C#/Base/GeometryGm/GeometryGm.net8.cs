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
        T dot = VectorMath.GetDotProduct3D(x, y, z, normalX, normalY, normalZ);
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
        float dot = VectorMath.GetDotProduct3D(vector.X, vector.Y, vector.Z, normal.X, normal.Y, normal.Z);
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
        /// Checks for an intersection between two circles.
        /// </summary>
        /// <param name="center1">The first circle's center.</param>
        /// <param name="radius1">The radius of the first circle.</param>
        /// <param name="center2">The second circle's center.</param>
        /// <param name="radius2">The radius of the second circle.</param>
        /// <returns>True if the circles intersect or touch; otherwise, false.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool CheckCircleVsCircle(Vector2 center1, float radius1, Vector2 center2, float radius2)
        {
            return GetDistanceSquared(center1.X, center1.Y, center2.X, center2.Y) <= (radius1 + radius2) * (radius1 + radius2);
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
        /// Checks for an intersection between two Axis-Aligned Bounding Boxes (AABB).
        /// </summary>
        /// <param name="box1">The first box.</param>
        /// <param name="width1">The total width of the first box.</param>
        /// <param name="height1">The total height of the first box.</param>
        /// <param name="box2">The second box.</param>
        /// <param name="width2">The total width of the second box.</param>
        /// <param name="height2">The total height of the second box.</param>
        /// <returns>True if the bounding boxes overlap or touch; otherwise, false.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool CheckAABBVsAABB(Vector2 box1, float width1, float height1, Vector2 box2, float width2, float height2)
        {
            return (box1.X + width1) >= box2.X && box1.X <= (box2.X + width2) && (box1.Y + height1) >= box2.Y && box1.Y <= (box2.Y + height2);
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
        /// <summary>
        /// Checks for an intersection between a circle and an Axis-Aligned Bounding Box (AABB).
        /// </summary>
        /// <param name="circle">The circle's center.</param>
        /// <param name="radius">The radius of the circle.</param>
        /// <param name="aabb">The minimum coordinate of the box.</param>
        /// <param name="width">The total width of the box.</param>
        /// <param name="height">The total height of the box.</param>
        /// <returns>True if the circle intersects or touches the bounding box; otherwise, false.</returns>
        public static bool CheckCircleVsAABB(Vector2 circle, float radius, Vector2 aabb, float width, float height)
        {
            float closestX = Math.Clamp(circle.X, aabb.X, aabb.X + width);
            float closestY = Math.Clamp(circle.Y, aabb.Y, aabb.Y + height);

            float deltaX = circle.X - closestX;
            float deltaY = circle.Y - closestY;

            float distanceSquare = (deltaX * deltaX) + (deltaY * deltaY);

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
    }
}