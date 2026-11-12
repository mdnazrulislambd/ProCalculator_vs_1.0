# 🧮 ProCalculator VS 1.0

[![CI](https://github.com/mdnazrulislambd/ProCalculator_vs_1.0/actions/workflows/ci.yml/badge.svg)](https://github.com/mdnazrulislambd/ProCalculator_vs_1.0/actions/workflows/ci.yml)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)

A **scientific calculator for the console**, built with **C# and .NET 8**. It was created to practice C# programming, event-driven input handling and project organisation, and is now packaged for release.

## ✨ Features

**Basic**
- Addition, subtraction, multiplication, division (with divide-by-zero protection)
- Percentage (`15% of 200`)

**Scientific**
- Square root, power, square, cube
- Sin, cos, tan (angles in **degrees**)
- Log (base 10), natural log (ln)
- Factorial (0 to 170)

**Convenience**
- Memory: store, recall, add (`M+`), subtract (`M-`), clear
- Calculation history, shown as full expressions (`12 + 5 = 17`), with clear option
- `ans` – reuse the last result in any number prompt; `mr` – reuse the memory value
- Menu shortcuts: type `+`, `-`, `*`, `/`, `sqrt`, `sin`, `h`, `q` ... instead of a number
- Default / Dark / Light console themes
- Invalid input never crashes the app: you are simply asked again
- Clear error messages (for example for `sqrt(-1)`, `tan(90)`, `log(0)`)

## 🖥️ Quick start

### Download (recommended)

Go to the [Releases](https://github.com/mdnazrulislambd/ProCalculator_vs_1.0/releases) page and download the zip for your system (`win-x64` or `linux-x64`). The build is self-contained, so .NET does not need to be installed. Unzip and run `ProCalculator`.

### Build from source

Requirements: [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) (Visual Studio 2022 is optional).

```bash
git clone https://github.com/mdnazrulislambd/ProCalculator_vs_1.0.git
cd ProCalculator_vs_1.0
dotnet run --project ProCalculator_VS_1.0
```

In Visual Studio: open `ProCalculator_VS_1.0.sln` and press `F5`.

### Run the tests

```bash
dotnet test
```

## 📂 Project structure

```
ProCalculator_vs_1.0/
├── ProCalculator_VS_1.0/          # Application source
│   ├── Program.cs                 # Entry point
│   ├── CalculatorEngine.cs        # Menu loop and command handling
│   ├── BasicOperations.cs         # + - * / %
│   ├── ScientificOperations.cs    # Facade for scientific functions
│   ├── Trigonometry.cs            # sin / cos / tan (degrees)
│   ├── Logarithmic.cs             # log / ln
│   ├── PowerOperations.cs         # power / square / cube
│   ├── MemoryManager.cs           # memory store / recall / M+ / M-
│   ├── HistoryManager.cs          # calculation history
│   ├── ThemeManager.cs            # console themes
│   ├── InputHandler.cs            # safe input parsing and shortcuts
│   ├── OutputHandler.cs           # menu and output
│   ├── NumberFormatter.cs         # consistent number formatting
│   └── Validator.cs               # input checks
├── ProCalculator_VS_1.0.Tests/    # xUnit tests
├── .github/workflows/             # CI and release automation
├── ProCalculator_VS_1.0.sln
├── LICENSE
└── README.md
```

## 🚢 Making a release

Pushing a version tag builds the app and publishes a GitHub release automatically:

```bash
git tag v1.0.0
git push origin v1.0.0
```

## 🔮 Ideas for the future

- [ ] Graphical user interface (WPF / WinForms / MAUI)
- [ ] Expression parsing (`2 + 3 * (4 - 1)`)
- [ ] Radians / degrees mode switch
- [ ] Save history to a file
- [ ] Inverse trigonometric and hyperbolic functions

## 👨‍💻 Author

**MD Nazrul Islam** – [@mdnazrulislambd](https://github.com/mdnazrulislambd)

Released under the [MIT License](LICENSE).

---

⭐ If you find this project useful, consider giving it a star.
