![GamemContributingBanner](https://raw.githubusercontent.com/nicky-suss/Gamem/refs/heads/main/.github/Assets/GamemContributingBanner.png)

# Contributing to Gamem
**Thank you for your interest in contributing to the project! I really appreciate it. In this file you can see instructions of how to run this project on your PC and submit your changes!**

## Contributing to C# Gamem
**Here are steps how to run C# Gamem on your PC**

### Requirements
- [.NET 8 SDK or newer](https://dotnet.microsoft.com/)
- [Git](https://git-scm.com/)
### Building the C# Gamem
1. **Clone the repo**
    ```bash
    git clone https://github.com/nicky-suss/Gamem.git
    ```
2. **Navigate to the project directory in your terminal**
    ```bash
    cd Gamem
    ```
3. **Restore dependencies**
    ```bash
    dotnet restore
    ```
4. **Make your changes :p**
5. **Test the project**
    [TUTORIAL FOR TESTS](https://github.com/nicky-suss/Gamem/blob/main/Tests/Unit/Csharp/README.md)
6. **Build the project**
    **REMEMBER** if you want to build every project and Gamem.Unity too you HAVE to install Unity and make `Gamem.Unity.csproj.user` in `src/Csharp/Base/Untiy`
    then type something like this in `Gamem.Unity.csproj.user`
    ```xml
    <Project>
        <PropertyGroup>
            <UNITY_ASSEMBLY_PATH>D:\YourPathToUnity\Version\Editor\Data\Managed</UNITY_ASSEMBLY_PATH>
        </PropertyGroup>
    </Project>
    ```
    Then you are able to type 
    ```bash
    dotnet clean
    dotnet build
    ```
    ---
    **OR** if you just want to build other projects and not Unity then type this
    ```bash
    dotnet clean
    dotnet build Gamem.slnf
    ```

7. (Optional) **Pack the project to .nupkg file (NuGet package)**
    ```bash
    dotnet pack
    ```
## Contributing to TS Gamem (Web, WASM)

> [!WARNING]
> gamem-wasm has been deprecated, so don't make any changes in Web folder, feel free to copy or use this code how it's allowed in MIT license

**Here are steps how to run WASM Gamem on your PC**
### Requirements
- [Node.js 20 or more](https://nodejs.org/)
- [Emscripten](https://github.com/emscripten-core/emscripten)
- [TypeScript](https://www.typescriptlang.org/)
### Building the Web/Wasm Gamem
1. **Clone the repo**
    ```bash
    git clone https://github.com/nicky-suss/Gamem.git
    ```
2. **Navigate to the Web directory in your terminal**
    ```bash
    cd Gamem/src/Web
    ```
3. **Install dependencies**
    ```bash
    npm ci
    ```
4. **Make your changes :p**
5. **Build the project**
    ```bash
    npm run build
    ```
> [!NOTE]
> `npm run build` actually runs `build:ts`,     `build:wasm`, and `copy:types`

## Final

- **Create a pull request (PR) with your updates**
- **Ensure that your PR targets the main branch and contains a clear description of the changes made**

## Rules

- **Write clear commit messages**
- **Follow the project's general coding style**