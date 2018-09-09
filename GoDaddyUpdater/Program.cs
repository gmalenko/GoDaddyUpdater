using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Text.RegularExpressions;

namespace GoDaddyUpdater
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var configuration = builder.Build();
            Console.WriteLine(configuration["ExternalIpServiceUrl"]);
            Console.WriteLine(configuration["GoDaddyUsername"]);
            Console.WriteLine(configuration["GodaddyPassword"]);
            


            //now start the program
            try
            {
                var currentIp = new CurrentIpAddress(configuration["ExternalIpServiceUrl"]);
                var goDaddy = new GoDaddy()
                {
                    ApiUrl = configuration["GoDaddyUrl"],
                    DnsName = configuration["DnsName"],
                    DnsType = configuration["DnsType"],
                    Domain = configuration["Domain"],
                    ApiKey = configuration["ApiKey"],
                    ApiSecret = configuration["ApiSecret"],
                };
                goDaddy.GetDnsRecord(goDaddy);
                currentIp.Value = Regex.Replace(currentIp.Value, @"\t|\n|\r", "");
                if(goDaddy.IpAddress != currentIp.Value)
                {
                    //update godaddy
                }
                Console.WriteLine(currentIp.Value);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }



            Console.ReadLine();
        }
    }
}
