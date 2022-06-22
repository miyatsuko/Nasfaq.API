using System.Threading.Tasks;
using System.Text.Json;
using Nasfaq.JSON;

namespace Nasfaq.JSON
{
    //api/addRoom
    public class AddRoom
    {
        public AddRoom()
        {
            
        }
        
        public AddRoom(string subject, string openingText)
        {
            this.subject = subject;
            this.openingText = openingText;
        }

        public string subject { get; set; }
        public string openingText { get; set; }
    }
}

namespace Nasfaq.API
{
    public partial class NasfaqAPI
    {
        public async Task<NasfaqResponse> AddRoom(AddRoom data)
        {
            return await HttpHelper.POST<NasfaqResponse>(
                httpClient,
                "https://nasfaq.biz/api/addRoom",
                headers,
                JsonSerializer.Serialize<AddRoom>(data)
            );
        }

        public async Task<NasfaqResponse> AddRoom(string subject, string openingText)
        {
            return await AddRoom(new AddRoom(subject, openingText));
        }
    }
}