using System;
using System.Runtime.CompilerServices;

namespace Gamem;

/// <summary>
/// Provides static methods for Geometry calculations
/// </summary>
public static class Geometry
{
    /// <summary>
    /// Converts an angle from degrees to radians.
    /// </summary>
    /// <param name="degrees">The angle in degrees.</param>
    /// <returns>The angle in radians.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static double ToRadians(double degrees) => degrees * (Math.PI / 180.0);
    /// <summary>
    /// Converts an angle from radians to degrees.
    /// </summary>
    /// <param name="radians">The angle in radians.</param>
    /// <returns>The angle in degrees.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static double ToDegrees(double radians) => radians * (180.0 / Math.PI);
    /// <summary>
    /// Converts an angle from degrees to radians.
    /// </summary>
    /// <param name="degrees">The angle in degrees.</param>
    /// <returns>The angle in radians.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float ToRadians(float degrees) => degrees * (MathF.PI / 180.0f);
    /// <summary>
    /// Converts an angle from radians to degrees.
    /// </summary>
    /// <param name="radians">The angle in radians.</param>
    /// <returns>The angle in degrees.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float ToDegrees(float radians) => radians * (180.0f / MathF.PI);
    /// <summary>
    /// Calculates the Euclidean distance between two points in a 2D plane.
    /// </summary>
    /// <param name="x1">The X-coordinate of the first point.</param>
    /// <param name="y1">The Y-coordinate of the first point.</param>
    /// <param name="x2">The X-coordinate of the second point.</param>
    /// <param name="y2">The Y-coordinate of the second point.</param>
    /// <returns>The distance between the two points in 2D space.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static double GetDistance(double x1, double y1, double x2, double y2)
    {
        double dx = x2 - x1;
        double dy = y2 - y1;
        double xy = (dx * dx) + (dy * dy);
        return Math.Sqrt(xy);
    }
    /// <summary>
    /// Calculates the Euclidean distance between two points in a 2D plane.
    /// </summary>
    /// <param name="x1">The X-coordinate of the first point.</param>
    /// <param name="y1">The Y-coordinate of the first point.</param>
    /// <param name="x2">The X-coordinate of the second point.</param>
    /// <param name="y2">The Y-coordinate of the second point.</param>
    /// <returns>The distance between the two points in 2D space.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float GetDistance(float x1, float y1, float x2, float y2)
    {
        float dx = x2 - x1;
        float dy = y2 - y1;
        float xy = (dx * dx) + (dy * dy);
        return MathF.Sqrt(xy);
    }
    /// <summary>
    /// Calculates the Euclidean distance between two points in 3D space.
    /// </summary>
    /// <param name="x1">The X-coordinate of the first point.</param>
    /// <param name="y1">The Y-coordinate of the first point.</param>
    /// <param name="z1">The Z-coordinate of the first point.</param>
    /// <param name="x2">The X-coordinate of the second point.</param>
    /// <param name="y2">The Y-coordinate of the second point.</param>
    /// <param name="z2">The Z-coordinate of the second point.</param>
    /// <returns>The distance between the two points in 3D space.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static double GetDistance3D(double x1, double y1, double z1, double x2, double y2, double z2)
    {
        double dx = x2 - x1;
        double dy = y2 - y1;
        double dz = z2 - z1;
        return Math.Sqrt((dx * dx) + (dy * dy) + (dz * dz));
    }
    /// <summary>
    /// Calculates the Euclidean distance between two points in 3D space.
    /// </summary>
    /// <param name="x1">The X-coordinate of the first point.</param>
    /// <param name="y1">The Y-coordinate of the first point.</param>
    /// <param name="z1">The Z-coordinate of the first point.</param>
    /// <param name="x2">The X-coordinate of the second point.</param>
    /// <param name="y2">The Y-coordinate of the second point.</param>
    /// <param name="z2">The Z-coordinate of the second point.</param>
    /// <returns>The distance between the two points in 3D space.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float GetDistance3D(float x1, float y1, float z1, float x2, float y2, float z2)
    {
        float dx = x2 - x1;
        float dy = y2 - y1;
        float dz = z2 - z1;
        return MathF.Sqrt((dx * dx) + (dy * dy) + (dz * dz));
    }
    /// <summary>
    /// Provides static methods for basic 2D intersection and collision detection.
    /// </summary>
    public static class Collision
    {
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
            if (GetDistance(x1, y1, x2, y2) <= (radius1 + radius2))
                return true;
            return false;
        }
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
        public static bool CheckCircleVsCircle(float x1, float y1, float radius1, float x2, float y2, float radius2)
        {
            if (GetDistance(x1, y1, x2, y2) <= (radius1 + radius2))
                return true;
            return false;
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
            if ((x1 + width1) >= x2 && x1 <= (x2 + width2) && (y1 + height1) >= y2 && y1 <= (y2 + height2))
                return true;
            return false;
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
        public static bool CheckAABBVsAABB(float x1, float y1, float width1, float height1, float x2, float y2, float width2, float height2)
        {
            if ((x1 + width1) >= x2 && x1 <= (x2 + width2) && (y1 + height1) >= y2 && y1 <= (y2 + height2))
                return true;
            return false;
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
            double closestX = Math.Clamp(circleX, aabbX, aabbX + width);
            double closestY = Math.Clamp(circleY, aabbY, aabbY + height);

            double deltaX = circleX - closestX;
            double deltaY = circleY - closestY;

            double distanceSquare = (deltaX * deltaX) + (deltaY * deltaY);

            if (distanceSquare <= (radius * radius))
                return true;
            return false;
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
        public static bool CheckCircleVsAABB(float circleX, float circleY, float radius, float aabbX, float aabbY, float width, float height)
        {
            float closestX = Math.Clamp(circleX, aabbX, aabbX + width);
            float closestY = Math.Clamp(circleY, aabbY, aabbY + height);

            float deltaX = circleX - closestX;
            float deltaY = circleY - closestY;

            float distanceSquare = (deltaX * deltaX) + (deltaY * deltaY);

            if (distanceSquare <= (radius * radius))
                return true;
            return false;
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
        public static double GetDotProduct(double x1, double y1, double x2, double y2) => (x1 * x2) + (y1 * y2);
        /// <summary>
        /// Calculates the dot product of two 2D vectors.
        /// </summary>
        /// <param name="x1">The X-component of the first vector.</param>
        /// <param name="y1">The Y-component of the first vector.</param>
        /// <param name="x2">The X-component of the second vector.</param>
        /// <param name="y2">The Y-component of the second vector.</param>
        /// <returns>The scalar dot product of the two 2D vectors.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float GetDotProduct(float x1, float y1, float x2, float y2) => (x1 * x2) + (y1 * y2);
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
        public static double GetDotProduct3D(double x1, double y1, double z1, double x2, double y2, double z2) => (x1 * x2) + (y1 * y2) + (z1 * z2);
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
        public static float GetDotProduct3D(float x1, float y1, float z1, float x2, float y2, float z2) => (x1 * x2) + (y1 * y2) + (z1 * z2);
        /// <summary>
        /// Calculates the magnitude (length) of a 2D vector.
        /// </summary>
        /// <param name="x">The X-component of the vector.</param>
        /// <param name="y">The Y-component of the vector.</param>
        /// <returns>The magnitude of the 2D vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double GetMagnitude(double x, double y) => Math.Sqrt((x * x) + (y * y));
        /// <summary>
        /// Calculates the magnitude (length) of a 2D vector.
        /// </summary>
        /// <param name="x">The X-component of the vector.</param>
        /// <param name="y">The Y-component of the vector.</param>
        /// <returns>The magnitude of the 2D vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float GetMagnitude(float x, float y) => MathF.Sqrt((x * x) + (y * y));
        /// <summary>
        /// Calculates the magnitude (length) of a 3D vector.
        /// </summary>
        /// <param name="x">The X-component of the vector.</param>
        /// <param name="y">The Y-component of the vector.</param>
        /// <param name="z">The Z-component of the vector.</param>
        /// <returns>The magnitude of the 3D vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double GetMagnitude3D(double x, double y, double z) => Math.Sqrt((x * x) + (y * y) + (z * z));
        /// <summary>
        /// Calculates the magnitude (length) of a 3D vector.
        /// </summary>
        /// <param name="x">The X-component of the vector.</param>
        /// <param name="y">The Y-component of the vector.</param>
        /// <param name="z">The Z-component of the vector.</param>
        /// <returns>The magnitude of the 3D vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float GetMagnitude3D(float x, float y, float z) => MathF.Sqrt((x * x) + (y * y) + (z * z));
        /// <summary>
        /// Calculates the cross product of two 3D vectors.
        /// </summary>
        /// <param name="x1">The X-component of the first vector.</param>
        /// <param name="y1">The Y-component of the first vector.</param>
        /// <param name="z1">The Z-component of the first vector.</param>
        /// <param name="x2">The X-component of the second vector.</param>
        /// <param name="y2">The Y-component of the second vector.</param>
        /// <param name="z2">The Z-component of the second vector.</param>
        /// <returns>A tuple representing the resulting 3D vector perpendicular to both input vectors</returns>
        public static (double x, double y, double z) GetCrossProduct(double x1, double y1, double z1, double x2, double y2, double z2)
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
        /// <param name="x1">The X-component of the first vector.</param>
        /// <param name="y1">The Y-component of the first vector.</param>
        /// <param name="z1">The Z-component of the first vector.</param>
        /// <param name="x2">The X-component of the second vector.</param>
        /// <param name="y2">The Y-component of the second vector.</param>
        /// <param name="z2">The Z-component of the second vector.</param>
        /// <returns>A tuple representing the resulting 3D vector perpendicular to both input vectors</returns>
        public static (float x, float y, float z) GetCrossProduct(float x1, float y1, float z1, float x2, float y2, float z2)
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
        /// <param name="dotProduct">The dot product of the two vectors.</param>
        /// <param name="lengthA">The magnitude (length) of the first vector.</param>
        /// <param name="lengthB">The magnitude (length) of the second vector.</param>
        /// <returns>The angle between the vectors in radians.</returns>
        public static double GetAngleBetween(double dotProduct, double lengthA, double lengthB)
        {
            if (lengthA == 0 || lengthB == 0)
                return 0.0;
            double A = dotProduct / (lengthA * lengthB);
            A = Math.Clamp(A, -1.0, 1.0);
            return Math.Acos(A);
        }
        /// <summary>
        /// Calculates the angle between two vectors in radians using their dot product and magnitudes.
        /// </summary>
        /// <param name="dotProduct">The dot product of the two vectors.</param>
        /// <param name="lengthA">The magnitude (length) of the first vector.</param>
        /// <param name="lengthB">The magnitude (length) of the second vector.</param>
        /// <returns>The angle between the vectors in radians.</returns>
        public static float GetAngleBetween(float dotProduct, float lengthA, float lengthB)
        {
            if (lengthA == 0 || lengthB == 0)
                return 0.0f;
            float A = dotProduct / (lengthA * lengthB);
            A = Math.Clamp(A, -1.0f, 1.0f);
            return MathF.Acos(A);
        }
    }
}