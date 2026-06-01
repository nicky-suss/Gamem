# Gamem
![NuGet Version](https://img.shields.io/nuget/v/Gamem) ![NuGet Downloads](https://img.shields.io/nuget/dt/Gamem) ![GitHub License](https://img.shields.io/github/license/nicky-suss/Gamem)


**🎮 Gamem is a C# library of Physics, Math and Geometry helpers, created for you to type code in one line instead of huge formulas. It works everywhere! From Console to [Unity](https://unity.com), [Godot](https://godotengine.org) and [MonoGame](https://monogame.net)! 👾**

## 🌟 Features
- **MathGm**: `RandomRange`, `SmoothStep`, `Lerp`, `InverseLerp`, `SmoothDamp` and more.
- **PhysicsGm**: `ApplyGravity`, `ApplyFriction`, `AddForce`, `AddImpulse`, `ClampVelocity`, `Bounce` and more.
- **GeometryGm**: `Reflect`, `ToRadians`, `ToDegrees`, `GetDistance`, `CheckCircleVsCircle`, `CheckAABBVsAABB` and more
## 🛍️ Installation
**Type this command:**
```
dotnet add package Gamem
```
## ⚙️ How to use
**To use Gamem methods type this:**
```csharp
using Gamem;
```
## 🚀 Write code much faster

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
## ✨ Why Gamem?
- 🍃 **Zero Dependencies** - C# only. Doesn't use other heavy libraries
- 🎮 **Engine doesn't matter** - You can use it everywhere. [Unity](https://unity.com), [Godot](https://godotengine.org), [MonoGame](https://monogame.net), Console or custom Engines
- ⚡ **Good performance** - Optimized methods
## ❤️ Contributing
- **⭐ Liked the project? Leave a star for [this repo](https://github.com/nicky-suss/Gamem), it motivates me to develop this project!**
- **🗨️ Have any ideas or found a bug? Open an issue or send Pull Request!**
## ⚖️ License
**Gamem is licensed under the [MIT](https://github.com/nicky-suss/Gamem/blob/main/LICENSE) license**