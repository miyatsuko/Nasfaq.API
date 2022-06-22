using System.Threading.Tasks;
using Nasfaq.JSON;

namespace Nasfaq.JSON
{
    //api/getBenchmarkLeaderboard
    public class GetBenchmarkLeaderboard
    {
        public bool success { get; set; }
        public BenchmarkLeaderboard benchmarkLeaderboard { get; set; }
    }

    public class BenchmarkLeaderboard
    {
        public BenchmarkLeaderboard_Player[] outperformers { get; set; }
        public BenchmarkLeaderboard_Player[] underperformers { get; set; }
        public long intervalStart { get; set; }
        public long intervalEnd { get; set; }
        public BenchmarkLeaderboard_Index index { get; set; }
    }

    public class BenchmarkLeaderboard_Player
    {
        public string username { get; set; }
        public string icon { get; set; }
        public double performanceChange { get; set; }
        public double performancePercent { get; set; }
        public double relativePerformance { get; set; }
    }

    public class BenchmarkLeaderboard_Index
    {
        public double oldVal { get; set; }
        public double newVal { get; set; }
        public double change { get; set; }
        public double percentChange { get; set; }
    }
}

namespace Nasfaq.API
{
    public partial class NasfaqAPI
    {
        public async Task<GetBenchmarkLeaderboard> GetBenchmarkLeaderboard()
        {
            return await HttpHelper.GET<GetBenchmarkLeaderboard>(
                httpClient,
                $"https://nasfaq.biz/api/getBenchmarkLeaderboard",
                headers
            );
        }
    }
}