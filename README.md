# Chantin

## Condominium Resident Management System
Version 2.0.0

## Features

* Property Management Company (Legal Entity Name, Address, Tax Information, Bank Accounts)
* Condominiums / Houses / Apartments / Housing Units / Residential Communities
* Residents (Contacts, Vehicles, Pets, Access Tags, Tax Information)
* Account Statements by Condominium / House / Street / Private Community / Building
* Publication of Documents such as Regulations / Assembly Minutes / Announcements / Others
* Access Control for Suppliers / Visitors / Domestic Staff / Others
* Scheduled Visits
* Income and Expense Management
* Issuance of Payment Receipts / Invoices / Expense Records
* Payment Concepts (Maintenance Fees, Special Assessments, Reservation Fees, Cleaning Fees, etc.)
* Homeowners Association Board
* Community Alerts
* Surveys and Voting for Initiatives / Evaluations / Others
* Service Requests
* Achievements and Activity History
* Resident and Supplier Directory
* Comments and Suggestions
* Common Area Reservations: Event Halls / Sports Courts / Recreational Areas / Palapas / Others
* Notifications for Meetings / Assemblies / Others (via Email / WhatsApp / Push Notifications)
* Internal Chat
* Authentication with Local Users or External Providers: Google, Microsoft, and Apple
* Multilingual Support, initially Spanish and English

## Architecture

### Backend - API Services

* Clean Architecture
* .NET Core
* Minimal APIs
* SQL Server
* Entity Framework
* Chat Service with WebSockets

### Folder Structure

```text
├── Api
│   ├── Chantin.Api
│   │   ├── EndPoints
│   │   └── Services
│   ├── Chantin.Core
│   │   ├── Features
│   │   └── Interfaces
│   ├── Chantin.Domain
│   │   ├── Config
│   │   ├── Entities
│   │   ├── Enums
│   │   ├── Dto
│   │   └── Models
│   └── Chantin.Infrastructure
│       ├── Persistence
│       │   └── Configurations
│       ├── Repositories
│       └── Services
└── TSM.Shared.Tools
```

### Frontend - Back Office

* Angular 22
* AdminLTE 4
* Bootstrap
* Font Awesome
* Reactive Forms
* NgRx & Effects
* Excel Export
* HTML to PDF Printing
* Ionic for Android and iOS Deployment
* Chat Service with WebSockets

### Folder Structure

```text
├── app
│   ├── core
│   │   ├── guards
│   │   ├── interceptors
│   │   ├── services
│   │   ├── providers
│   │   └── store
│   ├── shared
│   │   ├── loader
│   │   ├── dialog
│   │   ├── toaster
│   │   └── models
│   │       ├── dtos
│   │       └── enums
│   └── features
│       └── <feature>
│           ├── pages
│           └── store
└── assets
```

## Menu Structure

### Administration

```text
Administration
├── My Profile
│   ├── General Information
│   ├── Address
│   └── Tax Information
├── Employees (Third Parties)
│   ├── Address
│   ├── Departments
│   └── Positions
├── Suppliers (Third Parties)
│   ├── General Information
│   ├── Address
│   └── Tax Information
├── Treasury
│   ├── Bank Accounts
│   ├── Account Statements
│   ├── Billing
│   ├── Expense/Income Categories
│   ├── Expenses
│   └── Income
├── Residents
│   ├── General Information
│   ├── Address
│   ├── Tax Information
│   ├── Domestic Staff
│   └── Others (Access Card, Club Card, Vehicle Sticker, etc.)
├── Initiatives
├── Bids and Tenders
├── Documents
├── Surveys and Evaluations
├── Notifications
├── Service Desk
├── Chat
└── Parameters
```

### Association

```text
Association
├── My Profile
│   ├── General Information
│   ├── Address
│   └── Tax Information
├── Board of Directors
│   ├── General Information
│   ├── Address
│   └── Tax Information
├── Assemblies
│   ├── Agenda
│   └── Resolutions
├── Security
│   ├── Security Company
│   ├── Employees (Third Parties - Security Guards)
│   ├── Schedule
│   └── Access Log
├── Treasury
│   ├── Bank Accounts
│   ├── Account Statements
│   ├── Expense/Income Categories
│   ├── Expenses
│   └── Income
├── Events (Calendar)
├── Common Areas
│   ├── Fees
│   └── Schedule
├── Communications
│   ├── Notices
│   ├── Achievements
│   └── Pop-up Announcements
├── Initiatives
├── Bids and Tenders
├── Documents
├── Surveys and Evaluations
├── Notifications
├── Service Desk
└── Chat
```

### Residents

```text
Residents
├── My Profile
│   ├── General Information
│   ├── Address
│   ├── Tax Information
│   ├── Domestic Staff
│   └── Others (Access Card, Club Card, Vehicle Sticker, etc.)
├── Account Statement
│   ├── Charges
│   ├── Payments
│   └── Invoices
├── Visitors
├── Schedule
├── Administration
│   ├── Communications
│   ├── Initiatives
│   ├── Bids and Tenders
│   ├── Documents
│   └── Surveys and Evaluations
├── Association
│   ├── Communications
│   ├── Initiatives
│   ├── Bids and Tenders
│   ├── Documents
│   └── Surveys and Evaluations
├── Notifications
├── Service Desk
└── Chat
```

### Security

```text
Security
├── My Profile
│   └── General Information
├── Schedule
│   ├── Visitors
│   ├── Domestic Staff
│   ├── Suppliers
│   └── Others
└── Access Log
```

---

## Database Information

### Local Database

```text
Server: (LocalDB)\MSSQLLocalDB
Database: ChantinDB
```

### Location and Exact Command

1. Open a terminal in the workspace root (`/workspace`).
2. Run the following command:

```bash
dotnet ef migrations add InitialCreate --project src/Chantin.Infrastructure/Chantin.Infrastructure.csproj --startup-project src/Chantin.Api/Chantin.Api.csproj
```

3. To apply the migration and create the database:

```bash
dotnet ef database update --project src/Chantin.Infrastructure/Chantin.Infrastructure.csproj --startup-project src/Chantin.Api/Chantin.Api.csproj
```

### Prerequisites

Before running the commands, ensure the following:

#### Correct Connection String

Verify that `src/Chantin.Api/appsettings.json` contains the appropriate connection string for your local SQL Server:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=ChantinDB;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

If you use SQL Authentication, replace:

```text
Trusted_Connection=True
```

with:

```text
User ID=your_username;Password=your_password
```

#### EF Core Tools Installed

If the `dotnet ef` command is not recognized, install EF Core tools globally:

```bash
dotnet tool install --global dotnet-ef
```

#### Infrastructure Project Referenced

Ensure that `Chantin.Api` references `Chantin.Infrastructure`.

The file `src/Chantin.Api/Chantin.Api.csproj` should contain:

```xml
<ProjectReference Include="..\Chantin.Infrastructure\Chantin.Infrastructure.csproj" />
```

### Where Are Migration Files Stored?

By default, EF Core creates a `Migrations` folder inside the project specified by the `--project` parameter.

Expected location:

```text
/workspace/src/Chantin.Infrastructure/Migrations/
```

You should find files similar to:

```text
20231027_InitialCreate.cs
20231027_InitialCreate.Designer.cs
ApplicationDbContextModelSnapshot.cs
```

After executing `database update`, open SQL Server Management Studio (SSMS) or Azure Data Studio. You should find the **ChantinDB** database created with all tables defined in Phases 1 and 2.
