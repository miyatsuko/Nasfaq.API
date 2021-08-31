using System;
using System.Text;
using System.Text.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;

namespace Nasfaq.API
{
    public static class HttpHelper
    {
        public static async Task<string> GET(HttpClient client, string uri, List<(string, string)> header, string cookies = null)
        {
            string outdata = default;
            using(HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, uri))
            {
                SetHeaderValues(requestMessage.Headers, header);
                if(cookies != null)
                {
                    requestMessage.Headers.Add("Cookies", cookies);
                }
                HttpResponseMessage response = await client.SendAsync(requestMessage);
                response.EnsureSuccessStatusCode();
                outdata = await response.Content.ReadAsStringAsync();
            }
            return outdata;
        }

        public static async Task<T> GET<T>(HttpClient client, string uri, List<(string, string)> header, string cookies = null)
        {
            T outdata = default;
            using(HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, uri))
            {
                SetHeaderValues(requestMessage.Headers, header);
                if(cookies != null)
                {
                    requestMessage.Headers.Add("Cookies", cookies);
                }
                Console.WriteLine(requestMessage.ToString());
                HttpResponseMessage response = await client.SendAsync(requestMessage);
                response.EnsureSuccessStatusCode();
                using(Stream responseData = await response.Content.ReadAsStreamAsync())
                {
                    foreach(var str in response.Content.Headers.GetValues("Content-Encoding"))
                    {
                        Console.WriteLine(str);
                    }
                    Console.WriteLine($"GET: {uri}\nRESPONSE: {responseData.ToString()}");
                    responseData.Position++;
                    outdata = await JsonSerializer.DeserializeAsync<T>(responseData);
                }
            }
            return outdata;
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