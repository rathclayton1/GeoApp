using System;

namespace GeoApp
{
    public class Sample
    {
        private int _dbId;
        private int _sampleId;
        private String _name;
        private String _sampleType;
        private String _locationDescription;
        private String _geologicAge;
        private String _city;
        private String _state;
        private String _country;
        private Double _latitude;
        private Double _longitude;

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
    }
}