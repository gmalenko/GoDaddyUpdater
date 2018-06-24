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

        public string IpAddress { get; set; }
        


        public void GetDnsRecord(GoDaddy goDaddyValues)
        {
            var client = new RestClient(BuildApiUrl());
            var request = new RestRequest(Method.GET);
            var response = client.Execute(request);
            
        }


        private string BuildApiUrl()
        {
            return ApiUrl + $"/v1/domains/{this.Domain}/records/{this.DnsType}/{this.DnsName}"            
        }
    }
}
