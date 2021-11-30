using System.Windows;

namespace GeoApp
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class SampleViewWindow : Window
    {
        public Sample _sample;
        public SampleViewWindow(Sample sample)
        {
            InitializeComponent();

            _sample = sample;
            Resources.Add("sampleId", _sample.SampleId);
            Resources.Add("sampleName", _sample.Name);
            Resources.Add("sampleType", _sample.SampleType);
            Resources.Add("sampleLocationDescription", _sample.LocationDescription);
            Resources.Add("sampleGeologicAge", _sample.GeologicAge);
            Resources.Add("sampleCity", _sample.City);
            Resources.Add("sampleState", _sample.State);
            Resources.Add("sampleCountry", _sample.Country);
            Resources.Add("sampleLatitude", _sample.Latitude);
            Resources.Add("sampleLongitude", _sample.Longitude);
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
