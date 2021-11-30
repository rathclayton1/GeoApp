using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
            InitializeComponent();
            _controller = controller;
        }

        private void Submit(object sender, RoutedEventArgs e)
        {
            List<String> issue = new();
            issue.Add(Type.SelectedItem.ToString() == "Misinformation" ? "0" : "1");
            issue.Add(Description.Text);
            _controller.CreateIssue(issue);
            this.Close();
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
