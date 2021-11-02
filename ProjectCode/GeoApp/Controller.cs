using System;
using System.Collections.Generic;

namespace GeoApp
{
    public class Controller : IController
    {
        private Repository _repo;
        
        public Controller (Repository repository){
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
            int id;
            float lattitude;
            float longitude;
            if (!int.TryParse(sampleInfo[0], out id))
            {
                return false;
            }
            else
            {
                sample.Id = id;
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
                if (!float.TryParse(sampleInfo[7], out lattitude))
                {
                    return false;
                }
                else
                {
                    sample.Latitude = lattitude;
                }

            }
            else if (sampleInfo[8] != "")
            {
                if (!float.TryParse(sampleInfo[8], out longitude))
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

        public bool UpdateSample(Sample sample)
        {
            return _repo.EditSampleById(sample);
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
            int id;
            if (!int.TryParse(issueInfo[0], out id))
            {
                return false;
            }
            else
            {
                issue.SampleId = id;
            }
            if (issueInfo[1].Length > 500)
            {
                return false;
            }
            else
            {
                issue.IssueDescription = issueInfo[1];
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