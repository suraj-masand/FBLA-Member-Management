# FBLA Member Management System
***
* Competitor: Suraj Masand
* School: Alpharetta High School
* State: Georgia
* Event: Desktop Application Programming
* First Place - 2016 FBLA National Leadership Conference
* README.txt
***
## **Introduction / Notes**

The FBLA Member Management System application was developed by Suraj Masand from Alpharetta High School for FBLA's Desktop Application Programming competition at the 2016 FBLA National Leadership Conference. The application has a simple, user-friendly interface that allows the user to view, add, and update data for FBLA members, as well as generate reports from that data. This app also allows the user to save the reports as an Excel spreadsheet or a PDF. Further information on functionality can be found in the "Instructions" section below.

This application was developed using the C# (C-sharp) programming language and the Microsoft Visual Studio 2013 IDE. The app uses an embedded database (SQLite) to store and retrieve the data. A sample of 200 mock records has been included in the database for testing purposes. The app has been tested on Windows 8.1 and Windows 10, but may also work with prior versions of Windows. *Note* The exporting to Excel (.xls) will not work unless Excel is installed on the user’s machine.

The original code has been provided and can be opened in Microsoft Visual Studio. In Visual Studio, select the "File" tab, then select "Open" --> "Project/Solution" and navigate to the "SourceCode" folder and the "FBLA-App-1.sln" file inside. To open the code as a text file, you can navigate to "FBLA-App-1" within the "SourceCode" folder, right click on the ".cs" file(s), select "Open with...", and choose a text editor such as Notepad. Also, a PDF of all of the code has been provided, entitled "SourceCodePDF.pdf". A PDF of the screenshots of each screen can also be found, entitled "Screenshots.pdf". Instructions to run and use the program are found below as well as in the "About This Application" page within the application. Specific instructions for each screen can be found at the top right of the corresponding screen within the program.

## **Instructions**

Instructions for using each screen can be found below, as well as within the application in the upper right corner of the corresponding page / screen.

#### Running the Application
In order to open and run the application, open the "Execute" folder and double-click on the "FBLAMemberManagement.exe" file, or right-click on the file and select "Open". The program should automatically open up to the Home View.  



#### Home View

Here, you can see all of the data that is currently stored. There are 200 (fake) records as pre-populated data for testing this program. At the top right of the window, there is a link labeled "About this application", which will open a new window with all the information found here in this README file. All of this information can be found within the application by clicking that link. At the top left of the window, you will see a button that says "Show All Members". When this is clicked, all 200 records will appear in the table below. In the top middle of the window,  there is a search box, where you can search the students' FBLA membership number, first name, last name, email address, school, and state. After entering the search criteria, the table below will update the records shown. The search can be undone by clicking "Show All Members". At the top right of the window, you can see the total number of records shown, which should initially say "200" and will update if the user uses the "search" feature.

In the middle of the Home View, there is a table that shows all the data in the data table, unless the user uses the "search" function, which will yield only the search results. To edit an existing record, double-click on the record you want to edit, or select the row and click the "Edit Member" button at the bottom of the window. This will open up a new window with the member information, and the fields can be edited and saved from there. At the bottom of the window, in the center there is an "Add FBLA Member" button, which will open a form to fill out the information for a new member. All the fields are required except for the email and the amount owed (which is preset to zero). When you click save, the form will validate all the data, and if it is all validated, a new record will be added to the database. There is also a "Create Report" button at the bottom right of the window. This will open a form where you can select the criteria for a report and then generate the report.

At the top right of the window, there is a "Help" button, which will contain most of the same information as shown here in the README file.

