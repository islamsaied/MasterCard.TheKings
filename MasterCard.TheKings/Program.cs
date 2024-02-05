
using MasterCard.TheKings.DTO;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

IConfiguration config = new ConfigurationBuilder()
       .AddJsonFile("appsettings.json")
       .AddEnvironmentVariables()
       .Build();

var apiUrl = config.GetRequiredSection("KingApi").Get<KingApiSettings>()?.Url;

using (HttpClient client = new())
{
    var httpResponse = await client.GetAsync(apiUrl);
    string content = await httpResponse.Content.ReadAsStringAsync();

    var kingList = JsonConvert.DeserializeObject<List<KingDto>>(content);
}