using System.Collections.Generic;

namespace GeoApp
{
    public interface IRepository
    {
        public List<Sample> RetrieveAllSamples();
        public Sample RetrieveSampleById(int id);
        public bool AddNewSample(Sample sample);
        public bool EditSampleById(Sample sample);
        public bool DeleteSampleById(int id);
        public List<Issue> RetrieveAllIssues();
        public bool CreateIssue(Issue issue);
        public bool DeleteIssueById(int id);
    }
}