	Tools used for this task
	1. Microsoft Visual Studio Professional 2022 (64-bit)
	2. Google chrome browser Version 110.0.5481.178 
	
	Packages used 
	1. Selenium webdriver(4.8.1)
	2. Nunit (3.13.3)
	3. Extent reports(4.1.0)
	4. Chromedriver(110.0.5481.7700)

	Steps to run from Visual studio 2022
	1. Open the TradingViewE2ETests.sln in visual studio 2022
	2. Build the solution
	3. Go to menu View->Test Explorer
	4. Expand tests and right click on VerifyCurrencyOverviewPage
	5. Click Run
	6. After executing the test and closing the chrome browser
	   Goto ->TradingViewE2ETests/ExtentReports open index.htm in chrome to view the extent report

	Steps to run through command promp
	1. Open comman prompt
	2. Enter-> cd TradingViewE2ETests folder path
	3. Enter command ->dotnet test --no-build ./TradingViewE2ETests.csproj --verbosity normal  --logger "trx;LogFileName=TestResult.trx" --filter Name~VerifyCurrencyOverviewPage
	4. After executing the test and closing the chrome browser
	   Goto ->TradingViewE2ETests/ExtentReports open index.htm in chrome to view the extent report
	5. Goto ->TradingViewE2ETests/TestResult and open TestResult.trx in visual studio to view TestResult(optional)

	