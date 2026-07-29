import { getWasm } from "./WasmLoader.js";

export class PhysicsGm {
    /**
     * Applies gravity to the current vertical velocity over a specified time step.
     * @param velocity The current velocity.
     * @param gravity The acceleration due to gravity.
     * @param deltaTime The time elapsed since the last frame in seconds.
     * @returns The updated velocity after applying gravity.
     */
    public static applyGravity(velocity: number, gravity: number, deltaTime: number) {
        return getWasm()._gamem_applygravity(velocity, gravity, deltaTime);
    }
    /**
     * Applies friction to reduce velocity towards zero over a specified time step.
     * @param velocity The current velocity.
     * @param frictionCoeff The friction coefficient representing deceleration per second.
     * @param deltaTime The time elapsed since the last frame in seconds.
     * @returns The updated velocity after friction is applied, clamping to 0.0 if it changes direction.
     */
    public static applyFriction(velocity: number, frictionCoeff: number, deltaTime: number) {
        return getWasm()._gamem_applyfriction(velocity, frictionCoeff, deltaTime);
    }
    /**
     * Moves a value toward a target value by a maximum specified delta.
     * @param current The current value.
     * @param target The value to move towards.
     * @param maxDelta The maximum amount by which the value can change.
     * @returns The new value closer to the target, or the target itself if it is within range.
     */
    public static moveTowards(current: number, target: number, maxDelta: number) {
        return getWasm()._gamem_movetowards(current, target, maxDelta);
    }
    /**
     * Calculates the velocity after a bounce collision, reversing direction and applying a coefficient of restitution.
     * @param vOld The pre-collision velocity.
     * @param bounciness The bounciness coefficient (restitution), clamped between 0.0 and 1.0.
     */
    public static bounce(vOld: number, bounciness: number) {
        return getWasm()._gamem_bounce(vOld, bounciness);
    }
    /**
     * Calculates the velocity after a bounce collision, reversing direction and applying a coefficient of restitution.
     * @param vOld The pre-collision velocity.
     * @param bounciness The bounciness coefficient (restitution), clamped between 0.0 and 1.0.
     * @param minBounceThreshold The minimum velocity required to sustain a bounce. Below this magnitude, the velocity is clamped to zero to prevent endless micro-bouncing.
     * @returns The updated velocity after the bounce, or 0.0 if the resulting speed falls below the threshold.
     */
    public static bounceThreshold(vOld: number, bounciness: number, minBounceThreshold: number) {
        return getWasm()._gamem_bounce_threshold(vOld, bounciness, minBounceThreshold);
    }
    /**
     * Clamps a velocity value to be within a symmetric range defined by a maximum speed limit.
     * @param v The current velocity to clamp.
     * @param max The maximum allowed speed (magnitude), which will be used to define both upper and lower bounds.
     * @returns The clamped velocity, constrained between -abs(max) and abs(max).
     */
    public static clampVelocity(v: number, max: number) {
        return getWasm()._gamem_clampvelocity(v, max);
    }
    /**
     * Applies a continuous force over a specified time duration to update the velocity, based on Newton's second law.
     * @param v The initial velocity before the force is applied.
     * @param F The force magnitude.
     * @param t The duration of time over which the force acts.
     * @param m The mass of the object. If mass is 0, the velocity remains unchanged to avoid division by zero.
     * @returns The updated velocity after applying the force.
     */
    public static addForce(v: number, F: number, t: number, m: number) {
        return getWasm()._gamem_addforce(v, F, t, m);
    }
    /**
     * Applies an instantaneous impulse to update the velocity.
     * @param vOld The pre-impulse velocity.
     * @param J The impulse magnitude (change in momentum).
     * @param m The mass of the object. If mass is 0, the velocity remains unchanged to avoid division by zero.
     * @returns The updated velocity after the impulse is applied.
     */
    public static addImpulse(vOld: number, J: number, m: number) {
        return getWasm()._gamem_addimpulse(vOld, J, m);
    }
    /**
     * Reduces upward velocity when a jump button is released early, commonly used for variable jump heights in platformers.
     * @param v The current vertical velocity (positive = upward).
     * @param multiplier The factor by which to multiply the velocity (usually between 0.0 and 1.0).
     * @returns The modified velocity if moving upward (greater than 0), otherwise the original velocity.
     */
    public static jumpCut(v: number, multiplier: number) {
        return getWasm()._gamem_jumpcut(v, multiplier);
    }
    /**
     * Caps falling velocity to prevent an object from exceeding a maximum downward terminal velocity limit.
     * @param v The current vertical velocity (negative values represent falling).
     * @param vlimit The maximum allowed falling speed magnitude (should be positive).
     * @returns The clamped velocity, restricted so that it does not drop below -vlimit.
     */
    public static terminalVelocity(v: number, vlimit: number) {
        return getWasm()._gamem_terminalvelocity(v, vlimit);
    }
    /**
     * Calculates the initial upward velocity required to reach a specific jump height under a given gravity.
     * @param h The target maximum jump height.
     * @param g The gravity value. Its absolute value is used to ensure mathematical stability.
     * @returns The calculated initial jump velocity required to reach the target height.
     */
    public static calculateJumpVelocity(h: number, g: number) {
        return getWasm()._gamem_calculatejumpvelocity(h, g);
    }
    /**
     * Calculates the stopping distance required for an object to come to a complete stop from a given velocity under constant deceleration.
     * @param v The current velocity of the object.
     * @param a The constant deceleration rate (magnitude of acceleration slowing the object down).
     * @returns The calculated stopping distance, or zero if the deceleration is zero.
     */
    public static getStoppingDistance(v: number, a: number) {
        return getWasm()._gamem_getstoppingdistance(v, a);
    }
    /**
     * Applies quadratic drag (air resistance) to a velocity value over a given time step using Euler integration.
     * @param v The current velocity.
     * @param k The quadratic drag coefficient (typically dependent on fluid density, drag coefficient, and cross-sectional area).
     * @param t The time step (delta time) in seconds.
     * @returns The updated velocity after quadratic drag has been applied.
     */
    public static applyQuadraticDrag(v: number, k: number, t: number) {
        return getWasm()._gamem_applyquadraticdrag(v, k, t);
    }
    /**
     * Calculates the required initial velocity along a single axis to reach a target displacement in a given time under constant acceleration.
     * @param target The target position to reach.
     * @param start The starting position.
     * @param g The constant acceleration along this axis (e.g., gravity).
     * @param t The desired time to reach the target in seconds.
     * @returns The required initial velocity, or zero if t is zero.
     */
    public static calculateLaunchVelocity(target: number, start: number, g: number, t: number) {
        return getWasm()._gamem_calculatelaunchvelocity(target, start, g, t);
    }
    /**
     * Predicts the 2D position coordinates of a projectile at a given time under constant acceleration (gravity).
     * @param startPosX The initial X-coordinate position.
     * @param startPosY The initial Y-coordinate position.
     * @param startVelocityX The initial velocity along the X-axis.
     * @param startVelocityY The initial velocity along the Y-axis.
     * @param gravityX The acceleration along the X-axis.
     * @param gravityY The acceleration along the Y-axis.
     * @param t The time elapsed since the start of the trajectory in seconds.
     * @returns A tuple containing the calculated X and Y position coordinates at time t.
     */
    public static predictTrajectory(startPosX: number, startPosY: number, startVelocityX: number, startVelocityY: number, gravityX: number, gravityY: number, t: number): {x: number, y: number} {
        const outXPtr = getWasm()._malloc(8);
        const outYPtr = getWasm()._malloc(8);

        getWasm()._gamem_predicttrajectory(startPosX, startPosY, startVelocityX, startVelocityY, gravityX, gravityY, t, outXPtr, outYPtr);

        const resX = getWasm().getValue(outXPtr, "double");
        const resY = getWasm().getValue(outYPtr, "double");

        getWasm()._free(outXPtr);
        getWasm()._free(outYPtr);

        return { x: resX, y: resY };
    }
    /**
     * Applies linear drag to 3D velocity components over a given time step, stopping the movement along XY if the 3D velocity magnitude drops below a small threshold.
     * @param velocityX The X component of the velocity.
     * @param velocityY The Y component of the velocity.
     * @param velocityZ The Z component of the velocity.
     * @param drag The drag coefficient influencing the exponential decay speed.
     * @param deltaTime The time elapsed since the last frame in seconds.
     * @returns A tuple containing the updated X, Y and Z velocity components, or zeros if the total 3D speed is below the threshold.
     */
    public static drag(velocityX: number, velocityY: number, velocityZ: number, drag: number, deltaTime: number): { outVelocityX: number, outVelocityY: number, outVelocityZ: number } {
        const outXPtr = getWasm()._malloc(8);
        const outYPtr = getWasm()._malloc(8);
        const outZPtr = getWasm()._malloc(8);

        getWasm()._gamem_drag(velocityX, velocityY, velocityZ, drag, deltaTime, outXPtr, outYPtr, outZPtr);

        const resX = getWasm().getValue(outXPtr, "double");
        const resY = getWasm().getValue(outYPtr, "double");
        const resZ = getWasm().getValue(outZPtr, "double");

        return { outVelocityX: resX, outVelocityY: resY, outVelocityZ: resZ };
    }
}