# RegisterApplication in Asp.net core 8 web api

# Setup project
1. Clone the repo
   ```sh
   git clone https://github.com/Qaizx/RegisterApplication.git
   ```
2. Connect PostgreSQL server
3. Config ConnectionString: DefaultConnection to postgres server in appsettings.json
   ```sh
   "ConnectionStrings": {
    "DefaultConnection": "your config db connection"
   }
   ```
5. Package Manager Console
   1. Update database
      ```sh
      Update-Database
      ```
   2. Optional: If you want to migrate database as new version
       ```sh
       Add-Migration *{your file name migration}
       ```

# Tool
- Visual Studio

