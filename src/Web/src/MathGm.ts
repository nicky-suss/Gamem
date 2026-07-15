import { getWasm } from "./WasmLoader.js";

export class MathGm {
    /**
     * Performs a smooth cubic interpolation between two values based on a given percentage.
     * @param start The start value.
     * @param end The end value.
     * @param t The interpolation value, clamped between 0.0 and 1.0.
     * @returns The smoothly interpolated value between start and end.
     */
    public static smoothStep(start: number, end: number, t: number) {
        return getWasm()._gamem_smooth_step(start, end, t);
    }
    /**
     * Generates a random floating-point value within a specified inclusive range.
     * @param min The minimum bound of the range.
     * @param max The maximum bound of the range.
     * @returns A random value greater than or equal to min, and less than max.
     */
    public static randomRange(min: number, max: number) {
        return getWasm()._gamem_random_range(min, max);
    }
    /**
     * Linearly interpolates between start and end values, clamping the interpolation percentage between 0.0 and 1.0.
     * @param start The start value.
     * @param end The end value.
     * @param t The interpolation value, clamped between 0.0 and 1.0.
     * @returns The interpolated value between start and end.
     */
    public static lerp(start: number, end: number, t: number) {
        return getWasm()._gamem_lerp(start, end, t);
    }
    /**
     * Linearly interpolates between start and end values without clamping the interpolation percentage.
     * @param start The start value.
     * @param end The end value.
     * @param t The interpolation value, allowing extrapolation outside the start and end range.
     * @returns The interpolated or extrapolated value.
     */
    public static lerpUnclamped(start: number, end: number, t: number) {
        return getWasm()._gamem_lerp_unclamped(start, end, t);
    }
    /**
     * Calculates the linear parameter t that produces the given value within a specific range, clamped between 0.0 and 1.0.
     * @param value The value to find the interpolation factor for.
     * @param start The start value of the range.
     * @param end The end value of the range.
     * @returns The normalized linear parameter t between 0.0 and 1.0, or 0.0 if the range is zero.
     */
    public static inverseLerp(value: number, start: number, end: number) {
        return getWasm()._gamem_inverse_lerp(value, start, end);
    }
    /**
     * Smoothly accelerates current velocity toward a target velocity using an acceleration rate over a given time step.
     * @param Vcurrent The current velocity.
     * @param Vtarget The desired target velocity.
     * @param a The acceleration rate multiplier.
     * @param t The time elapsed since the last frame in seconds.
     * @returns The updated velocity approaching the target value.
     */
    public static accelerate(Vcurrent: number, Vtarget: number, a: number, t: number) {
        return getWasm()._gamem_accelerate(Vcurrent, Vtarget, a, t);
    }
    /**
     * Maps a value from an input range to an output range without clamping.
     * @param toMin The lower bound of the output range.
     * @param v The value to be mapped.
     * @param fromMin The lower bound of the input range.
     * @param toMax The upper bound of the output range.
     * @param fromMax The upper bound of the input range.
     * @returns The mapped value in the output range, or 0.0 if the input range size is zero.
     */
    public static map(toMin: number, v: number, fromMin: number, toMax: number, fromMax: number) {
        return getWasm()._gamem_map(toMin, v, fromMin, toMax, fromMax);
    }
    /**
     * Remaps a value from an input range to an output range, behaving identically to Map method.
     * @param toMin The lower bound of the output range.
     * @param v The value to be remapped.
     * @param fromMin The lower bound of the input range.
     * @param toMax The upper bound of the output range.
     * @param fromMax The upper bound of the input range.
     * @returns The remapped value in the output range.
     */
    public static remap(toMin: number, v: number, fromMin: number, toMax: number, fromMax: number) {
        return getWasm()._gamem_remap(toMin, v, fromMin, toMax, fromMax);
    }
    /**
     * Evaluates a percentage-based chance to determine a success outcome using an integer value.
     * @param chance The success probability as an integer percentage (e.g., 50 for a 50% chance).
     * @returns true if the random roll succeeds; otherwise, false.
     */
    public static rollChance(chance: number) {
        return getWasm()._gamem_roll_chance(chance);
    }
    /**
     * Moves a value toward a target value at a specified speed over a given time step.
     * @param current The current value.
     * @param target The target value to move towards.
     * @param speed The rate of movement per second.
     * @param dt The time elapsed since the last frame in seconds.
     * @returns The updated value closer to the target, or the target itself if it is within reaching distance.
     */
    public static moveTowards(current: number, target: number, speed: number, dt: number) {
        return getWasm()._gamem_move_towards(current, target, speed, dt);
    }
    /**
     * Divides one generic floating-point number by another, returning a fallback value if the denominator is zero.
     * @param a The dividend (numerator).
     * @param b The divisor (denominator).
     * @returns The result of a / b, or the fallback value if b is 0.0.
     */
    public static safeDivide(a: number, b: number) {
        return getWasm()._gamem_safe_divide(a, b);
    }
    /**
     * Divides one generic floating-point number by another, returning a fallback value if the denominator is zero.
     * @param a The dividend (numerator).
     * @param b The divisor (denominator).
     * @param fallback The value to return if b is zero.
     * @returns The result of a / b, or the fallback value if b is 0.0.
     */
    public static safeDivideFb(a: number, b: number, fallback: number) {
        return getWasm()._gamem_safe_divide_fb(a, b, fallback);
    }
    /**
     * Compares two floating-point values and determines if they are approximately equal within a small tolerance.
     * @param a The first value to compare.
     * @param b The second value to compare.
     * @returns true if the values are approximately equal; otherwise, false.
     */
    public static approximately(a: number, b: number) {
        return getWasm()._gamem_approximately(a, b);
    }
    /**
     * Smoothly damps a value toward a target destination over time using a critically damped spring-like function.
     * @param current The current position or value.
     * @param target The target position or value to reach.
     * @param currentVelocity A reference to the tracking velocity, which is updated internally by the function.
     * @param smoothTime The approximate time it will take to reach the target. Shorter values reach the target faster.
     * @param maxSpeed The maximum speed allowed during the movement transition.
     * @param deltaTime The time elapsed since the last frame in seconds.
     * @returns The newly smoothed value approaching the target.
     */
    public static smoothDamp(current: number, target: number, currentVelocity: number, smoothTime: number, maxSpeed: number, deltaTime: number): { result: number, newVelocity: number } {
        const wasm = getWasm();

        const velocityPtr = wasm._malloc(8);

        wasm.setValue(velocityPtr, currentVelocity, "double");

        const result = wasm._gamem_smooth_damp(current, target, velocityPtr, smoothTime, maxSpeed, deltaTime);
        const updatedVelocity = wasm.getValue(velocityPtr, "double");

        wasm._free(velocityPtr);

        return { result: result, newVelocity: updatedVelocity };
    }
    /**
     * Smoothly damps an angle toward a target angle over time in degrees, handling wrapping around 360 degrees.
     * @param current A reference to the current angle in degrees, which is updated internally by the function.
     * @param target The target angle to reach in degrees.
     * @param currentVelocity A reference to the tracking angular velocity, which is updated internally by the function.
     * @param smoothTime The approximate time it will take to reach the target. Shorter values reach the target faster.
     * @param deltaTime The time elapsed since the last frame in seconds.
     * @returns The newly smoothed angle in degrees, clamped between 0 and 360.
     */
    public static smoothDampAngle(current: number, target: number, currentVelocity: number, smoothTime: number, deltaTime: number): { result: number, newVelocity: number } {
        const wasm = getWasm();

        const velocityPtr = wasm._malloc(8);

        wasm.setValue(velocityPtr, currentVelocity, "double");
        const updatedAngle = wasm._gamem_smooth_damp_angle(current, target, velocityPtr, smoothTime, deltaTime);
        const updatedVelocity = wasm.getValue(velocityPtr, "double");

        wasm._free(velocityPtr);
        return { result: updatedAngle, newVelocity: updatedVelocity };
    }
    /**
     * Ping-pongs the value t, causing it to bounce back and forth between 0 and length.
     * @param t The incoming value (typically an accumulating time variable).
     * @param length The maximum value the result can reach at its peak before bouncing back.
     * @returns A value between 0 and length that oscillates continuously back and forth.
     */
    public static pingPong(t: number, length: number) {
        return getWasm()._gamem_ping_pong(t, length);
    }
    /**
     * Linearly interpolates between two angles in degrees, properly handling wrapping around 360 degrees.
     * @param start The starting angle in degrees.
     * @param end The target angle in degrees.
     * @param t The interpolation factor, which will be clamped between 0.0 and 1.0.
     * @returns The interpolated angle in degrees, adjusted to take the shortest path around the circle.
     */
    public static lerpAngle(start: number, end: number, t: number) {
        return getWasm()._gamem_lerp_angle(start, end, t);
    }
    /**
     * Loops the value t so that it is never larger than length and never smaller than 0.
     * @param t The input value to loop.
     * @param length The length of the loop (period).
     * @returns The looped value wrapped within the range [0, length).
     */
    public static repeat(t: number, length: number) {
        return getWasm()._gamem_repeat(t, length);
    }
}