using System;
using System.Collections.Generic;

namespace GeoApp
{
    public class Controller : IController 
    {
        private Repository _repo;
        
        public Controller (Repository repository)
        {
            _repo = repository;
        }

        public List<Sample> GetAllSamples()
        {
            return _repo.RetrieveAllSamples();
        }

        public Sample GetSampleById(int id)
        {
            return _repo.RetrieveSampleById(id);
        }

        public bool CreateNewSample(List<string> sampleInfo, byte[] image)
        {
            Sample sample = new Sample();
            if (!int.TryParse(sampleInfo[0], out int sampleId))
            {
                return false;
            }
            else
            {
                sample.SampleId = sampleId;
                for (int i = 1; i <= 6; i++)
                {
                    if (sampleInfo[i].Length > 50)
                    {
                        return false;
                    }
                }
            }
            sample.Name = sampleInfo[1];
            sample.SampleType = sampleInfo[2];
            sample.GeologicAge = sampleInfo[3];
            sample.LocationDescription = sampleInfo[4];
            sample.City = sampleInfo[5];
            sample.State = sampleInfo[6];
            sample.Country = sampleInfo[7];
            if (sampleInfo[8] != string.Empty)
            {
                if (!double.TryParse(sampleInfo[8], out double latitude))
                {
                    return false;
                }
                else
                {
                    sample.Latitude = latitude;
                }

            }
            if (sampleInfo[9] != string.Empty)
            {
                if (!double.TryParse(sampleInfo[9], out double longitude))
                {
                    return false;
                }
                else
                {
                    sample.Longitude = longitude;
                }

            }
            sample.Image = image;
            return _repo.AddNewSample(sample);
        }

        public bool UpdateSample(List<String> sampleInfo)
        {
            //TODO: TS-16 Update Edit Entry Logic and Handling 
            Sample sample = new Sample();
            if (!int.TryParse(sampleInfo[0], out int sampleId))
            {
                return false;
            }
            else
            {
                sample.SampleId = sampleId;
                for (int i = 1; i <= 6; i++)
                {
                    if (sampleInfo[i].Length > 50)
                    {
                        return false;
                    }
                }
            }
            sample.Name = sampleInfo[1];
            sample.SampleType = sampleInfo[2];
            sample.GeologicAge = sampleInfo[3];
            sample.City = sampleInfo[4];
            sample.State = sampleInfo[5];
            sample.Country = sampleInfo[6];
            if (sampleInfo[7] != string.Empty)
            {
                if (!double.TryParse(sampleInfo[7], out double latitude))
                {
                    return false;
                }
                else
                {
                    sample.Latitude = latitude;
                }

            }
            else if (sampleInfo[8] != string.Empty)
            {
                if (!double.TryParse(sampleInfo[8], out double longitude))
                {
                    return false;
                }
                else
                {
                    sample.Longitude = longitude;
                }

            }
            return _repo.EditSampleById(sample);
        }

        public bool DeleteSample(Sample sample)
        {
            return _repo.DeleteSampleById(sample.SampleId);
        }

        public List<Issue> GetAllIssues()
        {
            return _repo.RetrieveAllIssues();
        }

        public bool CreateIssue(List<String> issueInfo)
        {
            Issue issue = new Issue();
            if (issueInfo[1].Equals("0"))
            {
                issue.Type = Issue.IssueType.Misinformation;
            }
            else
            { 
                issue.Type = Issue.IssueType.SystemIssue;
            }
            if (issueInfo[2].Length > 500)
            {
                return false;
            }
            else
            {
                issue.IssueDescription = issueInfo[2];
            }
            issue.DateTimeSubmitted = DateTime.Now;
            issue.Resolved = false;

            return _repo.CreateIssue(issue);
        }

        public bool DeleteIssue(Issue issue)
        {
            return _repo.DeleteIssueById(issue.referenceId);
        }
    }
}
