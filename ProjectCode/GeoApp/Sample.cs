﻿using System;
using System.Collections.Generic;

namespace GeoApp
{
    public class Sample
    {
        private int _id;
        private String _name;
        private String _sampleType;
        private String _locationDescription;
        private String _geologicAge;
        private String _city;
        private String _state;
        private String _country;
        private Double _latitude;
        private Double _longitude;
        private List<List<Byte>> _images;

        public int Id
        {
            get { return _id; }
            set => _id = value;
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

        public Double Longtitude
        {
            get { return _longitude; }
            set => _longitude = value;
        }

        public List<List<Byte>> Images
        {
            get { return _images; }
            set => _images = value;
        }

        public Sample(int id, String name, String sampleType, String locationDescription, String geologic_age,
                           String city, String state, String country, Double latitude, Double longitude)
        {
            this.Id = id;
            this.Name = name;
            this.SampleType = sampleType;
            this.LocationDescription = locationDescription;
            this.GeologicAge = geologic_age;
            this.City = city;
            this.State = state;
            this.Country = country;
            this.Latitude = latitude;
            this.Longtitude = longitude;
        }

        public Sample()
        {
            this.Id = -1;
        }
    }
}