using Newtonsoft.Json;
using RestSharp;
using SolutionCore.Builders;
using SolutionCore.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionCore.ApiWorkFlow
{
    public class Issue
    {
        private readonly string IssueEndpoint = ConfigurationManager.AppSettings["IssueEndpoint"];
        RestClient restClient;
        public Issue(RestClient restClient)
        {
            this.restClient = restClient;
        }

        public CreateIssueResponse CreateIssue(IssueCreation issueCreation)
        {
            var request = new RestRequest(IssueEndpoint);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(issueCreation);
            var content = restClient.Post(request).Content;
            return JsonConvert.DeserializeObject<CreateIssueResponse>(content);
        }
        
        public string UpdateIssue(string issueToUpdate, string epic)
        {
            var request = new RestRequest(IssueEndpoint + issueToUpdate);
            var updateBody = new UpdateIssueBuilder()
                .WithIssueToUpdate(epic)
                .Build();
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(updateBody);
            var response = restClient.Put(request);
            return response.StatusCode.ToString();
        } 

        public string AddingComment(AddComment bodyComment, string issueComment)
        {
            var request = new RestRequest(IssueEndpoint+issueComment+ "/comment");
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(bodyComment);
            var response = restClient.Post(request);
            return response.StatusCode.ToString();
        }

        public int SetPriority(string priority, string issueToUpdate)
        {
            string body = "{\"fields\": {\"priority\":{\"name\": \""+priority+"\"}}}";
            Console.WriteLine(body);
            var request = new RestRequest(IssueEndpoint+issueToUpdate);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(body);
            var response = restClient.Put(request);
            return (int)response.StatusCode;
        }

        public int UpdateSummaryAndDescrip(string summary, string description, string issueToUpdate)
        {
            string body = "{\"fields\": {\"summary\": \"" + summary + "\",\"description\": \""+description+"\"}}";
            Console.WriteLine(body);
            var request = new RestRequest(IssueEndpoint + issueToUpdate);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(body);
            var response = restClient.Put(request);
            return (int)response.StatusCode;
        }
    }
}
