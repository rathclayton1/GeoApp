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
    /// Interaction logic for AddEntryWindow.xaml
    /// </summary>
    public partial class AddEntryWindow : Window
    {
        private Repository _repo;
        private IController _controller;

        /**
         * Window constructor
         */
        public AddEntryWindow(Repository repository)
        {
            InitializeComponent();
            _repo = repository;
            _controller = new Controller();
        }

        /**
         * Submit a new sample
         */
        private void Submit(object sender, RoutedEventArgs e)
        {
            List<string> sampleInfo = new List<string>();
            sampleInfo.Add(SampleID.Text);
            sampleInfo.Add(Name.Text);
            sampleInfo.Add(SampleType.Text);
            sampleInfo.Add(GeologicAge.Text);
            sampleInfo.Add(City.Text);
            sampleInfo.Add(State.Text);
            sampleInfo.Add(Country.Text);
            sampleInfo.Add(Latitude.Text);
            sampleInfo.Add(Longitude.Text);
            if (_controller.CreateNewSample(sampleInfo))
            {
                SuccessfulAddWindow confirmation = new();
                confirmation.Show();

            }
            else
            {
                UnsuccessfulAddWindow error = new();
                error.Show();
            }
            this.Close();
        }

        /**
         * Add an image to a sample
         */
        private void AddImage(object sender, RoutedEventArgs e)
        {
            //TODO
        }

        /**
         * Cancel add, return to main view
         */
        private void Cancel(object sender, RoutedEventArgs e) => this.Close();
    }
}
