using System.Windows;

namespace GeoApp
{
    /// <summary>
    /// Interaction logic for SuccessfulAddWindow.xaml
    /// </summary>
    public partial class SuccessfulAddWindow : Window
    {
        /// <summary>
        /// Window Constructor
        /// </summary>
        public SuccessfulAddWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Close the window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Exit(object sender, RoutedEventArgs e) => this.Close();
    }
}
