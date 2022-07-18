using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.Json;
using Nasfaq.JSON;

namespace Nasfaq.JSON
{
    //api/addChatGlobal
    //max 500 characters, min 1
    public class AddChatGlobal
    {
        public AddChatGlobal()
        {

        }

        public AddChatGlobal(string message, bool anonymous)
        {
            this.message = message;
            this.anonymous = anonymous;
        }

        public bool anonymous { get; set; }
        public string message { get; set; }
    }
}

namespace Nasfaq.API
{
    public partial class NasfaqAPI
    {
        public async Task<NasfaqResponse> AddChatGlobal(AddChatGlobal data)
        {
            return await HttpHelper.POST<NasfaqResponse>(
                httpClient,
                "https://nasfaq.biz/api/addChatGlobal",
                headers,
                JsonSerializer.Serialize<AddChatGlobal>(data)
            );
        }

        public async Task<NasfaqResponse> AddChatGlobal(string message, bool anonymous)
        {
            return await AddChatGlobal(new AddChatGlobal(message, anonymous));
        }
    }
}