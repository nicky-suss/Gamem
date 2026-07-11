# Gamem WASM
![npm version](https://img.shields.io/npm/v/gamem-wasm) ![npm downloads](https://img.shields.io/npm/dt/gamem-wasm) ![license](https://img.shields.io/badge/license-MIT-green)

**🎮 Gamem WASM is a TypeScript/JavaScript library of Physics, Math and Geometry helpers, powered by WebAssembly. It was created for you to type code in one line instead of huge formulas. It works everywhere in the web! From vanilla JS to [Phaser](https://phaser.io), [PixiJS](https://pixijs.com) and [Three.js](https://threejs.org)! 👾**

## 🌟 Features
- **MathGm**: `randomRange`, `smoothStep`, `lerp`, `inverseLerp`, `smoothDamp`, `smoothDampAngle` and more.
- **PhysicsGm**: `applyGravity`, `applyFriction`, `addForce`, `addImpulse`, `clampVelocity`, `bounce` and more.
- **GeometryGm**: `reflect`, `reflect3D`, `getCrossProduct`, `toRadians`, `toDegrees`, `getDistance`, `checkCircleVsCircle` and more.

## 🛍️ Installation
**Type this command in your project terminal:**
```bash
npm install gamem-wasm
```
## ⚙️ How to use
**To use Gamem methods just import them:**

```ts
import { MathGm, GeometryGm, PhysicsGm } from 'gamem-wasm';
```

## 🚀 Get Started
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
## ✨ Why Gamem?
- 🍃 **Zero Dependencies** - Pure TypeScript wrapper around compiled C++ code
- 🎮 **Engine doesn't matter** - You can use it in any web engine or vanilla project!
- ⚡ **Good performance** - Optimized methods by using WebAssembly
## ❤️ Contributing
- **⭐ Liked the project? Leave a star for [this repo](https://github.com/nicky-suss/Gamem), it motivates me to develop this project!**
- **🗨️ Have any ideas or found a bug? Open an issue or send Pull Request!**
## ⚖️ License
**Gamem WASM is licensed under the [MIT](https://github.com/nicky-suss/Gamem/blob/main/LICENSE) license**