using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionCore.Models
{
    public class IssueCreation
    {
        public Fields fields { get; set; }
    }
    public class Fields
    {
        public Project project { get; set; }
        public string summary { get; set; }
        public string description { get; set; }
        public Issuetype issuetype { get; set; }
        public string customfield_10104 { get; set; }
    }
    public class Project
    {
        public string key { get; set; }
    }

    public class Issuetype
    {
        public string name { get; set; }
    }
}
