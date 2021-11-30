using System.Windows;
using System.Windows.Controls;

namespace GeoApp.Windows
{
    /// <summary>
    /// Interaction logic for ViewIssuesWindow.xaml
    /// </summary>
    public partial class ViewIssuesWindow : Window
    {
        Controller _controller;
        public ViewIssuesWindow(Controller controller)
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();

            _controller = controller;
            MainWindow.Issues = new(_controller.GetAllIssues());

            IssuesTable.ItemsSource = MainWindow.Issues;
        }

        /// <summary>
        /// Method for handling deletion of an issue.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteIssueButton_Click(object sender, RoutedEventArgs e)
        {
            var issueData = (Button)e.OriginalSource;
            var issue = (Issue)issueData.DataContext;
            if (_controller.DeleteIssue(issue))
            {
                MessageBox.Show("Deleted successfully", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
                MainWindow.Issues.Remove(issue);
            }
            else
            {
                MessageBox.Show("Issue could not be deleted at this time.", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
