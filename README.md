# Gamem
![NuGet Version](https://img.shields.io/nuget/v/Gamem) ![NuGet Downloads](https://img.shields.io/nuget/dt/Gamem)

**🎮 This library allows you to use physics and math methods for developing your games 👾**
> [!NOTE]
> If you want to use Geometry methods you can use my another library -> [GeometrySharp](https://www.nuget.org/packages/GeometrySharp)
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
## Examples
### 🧮 Math
```csharp
// Generates a random number between 2.5 and 7.5
float speed = MathGamem.RandomRange(2.5f, 7.5f);

// Smoothly interpolates from 0.0 to 100.0 based on progress (0.0 to 1.0)
double currentAlpha = MathGamem.SmoothStep(0.0, 100.0, progress);
```
### 🏃 Physics
**Friction and gravity**
```csharp
double velocityX = 10.0;
double velocityY = 0.0;
double deltaTime = 0.016; // 60 FPS

// Apply gravity if the character is in the air
double gravity = -9.81;
velocityY = Physics.ApplyGravity(velocityY, gravity, deltaTime);

// Apply friction to slow down the character on the ground
double friction = 5.0;
velocityX = Physics.ApplyFriction(velocityX, friction, deltaTime);
```