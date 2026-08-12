using System;
using System.Runtime.CompilerServices;
using System.Numerics;

namespace Gamem
{
    /// <summary>
    /// Provides static methods for Geometry calculations
    /// </summary>
    public static partial class GeometryGm
    {

        //! ========================
        //! THIS PART OF THE CODE SUPPORTS OLDER VERSIONS OF .NET
        //! =========================

        /// <summary>
        /// Reflects a 2D vector off a surface defined by a normal vector.
        /// </summary>
        /// <param name="x">The X component of the incident vector.</param>
        /// <param name="y">The Y component of the incident vector.</param>
        /// <param name="normalX">The X component of the surface normal (should be normalized).</param>
        /// <param name="normalY">The Y component of the surface normal (should be normalized).</param>
        /// <returns>A tuple containing the X and Y components of the reflected vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double x, double y) Reflect(double x, double y, double normalX, double normalY)
        {
            double dot = VectorGm.GetDotProduct(x, y, normalX, normalY);
            return (x - 2 * dot * normalX, y - 2 * dot * normalY);
        }
        /// <inheritdoc cref="Reflect(double, double, double, double)"/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (float x, float y) Reflect(float x, float y, float normalX, float normalY)
        {
            float dot = VectorGm.GetDotProduct(x, y, normalX, normalY);
            return (x - 2 * dot * normalX, y - 2 * dot * normalY);
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
        /// <param name="x">The X component of the incident vector.</param>
        /// <param name="y">The Y component of the incident vector.</param>
        /// <param name="z">The Z component of the incident vector.</param>
        /// <param name="normalX">The X component of the surface normal (should be normalized).</param>
        /// <param name="normalY">The Y component of the surface normal (should be normalized).</param>
        /// <param name="normalZ">The Z component of the surface normal (should be normalized).</param>
        /// <returns>A tuple containing the X, Y, and Z components of the reflected vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double x, double y, double z) Reflect3D(double x, double y, double z, double normalX, double normalY, double normalZ)
        {
            double dot = VectorGm.GetDotProduct3D(x, y, z, normalX, normalY, normalZ);
            return (x - 2 * dot * normalX, y - 2 * dot * normalY, z - 2 * dot * normalZ);
        }
        /// <inheritdoc cref="Reflect3D(double, double, double, double, double, double)"/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (float x, float y, float z) Reflect3D(float x, float y, float z, float normalX, float normalY, float normalZ)
        {
            float dot = VectorGm.GetDotProduct3D(x, y, z, normalX, normalY, normalZ);
            return (x - 2 * dot * normalX, y - 2 * dot * normalY, z - 2 * dot * normalZ);
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
        /// <inheritdoc cref="ToRadians(double)"/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ToRadians(float degrees) => degrees * ((float)Math.PI / 180.0f);
        /// <inheritdoc cref="ToDegrees(double)"/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ToDegrees(float radians) => radians * (180.0f / (float)Math.PI);
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
        /// <inheritdoc cref="GetDistance(double, double, double, double)"/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float GetDistance(float x1, float y1, float x2, float y2)
        {
            float dx = x2 - x1;
            float dy = y2 - y1;
            float xy = (dx * dx) + (dy * dy);
            return (float)Math.Sqrt(xy);
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
        /// <param name="x1">The X coordinate of the first point.</param>
        /// <param name="y1">The Y coordinate of the first point.</param>
        /// <param name="x2">The X coordinate of the second point.</param>
        /// <param name="y2">The Y coordinate of the second point.</param>
        /// <returns>The squared distance between the two points, avoiding an expensive square root operation.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double GetDistanceSquared(double x1, double y1, double x2, double y2)
        {
            double dx = x2 - x1;
            double dy = y2 - y1;
            return (dx * dx) + (dy * dy);
        }
        /// <inheritdoc cref="GetDistanceSquared(double, double, double, double)"/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float GetDistanceSquared(float x1, float y1, float x2, float y2)
        {
            float dx = x2 - x1;
            float dy = y2 - y1;
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
        /// <inheritdoc cref="GetDistance3D(double, double, double, double, double, double)"/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float GetDistance3D(float x1, float y1, float z1, float x2, float y2, float z2)
        {
            float dx = x2 - x1;
            float dy = y2 - y1;
            float dz = z2 - z1;
            return (float)Math.Sqrt((dx * dx) + (dy * dy) + (dz * dz));
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
            return (float)Math.Sqrt((dx * dx) + (dy * dy) + (dz * dz));
        }
        /// <summary>
        /// Normalizes an angle in degrees into the range [0, 360).
        /// </summary>
        /// <param name="angle">The input angle in degrees to normalize.</param>
        /// <returns>The equivalent angle wrapped within the range of 0 (inclusive) to 360 (exclusive) degrees.</returns>
        public static float NormalizeAngle(float angle) => (angle % 360.0f + 360.0f) % 360.0f;
        /// <summary>
        /// Normalizes an angle in degrees into the range [0, 360).
        /// </summary>
        /// <param name="angle">The input angle in degrees to normalize.</param>
        /// <returns>The equivalent angle wrapped within the range of 0 (inclusive) to 360 (exclusive) degrees.</returns>
        public static double NormalizeAngle(double angle) => (angle % 360.0 + 360.0) % 360.0;
    }
}