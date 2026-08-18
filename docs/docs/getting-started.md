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
## Install Gamem for Unity
**A tutorial how to install Gamem for Unity**
1. Install **[NuGetForUnity](https://github.com/GlitchEnzo/NuGetForUnity)**
2. Select **NuGet → Manage NuGet Packages**

![01](https://raw.githubusercontent.com/nicky-suss/Gamem/refs/heads/main/.github/Assets/ScreenShots/01.png)
<br style="clear: both;" />

3. Search for **Gamem** in NuGet For Unity and Install the latest version

![02](https://raw.githubusercontent.com/nicky-suss/Gamem/refs/heads/main/.github/Assets/ScreenShots/02.png)
<br style="clear: both;" />

4. Type `using Gamem` and use any method!

![03](https://raw.githubusercontent.com/nicky-suss/Gamem/refs/heads/main/.github/Assets/ScreenShots/03.png)
<br style="clear: both;" />

[API Reference](../api/Gamem.html){.btn .btn-primary}