# Playwright

Playwright test repository for QMoney project. 
Playwright for .NET is a powerful framework designed for end-to-end testing, supporting all modern rendering engines including Chromium.

## Precondition
Before starting to explore Playwright, we need to make sure the following:

1. The system has Chromium installed.
2. Create a project folder in your local machine and copy the project from the repo to local.
3. Run the command below to install playwright for the first time, pointing to your local project folder:

      ./bin/Debug/net8.0/playwright.ps1 install

Note: If you plan to create project anew,select the NUnit project (as this). To understand how to create an NUnit project, please check the link https://playwright.dev/dotnet/docs/intro

Also, make sure the following is set in appsettings.json properties before execution:

 a. Build Action - Content/None
 b. Copy to Output Directory - Copy if newer 

This will improve the build performance as VS avoids unnecessary copying file to output directory.

## Running tests 

We can run the tests in two ways:

Method 1: Directly run the tests through Visual Studio.

Double-click on QMoneyCodeChallenge.sln from your local folder, right click on the QMoneyCodeChallenge project and select 'Run Tests' option.

Method 2:Run tests using Terminal or Command prompt.

In the terminal, navigate to the repo location and run the command below:

      dotnet test

Note (this is optional): The NUnit tests are run in parallel by running the tests within each file sequentially default. But this behaviour can be controlled by the queues of threads.

      dotnet test -- NUnit.NumberOfTestWorkers=4
