using System.Threading.Tasks;
using Nasfaq.JSON;

namespace Nasfaq.JSON
{
    //api/getHistory
    //api/getHistory?timestamp={date timestamp in ms}
    public class GetHistory
    {
        public bool success { get; set; }
        public History history { get; set; }
    }

    public class History
    {
        public long timestamp { get; set; }
        //only 1000 last entries if not ?full
        public Transaction[] transactions { get; set; }
    }
}

namespace Nasfaq.API
{
    public partial class NasfaqAPI
    {
        public async Task<GetHistory> GetHistory(bool fullHistory, long timestamp = default)
        {
            string param = "";
            if(fullHistory) param = "?full";
            if(timestamp != default)
            {
                if(fullHistory) param += $"&timestamp={timestamp}";
                else param = $"?timestamp={timestamp}";
            }
            return await HttpHelper.GET<GetHistory>(
                httpClient,
                $"https://nasfaq.biz/api/getHistory{param}",
                headers
            );
        }
    }
}