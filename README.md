# Gamem
![NuGet Version](https://img.shields.io/nuget/v/Gamem) ![NuGet Downloads](https://img.shields.io/nuget/dt/Gamem) ![Static Badge](https://img.shields.io/badge/license-MIT-green)

### If you need vectors for Godot or MonoGame, use these extensions:
- **[Gamem.Godot](https://www.nuget.org/packages/Gamem.Godot) for Godot**
- **[Gamem.MonoGame](https://www.nuget.org/packages/Gamem.MonoGame) for MonoGame**

**🎮 Gamem is a C# library of Physics, Math and Geometry helpers, created for you to type code in one line instead of huge formulas. It works everywhere! From Console to [Unity](https://unity.com), [Godot](https://godotengine.org) and [MonoGame](https://monogame.net)! 👾**

## 🌟 Features
- **MathGm**: `RandomRange`, `SmoothStep`, `Lerp`, `InverseLerp`, `SmoothDamp` and more.
- **PhysicsGm**: `ApplyGravity`, `ApplyFriction`, `AddForce`, `AddImpulse`, `ClampVelocity`, `Bounce` and more.
- **GeometryGm**: `Reflect`, `ToRadians`, `ToDegrees`, `GetDistance`, `CheckCircleVsCircle`, `CheckAABBVsAABB` and more
## 📂 Project Structure
<details>
<summary>📂 Click to view full Project Structure</summary>

```text
📂 Gamem
└── 📂 src                                       - Library source code
    ├── 📂 Base                                  - Library core
    │   ├── 📂 GeometryGm                        - Geometric methods for the library
    │   │   ├── 📄 GeometryGm.net8.cs
    │   │   └── 📄 GeometryGm.netstandard.cs
    │   ├── 📂 images                            - Library core logo
    │   │   └── 🖼️ logo.png
    │   ├── 📂 MathGm                            - Mathematical methods for the library
    │   │   ├── 📄 MathGm.net8.cs
    │   │   └── 📄 MathGm.netstandard.cs
    │   ├── 📂 PhysicsGm                         - Physics methods for the library
    │   │   ├── 📄 PhysicsGm.net8.cs
    │   │   └── 📄 PhysicsGm.netstandard.cs
    │   ├── ⚙️ Gamem.csproj
    │   └── 🛠️ README.md
    ├── 📂 Godot                                 - Extension for Godot
    │   ├── 📂 images                            - Extension logo
    │   │   └── 🖼️ logo.png
    │   ├── ⚙️ Gamem.Godot.csproj
    │   ├── 📄 GeometryGmGodot.cs                - Geometric methods for Godot
    │   ├── 📄 PhysicsGmGodot.cs                 - Physics methods for Godot
    │   └── 🛠️ README.md
    └── 📂 MonoGame                              - Extension for MonoGame
        ├── 📂 images                            - Extension logo
        │   └── 🖼️ logo.png
        ├── ⚙️ Gamem.MonoGame.csproj
        ├── 📄 GeometryGmMonoGame.cs              - Geometric methods for MonoGame
        ├── 📄 PhysicsGmMonoGame.cs               - Physics methods for MonoGame
        └── 🛠️ README.md
├── 🛠️ .gitignore
├── ⚙️ Gamem.slnx
├── 🛠️ LICENSE
└── 🛠️ README.md
```

</details>

## 🛍️ Installation
**Type this command:**
```
dotnet add package Gamem
```
## ⚙️ How to use
**To use Gamem methods type this:**
```csharp
using Gamem;
using Gamem.Godot; // If you use Godot extension
using Gamem.MonoGame; // If you use MonoGame extension
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
float speed = MathGm.RandomRange(2.5f, 7.5f);
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