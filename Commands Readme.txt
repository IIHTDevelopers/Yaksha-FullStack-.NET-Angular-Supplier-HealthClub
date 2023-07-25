BackEnd-Commands
* On command prompt, cd into your project folder (cd <Your-Project-folder>).

* To connect SQL  server from terminal:
(SupplierManagement /sqlcmd -S localhost -U sa -P pass@word1)
	-To create database from terminal - 
	1> Create Database SupplierManagement_Db
	2> Go

*	Steps to Apply Migration(Code first approach):
	- Press Ctrl+C to get back to command prompt
	- Run following command to apply migration-
             (SupplierManagement /dotnet-ef database update)


* To check whether migrations are applied from terminal:
(SupplierManagement /sqlcmd -S localhost -U sa -P pass@word1)

	1> Use SupplierManagement_Db
	2> Go
	1> Select * From __EFMigrationsHistory
	2> Go

* To build your project use command:
	(SupplierManagement/dotnet build)

* To launch your application, Run the following command to run the application:
	(SupplierManagement/dotnet run)


* To test web-based applications on a browser, use the internal browser in the workspace. Click on the second last option on the left panel of IDE, you can find Browser Preview, where you can launch the application.
	Note: The application will not run in the local browser

* To run the test cases in CMD, Run the following command to test the application:
	(SupplierManagement.Tests/dotnet test --logger "console;verbosity=detailed")
	(You can run this command multiple times to identify the test case status,and refactor code  to make maximum test cases passed before final submission)             
* You need to use CTRL+Shift+B - command compulsorily on code IDE, before final submission as well. This will push or save the updated contents in the internal git/repository, and will be used to evaluate the code quality.



FrontEnd-Commands
* You can follow series of command to setup Angular environment once you are in your project-name folder:

* npm install -> Will install all dependencies -> takes 10 to 15 min

* npm run start -> To compile and deploy the project in browser. You can press <Ctrl> key while clicking on localhost:4200 to open project in browser -> takes 2 to 3 min

* npm run test -> to run all test cases. It is mandatory to run this command before submission of workspace -> takes 5 to 6 min

* You need to use CTRL+Shift+B - command compulsorily on code IDE, before final submission as well. This will push or save the updated contents in the internal git/repository, and will be used to evaluate the code quality.