#### Add or Edit FBLA Member
To add a new FBLA Member record to the database, click the "Add FBLA Member" button at the bottom of the Home View window. This will open up a form for inputting the information associated with the FBLA Member. The Membership Number field is the number assigned by FBLA to each student. This number must only contain digits, and must be unique. The First Name and Last Name fields must also be provided. The student's email is an optional field, but if the field is not blank, it must be in a proper email format. The school name must be provided, and the school grade and state must be selected from their drop-down boxes. The final pieces of information include whether the member is active, the year the member joined FBLA, and the amount of money that the member owes. The default year joined is the current year. If the member does not owe any money, the default value is 0.00 dollars. Fields that are invalid will be marked by a red background. Click "Save" at the bottom of the window to create / add the data to the database.

In the Home View, if a row is double-clicked, or if a row is highlighted and "Edit Member" is clicked, the Edit FBLA Member form will open. This form contains the same fields as the Add FBLA Member form, but all the data is pre-populated from the existing record. Here, changes can be made to all of the fields. The fields work the same way as described in the previous paragraph about adding a new FBLA member.

#### Create Report Form
At the bottom right of the Home View, click the "Create Report" button to start the process of creating a report. Once the new form opens up, select which types of members you would like to include in the report. For the purposes of testing, you may select the presets shown at the top of the window in the drop-down box. The first preset is a list of all members who owe money. The second preset is a list of all the seniors (12th grade students).

Whether or not you choose a preset, the report can be customized. You can choose to include members from a specific state, members who are active/inactive, and/or members who owe money. You can also decide to include members in certain grades. The final filter is to decide how to sort the report. The final options for creating the form is to choose which columns of data to include in the form.

Near the top of the window, you have the option of resetting the filters, as well as selecting all of the columns to be included in the report. Once you have selected your desired options, click "Generate Report" at the bottom of the window.

#### Generated Report and Exporting
Once you have clicked "Generate Report" in the previous form, a new window will pop-up showing a table of the specified data. In the top left, the total number for records found (based on the previously selected filters) will be shown. In the top center, there is an option to change the number of records shown per page within this window. Based on the selected number of records per page, the number of pages (shown to the right) will be updated. The user can directly type in a page number or use the buttons in the upper-right corner to navigate through the pages. The bottom of the window shows several statistics about the member data that is included in the report. The total number of active and inactive members, the number of members who owe money, and the total amount owed, are all shown near the bottom. Also at the bottom of the page are options to export the report as an Excel file (.xls) or as a PDF.

##### *Note 1*
The exporting to .xls will not work unless Excel is installed on your machine. Since the Excel file is generated programmatically, there will be a confirmation prompt when you first open the Excel spreadsheet file, asking you if you want to continue since the data may not be in the proper format. Select "Yes" to continue and open the Excel file with the report data.

##### *Note 2*
The PDF button will save the report as a PDF and automatically open the file in your computer's default PDF viewer application. From there, you can print the report using your PDF-viewing application. The PDF that is created will include a maximum of 50 records per page, with a footer at the end of the report. The footer contains the same information as the bottom of the report-viewing window.

## **Functions of the Classes**
The application is composed of nine classes and one SQLite database file. Four of these classes are run in the background. These classes are: Program, FBLAMember, DButils, and Extensions. Program.cs is the entry point of the application, which tells the application which Windows Form to open first, which is the Home View in this application. The other three back-end classes contain methods and objects for the other classes to use to retrieve, store, and format data. The other eight classes in the application are: HomeView, AddEditMember, CreateReportForm, and ReportForm, AboutForm, AboutAddEditMember, AboutReport, and AboutGeneratedReport. The HomeView launches the first window when the program is opened. The AddEditMember class opens a form to allow the user to add a record or edit the information of an exiting record. The CreateReportForm class opens a window where the user can select the filters used when generating a report, and the user can also select which columns to include in the report. The ReportForm class contains the report that was generated, along with options to export the report. The rest of the classes each open a window that contains help / instruction text to guide the user.

The SQLite database file, named FBLAMembership.db, contains all of the member information and comes preloaded with 200 mock records. This database is permanently affected by changes the user makes to it in the application. Therefore, all changes are stored even if the application is closed and reopened at a later date.

*END*
