# DogWalkerApp - ECI Coding Challenge 2025 - Luis Enrique Martínez

Welcome to **DogWalkerApp**, a desktop application developed as part of the ECI coding challenge. Its purpose is to streamline the management of dog walking operations including clients, subscriptions, payments, walkers, dogs, and scheduled walks.

---

## Prerequisites

Make sure you have the following tools installed:

- **Visual Studio 2022 or newer**
- **.NET 8.0 SDK**
- **SQL Server LocalDB** (included with Visual Studio)
- (Optional) [SQL Server Management Studio (SSMS)](https://learn.microsoft.com/sql/ssms/download-ssms) to explore the database

---

## How to Run the Project

### 1. Clone or unzip the project

If you downloaded the `.zip` file, simply extract its contents.

If you use Git:

```bash
git clone https://github.com/luis-maca/DogWalkerApp.git
```

---

### 2. Open the solution in Visual Studio

Open the `DogWalkerApp.sln` file.

---

### 3. Set the startup project

Right-click on `DogWalkerApp.WinForms` → **Set as Startup Project**.

---

### 4. Run the database migrations

If this is your first time running the app, you'll need to initialize the database.

Open the **Package Manager Console** in Visual Studio and run:

```powershell
Update-Database -Project DogWalkerApp.Infrastructure
```

This will create the database automatically using the included schema and seed data.

---

### 5. Start the application

Press `F5` or click **Start** in Visual Studio.  
The login window will appear.

---

## Login Credentials

You can log in with any of the preloaded demo users (These are included in the DbInitialiazer.cs file):

```
Username: admin
Password: 1234

Username: demo
Password: demo
```

These accounts are automatically added on the first run.

---

## Key Features

- Full CRUD management for **Clients**, **Subscriptions**, **Payments**, **Walkers**, and **Dogs**
- Schedule dog walks with support for multiple dogs per client
- Smart validations:
  - Conflicting walk times
  - Max dogs per walk
  - Walker availability
  - Active subscriptions
- Weekly stats and today’s walk summary on the home page
- Modern and user-friendly **WinForms UI** using MVP architecture
- Footer displaying app version and author signature

---

## Author

Developed by **Luis Enrique Martínez**  
For the **ECI Coding Challenge 2025**

---

## Version

**v1.0.0**  
Dog Walker Management App - 2025

---

Thanks for taking the time to review this project. I'm happy to answer any technical or functional questions regarding this solution.
---
You can also visit my web-site to know a little bit more about my experience and background (USE MY AI AGENT!): https://luismartinezca.info/
---
