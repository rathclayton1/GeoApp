﻿using Microsoft.Win32;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;

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
            byte[] imageData = null;
            if (!string.IsNullOrEmpty(PathSampleImage.Text))
            {
                FileStream fs;
                BinaryReader br;
                string fileName = PathSampleImage.Text;
                fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                br = new BinaryReader(fs);
                imageData = br.ReadBytes((int)fs.Length);
                br.Close();
                fs.Close();
            }

            try
            {
                var createdSample = _controller.CreateNewSample(sampleInfo, imageData);
                if (createdSample != null)
                {
                    SuccessfulAddWindow confirmation = new();
                    confirmation.Show();
                    createdSample.Image = imageData;
                    MainWindow.Samples.Add(createdSample);
                }
                else
                {
                    UnsuccessfulAddWindow error = new();
                    error.Show();
                }
                this.Close();
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 0)
                {
                    MessageBox.Show("Couldn't connect to the server while adding the sample. Contact your administrator.", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("There was a problem in the database while adding entry, " +
                        "please check your connection, try again or contact your administrator.", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }

            
        }

        /// <summary>
        /// Add an image to a sample
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddImage(object sender, RoutedEventArgs e)
        {
            //TODO: implement image adding through controller
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter = "Image files | *.jpg";
                openFileDialog1.ShowDialog();
                if (!string.IsNullOrEmpty(openFileDialog1.FileName))
                {
                    PathSampleImage.Text = openFileDialog1.FileName;
                    SampleImage.Source = new BitmapImage(new Uri(openFileDialog1.FileName));
                    AddImageButton.Opacity = 0;
                    ImageTextBlock.Opacity = 0;
                    ChangeImageButton.Opacity = 100;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Cancel add, return to main view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cancel(object sender, RoutedEventArgs e) => this.Close();
    }
}
