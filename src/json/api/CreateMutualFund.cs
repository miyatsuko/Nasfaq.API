using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.Json;
using Nasfaq.JSON;

namespace Nasfaq.JSON
{
    public class CreateMutualFund
    {
        public string color { get; set; }
        public string icon { get; set; }
        public double initialInvestment { get; set; }
        public string missionStatement { get; set; }
        public string name { get; set; }
        public int startingShares { get; set; }
        public string tag { get; set; }

        public CreateMutualFund()
        {

        }

        public CreateMutualFund(string color, string icon, double initialInvestment, string missionStatement, string name, int startingShares, string tag)
        {
            this.color = color;
            this.icon = icon;
            this.initialInvestment = initialInvestment;
            this.missionStatement = missionStatement;
            this.name = name;
            this.startingShares = startingShares;
            this.tag = tag;
        }
    }
}

namespace Nasfaq.API
{
    public partial class NasfaqAPI
    {
        public async Task<NasfaqResponse> CreateMutualFund(CreateMutualFund data)
        {
            return await HttpHelper.POST<NasfaqResponse>(
                httpClient,
                "https://nasfaq.biz/api/createMutualFund",
                headers,
                JsonSerializer.Serialize<CreateMutualFund>(data)
            );
        }

        public async Task<NasfaqResponse> CreateMutualFund(string color, string icon, double initialInvestment, string missionStatement, string name, int startingShares, string tag)
        {
            return await CreateMutualFund(new CreateMutualFund(color, icon, initialInvestment, missionStatement, name, startingShares, tag));
        }
    }
}