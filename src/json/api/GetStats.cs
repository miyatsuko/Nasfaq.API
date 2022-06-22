using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.Json;
using Nasfaq.JSON;

namespace Nasfaq.JSON
{
    //api/getStats
    public class GetStats
    {   
        public Dictionary<string, Stats> stats { get; set; }
        public Stats_CoinHistory[] coinHistory { get; set; }
    }

    public class GetStats_Raw
    {   
        public Dictionary<string, Stats> stats { get; set; }
        public string coinHistory { get; set; }
    }
    
    public class Stats
    {
        public Stats_Data subscriberCount { get; set; }
        public Stats_Data dailySubscriberCount { get; set; }
        public Stats_Data weeklySubscriberCount { get; set; }
        public Stats_Data viewCount { get; set; }
        public Stats_Data dailyViewCount { get; set; }
        public Stats_Data weeklyViewCount { get; set; }
    }

    public class Stats_Data
    {
        public string name { get; set; }
        public string[] labels { get; set; }
        public int[] data { get; set; }
    }

    public class Stats_CoinHistory
    {
        public long timestamp { get; set; }
        public Dictionary<string, Stats_CoinInfo> data { get; set; }
    }

    public class Stats_CoinInfo
    {
        public string coin { get; set; }
        public double price { get; set; }
        public int inCirculation { get; set; }
    }
}

namespace Nasfaq.API
{
    public partial class NasfaqAPI
    {
        public async Task<GetStats> GetStats()
        {
            string json = await HttpHelper.GET(
                httpClient,
                "https://nasfaq.biz/api/getStats",
                headers
            );
            
            GetStats getStats = new GetStats();
            getStats.stats = new System.Collections.Generic.Dictionary<string, Stats>();
            JsonDocument jsonDocument = JsonDocument.Parse(json);
            JsonElement stats = jsonDocument.RootElement.GetProperty("stats");
            foreach(JsonProperty kvp in stats.EnumerateObject())
            {
                Stats statsObject = new Stats();
                for(int j = 0; j < 6; j++)
                {
                    JsonElement element = default;
                    if(j == 0) element = kvp.Value.GetProperty("subscriberCount");
                    else if(j == 1) element = kvp.Value.GetProperty("dailySubscriberCount");
                    else if(j == 2) element = kvp.Value.GetProperty("weeklySubscriberCount");
                    else if(j == 3) element = kvp.Value.GetProperty("viewCount");
                    else if(j == 4) element = kvp.Value.GetProperty("dailyViewCount");
                    else if(j == 5) element = kvp.Value.GetProperty("weeklyViewCount");

                    JsonElement nameElement = element.GetProperty("name");
                    JsonElement labelsElement = element.GetProperty("labels");
                    JsonElement dataElement = element.GetProperty("data");

                    Stats_Data data = new Stats_Data();
                    data.name = nameElement.ToString();
                    data.labels = new string[labelsElement.GetArrayLength()];
                    data.data = new int[dataElement.GetArrayLength()];

                    int i = 0;
                    foreach(JsonElement value in labelsElement.EnumerateArray())
                    {
                        data.labels[i] = value.ToString();
                        i++;
                    }

                    i = 0;
                    foreach(JsonElement value in dataElement.EnumerateArray())
                    {
                        if(value.ValueKind == JsonValueKind.String)
                        {
                            data.data[i] = Int32.Parse(value.GetString());
                        }
                        else
                        {
                            data.data[i] = value.GetInt32();
                        }
                        i++;
                    }

                    if(j == 0) statsObject.subscriberCount = data;
                    else if(j == 1) statsObject.dailySubscriberCount = data;
                    else if(j == 2) statsObject.weeklySubscriberCount = data;
                    else if(j == 3) statsObject.viewCount = data;
                    else if(j == 4) statsObject.dailyViewCount = data;
                    else if(j == 5) statsObject.weeklyViewCount = data;
                }
                getStats.stats.Add(kvp.Name, statsObject);
            }

            JsonElement coinHistory = jsonDocument.RootElement.GetProperty("coinHistory");
            getStats.coinHistory = JsonSerializer.Deserialize<Stats_CoinHistory[]>(coinHistory.ToString());


            return getStats;
        }
    }
}