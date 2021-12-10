using MySql.Data.MySqlClient;
using System.Windows;

namespace GeoApp
{
    /// <summary>
    /// Interaction logic for DeleteSampleConfirmationWindow.xaml
    /// </summary>
    public partial class DeleteSampleConfirmationWindow : Window
    {
        public DeleteSampleConfirmationWindow()
        {
            InitializeComponent();
        }

        private IController _controller;
        private Sample _sample;

        /// <summary>
        /// Initialize DeleteSampleConfirmationWindow
        /// </summary>
        /// <param name="sample">Sample to be deleted</param>
        /// <param name="controller">Main UI Controller</param>

        public DeleteSampleConfirmationWindow(Sample sample, Controller controller)
        {
            InitializeComponent();
            _sample = sample;
            _controller = controller;
        }


        /// <summary>
        /// Method for deleted a sample.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Delete(object sender, RoutedEventArgs e)
        {
            try
            {
                _controller.DeleteSample(_sample);
                MainWindow.Samples.Remove(_sample);
                Close();
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 0)
                {
                    MessageBox.Show("Couldn't connect to the server while deleting sample. Please " +
                        "try again, or contact your administrator.", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("There was a problem in the database while deleting your sample, please check your connection, " +
                        "try again or contact your administrator.", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close();
                }
            }
        }


        /// <summary>
        /// Method to cancel sample deletion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
