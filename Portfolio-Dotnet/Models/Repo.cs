using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Portfolio.Models
{
    public class Repo
    {
        public int Stargazers { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        public string Language { get; set; }

        public static List<Repo> GetRepos()
        {
            var client = new RestClient("https://api.github.com/search/repositories");
            var request = new RestRequest("?q=user:grepcats&sort=stars&order=desc");
            var response = new RestResponse();

            Task.Run(async () =>
            {
                response = await GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();

            JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(response.Content);
            var repoList = JsonConvert.DeserializeObject<List<Repo>>(jsonResponse["items"].ToString());
            return repoList;
        }

        public static Task<IRestResponse> GetResponseContentAsync(RestClient theClient, RestRequest theRequest)
        {
            var tcs = new TaskCompletionSource<IRestResponse>();
            theClient.ExecuteAsync(theRequest, response => {
                tcs.SetResult(response);
            });
            return tcs.Task;
        }
    }
}
