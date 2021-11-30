using System.Collections.Generic;

namespace GeoApp
{
    public interface IController
    {
        Sample CreateNewSample(List<string> sampleInfo, byte[] image);
        bool DeleteSample(Sample sample);
        List<Sample> GetAllSamples();
        Sample GetSampleById(int id);
        bool UpdateSample(List<string> sampleInfo, byte[] image);
        List<Issue> GetAllIssues();
        bool CreateIssue(List<string> issue);
        bool DeleteIssue(Issue issue);
    }
}