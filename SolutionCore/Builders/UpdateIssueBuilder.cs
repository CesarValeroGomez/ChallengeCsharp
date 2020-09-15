using SolutionCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionCore.Builders
{
    class UpdateIssueBuilder
    {
        public string _customfield_10102 = "JIR-3";

              
        public UpdateIssue Build()
        {
            return new UpdateIssue
            {
                fields = new UpdateFields
                {
                    customfield_10102 = _customfield_10102
                }
            };
        }

        public UpdateIssueBuilder WithIssueToUpdate(string issueToUpdate)
        {
            _customfield_10102 = issueToUpdate;
            return this;
        } 
    }
}
