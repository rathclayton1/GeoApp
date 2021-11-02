using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeoApp
{
    public class Issue
    {
        private IssueType _type;
        private String _issueDescription;
        private DateTime _dateSubmitted;
        private int _sampleID;
        private int _issueID;

        public Issue(int issueID, string description, DateTime date, int sampleID, string type)
        {
            //this.Type = type; gotta sortout the enum yet
            this._issueID = issueID;
            this._issueDescription = description;
            this._dateSubmitted = date;
            this.SampleId = sampleID;
        }

        public IssueType Type
        {
            get { return _type; }
            set => _type = value;
        }

        public String IssueDescription
        {
            get { return _issueDescription; }
            set => _issueDescription = value;
        }

        public DateTime DateTimeSubmitted
        {
            get { return _dateSubmitted; }
            set => _dateSubmitted = value;
        }

        public int SampleId
        {
            get { return _sampleID; }
            set => _sampleID = value;
        }

        public int IssueId
        {
            get { return _issueID; }
            set => _issueID = value;
        }

        public enum IssueType
        {
            Misinformation, SystemIssue
        }
    }
}