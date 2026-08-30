![GamemTestsBanner](https://raw.githubusercontent.com/nicky-suss/Gamem/refs/heads/main/.github/Assets/GamemTestsBanner.png)

### **This folder contains tests for the methods in the Gamem library**

## Tools
- **Tool for tests:** Xunit

## How to run tests

1. Clone the repo
```bash
git clone https://github.com/nicky-suss/Gamem.git
```
2. Change folder in your terminal
```bash
cd Gamem/Tests/Unit/Csharp
```
3. Run tests
```bash
dotnet test
```

## Rules for making tests

- **Name methods like they're called in the library and just add Test (e.g. AddForceTest)**
- **Don't make too many tests, 3-6 is enough**
- **Before sending PR, check all tests are ok**