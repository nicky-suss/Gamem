using System;
using System.Runtime.CompilerServices;
using System.Numerics;

namespace Gamem;

/// <summary>
/// Provides static methods for basic 2D intersection and collision detection.
/// </summary>
public static partial class CollisionGm
{

    //! ====================================
    //! THIS PART OF THE CODE SUPPORTS .NET 8, 9, 10 AND MORE
    //! ====================================

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
        return GeometryGm.GetDistanceSquared(x1, y1, x2, y2) <= (radius1 + radius2) * (radius1 + radius2);
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
        return GeometryGm.GetDistanceSquared(center1.X, center1.Y, center2.X, center2.Y) <= (radius1 + radius2) * (radius1 + radius2);
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