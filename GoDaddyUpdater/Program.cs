using Microsoft.Extensions.Configuration;
using System;
using System.IO;

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
                    Domain = configuration["Domain"]
                };
                goDaddy.GetDnsRecord(goDaddy);
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
