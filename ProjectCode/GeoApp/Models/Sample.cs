using System;

namespace GeoApp
{
    /// <summary>
    /// This class is the representation of our database sample.
    /// </summary>
    /// @author: Demetrios Green, Ben Pink, Clayton Rath, David Vegter
    public class Sample
    {
        private int _dbId;
        private int _sampleId;
        private string _name;
        private string _sampleType;
        private string _locationDescription;
        private string _geologicAge;
        private string _city;
        private string _state;
        private string _country;
        private double _latitude;
        private double _longitude;
        private byte[] _image;

        public int DbId
        {
            get { return _dbId; }
            set => _dbId = value;
        }

        public int SampleId
        {
            get { return _sampleId; }
            set => _sampleId = value;
        }

        public String Name
        {
            get { return _name; }
            set => _name = value;
        }

        public String SampleType
        {
            get { return _sampleType; }
            set => _sampleType = value;
        }

        public String LocationDescription
        {
            get { return _locationDescription; }
            set => _locationDescription = value;
        }

        public String GeologicAge
        {
            get { return _geologicAge; }
            set => _geologicAge = value;
        }

        public String City
        {
            get { return _city; }
            set => _city = value;
        }

        public String State
        {
            get { return _state; }
            set => _state = value;
        }

        public String Country
        {
            get { return _country; }
            set => _country = value;
        }

        public Double Latitude
        {
            get { return _latitude; }
            set => _latitude = value;
        }

        public Double Longitude
        {
            get { return _longitude; }
            set => _longitude = value;
        }

        public byte[] Image
        {
            get { return _image; }
            set => _image = value;
        }
    }
}