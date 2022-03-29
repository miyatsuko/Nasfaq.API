using System.Collections.Generic;

namespace Nasfaq.JSON
{
    //api/getBenchmarkInfo
    public class GetBenchmarkInfo
    {
        public BenchmarkInfo_Benchmark benchmark { get; set; }
        public BenchmarkInfo_History[] rolling { get; set; }
        public BenchmarkInfo_History[] history { get; set; }
    }

    public class BenchmarkInfo_Benchmark
    {
        public double index { get; set; }
        public double marketCap { get; set; }
        public int totalShares { get; set; }
        public Dictionary<string, double> weights { get; set; }
    }

    public class BenchmarkInfo_History
    {
        public double index { get; set; }
        public double marketCap { get; set; }
        public int totalShares { get; set; }
        public int timestamp { get; set; }
    }
}