using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;

namespace GeoApp.Windows
{
    /// <summary>
    /// Interaction logic for ImageViewWindow.xaml
    /// </summary>
    public partial class ImageViewWindow : Window
    {
        Sample _sample;
        public ImageViewWindow(Sample sample)
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();

            _sample = sample;

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

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
