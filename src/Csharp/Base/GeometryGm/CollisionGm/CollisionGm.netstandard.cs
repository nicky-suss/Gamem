using System;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace Gamem
{
    /// <summary>
    /// Provides static methods for basic 2D intersection and collision detection.
    /// </summary>
    public static partial class CollisionGm
    {

        //! ========================
        //! THIS PART OF THE CODE SUPPORTS OLDER VERSIONS OF .NET
        //! =========================

        /// <summary>
        /// Checks for an intersection between two circles.
        /// </summary>
        /// <param name="x1">The X-coordinate of the first circle's center.</param>
        /// <param name="y1">The Y-coordinate of the first circle's center.</param>
        /// <param name="radius1">The radius of the first circle.</param>
        /// <param name="x2">The X-coordinate of the second circle's center.</param>
        /// <param name="y2">The Y-coordinate of the second circle's center.</param>
        /// <param name="radius2">The radius of the second circle.</param>
        /// <returns>True if the circles intersect or touch; otherwise, false.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool CheckCircleVsCircle(double x1, double y1, double radius1, double x2, double y2, double radius2)
        {
            return GeometryGm.GetDistanceSquared(x1, y1, x2, y2) <= (radius1 + radius2) * (radius1 + radius2);
        }
        /// <inheritdoc cref="CheckCircleVsCircle(double, double, double, double, double, double)"/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool CheckCircleVsCircle(float x1, float y1, float radius1, float x2, float y2, float radius2)
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
        public static bool CheckAABBVsAABB(double x1, double y1, double width1, double height1, double x2, double y2, double width2, double height2)
        {
            return (x1 + width1) >= x2 && x1 <= (x2 + width2) && (y1 + height1) >= y2 && y1 <= (y2 + height2);
        }
        /// <inheritdoc cref="CheckAABBVsAABB(double, double, double, double, double, double, double, double)"/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool CheckAABBVsAABB(float x1, float y1, float width1, float height1, float x2, float y2, float width2, float height2)
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
        /// <param name="circleX">The X-coordinate of the circle's center.</param>
        /// <param name="circleY">The Y-coordinate of the circle's center.</param>
        /// <param name="radius">The radius of the circle.</param>
        /// <param name="aabbX">The minimum X-coordinate (left edge) of the box.</param>
        /// <param name="aabbY">The minimum Y-coordinate (top/bottom edge) of the box.</param>
        /// <param name="width">The total width of the box.</param>
        /// <param name="height">The total height of the box.</param>
        /// <returns>True if the circle intersects or touches the bounding box; otherwise, false.</returns>
        public static bool CheckCircleVsAABB(double circleX, double circleY, double radius, double aabbX, double aabbY, double width, double height)
        {
            double closestX = Math.Max(aabbX, Math.Min(circleX, aabbX + width));
            double closestY = Math.Max(aabbY, Math.Min(circleY, aabbY + height));

            double deltaX = circleX - closestX;
            double deltaY = circleY - closestY;

            double distanceSquare = (deltaX * deltaX) + (deltaY * deltaY);

            return distanceSquare <= (radius * radius);
        }
        /// <inheritdoc cref="CheckCircleVsAABB(double, double, double, double, double, double, double)"/>
        public static bool CheckCircleVsAABB(float circleX, float circleY, float radius, float aabbX, float aabbY, float width, float height)
        {
            float closestX = Math.Max(aabbX, Math.Min(circleX, aabbX + width));
            float closestY = Math.Max(aabbY, Math.Min(circleY, aabbY + height));

            float deltaX = circleX - closestX;
            float deltaY = circleY - closestY;

            float distanceSquare = (deltaX * deltaX) + (deltaY * deltaY);

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
            return CheckCircleVsAABB(circle.X, circle.Y, radius, aabb.X, aabb.Y, width, height);
        }
        /// <summary>
        /// Determines whether two 2D line segments intersect each other.
        /// </summary>
        /// <param name="p0X">The X-coordinate of the first point of the first segment.</param>
        /// <param name="p0Y">The Y-coordinate of the first point of the first segment.</param>
        /// <param name="p1X">The X-coordinate of the second point of the first segment.</param>
        /// <param name="p1Y">The Y-coordinate of the second point of the first segment.</param>
        /// <param name="p2X">The X-coordinate of the first point of the second segment.</param>
        /// <param name="p2Y">The Y-coordinate of the first point of the second segment.</param>
        /// <param name="p3X">The X-coordinate of the second point of the second segment.</param>
        /// <param name="p3Y">The Y-coordinate of the second point of the second segment.</param>
        /// <returns><see langword="true"/> if the two line segments intersect; otherwise, <see langword="false"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool CheckSegmentVsSegment(double p0X, double p0Y, double p1X, double p1Y, double p2X, double p2Y, double p3X, double p3Y)
        {
            double D = (p1X - p0X) * (p3Y - p2Y) - (p1Y - p0Y) * (p3X - p2X);

            double t1 = MathGm.SafeDivide((p2X - p0X) * (p3Y - p2Y) - (p2Y - p0Y) * (p3X - p2X), D);
            double t2 = MathGm.SafeDivide((p2X - p0X) * (p1Y - p0Y) - (p2Y - p0Y) * (p1X - p0X), D);

            return (D != 0.0) && (0.0 <= t1 && t1 <= 1.0) && (0.0 <= t2 && t2 <= 1.0);
        }
        /// <summary>
        /// Determines whether two 2D line segments intersect each other.
        /// </summary>
        /// <param name="p0X">The X-coordinate of the first point of the first segment.</param>
        /// <param name="p0Y">The Y-coordinate of the first point of the first segment.</param>
        /// <param name="p1X">The X-coordinate of the second point of the first segment.</param>
        /// <param name="p1Y">The Y-coordinate of the second point of the first segment.</param>
        /// <param name="p2X">The X-coordinate of the first point of the second segment.</param>
        /// <param name="p2Y">The Y-coordinate of the first point of the second segment.</param>
        /// <param name="p3X">The X-coordinate of the second point of the second segment.</param>
        /// <param name="p3Y">The Y-coordinate of the second point of the second segment.</param>
        /// <returns><see langword="true"/> if the two line segments intersect; otherwise, <see langword="false"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool CheckSegmentVsSegment(float p0X, float p0Y, float p1X, float p1Y, float p2X, float p2Y, float p3X, float p3Y)
        {
            float D = (p1X - p0X) * (p3Y - p2Y) - (p1Y - p0Y) * (p3X - p2X);

            float t1 = MathGm.SafeDivide((p2X - p0X) * (p3Y - p2Y) - (p2Y - p0Y) * (p3X - p2X), D);
            float t2 = MathGm.SafeDivide((p2X - p0X) * (p1Y - p0Y) - (p2Y - p0Y) * (p1X - p0X), D);

            return (D != 0.0) && (0.0 <= t1 && t1 <= 1.0) && (0.0 <= t2 && t2 <= 1.0);
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
}