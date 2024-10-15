using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MunicipalityApp
{
    public partial class ReportIssueWindow : Window
    {
        private MainWindow mainWindow;
        public ReportIssueWindow()
        {
            InitializeComponent();
            this.mainWindow = mainWindow;

        }

        private void AttachMediaButton_Click(object sender, RoutedEventArgs e)
        {
            // Create and configure an OpenFileDialog
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png|Video Files|*.mp4;*.avi|All Files|*.*";
            openFileDialog.Multiselect = false;

            // Show the dialog
            if (openFileDialog.ShowDialog() == true)
            {
                // Handle file selection (you can store the file path for later use)
                string selectedFilePath = openFileDialog.FileName;
                MessageBox.Show("File attached: " + selectedFilePath);

                // Show progress bar to indicate engagement
                EngagementProgressBar.Visibility = Visibility.Visible;
                EngagementProgressBar.Value = 100; // Mock progress
            }
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            // Extract data from the input controls
            string location = LocationTextBox.Text;
            string category = (CategoryComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            string description = new TextRange(DescriptionRichTextBox.Document.ContentStart, DescriptionRichTextBox.Document.ContentEnd).Text;

            // Assume you have a media file path (it can be empty if no file is attached)
            string mediaFilePath = "some_media_file_path";

            // Create a new report
            Report newReport = new Report(location, category, description, mediaFilePath);

            // Add the report to the main window's list
            mainWindow.AddReport(newReport);

            // Perform your submission logic here (e.g., send data to a database or web service)

            MessageBox.Show("Issue Submitted Successfully!");

            // Optionally reset the form or close the window
            this.Close();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            // Close this window and return to the main page
            this.Close();
        }
    }
}