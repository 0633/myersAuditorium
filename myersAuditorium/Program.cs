using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;


namespace myersAuditorium
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();

            var ops = new Ops();
            var status = new Status();

            string noSpeakers = "0,0";
            string leftSpeaker = "1,0";
            string rightSpeaker = "0,1";
            string bothSpeakers = "1,1";
            string speakerResponse = status.speakerStatus();






            if (string.Equals(noSpeakers, status.speakerStatus()))
            {
                Console.WriteLine("Speakers Are Off");
            }
            else if (string.Equals(bothSpeakers, status.speakerStatus()))

                Console.WriteLine("Speakers Are On");

            else if (string.Equals(leftSpeaker, status.speakerStatus()))

                Console.WriteLine("Left Speaker Is On");

            else if (string.Equals(rightSpeaker, status.speakerStatus()))
            {
                Console.WriteLine("Right Speaker Is On");
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();



    }
}
