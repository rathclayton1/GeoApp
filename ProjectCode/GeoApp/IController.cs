using System.Collections.Generic;

namespace GeoApp
{
    public interface IController
    {
        bool CreateNewSample(List<string> sampleInfo);
        bool DeleteSample(Sample sample);
        List<Sample> GetAllSamples();
        Sample GetSampleById(int id);
        bool UpdateSample(List<string> sampleInfo);
        List<Issue> GetAllIssues();
        bool CreateIssue(List<string> issue);
        bool DeleteIssue(Issue issue);
    }
}