# Getting Started

## Installing
Install Gamem with NuGet CLI:

```bash
dotnet add package Gamem
```

Or with Package Manager Console in Visual Studio
```bash
NuGet\Install-Package Gamem
```
## Quick Start
import the library and use any method
```csharp
using Gamem;

bool isColliding = CollisionGm.CheckAABBVsaABB(
    x1: 0, y1: 0, width1: 10, height1: 10,
    x2: 5, y2: 5, width2: 10, height2: 10
);

if (isColliding) 
{
    // Something
}
```