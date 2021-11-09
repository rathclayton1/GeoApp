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
        private int _referenceId;
        private bool _resolved;

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

        public int referenceId
        {
            get { return _referenceId; }
            set => _referenceId = value;
        }

        public bool Resolved
        {
            get { return _resolved; }
            set => _resolved = value;
        }

        public enum IssueType
        {
            Misinformation, SystemIssue
        }
    }
}