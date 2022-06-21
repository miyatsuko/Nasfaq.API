using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.Json;
using Nasfaq.JSON;

namespace Nasfaq.JSON
{
    //api/mutualFundToggleBoardMember
    public class MutualFundToggleBoardMember
    {
        public string fund { get; set; }
        public string member { get; set; }

        public MutualFundToggleBoardMember()
        {

        }

        public MutualFundToggleBoardMember(string fund, string member)
        {
            this.fund = fund;
            this.member = member;
        }
    }
}

namespace Nasfaq.API
{
    public partial class NasfaqAPI
    {
        public async Task<NasfaqResponse> MutualFundToggleBoardMember(MutualFundToggleBoardMember data)
        {
            return await HttpHelper.POST<NasfaqResponse>(
                httpClient,
                "https://nasfaq.biz/api/mutualFundToggleBoardMember",
                headers,
                JsonSerializer.Serialize<MutualFundToggleBoardMember>(data)
            );
        }

        public async Task<NasfaqResponse> MutualFundToggleBoardMember(string fund, string member)
        {
            return await MutualFundToggleBoardMember(new MutualFundToggleBoardMember(fund, member));
        }
    }
}