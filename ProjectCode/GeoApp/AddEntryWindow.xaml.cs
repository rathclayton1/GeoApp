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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class AddEntryWindow : Window
    {
        IController controller;
        public AddEntryWindow()
        {
            InitializeComponent();
            this.controller = new Controller();
        }

        public void Submit()
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
            controller.CreateNewSample(sampleInfo);
            System.Environment.Exit(0);
        }

        public void AddImage()
        {

        }
        public void Cancel()
        {

        }

        public List<string> CleanInput(List<string>)
        {
            return new List<string>();
        }

    }
}
