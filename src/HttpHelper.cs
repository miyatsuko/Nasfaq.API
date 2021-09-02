using System;
using System.Text;
using System.Text.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;

namespace Nasfaq.API
{
    public static class HttpHelper
    {
        public static async Task<string> GET(HttpClient client, string uri, List<(string, string)> header, string cookies = null)
        {
            HttpResponseMessage response;
            using(HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, uri))
            {
                SetHeaderValues(requestMessage.Headers, header);
                if(cookies != null)
                {
                    requestMessage.Headers.Add("Cookies", cookies);
                }
                response = await client.SendAsync(requestMessage);
                response.EnsureSuccessStatusCode();
            }

            bool isGzipped = false;
            if(response.Content.Headers.Contains("Content-Encoding"))
            {
                foreach(string str in response.Content.Headers.GetValues("Content-Encoding"))
                {
                    if(str == "gzip")
                    {
                        isGzipped = true;
                        Console.WriteLine("Was gzip");
                        break;
                    }
                }
            }

            using(Stream responseData = await response.Content.ReadAsStreamAsync())
            using(MemoryStream memStream = new MemoryStream())
            {
                if(isGzipped)
                {
                    using(GZipStream decompressedData = new GZipStream(responseData, CompressionMode.Decompress))
                    {
                        decompressedData.CopyTo(memStream);
                    }
                }
                else
                {
                    responseData.CopyTo(memStream);
                }

                memStream.Position = 0L;
                return Encoding.UTF8.GetString(memStream.ToArray());
            }
        }

        public static async Task<T> GET<T>(HttpClient client, string uri, List<(string, string)> header, string cookies = null)
        {
            string result = await GET(client, uri, header, cookies);
            return JsonSerializer.Deserialize<T>(result);
        }

        public static async Task<string> POST(HttpClient client, string uri, List<(string, string)> header, string content, string cookies = null)
        {
            string outdata = default;
            using(HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, uri))
            {
                requestMessage.Content = new StringContent(content, Encoding.UTF8, "text/plain");
                SetHeaderValues(requestMessage.Headers, header);
                if(cookies != null)
                {
                    requestMessage.Headers.Add("Cookies", cookies);
                }
                Console.WriteLine(requestMessage.ToString());
                HttpResponseMessage response = await client.SendAsync(requestMessage);
                response.EnsureSuccessStatusCode();
                outdata = await response.Content.ReadAsStringAsync();
            }
            return outdata;
        }

        public static void SetHeaderValues(HttpRequestHeaders header, List<(string, string)> headerValues)
        {   
            header.Clear();
            for(int i = 0; i < headerValues.Count; i++)
            {
                (string, string) pair = headerValues[i];
                header.Add(pair.Item1, pair.Item2);
            }
        }
    }
}