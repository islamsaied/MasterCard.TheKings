using MasterCard.Kings.DTO;
using MasterCard.TheKings.DTO;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace MasterCard.Kings
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();

            var apiUrl = config.GetRequiredSection("KingApi").Get<KingApiSettings>()?.Url;
            var monarchsList = new List<MonarchsDto>();

            using (HttpClient client = new())
            {
                var httpResponse = await client.GetAsync(apiUrl);
                string content = await httpResponse.Content.ReadAsStringAsync();

                monarchsList = JsonConvert.DeserializeObject<List<MonarchsDto>>(content);

            }

            var kingsList = monarchsList?.Select(monarch =>
            {
                return MappToKingDto(monarch);

            }).OrderByDescending(king => king.Years).ToList();

            var longestRuledKing = kingsList.First();

            var LongestRuledHouse = kingsList.GroupBy(king => king.House)
                                             .OrderByDescending(x => x.Sum(_ => _.Years))
                                             .Select(x => new { House = x.Key, Years = x.Sum(_ => _.Years) })
                                             .First();

            var mostRepeatedFirstName = kingsList.GroupBy(king => king.Name.Split(" ")[0])
                                                 .OrderByDescending(_ => _.Count())
                                                 .First().Key;

            Console.WriteLine($" 1) How many monarchs are there in the list? {kingsList?.Count} monarchs");
            Console.WriteLine("");

            Console.WriteLine($" 2) Which monarch ruled the longest (and for how long)??  the king {longestRuledKing.Name} for {longestRuledKing.Years} years");
            Console.WriteLine("");

            Console.WriteLine($" 3) Which house ruled the longest (and for how long)??  {LongestRuledHouse.House} for {LongestRuledHouse.Years} years");
            Console.WriteLine("");

            Console.WriteLine($" 4) What was the most common first name??  {mostRepeatedFirstName} ");
            Console.WriteLine("");

            Console.ReadLine();

        }

        private static KingDto MappToKingDto(MonarchsDto monarch)
        {
            var king = new KingDto
            {
                Id = monarch.Id,
                Name = monarch.Name,
                City = monarch.City,
                House = monarch.House,
            };

            var monarchPeriods = monarch.Period.Split('-');

            king.Years = monarchPeriods.Count() == 0 ?
                                Convert.ToInt32(monarch.Period) :
                         monarchPeriods.Count() == 1 || string.IsNullOrWhiteSpace(monarchPeriods[1]) ?
                                DateTime.Now.Year - Convert.ToInt32(monarchPeriods[0]) :
                                Convert.ToInt32(monarchPeriods[1]) - Convert.ToInt32(monarchPeriods[0]);
            return king;
        }
    }
}