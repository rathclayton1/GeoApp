using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;

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
            Sample sample = _sample;
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
            if (sample.Image != null)
            {
                SampleImage.Source = ToImage(sample.Image);
            }
            else
            {
                NoImageText.Visibility = Visibility.Visible;
            }
        }

        private static BitmapImage ToImage(byte[] array)
        {
            using (var ms = new MemoryStream(array))
            {
                BitmapImage image = new();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.StreamSource = ms;
                image.EndInit();
                return image;
            }
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
