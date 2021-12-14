using System.Collections.Generic;

/// <summary>
/// This is a public version of a concrete class.
/// </summary>
/// @author: Demetrios Green, Ben Pink, Clayton Rath, David Vegter
namespace GeoApp
{
    public interface IController
    {
        Sample CreateNewSample(List<string> sampleInfo, byte[] image);
        bool DeleteSample(Sample sample);
        List<Sample> GetAllSamples();
        List<Sample> GetSamplesByKeyword(string keyword);
        Sample GetSampleById(int id);
        bool UpdateSample(List<string> sampleInfo, byte[] image);
        List<Issue> GetAllIssues();
        bool CreateIssue(List<string> issue);
        bool DeleteIssue(Issue issue);
        string getErrorMessage();
    }
}