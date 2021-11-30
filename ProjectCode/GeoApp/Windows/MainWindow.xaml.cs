using MySql.Data.MySqlClient;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace GeoApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static ObservableCollection<Sample> Samples { get; set; }
        public string _searchText;
        private Controller _controller;
        private Repository _repo;
        private MySqlConnection _conn;
        private string _connectionStringToDB = ConfigurationManager.ConnectionStrings["TeamProjectDB"].ConnectionString;

        public MainWindow() 
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();

            _conn = new MySqlConnection(_connectionStringToDB);
            _conn.Open();
            _repo = new(_conn);
            _controller = new Controller(_repo);

            Samples = LoadCollectionData();

            SampleTable.ItemsSource = Samples;
        }

        /// <summary>
        /// Method for loading initial table data of all samples
        /// </summary>
        /// <returns>A list of all samples</returns>
        private ObservableCollection<Sample> LoadCollectionData()
        {
            return new ObservableCollection<Sample>(_controller.GetAllSamples());
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddSampleWindow addEntryWindow = new(_controller);
            addEntryWindow.Show();

        }

        private void ReportIssueButton_Click(object sender, RoutedEventArgs e)
        {
            //TODO: Link report issue window
        }

        private void ViewIssuesButton_Click(object sender, RoutedEventArgs e)
        {
            //TODO: Link ViewIssue window
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            SampleTable.ItemsSource = new ObservableCollection<Sample>(_controller.GetSamplesByKeyword(_searchText));
        }

        private void SearchBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                SampleTable.ItemsSource = new ObservableCollection<Sample>(_controller.GetSamplesByKeyword(_searchText));
            }
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            _searchText = SearchBox.Text;
        }

        private void SearchBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (SearchBox.Text.Equals("Search"))
            {
                SearchBox.Text = "";
            }
        }

        private void ViewButton_Click(object sender, RoutedEventArgs e)
        {
            var sampleData = (Button)e.OriginalSource;
            var sample = (Sample)sampleData.DataContext;
            SampleViewWindow window = new(sample);
            window.Show();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            var sampleData = (Button)e.OriginalSource;
            var sample = (Sample)sampleData.DataContext;
            EditSampleWindow window = new(sample, _controller);
            window.Show();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var sampleData = (Button)e.OriginalSource;
            var sample = (Sample)sampleData.DataContext;
            DeleteSampleConfirmationWindow window = new(sample, _controller);
            window.Show();
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            SearchBox.Text = "Search";
            SampleTable.ItemsSource = new ObservableCollection<Sample>(_controller.GetAllSamples());
        }
    }
}
