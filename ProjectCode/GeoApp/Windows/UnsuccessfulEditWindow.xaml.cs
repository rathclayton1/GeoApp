using System.Windows;

namespace GeoApp
{
    /// <summary>
    /// Interaction logic for UnsuccessfulEditWindow.xaml
    /// </summary>
    public partial class UnsuccessfulEditWindow : Window
    {
        public UnsuccessfulEditWindow()
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

        public void setErrorMessage(string message)
        {
            ErrorReasonTextBlock.Text = message;
        }
    }
}
