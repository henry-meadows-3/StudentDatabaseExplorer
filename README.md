# Student Database Explorer

This repository contains the source code for a GUI-based database interface called **StudentDatabaseExplorer**.

## About This Project
The application is built using **C#** and **Windows Presentation Foundation (WPF)**.

- The interface is defined using **XAML** (eXtensible Application Markup Language).
- The **C# code-behind** handles user interactions, including:
  - Click event handler for the **Add Student** button
  - Click event handler for the **Load Students** button
  - Click event handler for the **Load Enrollment** button
  - Click event handler for **Help :arrow_right: About**
  - Click event handler for **File :arrow_right: Exit**

## Setup Instructions

### Prerequisites
- **Visual Studio 2022** (Community Edition is fine)
- **.NET Desktop Development** workload installed
- **.NET 6 or .NET 7 SDK** (depending on your project settings)

### How to Run the Project
1. Clone the repository:
   ```
   git clone https://github.com/henry-meadows-3/StudentDatabaseExplorer.git
   ```
2. Open the solution file (`.slnx`) in Visual Studio
3. Build the project using **Build :arrow_right: Build Solution**.
4. Run the application with **Start Debugging** (F5).

# Project Structure
```
StudentDatabaseExplorer/
│
├── StudentWorksheetStarter.slnx
├── StudentWorksheetStarter.csproj
├── App.xaml
├── App.xaml.cs
├── MainWindow.xaml
├── MainWindow.xaml.cs
├── students.db                      # SQLite database created on SQLiteOnline.com
├── Assets
│   └── Logo.png                     # .png created by AI to provide branding 
├── Data
│   └── Database.cs
└── README.md
```

## Database Information

This project uses a pre-built SQLite database (`students.db`) that was created using **SQLiteOnline.com**.  
The database is included in the repository so students do not need to create it themselves.

### What’s in the database
- A `Students` table containing sample student records  
- An `Enrollment` table linking students to courses  
- Basic test data for practicing queries and loading information into the GUI

### How the application uses the database
The WPF application connects directly to `students.db` using standard SQLite connections.  
Students can:
- Load student records  
- View enrollment information  
- Add new students 

## Modifying the Database (Optional)

If you want to explore or edit the database:

1. Visit https://sqliteonline.com
2. Upload the `students.db` file
3. Run SQL queries, add tables, or modify data
4. Save and replace the file in the project directory

Changes will appear the next time you run the application.

## Future Enhancements

Potential improvements for future versions:

- Add the ability to create or initialize the SQLite database automatically if it is missing
- Expand the database schema (e.g., Courses table, Instructors table, Grades table)
- Add search, filtering, and sorting features for student records
- Implement input validation before inserting new students into the database
- Add UI improvements such as themes, styling, or responsive layout adjustments
- Add support for editing or deleting existing student records
- Implement database migrations or versioning for easier updates
- Add unit tests for database access logic and data models

## Purpose of this Repository
This project is designed to give studetns hands-on experience downloading, running, and exploring a WPF application connected to a SQLite database.
