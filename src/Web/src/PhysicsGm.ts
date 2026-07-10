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
}