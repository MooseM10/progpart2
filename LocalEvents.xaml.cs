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
    /// <summary>
    /// Interaction logic for LocalEvents.xaml
    /// </summary>
    public partial class LocalEvents : Window
    {
       
        private SortedDictionary<DateTime, List<Event>> eventsDict = new SortedDictionary<DateTime, List<Event>>();
        private ObservableCollection<Event> displayedEvents = new ObservableCollection<Event>();
        private HashSet<string> eventCategories = new HashSet<string> { "Sports", "Meetings", "Concerts", "Functions", "Other" };
        private Stack<string> searchHistory = new Stack<string>();

        public LocalEvents()
        {
            InitializeComponent();
            LoadSampleEvents();
            DisplayEvents();
        }

        private void LoadSampleEvents()
        {
            // Sample data for eventCollection
            eventsDict[new DateTime(2024, 10, 15)] = new List<Event>
            {
                new Event("Football Match", "Sports", new DateTime(2024, 10, 15), "Local football match at the stadium."),
                new Event("Basketball Game", "Sports", new DateTime(2024, 10, 18), "Basketball game in the sports hall.")
            };

            eventsDict[new DateTime(2024, 10, 20)] = new List<Event>
            {
                new Event("Town Hall Meeting", "Meetings", new DateTime(2024, 10, 20), "Town Hall meeting to discuss local issues.")
            };
        }
       
        private void AddEvent(Event ev)
        {
            if (!eventsDict.ContainsKey(ev.Date))
                eventsDict[ev.Date] = new List<Event>();
            eventsDict[ev.Date].Add(ev);
        }
        // Search button click event
        private void OnSearchClick(object sender, RoutedEventArgs e)
        {
            // Ensure the category dropdown is selected
            if (categoryDropdown.SelectedItem is ComboBoxItem selectedItem)
            {
                string selectedCat = selectedItem.Content.ToString();

                // Ensure a date is selected
                if (datePicker.SelectedDate.HasValue)
                {
                    DateTime selectedDate = datePicker.SelectedDate.Value;

                    // Check if the date exists in the dictionary
                    if (eventsDict.TryGetValue(selectedDate, out var searchedEvents))
                    {
                        // Clear displayed events and add searched events
                        displayedEvents.Clear();
                        foreach (var ev in searchedEvents)
                        {
                            // Optionally filter by category if needed
                            if (ev.Category == selectedCat)
                            {
                                displayedEvents.Add(ev);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("No events found for the selected date.");
                    }
                }
                else
                {
                    MessageBox.Show("Please select a date.");
                }
            }
            else
            {
                MessageBox.Show("Please select a category.");
            }
        }

        private void DisplayEvents()
        {
            displayedEvents.Clear(); // Clear the previous results
            foreach (var ev in eventsDict.Values.SelectMany(e => e))
            {
                //resultsListView.Items.Add($"{ev.Name} - {ev.Date.ToShortDateString()} - {ev.Description}");
                displayedEvents.Add(ev);
            }
            resultsListView.ItemsSource = displayedEvents;
        }

        // Recommend events based on the search history
        private void RecommendEvents(string category)
        {
            var recommended = eventsDict.Values.SelectMany(ev => ev)
                              .Where(ev => ev.Category == category)
                              .Take(5);
            resultsListView.ItemsSource = recommended.ToList(); // Ensure it's a list
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (categoryDropdown.SelectedItem is ComboBoxItem selectedItem)
            {
                string selectedCat = selectedItem.Content.ToString();
                RecommendEvents(selectedCat);
            }
            else
            {
                MessageBox.Show("Please select a category to get recommendations.");
            }
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            DisplayEvents();
        }
    }
}
