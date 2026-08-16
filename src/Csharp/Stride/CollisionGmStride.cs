using Gamem;
using Stride.Core.Mathematics;
using System;
using System.Runtime.CompilerServices;

namespace Gamem.Stride;

/// <summary>
/// Provides static methods for basic 2D intersection and collision detection for MonoGame.
/// </summary>
public static class CollisionGmStride
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
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool CheckCircleVsAABB(Vector2 circle, float radius, Vector2 aabb, float width, float height)
    {
        float closestX = Math.Clamp(circle.X, aabb.X, aabb.X + width);
        float closestY = Math.Clamp(circle.Y, aabb.Y, aabb.Y + height);

        float deltaX = circle.X - closestX;
        float deltaY = circle.Y - closestY;

        float distanceSquare = (deltaX * deltaX) + (deltaY * deltaY);

        return distanceSquare <= (radius * radius);
    }
    /// <summary>
    /// Determines whether two 2D line segments defined by vectors intersect each other.
    /// </summary>
    /// <param name="p0">The starting point of the first line segment.</param>
    /// <param name="p1">The ending point of the first line segment.</param>
    /// <param name="p2">The starting point of the second line segment.</param>
    /// <param name="p3">The ending point of the second line segment.</param>
    /// <returns><see langword="true"/> if the two line segments intersect; otherwise, <see langword="false"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool CheckSegmentVsSegment(Vector2 p0, Vector2 p1, Vector2 p2, Vector2 p3)
    {
        float D = (p1.X - p0.X) * (p3.Y - p2.Y) - (p1.Y - p0.Y) * (p3.X - p2.X);

        float t1 = MathGm.SafeDivide((p2.X - p0.X) * (p3.Y - p2.Y) - (p2.Y - p0.Y) * (p3.X - p2.X), D);
        float t2 = MathGm.SafeDivide((p2.X - p0.X) * (p1.Y - p0.Y) - (p2.Y - p0.Y) * (p1.X - p0.X), D);

        return (D != 0.0) && (0.0 <= t1 && t1 <= 1.0) && (0.0 <= t2 && t2 <= 1.0);
    }
}