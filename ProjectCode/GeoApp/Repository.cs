using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeoApp
{
    public class Repository : IRepository
    {
        public Issue Issue
        {
            get => default;
            set
            {
            }
        }

        public Sample Sample
        {
            get => default;
            set
            {
            }
        }

        public bool AddNewSample(Sample sample)
        {
            throw new NotImplementedException();
        }

        public bool DeleteIssueById(int id)
        {
            throw new NotImplementedException();
        }

        public bool DeleteSampleById(int id)
        {
            throw new NotImplementedException();
        }

        public bool EditSampleById(Sample sample)
        {
            throw new NotImplementedException();
        }

        public Issue RetrieveAllIssues()
        {
            throw new NotImplementedException();
        }

        public List<Sample> RetrieveAllSamples()
        {
            return new List<Sample>();
        }

        public Sample RetrieveSampleById(int id)
        {
            return new Sample();
        }
    }
}