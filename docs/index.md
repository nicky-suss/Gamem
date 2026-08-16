---
_layout: landing
---

# Gamem
**Gamem is a C# library of Physics, Math and Geometry helpers, created for you to type code in one line instead of huge formulas. It works everywhere! From Console to [Unity](https://unity.com), [Godot](https://godotengine.org), [MonoGame](https://monogame.net) and other engines and frameworks!**

[Getting Started](docs/getting-started.md){.btn .btn-primary} [API Reference](api/Gamem.html){.btn-outline-secondary}

## Key features

- **2D Collision Detection**: collision checks for AABB vs. AABB, Circle vs. Circle, and Circle vs. AABB
- **Physics Helpers**: methods for calculating gravity, friction, ballistic trajectories, and launch velocity
- **Vector & Math Utils**: optimized utilities for vector operations and trigonometry.
- **Zero Dependencies**: no unnecessary, resource-intensive dependencies.

## Quick example

```csharp
using Gamem;

bool isColliding = CollisionGm.CheckAABBVsaABB(
    x1: 0, y1: 0, width1: 10, height1: 10,
    x2: 5, y2: 5, width2: 10, height2: 10
);

double newVelocity = PhysicsGm.ApplyGravity(
    velocity: 0.0, 
    gravity: 9.81, 
    deltaTime: 0.16
);
```

## Installing

Install package via NuGet CLI

```bash
dotnet add package Gamem
```