using System.Collections.Generic;
using System.Windows;

namespace GeoApp
{
    /// <summary>
    /// Interaction logic for ReportIssueWindow.xaml
    /// </summary>
    public partial class ReportIssueWindow : Window
    {
        private IController _controller;
        public ReportIssueWindow(Controller controller)
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            _controller = controller;
        }

        private void Submit(object sender, RoutedEventArgs e)
        {
            List<string> issueData = new();
            string typeSelected = Type.Text;
            issueData.Add(typeSelected.Equals(Issue.IssueType.Misinformation.ToString()) ? "0" : "1");
            issueData.Add(Description.Text);
            if(_controller.CreateIssue(issueData))
            {
                MessageBox.Show("Added successfully", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
            } else
            {
                MessageBox.Show("Please make sure issue is less that 500 characters", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
                Submit(sender, e);
            }
            MainWindow.Issues = new(_controller.GetAllIssues());
            Close();
        }

        private void Cancel(object sender, RoutedEventArgs e) => Close();
    }
}