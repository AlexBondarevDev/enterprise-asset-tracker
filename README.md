# Enterprise Asset Tracker

![Authorization](https://github.com/user-attachments/assets/26340b6c-7f25-4ca5-b1f3-565fb2b3a67b)
![ReceiptEA](https://github.com/user-attachments/assets/90a13b31-6557-4858-aaf3-2127a10490d7)
![Analitics](https://github.com/user-attachments/assets/d3952777-37b7-46ee-964a-416bb4592aa2)
![SaldoReport](https://github.com/user-attachments/assets/7797014c-a1d3-4d22-bbfa-3e9b324e096a)

Enterprise Asset Tracker is an automated information system for managing and tracking enterprise assets. It allows businesses to efficiently monitor, record, and manage their fixed assets using a user-friendly interface and powerful database integration.

#### User Roles: Economist and Administrator.

Economist - main functions:
- Tracking the movement of enterprise assets, from acquisition to disposal.
- Recording data on repairs and upgrades performed on enterprise assets.
- Generating reporting and analytical documentation based on the data.

Administrator - main functions:
- Deleting data that requires "Administrator" access level.
- Managing data in the application directories.
- Managing data on asset custodians.
- Managing user accounts and access level permissions.

### Prerequisites

Before you begin, ensure you have the following installed on your machine:

- [.NET Framework](https://dotnet.microsoft.com/download/dotnet-framework) (version 4.7.2 or later)
- [MySQL](https://dev.mysql.com/downloads/mysql/) (version 5.6 or later)

### Installing

Follow these steps to get the development environment up and running:

1. **Clone the repository:**
   git clone https://github.com/AlexBond266/enterprise-asset-tracker.git

2. **Set up the MySQL database:**
   - Create a new MySQL database.
   - Execute the provided SQL script (`eat_db.sql`) to set up the required tables and schema.
     
![db](https://github.com/user-attachments/assets/ba511c4f-fd0b-4446-b359-061a2e658911)

3. **Configure the database connection:**
   - Open the project in Visual Studio.
   - In the `EnterpriseAssetTracker/scripts/DatabaseHelper.cs` file, update the connection string to point to your MySQL database.

4. **Some NuGet packages are missing from this solution:**
   - Open the Package Manager Console.
   - Click to `Restore` from your online package sources.

5. **Build the project:**
   - Use Visual Studio to build the solution.
   - Ensure there are no build errors.

6. **Run the application:**
   - Start the application from Visual Studio.
   - The main window should appear, allowing you to begin managing enterprise assets.

### Deployment

To deploy the Enterprise Asset Tracker on a live system:

1. **Publish the application:**
   - Use the Publish feature in Visual Studio to create a release build.
   - Package the application for distribution.

2. **Set up the live environment:**
   - Install MySQL on the target server.
   - Set up the database using the provided SQL script.
   - Deploy the application to the server.

3. **Run the application:**
   - Ensure the application is configured correctly with the live database.
   - Start the application and begin using it in a production environment.

### Built With

- **WinForms** - For the graphical user interface
- **BunifuUI** - For a sleek and modern user interface
- **MySQL** - For database management
- **Visual Studio** - For development and debugging

### Acknowledgments

- Thanks to anyone whose code or libraries were used in this project.
- Inspiration from similar asset management tools.