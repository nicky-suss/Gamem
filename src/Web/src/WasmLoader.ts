export interface GamemWasmModule {
    // === MathGm ===
    _gamem_smooth_step(start: number, end: number, t: number): number;
    _gamem_random_range(min: number, max: number): number;
    _gamem_lerp(start: number, end: number, t: number): number;
    _gamem_lerp_unclamped(start: number, end: number, t: number): number;
    _gamem_inverse_lerp(value: number, start: number, end: number): number;
    _gamem_accelerate(Vcurrent: number, Vtarget: number, a: number, t: number): number;
    _gamem_map(toMin: number, v: number, fromMin: number, toMax: number, fromMax: number): number;
    _gamem_remap(toMin: number, v: number, fromMin: number, toMax: number, fromMax: number): number;
    _gamem_roll_chance(chance: number): number;
    _gamem_move_towards(current: number, target: number, speed: number, dt: number): number;
    _gamem_safe_divide(a: number, b: number): number;
    _gamem_safe_divide_fb(a: number, b: number, fallback: number): number;
    _gamem_approximately(a: number, b: number): number;
    _gamem_smooth_damp(current: number, target: number, currentVelocity: number, smoothTime: number, maxSpeed: number, deltaTime: number): number;
    _gamem_smooth_damp_angle(current: number, target: number, currentVelocity: number, smoothTime: number, deltaTime: number): number;
    _gamem_ping_pong(t: number, length: number): number
    _gamem_lerp_angle(start: number, end: number, t: number): number;
    _gamem_repeat(t: number, length: number): number;

    // === GeometryGm ===
    _gamem_getdotproduct(x1: number, y1: number, x2: number, y2: number): number;
    _gamem_getdotproduct3d(x1: number, y1: number, z1: number, x2: number, y2: number, z2: number): number;
    _gamem_reflect(x: number, y: number, normalX: number, normalY: number, outXPtr: number, outYPtr: number): void
    _gamem_reflect3d(x: number, y: number, z: number, normalX: number, normalY: number, normalZ: number, outXPtr: number, outYPtr: number, outZPtr: number): void;
    _gamem_toradians(degrees: number): number;
    _gamem_todegrees(radians: number): number;
    _gamem_getdistance(x1: number, y1: number, x2: number, y2: number): number;
    _gamem_getdistancesquared(x1: number, y1: number, x2: number, y2: number): number;
    _gamem_getdistance3d(x1: number, y1: number, z1: number, x2: number, y2: number, z2: number): number;
    _gamem_checkcirclevscircle(x1: number, y1: number, radius1: number, x2: number, y2: number, radius2: number): boolean;
    _gamem_checkaabbvsaabb(x1: number, y1: number, width1: number, height1: number, x2: number, y2: number, width2: number, height2: number): boolean;
    _gamem_checkcirclevsaabb(circleX: number, circleY: number, radius: number, aabbX: number, aabbY: number, width: number, height: number): boolean;
    _gamem_getmagnitude(x: number, y: number): number;
    _gamem_getmagnitude3d(x: number, y: number, z: number): number;
    _gamem_getcrossproduct(x1: number, y1: number, z1: number, x2: number, y2: number, z2: number, outXPtr: number, outYPtr: number, outZPtr: number): void;
    _gamem_getanglebetween(dotProduct: number, lengthA: number, lengthB: number): number;

    // === PhysicsGm ===
    _gamem_applygravity(velocity: number, gravity: number, deltaTime: number): number
    _gamem_applyfriction(velocity: number, frictionCoeff: number, deltaTime: number): number;
    _gamem_movetowards(current: number, target: number, maxDelta: number): number;
    _gamem_bounce(vOld: number, bounciness: number): number;
    _gamem_bounce_threshold(vOld: number, bounciness: number, minBounceThreshold: number): number;
    _gamem_clampvelocity(v: number, max: number): number;
    _gamem_addforce(v: number, F: number, t: number, m: number): number;
    _gamem_addimpulse(vOld: number, J: number, m: number): number;
    _gamem_jumpcut(v: number, multiplier: number): number;
    _gamem_terminalvelocity(v: number, vlimit: number): number;
    _gamem_calculatejumpvelocity(h: number, g: number): number
    _gamem_getstoppingdistance(v: number, a: number): number;
    _gamem_applyquadraticdrag(v: number, k: number, t: number): number;
    _gamem_calculatelaunchvelocity(target: number, start: number, g: number, t: number): number;
    _gamem_predicttrajectory(startPosX: number, startPosY: number, startVelocityX: number, startVelocityY: number, gravityX: number, gravityY: number, t: number, outXPtr: number, outYPtr: number): void;

    _malloc(size: number): number;
    _free(ptr: number): number;
    setValue(ptr: number, value: any, type: string, reassign?: boolean): void;
    getValue(ptr: number, type: string): number;
}
let wasmModule: GamemWasmModule | null = null;

export async function initializeGamem(moduleFactory: any): Promise<void> {
    if (!wasmModule) {
        wasmModule = await moduleFactory();
    }
}
export function getWasm(): GamemWasmModule {
    if (!wasmModule) {
        throw new Error("Gamem WebAssembly module is not initialized. Call initializeGamem(gamemWasmFactory) first before using any library methods.");
    }
    return wasmModule;
}