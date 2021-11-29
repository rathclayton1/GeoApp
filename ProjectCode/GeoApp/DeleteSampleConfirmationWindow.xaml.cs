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
    /// Interaction logic for DeleteSampleConfirmationWindow.xaml
    /// </summary>
    public partial class DeleteSampleConfirmationWindow : Window
    {
        public DeleteSampleConfirmationWindow()
        {
            InitializeComponent();
        }

        private IController _controller;
        private Sample _sample;

        /// <summary>
        /// Initialize DeleteSampleConfirmationWindow
        /// </summary>
        /// <param name="repository"></param>
        public DeleteSampleConfirmationWindow(Sample sample, Controller controller)
        {
            InitializeComponent();
            _sample = sample;
            _controller = controller;
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            _controller.DeleteSample(_sample);
            this.Close();
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
