# Student Database Explorer

This repository contains the source code for a GUI-based database interface called **StudentDatabaseExplorer**.

## About This Project
The application is built using **C#** and **Windows Presentation Foundation (WPF)**.

- The interface is defined using **XAML** (eXtensible Application Markup Language).
- The **C# code-behind** handles user interactions, including:
  - Click event handler for the **Add Student** button
  - Click event handler for the **Load Students** button
  - Click event handler for the **Load Enrollment** button
  - Click event handler for **Help ➡️ About**
  - Click event handler for **File :arrow_right: Exit**

---

## Setup Instructions

### Prerequisites
- **Visual Studio 2022** (Community Edition is fine)
- **.NET Desktop Development** workload installed
- **.NET 6 or .NET 7 SDK** (depending on your project settings)

### How to Run the Project
1. Clone the repository:
   ```bash
   git clone https://github.com/henry-meadows-3/StudentDatabaseExplorer.git
2. Open the solution file (`.sln`) in Visual Studio
3. Build the project using **Build :arrow_right: Build Solution**.
4. Run the application with **Start Debugging** (F5).

---
# Project Structure
```
StudentDatabaseExplorer/
│
├── StudentDatabaseExplorer.sln
├── App.xaml
├── App.xaml.cs
├── MainWindow.xaml
├── MainWindow.xaml.cs
├── Models/
│   ├── Student.cs
│   └── Enrollment.cs
├── Data/
│   └── SampleData.json   (if applicable)
└── README.md```
