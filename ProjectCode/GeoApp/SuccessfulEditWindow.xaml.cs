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
    /// Interaction logic for SuccessfulEditWindow.xaml
    /// </summary>
    public partial class SuccessfulEditWindow : Window
    {
        public SuccessfulEditWindow()
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
