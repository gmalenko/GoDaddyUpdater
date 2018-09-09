using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoDaddyUpdater
{
    public class GoDaddy
    {
        public string Domain { get; set; }
        public string DnsName { get; set; }
        public string DnsType { get; set; }
        public int Ttl { get; set; }
        public string ApiUrl { get; set; }
        public string Type { get; set; }
        public string IpAddress { get; set; }
        public string ApiKey { get; set; }
        public string ApiSecret { get; set; }



        public void GetDnsRecord(GoDaddy goDaddyValues)
        {
            var client = new RestClient(BuildApiUrl());
            var request = new RestRequest(Method.GET);
            request.RequestFormat = DataFormat.Json;
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", $"sso-key {goDaddyValues.ApiKey}:{goDaddyValues.ApiSecret}");
            var response = client.Execute(request);
            dynamic dynamicResponse = JsonConvert.DeserializeObject(response.Content);
            this.IpAddress = dynamicResponse[0].data;
            this.Ttl = Convert.ToInt32(dynamicResponse[0].ttl);
            this.Type = dynamicResponse[0].type;            
        }

        public Boolean UpdateDnsRecord(GoDaddy goDaddyValues)
        {
            return false
        }


        private string BuildApiUrl()
        {
            return ApiUrl + $"/v1/domains/{this.Domain}/records/{this.DnsType}/{this.DnsName}";     
        }
    }
}
