using System;
using Microsoft.Xna.Framework;
using Gamem;
using System.Runtime.CompilerServices;

namespace Gamem.MonoGame;

/// <summary>
/// Provides general-purpose static mathematical functions including interpolation and random number generation.
/// </summary>
public static class MathGmMonoGame
{
    /// <summary>
    /// Performs spherical linear interpolation (Slerp) between two 3D unit vectors.
    /// </summary>
    /// <param name="v1">The start unit vector.</param>
    /// <param name="v2">The target unit vector.</param>
    /// <param name="t">The interpolation parameter, where 0.0f returns the start vector and 1.0f returns the target vector.</param>
    /// <returns>A <see cref="Vector3"/> representing the spherically interpolated vector.</returns>
    public static Vector3 Slerp(Vector3 v1, Vector3 v2, float t)
    {
        float dot = v1.X * v2.X + v1.Y * v2.Y + v1.Z * v2.Z;
        dot = Math.Clamp(dot, -1, 1);
        if (dot > 1 - 1e-5)
        {
            float x = v1.X + t * (v2.X - v1.X);
            float y = v1.Y + t * (v2.Y - v1.Y);
            float z = v1.Z + t * (v2.Z - v1.Z);

            float length = MathF.Sqrt(x * x + y * y + z * z);
            if (length <= 1e-5)
                return new Vector3(v1.X, v1.Y, v1.Z);

            return new Vector3(
                x / length,
                y / length,
                z / length
            );
        }
        float omega = MathF.Acos(dot);
        float SinOmega = MathF.Sin(omega);

        float factor1 = MathF.Sin((1.0f - t) * omega) / SinOmega;
        float factor2 = MathF.Sin(t * omega) / SinOmega;
        return new Vector3(
            factor1 * v1.X + factor2 * v2.X,
            factor1 * v1.Y + factor2 * v2.Y,
            factor1 * v1.Z + factor2 * v2.Z
        );
    }
}