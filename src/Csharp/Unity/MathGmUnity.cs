using Gamem;
using System;
using UnityEngine;
using Unity.Mathematics;
using System.Runtime.CompilerServices;

namespace Gamem.Unity;

/// <summary>
/// Provides general-purpose static mathematical functions including interpolation and random number generation.
/// </summary>
public static class MathGmUnity
{
    /// <summary>
    /// Performs spherical linear interpolation (Slerp) between two 3D unit vectors.
    /// </summary>
    /// <param name="v1">The start unit vector.</param>
    /// <param name="v2">The target unit vector.</param>
    /// <param name="t">The interpolation parameter, where 0.0f returns the start vector and 1.0f returns the target vector.</param>
    /// <returns>A <see cref="Vector3"/> representing the spherically interpolated vector.</returns>
    public static float3 Slerp(float3 v1, float3 v2, float t)
    {
        float dot = v1.x * v2.x + v1.y * v2.y + v1.z * v2.z;
        dot = Math.Clamp(dot, -1, 1);
        if (dot > 1 - 1e-5)
        {
            float x = v1.x + t * (v2.x - v1.x);
            float y = v1.y + t * (v2.y - v1.y);
            float z = v1.z + t * (v2.z - v1.z);

            float length = MathF.Sqrt(x * x + y * y + z * z);
            if (length <= 1e-5)
                return new float3(v1.x, v1.y, v1.z);

            return new float3(
                x / length,
                y / length,
                z / length
            );
        }
        float omega = MathF.Acos(dot);
        float SinOmega = MathF.Sin(omega);

        float factor1 = MathF.Sin((1.0f - t) * omega) / SinOmega;
        float factor2 = MathF.Sin(t * omega) / SinOmega;
        return new float3(
            factor1 * v1.x + factor2 * v2.x,
            factor1 * v1.y + factor2 * v2.y,
            factor1 * v1.z + factor2 * v2.z
        );
    }
    /// <summary>
    /// Performs spherical linear interpolation (Slerp) between two 3D unit vectors.
    /// </summary>
    /// <param name="v1">The start unit vector.</param>
    /// <param name="v2">The target unit vector.</param>
    /// <param name="t">The interpolation parameter, where 0.0f returns the start vector and 1.0f returns the target vector.</param>
    /// <returns>A <see cref="Vector3"/> representing the spherically interpolated vector.</returns>
    public static Vector3 Slerp(Vector3 v1, Vector3 v2, float t)
    {
        float dot = v1.x * v2.x + v1.y * v2.y + v1.z * v2.z;
        dot = Math.Clamp(dot, -1, 1);
        if (dot > 1 - 1e-5)
        {
            float x = v1.x + t * (v2.x - v1.x);
            float y = v1.y + t * (v2.y - v1.y);
            float z = v1.z + t * (v2.z - v1.z);

            float length = MathF.Sqrt(x * x + y * y + z * z);
            if (length <= 1e-5)
                return new Vector3(v1.x, v1.y, v1.z);

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
            factor1 * v1.x + factor2 * v2.x,
            factor1 * v1.y + factor2 * v2.y,
            factor1 * v1.z + factor2 * v2.z
        );
    }
}