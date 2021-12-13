using System.Windows;

namespace GeoApp
{
    /// <summary>
    /// Interaction logic for SuccessfulEditWindow.xaml
    /// </summary>
    public partial class SuccessfulEditWindow : Window
    {
        public SuccessfulEditWindow()
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
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
