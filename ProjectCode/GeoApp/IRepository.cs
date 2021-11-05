﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeoApp
{
    public interface IRepository
    {
        public List<Sample> RetrieveAllSamples();
        public Sample RetrieveSampleById(int id);
        public bool AddNewSample(Sample sample);
        public bool EditSampleById(Sample sample);
        public bool DeleteSampleById(int id);
        public Issue RetrieveAllIssues();
        public bool DeleteIssueById(int id);
    }
}