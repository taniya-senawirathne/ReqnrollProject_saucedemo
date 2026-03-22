# ReqnrollProject_saucedemo


BDD test suite for the [SauceDemo](https://www.saucedemo.com/) checkout flow, built with Reqnroll (SpecFlow successor), Selenium WebDriver, and NUnit on .NET 8.

---

## Tech Stack

| Tool | Version |
|---|---|
| .NET | 8.0 |
| Reqnroll.NUnit | 3.3.3 |
| NUnit | 4.5.1 |
| Selenium WebDriver | 4.41.0 |
| Chrome WebDriver | 85.0.0 |

---

## Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8)
- Google Chrome browser installed
- ChromeDriver compatible with your Chrome version (see note below)

---

## Setup

1. **Clone the repository**
   ```bash
   git clone https://github.com/taniya-senawirathne/ReqnrollProject_saucedemo.git
   cd ReqnrollProject_saucedemo
   ```

2. **Restore dependencies**
   ```bash
   dotnet restore
   ```

3. **Build the project**
   ```bash
   dotnet build
   ```

---

## Running the Tests

Run all scenarios:
```bash
dotnet test
```

Run with detailed console output:
```bash
dotnet test --logger "console;verbosity=detailed"
```

After the test run completes, a `LivingDoc.html` report is automatically generated in the build output directory and opened in your default browser.

---

## Project Structure

```
├── Features/               # Gherkin .feature files
├── StepDefinitions/        # Step definition implementations
├── Pages/                  # Page Object Model classes
├── Drivers/                # WebDriver factory
├── Hooks/                  # Before/After scenario setup & teardown
├── Support/                # Shared constants (base URL, credentials)
└── reqnroll.json           # Reqnroll configuration
```

---

## Test Scenarios

All scenarios are defined in `Features/Checkout.feature` and cover:

- End-to-end checkout with a single item
- Cart badge item count after adding an item
- Checkout overview pricing (item total + tax)
- Validation error on empty checkout form submission
- Navigation back to products after order completion

---

## Assumptions & Considerations

- **Credentials are hardcoded** in `Support/TestSettings.cs` using the standard SauceDemo test account (`standard_user` / `secret_sauce`). These are public demo credentials.
- **Chrome only** — the `DriverFactory` is configured for Chrome and launches with a maximised window. No other browsers are supported without modifying `DriverFactory.cs`.
- **ChromeDriver version** — the project references `Selenium.Chrome.WebDriver 85.0.0`. If your installed Chrome version is significantly newer, you may need to update this package or manually place a matching ChromeDriver on your `PATH`.
- **Living Doc report** — the `Expressium.LivingDoc.ReqnrollPlugin` generates `LivingDoc.ndjson` during the run and an HTML report (`LivingDoc.html`) at the end. The `AfterTestRun` hook attempts to open it automatically; this may not work in headless/CI environments.
