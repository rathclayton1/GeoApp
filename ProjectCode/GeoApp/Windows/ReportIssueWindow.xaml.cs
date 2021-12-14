using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Windows;

namespace GeoApp
{
    /// <summary>
    /// Interaction logic for ReportIssueWindow.xaml
    /// @author: Demetrios Green, Ben Pink, Clayton Rath, David Vegter
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
            try
            {
                if (_controller.CreateIssue(issueData))
                {
                    MessageBox.Show("Added successfully", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Please make sure issue is less that 500 characters", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
                    Submit(sender, e);
                }
                MainWindow.Issues = new(_controller.GetAllIssues());
                Close();
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 0)
                {
                    MessageBox.Show("Couldn't connect to the server while adding issue. Please" +
                        " try again, or contact your administrator.", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("There was a problem in the database while adding issue," +
                        " please try again, check your connection, or contact your administrator.", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }


        private void Cancel(object sender, RoutedEventArgs e) => Close();
    }
}