using Godot;
using Gamem;
using System.Runtime.CompilerServices;
using System;

namespace Gamem.Godot;

/// <summary>
/// Provides static methods for Geometry calculations for Godot
/// </summary>
public static class GeometryGmGodot
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
    /// <summary>
    /// Provides static methods for basic 2D intersection and collision detection for Godot.
    /// </summary>
    public static class CollisionGodot
    {
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
            return GeometryGm.GetDistanceSquared(center1.X, center1.Y, center2.X, center2.Y) <= (radius1 + radius2) * (radius1 + radius2);
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
    /// Provides static methods for vector mathematics in 2D and 3D spaces for Godot
    /// </summary>
    public static class VectorMathGodot
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
    }
}