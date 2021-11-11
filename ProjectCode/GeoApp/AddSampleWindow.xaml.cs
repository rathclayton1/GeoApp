﻿using System.Collections.Generic;
using System.Windows;

namespace GeoApp
{
    /// <summary>
    /// Interaction logic for AddSampleWindow.xaml
    /// </summary>
    public partial class AddSampleWindow : Window
    {
        private IController _controller;

        /// <summary>
        /// Initialize AddSampleWindow
        /// </summary>
        /// <param name="repository"></param>
        public AddSampleWindow(Controller controller)
        {
            InitializeComponent();
            _controller = controller;
        }

        /// <summary>
        /// Submit a new sample
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Submit(object sender, RoutedEventArgs e)
        {
            List<string> sampleInfo = new List<string>();
            sampleInfo.Add(SampleID.Text);
            sampleInfo.Add(Name.Text);
            sampleInfo.Add(SampleType.Text);
            sampleInfo.Add(GeologicAge.Text);
            sampleInfo.Add(LocationDescription.Text);
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

        /// <summary>
        /// Add an image to a sample
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddImage(object sender, RoutedEventArgs e)
        {
            //TODO implement image adding through controller
        }


        /// <summary>
        /// Cancel add, return to main view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cancel(object sender, RoutedEventArgs e) => this.Close();
    }
}
