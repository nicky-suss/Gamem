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
    _gamem_smooth_damp(current: number, target: number, currentVelocity: number, smoothTime: number, maxSpeed: number, deltaTim: number): number;
    _gamem_smooth_damp_angle(current: number, target: number, currentVelocity: number, smoothTime: number, deltaTime: number): number;
}
let wasmModule: GamemWasmModule | null = null;

export async function initializeGamem(moduleFactory: any): Promise<void> {
    if (!wasmModule) {
        wasmModule = await moduleFactory;
    }
}
export function getWasm(): GamemWasmModule {
    if (!wasmModule) {
        throw new Error("Gamem WebAssembly module is not initialized. Call initializeGamem(gamemWasmFactory) first before using any library methods.");
    }
    return wasmModule;
}