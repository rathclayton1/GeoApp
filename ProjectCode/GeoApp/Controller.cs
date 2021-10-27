using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeoApp
{
    public class Controller : IController
    {
        public Repository Repository
        {
            get => default;
            set
            {
            }
        }

        public List<Sample> GetAllSamples()
        {
            return new List<Sample>();
        }

        public Sample GetSampleById(int id)
        {
            return new Sample();
        }

        public bool CreateNewSample(List<String> sampleInfo)
        {
            return true;
        }

        public bool UpdateSample(Sample sample)
        {
            return true;
        }

        public bool DeleteSample(Sample sample)
        {
            return true;
        }

        public Issue GetAllIssues()
        {
            return new Issue();
        }

        public bool DeleteIssue(Issue issue)
        {
            return true;
        }
    }
}