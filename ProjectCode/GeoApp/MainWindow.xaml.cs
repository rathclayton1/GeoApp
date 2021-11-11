using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Configuration;
using MySqlConnector;

namespace GeoApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Sample> _samples;
        private string _searchText;
        private Controller _controller;
        private Repository _repo;
        private MySqlConnection _conn;
        private string _connectionStringToDB = ConfigurationManager.ConnectionStrings["TeamProjectDB"].ConnectionString;

        public MainWindow()
        {
            InitializeComponent();

            _conn = new MySqlConnection(_connectionStringToDB);
            _conn.Open();
            _repo = new(_conn);
            _controller = new Controller(_repo);

            DataGridTextColumn sampleIdColumn = new()
            {
                Header = "Sample ID",
                Binding = new Binding("SampleId")
            };

            SampleTable.Columns.Add(sampleIdColumn);


            DataGridTextColumn nameColumn = new()
            {
                Header = "Name",
                Binding = new Binding("Name")
            };

            SampleTable.Columns.Add(nameColumn);


            DataGridTextColumn sampleTypeColumn = new()
            {
                Header = "Sample Type",
                Binding = new Binding("SampleType")
            };

            SampleTable.Columns.Add(sampleTypeColumn);


            DataGridTextColumn locationDescriptionColumn = new()
            {
                Header = "Location Description",
                Binding = new Binding("LocationDescription")
            };

            SampleTable.Columns.Add(locationDescriptionColumn);


            DataGridTextColumn geologicAgeColumn = new()
            {
                Header = "Geologic Age",
                Binding = new Binding("GeologicAge")
            };

            SampleTable.Columns.Add(geologicAgeColumn);


            DataGridTextColumn imageColumn = new()
            {
                Header = "Image",
                Binding = new Binding("Image")
            };

            SampleTable.Columns.Add(imageColumn);


            DataGridTextColumn actionsColumn = new()
            {
                Header = "Actions",
                Binding = new Binding("Actions")
            };

            SampleTable.Columns.Add(actionsColumn);

            _samples = LoadCollectionData();

            SampleTable.ItemsSource = _samples;
        }

        /// <summary>
        /// Method for loading initial table data of all samples
        /// </summary>
        /// <returns>A list of all samples</returns>
        private List<Sample> LoadCollectionData()
        {
            return _controller.GetAllSamples();
        }

        public void UpdateCollectionData()
        {
            _samples = _controller.GetAllSamples();
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddSampleWindow addSampleWindow = new(_controller);
            addSampleWindow.Show();
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
            //TODO: Link to contoroller search function _searchText and pass to controller.
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            _searchText = SearchBox.Text;
        }

    }
}
