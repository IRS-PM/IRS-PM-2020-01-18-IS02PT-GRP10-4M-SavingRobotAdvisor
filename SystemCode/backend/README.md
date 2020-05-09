
## Setup instructions for backend Web Api

##### Step 1:
Download IDE Visual Studio Code: https://code.visualstudio.com/download
Download Dotnet Core 2.2 SDK: https://dotnet.microsoft.com/download/dotnet-core/2.2

#### Step 2:
Open Visual Studio Code IDE and click Extension icon/button at left side of window,
then type keywords 'C#' in the extension search box to enable C# language for Visual Studio Code

#### Step 3:
Click File menu from top left corner in Visual Studio Code and select 'Open Folder',
to choose the folder name 'SavingRobotAdvisorApi', which is the source code of dotnet core web api downloaded in the beginning of frontend setup instruction.

#### Step 4: 
1. Press "Ctrl+`" to open Terminal in Visual Studio Code.
2. Navigate to project folder IRS-MRS-2020-01-18-IS02PT-GRP-4M-SavingRobotAdvisor\api\SavingRobotAdvisorApi
3. Type command "dotnet build" to wait for build successful status
4. Type command "dotnet run" to web api application (The default web api URL http://localhost:5000 will be launched and opened in browser)
5. Copy the below test Request URL and open it in Postman for web api testing
   Request URL : http://localhost:5000/api/SavingRobotAdvisor
   Request Method: HTTP Get
   Request Content-Type: application/json
   Request Body: "{\"Income\":5000,\"Balance\":10000,\"MonthlySpending\":{\"TotalAmount\":2000,\"GroceryPercent\":0.35,\"DiningPercent\":0.25,\"PublicTransportPercent\":0.05,\"PetrolPercent\":0.2,\"TelcoPercent\":0.05,\"TravelPercent\":0.1}}"
6. The below sample response will be returned by web api:
[{
  "bank": "UOB",
  "account": "UOBONE",
  "card": "UOBONE",
  "interest": 577.5,
  "interest_rate": 1.92,
  "rebate": 198,
  "rebate_rate": 3.3
}]
7. Web Api setup finished.
8. Alternatively, just press F5 in visual studio code to launch web api endpoint in a fast way.
