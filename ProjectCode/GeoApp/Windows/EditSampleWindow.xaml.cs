using System.Collections.Generic;
using System.Windows;

namespace GeoApp
{
    /// <summary>
    /// Interaction logic for EditSampleWindow.xaml
    /// </summary>
    public partial class EditSampleWindow : Window
    {
        public EditSampleWindow()
        {
            InitializeComponent();
        }

        private IController _controller;
        private int id;

        /// <summary>
        /// Initialize EditSampleWindow
        /// </summary>
        /// <param name="repository"></param>
        public EditSampleWindow(Controller controller, int id)
        {
            InitializeComponent();
            _controller = controller;
            this.id = id;
            FillProperties();
        }

        /// <summary>
        /// Populate the sample properties with current data
        /// </summary>
        private void FillProperties()
        {
            Sample sample = _controller.GetSampleById(id);
            SampleID.Text = sample.SampleId.ToString();
            Name.Text = sample.Name;
            SampleType.Text = sample.SampleType;
            GeologicAge.Text = sample.GeologicAge;
            LocationDescription.Text = sample.LocationDescription;
            City.Text = sample.City;
            State.Text = sample.State;
            Country.Text = sample.Country;
            Latitude.Text = sample.Latitude.ToString();
            Longitude.Text = sample.Longitude.ToString();
        }

        /// <summary>
        /// Submit the updated sample
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Submit(object sender, RoutedEventArgs e)
        {
            List<string> sampleInfo = new List<string>();
            sampleInfo.Add(SampleID.Text);
            sampleInfo.Add(Name.Text);
            sampleInfo.Add(SampleType.Text);
            sampleInfo.Add(GeologicAge.Text);
            sampleInfo.Add(LocationDescription.Text);
            sampleInfo.Add(City.Text);
            sampleInfo.Add(State.Text);
            sampleInfo.Add(Country.Text);
            sampleInfo.Add(Latitude.Text);
            sampleInfo.Add(Longitude.Text);
            if (_controller.UpdateSample(sampleInfo))
            {
                SuccessfulEditWindow confirmation = new();
                confirmation.Show();
            }
            else
            {
                UnsuccessfulEditWindow error = new();
                error.Show();
            }
            this.Close();
        }

        /// <summary>
        /// Edit an image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditImage(object sender, RoutedEventArgs e)
        {
            //TODO: Add edit image(s) functionality
        }

        /// <summary>
        /// Cancel edit, return to main view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cancel(object sender, RoutedEventArgs e) => this.Close();
    }
}
