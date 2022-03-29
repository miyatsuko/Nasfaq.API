namespace Nasfaq.JSON
{
    //benchmarkUpdate
    public class WSBenchmarkUpdate : IWebsocketData
    {
        public BenchmarkInfo_Benchmark benchmark { get; set; }
        public BenchmarkInfo_History benchmarkLog { get; set; }
    }
}