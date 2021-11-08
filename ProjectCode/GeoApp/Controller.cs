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

        public bool CreateNewSample(List<String> sampleInfo)
        {
            Sample sample = new Sample();
            if (!int.TryParse(sampleInfo[0], out int sampleId))
            {
                return false;
            }
            else
            {
                sample.Id = sampleId;
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
            if (sampleInfo[7] != "")
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
            else if (sampleInfo[8] != "")
            {
                if (!double.TryParse(sampleInfo[8], out double longitude))
                {
                    return false;
                }
                else
                {
                    sample.Longtitude = longitude;
                }

            }
            return true;
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
                sample.Id = sampleId;
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
            if (sampleInfo[7] != "")
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
            else if (sampleInfo[8] != String.Empty)
            {
                if (!double.TryParse(sampleInfo[8], out double longitude))
                {
                    return false;
                }
                else
                {
                    sample.Longtitude = longitude;
                }

            }
            return _repo.EditSampleById(sampleId);
        }

        public bool DeleteSample(Sample sample)
        {
            return _repo.DeleteSampleById(sample.Id);
        }

        public List<Issue> GetAllIssues()
        {
            return _repo.RetrieveAllIssues();
        }

        public bool CreateIssues(List<String> issueInfo)
        {
            Issue issue = new Issue();
            if (!int.TryParse(issueInfo[0], out int sampleId))
            {
                return false;
            }
            else
            {
                issue.SampleId = sampleId;
            }
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
            return true;
        }

        public bool DeleteIssue(Issue issue)
        {
            return _repo.DeleteIssueById(issue.SampleId);
        }
    }
}