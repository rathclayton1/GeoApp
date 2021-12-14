using System.Windows;

namespace GeoApp
{
    /// <summary>
    /// Interaction logic for UnsuccessfulAddWindow.xaml
    /// </summary>
    public partial class UnsuccessfulAddWindow : Window
    {
        /// <summary>
        /// Window Constructor
        /// </summary>
        public UnsuccessfulAddWindow()
        {
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
