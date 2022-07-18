using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.Json;
using Nasfaq.JSON;

namespace Nasfaq.JSON
{
    //api/vote
    public class Vote
    {
        public Vote()
        {

        }

        public Vote(int optionid, string pollid)
        {
            this.optionid = optionid;
            this.pollid = pollid;
        }

        public int optionid { get; set; }
        public string pollid { get; set; }
    }
}

namespace Nasfaq.API
{
    public partial class NasfaqAPI
    {
        public async Task<NasfaqResponse> Vote(Vote data)
        {
            return await HttpHelper.POST<NasfaqResponse>(
                httpClient,
                "https://nasfaq.biz/api/vote",
                headers,
                JsonSerializer.Serialize<Vote>(data)
            );
        }

        public async Task<NasfaqResponse> Vote(int optionid, string pollid)
        {
            return await Vote(new Vote(optionid, pollid));
        }
    }
}