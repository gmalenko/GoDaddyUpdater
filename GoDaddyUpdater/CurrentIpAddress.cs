using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoDaddyUpdater
{
    public class CurrentIpAddress
    {
        public string Value { get; set; }



        public CurrentIpAddress(string url)
        {
            SetCurrentIpAddress(url);
        }

        public void SetCurrentIpAddress(string url)
        {
            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            var response = client.Execute(request);
            this.Value = response.Content.ToString();            
        }
    }
}
