using UnityEngine;
using Gamem;
using Unity.Mathematics;
using System.Runtime.CompilerServices;
using System;

namespace Gamem.Unity;

/// <summary>
/// Provides static mathematical methods for basic physics calculations like gravity, friction, and movement interpolation.
/// </summary>
public static class PhysicsGmUnity
{
    /// <summary>
    /// Applies linear drag to a 3D velocity vector over a given time step, stopping the object completely if its speed drops below a small threshold.
    /// </summary>
    /// <param name="velocity">The current velocity vector.</param>
    /// <param name="drag">The drag coefficient (typically negative to slow the object down, or positive depending on the expected math convention).</param>
    /// <param name="deltaTime">The time elapsed since the last frame in seconds.</param>
    /// <returns>The updated velocity vector after drag has been applied, or float3(0, 0, 0) if the squared velocity is below 0.0001f.</returns>
    public static float3 Drag(float3 velocity, float drag, float deltaTime)
    {
        velocity *= MathF.Exp(drag * deltaTime);

        if (VectorGmUnity.LengthSquared(velocity) < 0.0001f)
            return new float3(0, 0, 0);

        return velocity;
    }
    /// <summary>
    /// Applies linear drag to a 3D velocity vector over a given time step, stopping the object completely if its speed drops below a small threshold.
    /// </summary>
    /// <param name="velocity">The current velocity vector.</param>
    /// <param name="drag">The drag coefficient (typically negative to slow the object down, or positive depending on the expected math convention).</param>
    /// <param name="deltaTime">The time elapsed since the last frame in seconds.</param>
    /// <returns>The updated velocity vector after drag has been applied, or Vector3.zero if the squared velocity is below 0.0001f.</returns>
    public static Vector3 Drag(Vector3 velocity, float drag, float deltaTime)
    {
        velocity *= MathF.Exp(drag * deltaTime);

        if (VectorGmUnity.LengthSquared(velocity) < 0.0001f)
            return Vector3.zero;

        return velocity;
    }
    /// <summary>
    /// Predicts the 2D position of a projectile at a given time under constant acceleration (gravity).
    /// </summary>
    /// <param name="startPos">The initial position vector.</param>
    /// <param name="startVelocity">The initial velocity vector.</param>
    /// <param name="gravity">The acceleration vector (such as gravity).</param>
    /// <param name="t">The time elapsed since the start of the trajectory in seconds.</param>
    /// <returns>The calculated <see cref="float2"/> position at time <paramref name="t"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float2 PredictTrajectory(float2 startPos, float2 startVelocity, float2 gravity, float t)
    {
        return new float2(startPos.x + startVelocity.x * t + 1.0f / 2.0f * gravity.x * (t * t), startPos.y + startVelocity.y * t + 1.0f / 2.0f * gravity.y * (t * t));
    }
    /// <summary>
    /// Predicts the 2D position of a projectile at a given time under constant acceleration (gravity).
    /// </summary>
    /// <param name="startPos">The initial position vector.</param>
    /// <param name="startVelocity">The initial velocity vector.</param>
    /// <param name="gravity">The acceleration vector (such as gravity).</param>
    /// <param name="t">The time elapsed since the start of the trajectory in seconds.</param>
    /// <returns>The calculated <see cref="Vector2"/> position at time <paramref name="t"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector2 PredictTrajectory(Vector2 startPos, Vector2 startVelocity, Vector2 gravity, float t)
    {
        return new Vector2(startPos.x + startVelocity.x * t + 1.0f / 2.0f * gravity.x * (t * t), startPos.y + startVelocity.y * t + 1.0f / 2.0f * gravity.y * (t * t));
    }
}