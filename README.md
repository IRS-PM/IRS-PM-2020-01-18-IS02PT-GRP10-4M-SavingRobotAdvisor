This project was bootstrapped with [Create React App](https://github.com/facebook/create-react-app) and dotnet core 2.2 Web Api.

## Setup instructions for frontend

Before installing you must have npm and node installed, if not please go through the below link

https://nodejs.org/en/

https://www.npmjs.com/get-npm

Recommended to use Webstorm IDE. Register as educational user for free license
(https://www.jetbrains.com/student/)

https://www.jetbrains.com/webstorm/


##### Step 1:
Copy the Github URL:
https://github.com/gvinto/IRS-MRS-2020-01-18-IS02PT-GRP-4M-SavingRobotAdvisor

##### Step 2:
Checkout the project from Github in Webstorm
https://www.jetbrains.com/help/webstorm/manage-projects-hosted-on-github.html

##### Step 3: 
/* Delete the node_modules folder and any 'lock' files such as 
yarn.lock or package-lock.json if present.*/

##### Step 4: 
Install project dependencies (this will take a while)

`npm install` (Webstorm will usually prompt this after checkout)

##### Step 5:
Add a run configuration for 'npm start'
https://www.jetbrains.com/help/webstorm/run-debug-configuration-npm.html

Run the app in the development mode.<br />
Open [http://localhost:3000](http://localhost:3000) to view it in the browser.

The page will reload if you make edits.<br />
You will also see any lint errors in the console.

#Additional information
## Available Scripts

In the project directory, you can run:

### `npm start`

Runs the app in the development mode.<br />
Open [http://localhost:3000](http://localhost:3000) to view it in the browser.

The page will reload if you make edits.<br />
You will also see any lint errors in the console.

### `npm test`

Launches the test runner in the interactive watch mode.<br />
See the section about [running tests](https://facebook.github.io/create-react-app/docs/running-tests) for more information.

### `npm run build`

Builds the app for production to the `build` folder.<br />
It correctly bundles React in production mode and optimizes the build for the best performance.

The build is minified and the filenames include the hashes.<br />
Your app is ready to be deployed!

See the section about [deployment](https://facebook.github.io/create-react-app/docs/deployment) for more information.

### `npm run eject`

**Note: this is a one-way operation. Once you `eject`, you can’t go back!**

If you aren’t satisfied with the build tool and configuration choices, you can `eject` at any time. This command will remove the single build dependency from your project.

Instead, it will copy all the configuration files and the transitive dependencies (Webpack, Babel, ESLint, etc) right into your project so you have full control over them. All of the commands except `eject` will still work, but they will point to the copied scripts so you can tweak them. At this point you’re on your own.

You don’t have to ever use `eject`. The curated feature set is suitable for small and middle deployments, and you shouldn’t feel obligated to use this feature. However we understand that this tool wouldn’t be useful if you couldn’t customize it when you are ready for it.

## Learn More

You can learn more in the [Create React App documentation](https://facebook.github.io/create-react-app/docs/getting-started).

To learn React, check out the [React documentation](https://reactjs.org/).

### Code Splitting

This section has moved here: https://facebook.github.io/create-react-app/docs/code-splitting

### Analyzing the Bundle Size

This section has moved here: https://facebook.github.io/create-react-app/docs/analyzing-the-bundle-size

### Making a Progressive Web App

This section has moved here: https://facebook.github.io/create-react-app/docs/making-a-progressive-web-app

### Advanced Configuration

This section has moved here: https://facebook.github.io/create-react-app/docs/advanced-configuration

### Deployment

This section has moved here: https://facebook.github.io/create-react-app/docs/deployment

### `npm run build` fails to minify

This section has moved here: https://facebook.github.io/create-react-app/docs/troubleshooting#npm-run-build-fails-to-minify

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
5. Copy the below test URL and open it in browser for web api testing
http://localhost:5000/api/SavingRobotAdvisor/?income=5000&balance=30000&spending=500
6. The below sample response will be returned by web api:
{
  "bank": "UOB",
  "account": "UOBONE",
  "card": "UOBONE",
  "interest": 577.5,
  "interest_rate": 1.92,
  "rebate": 198,
  "rebate_rate": 3.3
}
7. Web Api setup finished.
8. Alternatively, just press F5 in visual studio code to launch web api endpoint in a fast way.
