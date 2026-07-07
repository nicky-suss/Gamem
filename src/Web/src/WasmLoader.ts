export interface GamemWasmModule {
    //
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