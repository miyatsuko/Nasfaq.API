using System.Threading.Tasks;
using System.Text.Json;
using Nasfaq.JSON;

namespace Nasfaq.JSON
{
    //api/addReport
    public class AddReport
    {
        public AddReport()
        {
            
        }
        
        public AddReport(int id, string roomId, string text, long timestamp, string username)
        {
            report = new Report()
            {
                message = new Report_Message()
                {
                    id = id,
                    roomId = roomId,
                    text = text,
                    timestamp = timestamp,
                    username = username
                }
            };
        }

        public Report report { get; set; }
    }

    public class Report
    {
        public Report_Message message { get; set; }
    }

    public class Report_Message
    {
        public int id { get; set; }
        public string roomId { get; set; }
        public string text { get; set; }
        public long timestamp { get; set; }
        public string username { get; set; }
    }
}

namespace Nasfaq.API
{
    public partial class NasfaqAPI
    {
        public async Task<NasfaqResponse> AddReport(AddReport data)
        {
            return await HttpHelper.POST<NasfaqResponse>(
                httpClient,
                "https://nasfaq.biz/api/addReport",
                headers,
                JsonSerializer.Serialize<AddReport>(data)
            );
        }

        public async Task<NasfaqResponse> AddReport(int id, string roomId, string text, long timestamp, string username)
        {
            return await AddReport(new AddReport(id, roomId, text, timestamp, username));
        }
    }
}