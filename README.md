# Retail-Management-System
Workshop 1

1. This project is required to run in the Microsoft Visual Studio (Suggest version: 2019)
2. To implement this system, you should install the Microsoft Visual studio and install the ".Net desktop development" in its installer
3. Extract the "Retail Management System.rar" and then open the "Retail Management System.sln"
4. Click the "Connect to Database" icon in the "Server Explorer" then the "add connection" dialog will appear
5. Select "Microsoft SQL Server Database File (SQLClient)" as the "Data source" and browse the "Data.mdf" file which is in the "Retail Management System.rar" to the "Database file name" and then click "OK"
6. After that, expand "Data Connections" in the "Server Explorer" and the right click and select the "Properties" of the "Data.mdf" that we just added into the "Data Connections"
7. Copy the "Connection String" at the properties of the "Data.mdf"
8. Double click to open the "Connection.cs" at the "Solution Explorer" and paste the string copied into the double quote of the "ConString"
9. Then click the "Start" to run the application
10. This system is design as the first registered user will be the admin of the whole system and the rest users will be the normal store owner
11. You can login with these pre-registered account: 
	ADMIN: 
		Store name	: FTMK Store
		Password	: 123123
	NORMAL USER:
		Store name	: FKE Store
		Password	: abcabc
12: Lets try it!
