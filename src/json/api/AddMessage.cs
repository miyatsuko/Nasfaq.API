using System.Threading.Tasks;
using System.Text.Json;
using Nasfaq.JSON;

namespace Nasfaq.JSON
{
    //api/addMessage
    public class AddMessage
    {
        public AddMessage()
        {
            
        }
        
        public AddMessage(string room, string text)
        {
            this.room = room;
            this.text = text;
        }

        public string room { get; set; }
        public string text { get; set; }
    }
}

namespace Nasfaq.API
{
    public partial class NasfaqAPI
    {
        public async Task<NasfaqResponse> AddMessage(AddMessage data)
        {
            return await HttpHelper.POST<NasfaqResponse>(
                httpClient,
                "https://nasfaq.biz/api/addMessage",
                headers,
                JsonSerializer.Serialize<AddMessage>(data)
            );
        }

        public async Task<NasfaqResponse> AddMessage(string room, string text)
        {
            return await AddMessage(new AddMessage(room, text));
        }
    }
}