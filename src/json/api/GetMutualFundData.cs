using System.Threading.Tasks;
using System.Collections.Generic;
using Nasfaq.JSON;

namespace Nasfaq.JSON
{
    //api/getMutualFundData
    public class GetMutualFundData : NasfaqResponse
    {
        public Dictionary<string, MutualFundData_Fund> funds { get; set; }
        public Dictionary<string, MutualFundData_Bulletin[]> bulletins { get; set; }
        public Dictionary<string, MutualFundData_History[]> fundHistory { get; set; }
        public Dictionary<string, MutualFundData_Stat> fundStats { get; set; }
        public Dictionary<string, MutualFundData_Order> orders { get; set; }
        public Dictionary<string, double> fundPayouts { get; set; }
        public Dictionary<string, long> fundsToDissolve { get; set; }
        public Dictionary<string, MutualFundData_UserTotal[]> fundUserTotals { get; set; }

        public List<string> GetEveryFundManagedByUser(string userid)
        {
            List<string> fundids = new List<string>();
            foreach(KeyValuePair<string, MutualFundData_Fund> kvp in funds)
            {
                foreach(MutualFundData_Fund_Member member in kvp.Value.members)
                {
                    if(member.id == userid)
                    {
                        fundids.Add(kvp.Key);
                        break;
                    }
                }
            }
            return fundids;
        }
    }

    public class MutualFundData_Fund
    {
        public string id { get; set; }
        public string name { get; set; }
        public string dateCreated { get; set; }
        public string icon { get; set; }
        public string missionStatement { get; set; }
        public string tag { get; set; }
        public string color { get; set; }
        public string ceo { get; set; }
        public double balance { get; set; }
        public bool released { get; set; }
        public MutualFundData_Fund_Member[] members { get; set; }
        public Dictionary<string, MutualFundData_Fund_Portfolio> portfolio { get; set; }
    }

    public class MutualFundData_Fund_Member
    {
        public string id { get; set; }
        public string username { get; set; }
        public bool boardMember { get; set; }
    }

    public class MutualFundData_Fund_Portfolio
    {
        public int amount { get; set; }
        public long timestamp { get; set; }
        public double meanPurchasePrice { get; set; }
    }

    public class MutualFundData_Bulletin
    {
        public string id { get; set; }
        public string fund { get; set; }
        public string author { get; set; }
        public string authorName { get; set; }
        public string timestamp { get; set; }
        public string message { get; set; }
    }

    public class MutualFundData_History
    {
        public string timestamp { get; set; }
        public int volume { get; set; }
        public double price { get; set; }
        public double networth { get; set; }
        public int members { get; set; }
    }

    public class MutualFundData_Stat
    {
        public int volume { get; set; }
        public double price { get; set; }
        public double saleValue { get; set; }
        public double networth { get; set; }
        public int members { get; set; }
        public MutualFundData_Stat_History[] history { get; set; }
    }

    public class MutualFundData_Stat_History
    {
        public int volume { get; set; }
        public double price { get; set; }
        public double saleValue { get; set; }
        public double networth { get; set; }
        public int members { get; set; }
        public long timestamp { get; set; }
    }

    public class MutualFundData_Order
    {
        public int buys { get; set; }
        public int sells { get; set; }
    }

    public class MutualFundData_UserTotal
    {
        public string userid { get; set; }
        public string username { get; set; }
        public string icon { get; set; }
        public int quantity { get; set; }
    }
}

namespace Nasfaq.API
{
    public partial class NasfaqAPI
    {
        public static string[] GetFundsUserIsIn(GetMutualFundData fundData, string userid)
        {
            List<string> funds = new List<string>();
            foreach(KeyValuePair<string, MutualFundData_Fund> fund in fundData.funds)
            {
                foreach(MutualFundData_Fund_Member member in fund.Value.members)
                {
                    if(member.id == userid)
                    {
                        funds.Add(fund.Value.id);
                        break;
                    }
                }
            }
            return funds.ToArray();
        }

        public async Task<GetMutualFundData> GetMutualFundData()
        {
            return await HttpHelper.GET<GetMutualFundData>(
                httpClient,
                $"https://nasfaq.biz/api/getMutualFundData",
                headers
            );
        }
    }
}