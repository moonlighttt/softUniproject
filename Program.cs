using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.SrybskoRegex
{
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main(string[] args)
        {
            var regx = new Regex(@"(\D+)@(\D+)\s(\d+)\s(\d+)");

            var eventsInformation = new Dictionary<string, Dictionary<string, int>>();
            string input = Console.ReadLine();

            while (input != "End")
            {
                var match = regx.Match(input);
                if (match.Success)
                {
                    var singer = match.Groups[1].Value.Trim();
                    var place = match.Groups[2].Value.Trim();
                    var ticketPrice = int.Parse(match.Groups[3].Value.Trim());
                    var ticketsCount = int.Parse(match.Groups[4].Value.Trim());

                    var sum = ticketsCount*ticketPrice;

                    if (!eventsInformation.ContainsKey(place))
                    {
                        eventsInformation[place] = new Dictionary<string, int>(); 
                        //eventsInformation[singer][place]++;
                    }
                    if (!eventsInformation[place].ContainsKey(singer))
                    {
                        eventsInformation[place][singer] = 0;
                    }
                   
                    eventsInformation[place][singer] += sum;
                }
                input = Console.ReadLine();
            }
            foreach (var pair in eventsInformation)
            {
                Console.WriteLine(pair.Key);
                foreach (var eventsInfo in pair.Value.OrderByDescending(c => c.Value))
                {
                    Console.WriteLine("#  {0} -> {1}", eventsInfo.Key, eventsInfo.Value);
                }
                Console.WriteLine();
            }
        }
    }
}
