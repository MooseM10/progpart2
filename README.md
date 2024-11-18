README: MunicipalityApp

Overview
MunicipalityApp is a Windows desktop application designed to manage and track service requests efficiently. The app implements advanced data structures like AVL Trees, Min Heaps, and Graphs to organize, prioritize, and visualize relationships between service requests. It features functionality to display all requests, prioritize them, show relationships, and search for a specific request by ID.

Features
1. Add Service Requests: 
   Users can add new service requests through the "Report an Issue" page.
   
2. View All Requests: 
   View all service requests sorted by their IDs using the AVL Tree.

3. Prioritize Requests:
   Service requests are managed in a priority queue using a Min Heap.

4. Visualize Relationships:
   Service request relationships are displayed using a Graph.

5. Search for Requests:
   Search for a specific service request by entering its unique ID.

6. Advanced Data Structures:
   - AVL Tree: Ensures sorted storage of service requests for efficient retrieval.
   - Min Heap: Provides priority-based access.
   - Graph: Models and visualizes relationships between service requests.



Prerequisites
1. Software Requirements:
   -Windows OS (for running the app)
   - Visual Studio 2019 or later (for development)
   - .NET Framework 4.7.2 or later

2. Languages and Libraries:
   -C# (WPF and backend logic)

How to Compile the Program
1. Clone the Repository:
   - Download or clone the repository from [GitHub](https://github.com/YourRepoLinkHere).
   - Example command:  
     ```bash
     git clone https://github.com/YourRepoLinkHere
     ```

2. Open the Solution in Visual Studio:
   - Double-click the `MunicipalityApp.sln` file to open the project in Visual Studio.

3. Restore Dependencies:
   - Ensure all dependencies are installed. Right-click the solution in Solution Explorer and select:
     - `Restore NuGet Packages`

4. Build the Solution:
   - Select Build > Build Solution from the menu bar or press `Ctrl + Shift + B`.
   - Check the Output Window for any build errors and resolve them if necessary.



How to Run the Program
1. Start the Application:
   - In Visual Studio, press `F5` or select Debug > Start Debugging.
   - Alternatively, navigate to the `/bin/Debug` or `/bin/Release` folder and run the `MunicipalityApp.exe` file.

2. Navigate the Application:
   - Main Menu:  
     - Access "Report an Issue" to add a new service request.  
     - Access "Service Request Status" to view, search, and explore requests.

   - Service Request Status Page:  
     - View all requests in sorted order (AVL Tree).  
     - View prioritized requests (Heap).  
     - View request relationships (Graph).  
     - Search for a specific request by its unique ID.



How to Use the Program
Adding a Service Request
1. Navigate to the "Report an Issue" page.
2. Enter the following details:
   - Request ID (e.g., "SR001")
   - Description
   - Priority
   - Related Request IDs (if applicable)
3. Click Submit to add the service request.

Viewing Requests
1. Navigate to "Service Request Status."
2. Use the buttons:
   - Show All Requests: Display all requests in sorted order.
   - Show Related Requests: Visualize relationships using a graph.

Search Functionality
1. Enter a request ID in the search bar (e.g., "SR001").
2. Click the Search button.
3. If found, the details of the request will be displayed in a message box.



How the Code Works
Core Data Structures
1. AVL Tree:  
   Stores and retrieves service requests in sorted order based on their unique ID. Supports efficient search functionality.

2. Min Heap:
   Manages requests based on priority (e.g., urgent requests appear first).

3. Graph:  
   Represents relationships between service requests (e.g., related or dependent requests).

UI Components
- Main Menu: Provides navigation.
- TextBox and Buttons: Enable user interaction for searching and displaying data.
- ListBox: Displays sorted, prioritized, or related service requests.

Search Implementation
- Backend:  
   Searches the AVL Tree using an efficient recursive method.
- Frontend: 
   The search result is displayed in a message box.


Known Issues and Troubleshooting
1. Graph or Heap Not Displaying Properly:
   - Verify that relationships and priorities are correctly set when adding requests.
