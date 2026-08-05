![GamemBanner](https://raw.githubusercontent.com/nicky-suss/Gamem/refs/heads/main/Assets/GamemBanner.png)

[![NuGet Version](https://img.shields.io/nuget/v/Gamem?logo=nuget&labelColor=28333C&color=F0024B)](https://www.nuget.org/packages/Gamem) [![NuGet Downloads](https://img.shields.io/nuget/dt/Gamem?logo=nuget&labelColor=28333C&color=F0024B)](https://www.nuget.org/packages/Gamem) ![Static Badge](https://img.shields.io/badge/license-MIT-green?labelColor=28333C&color=F0024B)

### If you need vectors for Godot, MonoGame or Stride, use these extensions:
- **[Gamem.Godot](https://www.nuget.org/packages/Gamem.Godot) for Godot** 
[![NuGet Version](https://img.shields.io/nuget/v/Gamem.Godot?logo=nuGet&labelColor=28333C&color=478CBF)](https://www.nuget.org/packages/Gamem.Godot) [![NuGet Downloads](https://img.shields.io/nuget/dt/Gamem.Godot?logo=nuget&labelColor=28333C&color=478CBF)](https://www.nuget.org/packages/Gamem.Godot)
- **[Gamem.MonoGame](https://www.nuget.org/packages/Gamem.MonoGame) for MonoGame** 
[![NuGet Version](https://img.shields.io/nuget/v/Gamem.MonoGame?logo=nuGet&labelColor=28333C&color=E73C00)](https://www.nuget.org/packages/Gamem.MonoGame) [![NuGet Downloads](https://img.shields.io/nuget/dt/Gamem.MonoGame?logo=nuget&labelColor=28333C&color=E73C00)](https://www.nuget.org/packages/Gamem.MonoGame)
- **[Gamem.Stride](https://www.nuget.org/packages/Gamem.Stride) for Stride** 
[![NuGet Version](https://img.shields.io/nuget/v/Gamem.Stride?logo=nuGet&labelColor=28333C&color=FFFFFF)](https://www.nuget.org/packages/Gamem.Stride) [![NuGet Downloads](https://img.shields.io/nuget/dt/Gamem.Stride?logo=nuget&labelColor=28333C&color=FFFFFF)](https://www.nuget.org/packages/Gamem.Stride)

**Gamem is a C# library of Physics, Math and Geometry helpers, created for you to type code in one line instead of huge formulas. It works everywhere! From Console to [Unity](https://unity.com), [Godot](https://godotengine.org), [MonoGame](https://monogame.net) and other engines and frameworks!**

## Features
- **MathGm**: `RandomRange`, `SmoothStep`, `Lerp`, `InverseLerp`, `SmoothDamp` and more.
- **PhysicsGm**: `ApplyGravity`, `ApplyFriction`, `AddForce`, `AddImpulse`, `ClampVelocity`, `Bounce` and more.
- **GeometryGm**: `Reflect`, `ToRadians`, `ToDegrees`, `GetDistance`, `CheckCircleVsCircle`, `CheckAABBVsAABB` and more
## Installation
**Type this command:**
```
dotnet add package Gamem
```
## How to use
**To use Gamem methods type this:**
```csharp
using Gamem;
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
float speed = MathGamem.RandomRange(2.5f, 7.5f);
```
## Why Gamem?
- **Zero Dependencies** - C# only. Doesn't use other heavy libraries
- **Engine doesn't matter** - You can use it everywhere. [Unity](https://unity.com), [Godot](https://godotengine.org), [MonoGame](https://monogame.net), Console or custom Engines
- **Good performance** - Optimized methods
## Contributing
- **Liked the project? Leave a star for [this repo](https://github.com/nicky-suss/Gamem), it motivates me to develop this project!**
- **Have any ideas or found a bug? Open an issue or send Pull Request!**
- **To contribute the project check [CONTRIBUTING.md](https://github.com/nicky-suss/Gamem?tab=contributing-ov-file)**
## License
**Gamem is licensed under the [MIT](https://github.com/nicky-suss/Gamem/blob/main/LICENSE) license**