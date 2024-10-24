Cloning and Running the Application

1. Clone the repository
   -Open terminal/command prompt
   -Navigate to where you want to store the project
   cd C:\Projects  # Windows example
   -Clone the repository (replace with your actual repository URL)
   git clone https://github.com/yourusername/ContractMonthlyClaimSystem.git
   -Navigate into the project directory
   cd ContractMonthlyClaimSystem
   
2.Restore and build the application
   -Restore NuGet packages
   dotnet restore
   -Build the application
   dotnet build
   
3. Update database (if using Entity Framework)
   bash
   -Apply database migrations
   dotnet ef database update
   
4. Run the application
   bash
   # Run the application
   dotnet run
   
5. Access the application
   - Open a web browser
   - Navigate to https://localhost:5001 or http://localhost:5000
   - The exact URLs will be shown in the terminal when you run the application

