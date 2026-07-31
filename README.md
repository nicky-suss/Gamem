# Gamem
![NuGet Version](https://img.shields.io/nuget/v/Gamem?logo=nuget&link=https%3A%2F%2Fwww.nuget.org%2Fpackages%2FGamem) ![NuGet Downloads](https://img.shields.io/nuget/dt/Gamem?logo=nuget&link=https%3A%2F%2Fwww.nuget.org%2Fpackages%2FGamem) ||| ![NPM Version](https://img.shields.io/npm/v/gamem-wasm?logo=npm&link=https%3A%2F%2Fwww.npmjs.com%2Fpackage%2Fgamem-wasm) ![NPM Downloads](https://img.shields.io/npm/d18m/gamem-wasm?logo=npm&link=https%3A%2F%2Fwww.npmjs.com%2Fpackage%2Fgamem-wasm) ||| ![Static Badge](https://img.shields.io/badge/license-MIT-green)

### If you need vectors for Godot, MonoGame or Stride, use these extensions:
- **[Gamem.Godot](https://www.nuget.org/packages/Gamem.Godot) for Godot** ![NuGet Version](https://img.shields.io/nuget/v/Gamem.Godot?logo=nuGet&link=https%3A%2F%2Fwww.nuget.org%2Fpackages%2FGamem.Godot) ![NuGet Downloads](https://img.shields.io/nuget/dt/Gamem.Godot?logo=nuget&link=https%3A%2F%2Fwww.nuget.org%2Fpackages%2FGamem.Godot)
- **[Gamem.MonoGame](https://www.nuget.org/packages/Gamem.MonoGame) for MonoGame** ![NuGet Version](https://img.shields.io/nuget/v/Gamem.MonoGame?logo=nuGet&link=https%3A%2F%2Fwww.nuget.org%2Fpackages%2FGamem.MonoGame) ![NuGet Downloads](https://img.shields.io/nuget/dt/Gamem.MonoGame?logo=nuget&link=https%3A%2F%2Fwww.nuget.org%2Fpackages%2FGamem.MonoGame)
- **[Gamem.Stride](https://www.nuget.org/packages/Gamem.Stride) for Stride** ![NuGet Version](https://img.shields.io/nuget/v/Gamem.Stride?logo=nuGet&link=https%3A%2F%2Fwww.nuget.org%2Fpackages%2FGamem.MonoGame) ![NuGet Downloads](https://img.shields.io/nuget/dt/Gamem.Stride?logo=nuget&link=https%3A%2F%2Fwww.nuget.org%2Fpackages%2FGamem.Stride)

**Gamem is a C# and TypeScript library of Physics, Math and Geometry helpers, created for you to type code in one line instead of huge formulas. It works everywhere! From Console to [Unity](https://unity.com), [Godot](https://godotengine.org), [MonoGame](https://monogame.net) and different JS engines!**

## 🌟 Features
- **MathGm**: `RandomRange`, `SmoothStep`, `Lerp`, `InverseLerp`, `SmoothDamp` and more.
- **PhysicsGm**: `ApplyGravity`, `ApplyFriction`, `AddForce`, `AddImpulse`, `ClampVelocity`, `Bounce` and more.
- **GeometryGm**: `Reflect`, `ToRadians`, `ToDegrees`, `GetDistance`, `CheckCircleVsCircle`, `CheckAABBVsAABB` and more
## 📂 Project Structure
<details>
<summary>Click to view full Project Structure</summary>

```text
📂 Gamem
├── 📂 src
│   ├── 📂 C#                                     - Library source code for the .NET ecosystem
│   │   ├── 📂 Base                               - Core library functionality (pure C#)
│   │   │   ├── 📂 GeometryGm                     - Geometric methods
│   │   │   │   ├── 📄 GeometryGm.net8.cs
│   │   │   │   └── 📄 GeometryGm.netstandard.cs
│   │   │   ├── 📂 images                         - Core library logo
│   │   │   │   └── 🖼️ logo.png
│   │   │   ├── 📂 MathGm                         - Mathematical methods
│   │   │   │   ├── 📄 MathGm.net8.cs
│   │   │   │   └── 📄 MathGm.netstandard.cs
│   │   │   ├── 📂 PhysicsGm                      - Physics methods
│   │   │   │   ├── 📄 PhysicsGm.net8.cs
│   │   │   │   └── 📄 PhysicsGm.netstandard.cs
│   │   │   ├── ⚙️ Gamem.csproj
│   │   │   └── 🛠️ README.md
│   │   ├── 📂 Godot                              - Extension for the Godot game engine
│   │   │   ├── 📂 images                         - Godot extension logo
│   │   │   │   └── 🖼️ logo.png
│   │   │   ├── ⚙️ Gamem.Godot.csproj
│   │   │   ├── 📄 GeometryGmGodot.cs
│   │   │   ├── 📄 PhysicsGmGodot.cs
│   │   │   └── 🛠️ README.md
│   │   ├── 📂 MonoGame                           - Extension for the MonoGame framework
│   │   │   ├── 📂 images                         - MonoGame extension logo
│   │   │   │   └── 🖼️ logo.png
│   │   │   ├── ⚙️ Gamem.MonoGame.csproj
│   │   │   ├── 📄 GeometryGmMonoGame.cs
│   │   │   ├── 📄 PhysicsGmMonoGame.cs
│   │   │   └── 🛠️ README.md
│   │   └── 📂 Stride                             - Extension for the Stride game engine
│   │       ├── 📂 images                         - Stride extension logo
│   │       │   └── 🖼️ logo.png
│   │       ├── ⚙️ Gamem.Stride.csproj
│   │       ├── 📄 GeometryGmStride.cs
│   │       ├── 📄 PhysicsGmStride.cs
│   │       └── 🛠️ README.md
│   └── 📂 Web                                     - Web, C++, and WebAssembly support module
│       ├── 📂 cpp                                 - Native C++ source code
│       │   ├── 📂 include                         - C++ header files (.hpp)
│       │   │   ├── 📄 GeometryGm.hpp
│       │   │   ├── 📄 MathGm.hpp
│       │   │   └── 📄 PhysicsGm.hpp
│       │   └── 📂 src                             - C++ implementation files (.cpp)
│       │       ├── 📄 GeometryGm.cpp
│       │       ├── 📄 MathGm.cpp
│       │       └── 📄 PhysicsGm.cpp
│       ├── 📂 src                                 - Compiled WASM outputs and TypeScript wrappers
│       │   ├── 📄 GeometryGm.ts
│       │   ├── 📄 MathGm.ts
│       │   ├── 📄 PhysicsGm.ts
│       │   └── 📄 WasmLoader.ts                   - WASM module loader and initializer
│       ├── 📄 3RD-PARTY-LICENSES                  - Licenses for third-party web dependencies
│       ├── 📄 package.json                        - npm package configuration and dependencies
│       └── 📄 README.md                           - Documentation for the Web version
├── 🛠️ .clangd      
├── 🛠️ .gitignore
├── ⚙️ Gamem.slnx
├── 🛠️ LICENSE
├── 🛠️ README.md
└── ⚙️ tsconfig.json
```

</details>

## 🛍️ Installation
**(C#) Type this command:**
```
dotnet add package Gamem
```
**(TypeScript) Type this command**
```
npm install gamem-wasm
```
## ⚙️ How to use
**(C#) To use Gamem methods type this:**
```csharp
using Gamem;
using Gamem.Godot; // If you use Godot extension
using Gamem.MonoGame; // If you use MonoGame extension
using Gamem.Stride; // If you use Stride extension
```
**(TypeScript) To use Gamem methods type this:**
```ts
import { MathGm, GeometryGm, PhysicsGm, initializeGamem } from "gamem-wasm";
import gamemWasmFactory from "gamem-wasm/dist/gamem_wasm.js";
```
## Write code much faster

**Without Gamem:**
```csharp
float min = 2.5f;
float max = 7.5f;
float speed = Random.Shared.NextDouble() * (max - min) + min;
```
**With Gamem (1 line of code only):**
```csharp
float speed = MathGm.RandomRange(2.5f, 7.5f);
```
## ✨ Why Gamem?
- **Zero Dependencies** - C# and TypeScript only. Doesn't use other heavy libraries
- **Engine doesn't matter** - You can use it in any engine or project!
- **Good performance** - Optimized methods via Aggressive Inlining
## ❤️ Contributing
- **Liked the project? Leave a star for [this repo](https://github.com/nicky-suss/Gamem), it motivates me to develop this project!**
- **Have any ideas or found a bug? Open an issue or send Pull Request!**
## License
**Gamem is licensed under the [MIT](https://github.com/nicky-suss/Gamem/blob/main/LICENSE) license**