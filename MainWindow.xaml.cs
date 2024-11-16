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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MunicipalityApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Report> reports = new List<Report>();

        public MainWindow()
        {
            InitializeComponent();

        }
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void ReportIssueButton_Click(object sender, RoutedEventArgs e) 
        {
            ReportIssueWindow reportIssueWindow = new ReportIssueWindow();
            reportIssueWindow.ShowDialog();
        }

        private void ServiceRequestStatusButton_Click(object sender, RoutedEventArgs e)
        {
            ServiceRequestStatusWindow statusWindow = new ServiceRequestStatusWindow();
            statusWindow.ShowDialog();
        }


        // Method to add a report to the list
        public void AddReport(Report report)
        {
            reports.Add(report);
            MessageBox.Show("Report successfully added. Total reports: " + reports.Count);
        }

        private void AddReportButton_Click(object sender, RoutedEventArgs e)
        {
            LocalEvents localEvents = new LocalEvents();
            localEvents.ShowDialog();
        }


    }
}
