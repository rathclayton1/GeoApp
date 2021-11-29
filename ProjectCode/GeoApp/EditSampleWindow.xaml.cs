using System.Collections.Generic;
using System.Windows;
using System.IO;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using System;

namespace GeoApp
{
    /// <summary>
    /// Interaction logic for EditSampleWindow.xaml
    /// </summary>
    public partial class EditSampleWindow : Window
    {
        public EditSampleWindow()
        {
            InitializeComponent();
        }

        private IController _controller;
        private int id;
        private Sample _sample;

        /// <summary>
        /// Initialize EditSampleWindow
        /// </summary>
        /// <param name="repository"></param>
        public EditSampleWindow(Sample sample)
        {
            InitializeComponent();
            _sample = sample;
            FillProperties();
        }

        /// <summary>
        /// Populate the sample properties with current data
        /// </summary>
        private void FillProperties()
        {
            Sample sample = _sample;
            SampleID.Text = sample.SampleId.ToString();
            Name.Text = sample.Name;
            SampleType.Text = sample.SampleType;
            GeologicAge.Text = sample.GeologicAge;
            LocationDescription.Text = sample.LocationDescription;
            City.Text = sample.City;
            State.Text = sample.State;
            Country.Text = sample.Country;
            Latitude.Text = sample.Latitude.ToString();
            Longitude.Text = sample.Longitude.ToString();
            SampleImage.Source = ToImage(sample.Image);
        }

        private BitmapImage ToImage(byte[] array)
        {
            using (var ms = new MemoryStream(array))
            {
                var image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad; // here
                image.StreamSource = ms;
                image.EndInit();
                return image;
            }
        }

        /// <summary>
        /// Submit the updated sample
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
            if (_controller.UpdateSample(sampleInfo))
            {
                SuccessfulEditWindow confirmation = new();
                confirmation.Show();
            }
            else
            {
                UnsuccessfulEditWindow error = new();
                error.Show();
            }
            this.Close();
        }

        /// <summary>
        /// Edit an image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditImage(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter = "Image files | *.jpg";
                openFileDialog1.ShowDialog();
                if (!string.IsNullOrEmpty(openFileDialog1.FileName))
                {
                    PathSampleImage.Text = openFileDialog1.FileName;
                    SampleImage.Source = new BitmapImage(new Uri(openFileDialog1.FileName));
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Cancel edit, return to main view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cancel(object sender, RoutedEventArgs e) => this.Close();

    }
}
