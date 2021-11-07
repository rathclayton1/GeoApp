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
    /// Interaction logic for UnsuccessfulAddWindow.xaml
    /// </summary>
    public partial class UnsuccessfulAddWindow : Window
    {
        public UnsuccessfulAddWindow()
        {
            InitializeComponent();
        }

        private void Exit(object sender, RoutedEventArgs e) => this.Close();
    }
}
