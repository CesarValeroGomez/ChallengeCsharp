using SolutionCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionCore.Builders
{
    public class CreateIssueBuilder
    {
        private string _summary = "Issue created from API";
        private string _description = "Created from the automation solution";
        private string _customfield_10104 = "MyIssue";
        private string _key = "JIR";
        private string _name = "Epic";


        public IssueCreation Build()
        {
            var issueType = new Issuetype
            {
                name = _name
            };

            var project = new Project
            {
                key = _key
            };
            return new IssueCreation
            {
                fields = new Fields
                {
                    project = project,
                    summary = _summary,
                    description = _description,
                    issuetype = issueType,
                    customfield_10104 = _customfield_10104
                }
            };
        }

        public CreateIssueBuilder WithIssueType(string issueType)
        {
            _name = issueType;
            return this;
        }

        public CreateIssueBuilder WithIssueName(string issueName)
        {
            _customfield_10104 = issueName;
            return this;
        }
    }
}
