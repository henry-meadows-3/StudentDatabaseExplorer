using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
// The following are required for database access
using Microsoft.Data.Sqlite;
using StudentWorksheetStarter.Data;
using System.Data;

/**
 * @ID: 123456789
 * @file: MainWindow.xaml.cs
 * @namespace: StudentWorksheetStarter
 * @brief: Main window code-behind for the Student Enrollment Viewer application.
 * 
 */


namespace StudentWorksheetStarter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Event Handlers go HERE -- outside the constructor
        private void AddStudent_Click(object sender, RoutedEventArgs e)
        {
            // Read and clean input
            string studentName = StudentNameTextBox.Text.Trim();

            // Validation: prevent empty or whitespace-only names
            if (string.IsNullOrWhiteSpace(studentName))
            {
                MessageBox.Show(
                    "The student name field cannot be empty.\n\nPlease enter a name and try again.",
                    "Input Required",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);

                StudentNameTextBox.Focus();
                return;
            }

            try
            {
                // Open database connection
                using (var connection = Database.GetConnection())
                using (var command = connection.CreateCommand())
                {
                    // Parameterized INSERT statement
                    command.CommandText =
                        "INSERT INTO Students (Name) VALUES (@name);";

                    command.Parameters.AddWithValue("@name", studentName);

                    // Execute the command
                    command.ExecuteNonQuery();
                }

                // Success feedback
                MessageBox.Show(
                    "Student added successfully.",
                    "Success",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);

                // Reset input field
                StudentNameTextBox.Clear();
                StudentNameTextBox.Focus();
                StatusText.Text = $"Added student: {studentName}";
            }
            catch (Exception ex)
            {
                // Error handling
                MessageBox.Show(
                    $"An error occurred while adding the student:\n{ex.Message}",
                    "Database Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }



        private void LoadStudents_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var connection = Database.GetConnection())
                using (var command = connection.CreateCommand())
                {
                    command.CommandText =
                        "SELECT ID as 'Student ID', Name as 'Student Name' FROM Students ORDER BY Name;";

                    using (var reader = command.ExecuteReader())
                    {
                        var table = new DataTable();
                        table.Load(reader);

                        ResultsGrid.ItemsSource = table.DefaultView;
                        StatusText.Text = $"{table.Rows.Count} students loaded.";
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error loading students:\n{ex.Message}",
                    "Database Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                "Student Enrollment Viewer\n\n" +
                "CISP‑1020 Computer Science II\n" +
                "Volunteer State Community College",
                "About",
               MessageBoxButton.OK, 
                MessageBoxImage.Information);
        }


        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }


        private void LoadEnrollments_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var connection = Database.GetConnection())
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = @"
                SELECT
                    Students.Name AS 'Student Name',
                    Enrollments.CourseName as 'Course Name'
                FROM Students
                JOIN Enrollments
                    ON Students.ID = Enrollments.StudentID
                ORDER BY Students.Name, Enrollments.CourseName;
            ";

                    using (var reader = command.ExecuteReader())
                    {
                        var table = new DataTable();
                        table.Load(reader);
                        ResultsGrid.ItemsSource = table.DefaultView;
                        StatusText.Text = $"{table.Rows.Count} enrollments loaded.";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error loading enrollments:\n{ex.Message}",
                    "Database Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }
    }
}