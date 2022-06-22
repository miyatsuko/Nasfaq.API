using System.Threading.Tasks;
using Nasfaq.JSON;

namespace Nasfaq.JSON
{
    //api/getCooldown
    public class GetCooldown
    {
        public bool success { get; set; } = true;
        public Cooldown cooldown { get; set; }
    }

    public class Cooldown
    {
        public long room { get; set; }
        public long post { get; set; }
        public long superchat { get; set; }
    }
}

namespace Nasfaq.API
{
    public partial class NasfaqAPI
    {
        public async Task<GetCooldown> GetCooldown()
        {
            return await HttpHelper.GET<GetCooldown>(
                httpClient,
                "https://nasfaq.biz/api/getCooldown",
                headers
            );
        }
    }
}