using Stride.Core.Mathematics;
using System;
using System.Runtime.CompilerServices;

namespace Gamem.Stride;

/// <summary>
/// Provides static mathematical methods for basic physics calculations like gravity, friction, and movement interpolation.
/// </summary>
public static class PhysicsGmMonoGame
{
    /// <summary>
    /// Applies linear drag to a 3D velocity vector over a given time step, stopping the object completely if its speed drops below a small threshold.
    /// </summary>
    /// <param name="velocity">The current velocity vector.</param>
    /// <param name="drag">The drag coefficient (typically negative to slow the object down, or positive depending on the expected math convention).</param>
    /// <param name="deltaTime">The time elapsed since the last frame in seconds.</param>
    /// <returns>The updated velocity vector after drag has been applied, or <see cref="Vector3.Zero"/> if the squared velocity is below 0.0001f.</returns>
    public static Vector3 Drag(Vector3 velocity, float drag, float deltaTime)
    {
        velocity *= MathF.Exp(drag * deltaTime);

        if (velocity.LengthSquared() < 0.0001f)
            return Vector3.Zero;

        return velocity;
    }
}