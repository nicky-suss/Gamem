![GamemBanner](https://raw.githubusercontent.com/nicky-suss/Gamem/refs/heads/main/.github/Assets/GamemBanner.png)

<div align="center"> 

[![NuGet Version](https://img.shields.io/nuget/v/Gamem?logo=nuget&labelColor=28333C&color=F0024B)](https://www.nuget.org/packages/Gamem) [![NuGet Downloads](https://img.shields.io/nuget/dt/Gamem?logo=nuget&labelColor=28333C&color=F0024B)](https://www.nuget.org/packages/Gamem)

[![NPM Version](https://img.shields.io/npm/v/gamem-wasm?logo=npm&labelColor=28333C&color=F0024B)](https://www.npmjs.com/package/gamem-wasm) [![NPM Downloads](https://img.shields.io/npm/d18m/gamem-wasm?logo=npm&labelColor=28333C&color=F0024B)](https://www.npmjs.com/package/gamem-wasm)

![Static Badge](https://img.shields.io/badge/license-MIT-green?labelColor=28333C&color=F0024B)

</div>

<h3 align="center"> If you need vectors for Unity, Godot, MonoGame or Stride, use these extensions: </h3>

- **[Gamem.Unity](https://www.nuget.org/packages/Gamem.Unity) for Unity (⚠️ UNITY PROJECTS ONLY)** 
[![NuGet Version](https://img.shields.io/nuget/v/Gamem.Godot?logo=nuGet&labelColor=28333C&color=111F28)](https://www.nuget.org/packages/Gamem.Unity) [![NuGet Downloads](https://img.shields.io/nuget/dt/Gamem.Godot?logo=nuget&labelColor=28333C&color=111F28)](https://www.nuget.org/packages/Gamem.Unity)
- **[Gamem.Godot](https://www.nuget.org/packages/Gamem.Godot) for Godot** 
[![NuGet Version](https://img.shields.io/nuget/v/Gamem.Godot?logo=nuGet&labelColor=28333C&color=478CBF)](https://www.nuget.org/packages/Gamem.Godot) [![NuGet Downloads](https://img.shields.io/nuget/dt/Gamem.Godot?logo=nuget&labelColor=28333C&color=478CBF)](https://www.nuget.org/packages/Gamem.Godot)
- **[Gamem.MonoGame](https://www.nuget.org/packages/Gamem.MonoGame) for MonoGame** 
[![NuGet Version](https://img.shields.io/nuget/v/Gamem.MonoGame?logo=nuGet&labelColor=28333C&color=E73C00)](https://www.nuget.org/packages/Gamem.MonoGame) [![NuGet Downloads](https://img.shields.io/nuget/dt/Gamem.MonoGame?logo=nuget&labelColor=28333C&color=E73C00)](https://www.nuget.org/packages/Gamem.MonoGame)
- **[Gamem.Stride](https://www.nuget.org/packages/Gamem.Stride) for Stride** 
[![NuGet Version](https://img.shields.io/nuget/v/Gamem.Stride?logo=nuGet&labelColor=28333C&color=FFFFFF)](https://www.nuget.org/packages/Gamem.Stride) [![NuGet Downloads](https://img.shields.io/nuget/dt/Gamem.Stride?logo=nuget&labelColor=28333C&color=FFFFFF)](https://www.nuget.org/packages/Gamem.Stride)

**Gamem is a C# and TypeScript library of Physics, Math and Geometry helpers, created for you to type code in one line instead of huge formulas. It works everywhere! From Console to [Unity](https://unity.com), [Godot](https://godotengine.org), [MonoGame](https://monogame.net) and different JS engines!**

<h2 align="center">Features</h2>

- **MathGm**: `RandomRange`, `SmoothStep`, `Lerp`, `InverseLerp`, `SmoothDamp` and more.
- **PhysicsGm**: `ApplyGravity`, `ApplyFriction`, `AddForce`, `AddImpulse`, `ClampVelocity`, `Bounce` and more.
- **GeometryGm**: `Reflect`, `ToRadians`, `ToDegrees`, `GetDistance`, `CheckCircleVsCircle`, `CheckAABBVsAABB` and more
<h2 align="center"> Project Structure </h2>

<details>
<summary>Click to view full Project Structure</summary>

```text
Gamem
    ├── .github
    │   ├── Assets
    │   │   ├── ScreenShots
    │   │   │   ├── 01.png
    │   │   │   ├── 02.png
    │   │   │   └── 03.png
    │   │   ├── GamemBanner.png
    │   │   ├── GamemContributingBanner.png
    │   │   └── GamemTestsBanner.png
    │   └── workflows
    │       ├── build-docs.yml
    │       └── scheduled-release.yml
    ├── docs
    │   ├── docs
    │   │   ├── getting-started.md
    │   │   └── toc.yml
    │   ├── images
    │   │   └── logo.png
    │   ├── public
    │   │   └── main.css
    │   ├── docfx.json
    │   ├── favicon.ico
    │   ├── index.md
    │   ├── README.md
    │   └── toc.yml
    ├── src
    │   ├── Csharp
    │   │   ├── Base
    │   │   │   ├── GeometryGm
    │   │   │   │   ├── CollisionGm
    │   │   │   │   │   ├── CollisionGm.net8.cs
    │   │   │   │   │   └── CollisionGm.netstandard.cs
    │   │   │   │   ├── VectorGm
    │   │   │   │   │   ├── VectorGm.net8.cs
    │   │   │   │   │   └── VectorGm.netstandard.cs
    │   │   │   │   ├── GeometryGm.net8.cs
    │   │   │   │   └── GeometryGm.netstandard.cs
    │   │   │   ├── images
    │   │   │   │   └── logo.png
    │   │   │   ├── MathGm
    │   │   │   │   ├── MathGm.net8.cs
    │   │   │   │   └── MathGm.netstandard.cs
    │   │   │   ├── PhysicsGm
    │   │   │   │   ├── PhysicsGm.net8.cs
    │   │   │   │   └── PhysicsGm.netstandard.cs
    │   │   │   ├── Extra.net8.cs
    │   │   │   ├── Gamem.csproj
    │   │   │   └── README.md
    │   │   ├── Godot
    │   │   │   ├── images
    │   │   │   │   └── logo.png
    │   │   │   ├── CollisionGmGodot.cs
    │   │   │   ├── Gamem.Godot.csproj
    │   │   │   ├── GeometryGmGodot.cs
    │   │   │   ├── MathGmGodot.cs
    │   │   │   ├── PhysicsGmGodot.cs
    │   │   │   ├── README.md
    │   │   │   └── VectorGmGodot.cs
    │   │   ├── MonoGame
    │   │   │   ├── images
    │   │   │   │   └── logo.png
    │   │   │   ├── CollisionGmMonoGame.cs
    │   │   │   ├── Gamem.MonoGame.csproj
    │   │   │   ├── GeometryGmMonoGame.cs
    │   │   │   ├── MathGmMonoGame.cs
    │   │   │   ├── PhysicsGmMonoGame.cs
    │   │   │   ├── README.md
    │   │   │   └── VectorGmMonoGame.cs
    │   │   └── Stride
    │   │       ├── images
    │   │       │   └── logo.png
    │   │       ├── CollisionGmStride.cs
    │   │       ├── Gamem.Stride.csproj
    │   │       ├── GeometryGmStride.cs
    │   │       ├── MathGmStride.cs
    │   │       ├── PhysicsGmStride.cs
    │   │       ├── README.md
    │   │       └── VectorGmStride.cs
    │   └── Web
    │       ├── cpp
    │       │   ├── include
    │       │   │   ├── GeometryGm.hpp
    │       │   │   ├── MathGm.hpp
    │       │   │   └── PhysicsGm.hpp
    │       │   └── src
    │       │       ├── GeometryGm.cpp
    │       │       ├── MathGm.cpp
    │       │       └── PhysicsGm.cpp
    │       ├── src
    │       │   ├── gamem_wasm.d.ts
    │       │   ├── GeometryGm.ts
    │       │   ├── index.ts
    │       │   ├── MathGm.ts
    │       │   ├── PhysicsGm.ts
    │       │   └── WasmLoader.ts
    │       ├── 3RD-PARTY-LICENSES
    │       ├── package-lock.json
    │       ├── package.json
    │       ├── README.md
    │       └── tsconfig.json
    ├── Tests
    │   ├── Unit
    │   │   └── Csharp
    │   │       ├── Gamem.Tests.csproj
    │   │       ├── MathGmTests.cs
    │   │       └── PhysicsGmTests.cs
    │   └── README.md
    ├── .clangd
    ├── .gitignore
    ├── CONTRIBUTING.md
    ├── Gamem.slnx
    ├── google223cc46a9ab379ba.html
    ├── LICENSE
    └── README.md

```

</details>

<h2 align="center"> Installation </h2>

**(C#) Type this command:**
```
dotnet add package Gamem
```
**(TypeScript) Type this command**
```
npm install gamem-wasm
```
<h2 align="center"> How to use </h2>

**(C#) To use Gamem methods type this:**
```csharp
using Gamem;
using Gamem.Unity; // If you use Unity extension
using Gamem.Godot; // If you use Godot extension
using Gamem.MonoGame; // If you use MonoGame extension
using Gamem.Stride; // If you use Stride extension
```
**(TypeScript) To use Gamem methods type this:**
```ts
import { MathGm, GeometryGm, PhysicsGm, initializeGamem } from "gamem-wasm";
import gamemWasmFactory from "gamem-wasm/dist/gamem_wasm.js";
```
<h2 align="center"> Write code much faster </h2>

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
<h2 align="center"> Why Gamem? </h2>

- **Zero Dependencies** - C# and TypeScript only. Doesn't use other heavy libraries
- **Engine doesn't matter** - You can use it in any engine or project!
- **Good performance** - Optimized methods via Aggressive Inlining
<h2 align="center"> Contributing </h2>

- **Liked the project? Leave a star for [this repo](https://github.com/nicky-suss/Gamem), it motivates me to develop this project!**
- **Have any ideas or found a bug? Open an issue or send Pull Request!**
- **To contribute the project check [CONTRIBUTING.md](https://github.com/nicky-suss/Gamem?tab=contributing-ov-file)**
<h2 align="center"> License </h2>

**Gamem is licensed under the [MIT](https://github.com/nicky-suss/Gamem/blob/main/LICENSE) license**