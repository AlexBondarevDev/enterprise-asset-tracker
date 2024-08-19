# Enterprise Asset Tracker
![add_asset](https://github.com/user-attachments/assets/808ab04c-38a7-4f4d-bde2-6f968ede10c1)
![analitics](https://github.com/user-attachments/assets/cbea9f67-8763-4fb9-bcca-f233c3e339c5)

Enterprise Asset Tracker is an automated information system for managing and tracking enterprise assets. It allows businesses to efficiently monitor, record, and manage their fixed assets using a user-friendly interface and powerful database integration.

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
   - Execute the provided SQL script (`kbd.sql` or `kbd.xml`) to set up the required tables and schema.

3. **Configure the database connection:**
   - Open the project in Visual Studio.
   - In the `EnterpriseAssetTracker/scripts/Database.cs` file, update the connection string to point to your MySQL database.

4. **Install BunifuUI:**
   - Open the Nuget Console.
   - `dotnet add package Bunifu.UI.WinForms --version 1.11.5.1` or later version.

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
