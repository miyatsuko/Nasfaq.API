using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.Json;
using Nasfaq.JSON;

namespace Nasfaq.JSON
{
    //api/mutualFundSendChat
    public class MutualFundSendChat
    {
        public string fund { get; set; }
        public string message { get; set; }

        public MutualFundSendChat()
        {

        }

        public MutualFundSendChat(string fund, string message)
        {
            this.fund = fund;
            this.message = message;
        }
    }
}

namespace Nasfaq.API
{
    public partial class NasfaqAPI
    {
        public async Task<NasfaqResponse> MutualFundSendChat(MutualFundSendChat data)
        {
            return await HttpHelper.POST<NasfaqResponse>(
                httpClient,
                "https://nasfaq.biz/api/mutualFundSendChat",
                headers,
                JsonSerializer.Serialize<MutualFundSendChat>(data)
            );
        }

        public async Task<NasfaqResponse> MutualFundSendChat(string fund, string message)
        {
            return await MutualFundSendChat(new MutualFundSendChat(fund, message));
        }
    }
}