# Chantin

## Condominium Resident Management System Ver. 2.0.0

## Features:

* Property Management Company (Legal Name, Address, Tax Information, Bank Accounts)
* Condominiums / Houses / Apartments / Housing Units / Residential Communities
* Residents (Contacts, Vehicles, Pets, Access Tags, Tax Information)
* Account Statements by Condominium / House / Street / Private Community / Building
* Publication of Documents such as Regulations / Assembly Minutes / Announcements / Others
* Access Control for Suppliers / Visitors / Domestic Staff / Others
* Scheduled Visits
* Income / Expense Management
* Issuance of Payment Receipts / Invoices / Expense Records
* Payment Concepts (Maintenance Fees, Special Assessments, Reservation Fees, Cleaning Fees, etc.)
* Homeowners Association Board
* Neighborhood Alerts
* Surveys and Voting for Initiatives / Evaluations / Others
* Service Requests
* Achievements and Activity History
* Resident / Supplier Directory
* Comments and Suggestions
* Common Area Reservations: Event Halls / Sports Courts / Recreational Areas / Palapas / Others
* Notifications for Meetings / Assemblies / Others (via Email / WhatsApp / Push Notifications)
* Internal Chat
* Authentication with Local Users or External Providers: Google, Microsoft, and Apple
* Multi-language Support, initially Spanish and English

## Architecture

### Backend - API Services

* Clean Architecture
* .NET Core
* Minimal API Services
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
