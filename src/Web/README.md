![GamemBanner](https://raw.githubusercontent.com/nicky-suss/Gamem/refs/heads/main/.github/Assets/GamemBanner.png)

[![NPM Version](https://img.shields.io/npm/v/gamem-wasm?logo=npm&labelColor=28333C&color=F0024B)](https://www.npmjs.com/package/gamem-wasm) [![NPM Downloads](https://img.shields.io/npm/d18m/gamem-wasm?logo=npm&labelColor=28333C&color=F0024B)](https://www.npmjs.com/package/gamem-wasm) ![Static Badge](https://img.shields.io/badge/license-MIT-green?labelColor=28333C&color=F0024B)

**Gamem WASM is a TypeScript/JavaScript library of Physics, Math and Geometry helpers, powered by WebAssembly. It was created for you to type code in one line instead of huge formulas. It works everywhere in the web! From vanilla JS to [Phaser](https://phaser.io), [PixiJS](https://pixijs.com) and [Three.js](https://threejs.org)!**

## Features
- **MathGm**: `randomRange`, `smoothStep`, `lerp`, `inverseLerp`, `smoothDamp`, `smoothDampAngle` and more.
- **PhysicsGm**: `applyGravity`, `applyFriction`, `addForce`, `addImpulse`, `clampVelocity`, `bounce` and more.
- **GeometryGm**: `reflect`, `reflect3D`, `getCrossProduct`, `toRadians`, `toDegrees`, `getDistance`, `checkCircleVsCircle` and more.

## Installation
**Type this command in your project terminal:**
```bash
npm install gamem-wasm
```
## How to use
**To use Gamem methods just import them:**

```ts
import { MathGm, GeometryGm, PhysicsGm, initializeGamem } from "gamem-wasm";
import gamemWasmFactory from "gamem-wasm/dist/gamem_wasm.js";
```

## Get Started
**You must initialize the library before using any methods**
```ts
import { MathGm, GeometryGm, PhysicsGm, initializeGamem } from "gamem-wasm";
import gamemWasmFactory from "gamem-wasm/dist/gamem_wasm.js";

async function main() {
    await initializeGamem(gamemWasmFactory); // Very important!

    // Now you can use any method!
    // example:
    const num: number = MathGm.lerp(1, 2, 0.5);
    console.log(num); // 1.5
}
main(); // Call main to run the code
```
**How to use with vectors (I've used [ts-matrix](https://www.npmjs.com/package/ts-matrix) as example)**
```ts
import { MathGm, GeometryGm, PhysicsGm, initializeGamem } from "gamem-wasm";
import gamemWasmFactory from "gamem-wasm/dist/gamem_wasm.js";
import { Vector } from "ts-matrix";

async function main() {
    await initializeGamem(gamemWasmFactory);

    const vector = new Vector([1, 2]);
    const normal = new Vector([3, 1110]); // Just random numbers for example

    console.log(GeometryGm.reflect(vector.values[0], vector.values[1], normal.values[0], normal.values[1]));
    // { x: -13337, y: -4935058 }
}
main();
```
## Why Gamem?
- **Zero Dependencies** - Pure TypeScript wrapper around compiled C++ code
- **Engine doesn't matter** - You can use it in any web engine or vanilla project!
- **Good performance** - Optimized methods by using WebAssembly
## Contributing
- **Liked the project? Leave a star for [this repo](https://github.com/nicky-suss/Gamem), it motivates me to develop this project!**
- **Have any ideas or found a bug? Open an issue or send Pull Request!**
- **To contribute the project check [CONTRIBUTING.md](https://github.com/nicky-suss/Gamem?tab=contributing-ov-file)**
## License
**Gamem WASM is licensed under the [MIT](https://github.com/nicky-suss/Gamem/blob/main/LICENSE) license**