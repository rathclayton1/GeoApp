using MySql.Data.MySqlClient;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Windows;
using System.Windows.Controls;

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
            ReportIssueWindow reportIssueWindow = new(_controller);
            reportIssueWindow.Show();
        }

        private void ViewIssuesButton_Click(object sender, RoutedEventArgs e)
        {
            //TODO: Link ViewIssue window
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            //TODO: Link to contoroller search function _searchText and pass to controller.
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            _searchText = SearchBox.Text;
        }

        private void ViewButton_Click(object sender, RoutedEventArgs e)
        {

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
    }
}
