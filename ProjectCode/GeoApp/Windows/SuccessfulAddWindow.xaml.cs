using System.Windows;

namespace GeoApp
{
    /// <summary>
    /// Interaction logic for SuccessfulAddWindow.xaml
    /// @author: Demetrios Green, Ben Pink, Clayton Rath, David Vegter
    /// </summary>
    public partial class SuccessfulAddWindow : Window
    {
        /// <summary>
        /// Window Constructor
        /// </summary>
        public SuccessfulAddWindow()
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
