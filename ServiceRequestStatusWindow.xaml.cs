using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public partial class ServiceRequestStatusWindow : Window
    {
        // Data structures for managing service requests
        private AVLTree<string> avlTree = new AVLTree<string>(); // Using AVL tree to store service requests
        private MinHeap<string> heap = new MinHeap<string>();   // Using Heap to store service requests by priority
        private Graph serviceRequestGraph = new Graph();         // Graph for visualizing relationships between requests

        public ServiceRequestStatusWindow()
        {
            InitializeComponent();
            LoadSampleData();
            DisplayServiceRequests();
        }

        // Load sample data for demonstration
        private void LoadSampleData()
        {
            // Sample data for AVL Tree
            avlTree.Insert("SR001 - Pending - Issue with water supply");
            avlTree.Insert("SR002 - Completed - Electricity outage");
            avlTree.Insert("SR003 - In Progress - Road repair");

            // Sample data for Heap (Urgency based on status)
            heap.Insert("SR003 - In Progress - Road repair");
            heap.Insert("SR002 - Completed - Electricity outage");
            heap.Insert("SR001 - Pending - Issue with water supply");

            // Sample data for Graph (representing relationships between requests)
            serviceRequestGraph.AddEdge("SR001", "SR003", 10);  // Water supply issue is related to road repair
            serviceRequestGraph.AddEdge("SR002", "SR003", 5);   // Electricity issue related to road repair
        }

        // Display service requests in the window using the appropriate structure
        private void DisplayServiceRequests()
        {
            // Displaying data from AVL Tree
            avlTreeDisplay.Items.Clear();
            foreach (var request in avlTree.GetRequests())
            {
                avlTreeDisplay.Items.Add(request);
            }

            // Displaying data from Heap
            heapDisplay.Items.Clear();
            List<string> allHeapRequests = heap.GetAllElements();
            foreach (var request in allHeapRequests)
            {
                heapDisplay.Items.Add(request);
            }

            // Displaying data from Graph (Simple traversal display)
            serviceRequestGraphDisplay.Items.Clear();
            serviceRequestGraph.DisplayGraph();
        }

        // Event handler for clicking "Show All Requests" button
        private void ShowAllRequests_Click(object sender, RoutedEventArgs e)
        {
            // Optionally you can display data from different structures
            DisplayServiceRequests();
        }

        // Event handler for clicking "Show Related Requests" button
        private void ShowRelatedRequests_Click(object sender, RoutedEventArgs e)
        {
            // Sample DFS traversal from a starting request (e.g., SR001)
            serviceRequestGraph.PerformDFS("SR001");
        }
    }
}
