using GeoApp.Windows;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;

namespace GeoApp
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// @author: Demetrios Green, Ben Pink, Clayton Rath, David Vegter
    /// </summary>
    public partial class SampleViewWindow : Window
    {
        public Sample _sample;
        public SampleViewWindow(Sample sample)
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();

            _sample = sample;
            FillProperties();
        }

        /// <summary>
        /// Populate the sample properties with current data
        /// </summary>
        private void FillProperties()
        {
            SampleID.Text = _sample.SampleId.ToString();
            Name.Text = _sample.Name;
            SampleType.Text = _sample.SampleType;
            GeologicAge.Text = _sample.GeologicAge;
            LocationDescription.Text = _sample.LocationDescription;
            City.Text = _sample.City;
            State.Text = _sample.State;
            Country.Text = _sample.Country;
            Latitude.Text = _sample.Latitude.ToString();
            Longitude.Text = _sample.Longitude.ToString();
            if (_sample.Image != null)
            {
                SampleImage.Source = ToImage(_sample.Image);
            }
            else
            {
                NoImageText.Visibility = Visibility.Visible;
            }
        }

        private static BitmapImage ToImage(byte[] array)
        {
            using MemoryStream ms = new(array);
            BitmapImage image = new();
            image.BeginInit();
            image.CacheOption = BitmapCacheOption.OnLoad;
            image.StreamSource = ms;
            image.EndInit();
            return image;
        }

        private void ViewImage_Click(object sender, RoutedEventArgs e)
        {
            ImageViewWindow window = new(_sample);
            window.Show();
        }

        /// <summary>
        /// Event handler for OK button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
