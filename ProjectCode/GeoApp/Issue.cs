using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeoApp
{
    public class Issue
    {
        private IssueType Type { get; set; }
        private String IssueDescription { get; set; }
        private DateTime DateSubmitted { get; set; }
        private int SampleID { get; set; }

        private enum IssueType
        {
            Misinformation, SystemIssue
        }
    }
}