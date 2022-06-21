using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.Json;
using Nasfaq.JSON;

namespace Nasfaq.JSON
{
    //api/addFundToDissolve
    public class AddFundToDissolve
    {
        public string fund { get; set; }

        public AddFundToDissolve()
        {

        }

        public AddFundToDissolve(string fun)
        {
            this.fund = fund;
        }
    }
}

namespace Nasfaq.API
{
    public partial class NasfaqAPI
    {
        public async Task<NasfaqResponse> AddFundToDissolve(AddFundToDissolve data)
        {
            return await HttpHelper.POST<NasfaqResponse>(
                httpClient,
                "https://nasfaq.biz/api/addFundToDissolve",
                headers,
                JsonSerializer.Serialize<AddFundToDissolve>(data)
            );
        }

        public async Task<NasfaqResponse> AddFundToDissolve(string fund)
        {
            return await AddFundToDissolve(new AddFundToDissolve(fund));
        }
    }
}