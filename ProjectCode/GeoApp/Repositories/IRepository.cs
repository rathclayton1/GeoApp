using System.Collections.Generic;
/// <summary>
/// Public version of concrete class
/// </summary>
/// @author: Demetrios Green, Ben Pink, Clayton Rath, David Vegter
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
        public Sample RetrieveSampleByFields(Sample sampleNoDbId);
        public bool CreateIssue(Issue issue);
        public bool DeleteIssueById(int id);
    }
}