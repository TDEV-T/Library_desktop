using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Library_desktop.Class;

namespace Library_desktop.Service
{
    class BorrowService
    {
        public static readonly string baseAPI = "http://localhost:5050/api/";

        public async Task<List<Library_desktop.Class.BorrowMapping>> FetchBorrowData()
        {
            try
            {
                Console.WriteLine("Fetch Data");
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync(baseAPI + "borrows");
                string responseBody = await response.Content.ReadAsStringAsync();
                var respObject = JsonSerializer.Deserialize<ListBorrow>(responseBody);

                if (respObject != null)
                {
                    Console.WriteLine("Data coming");
                    return respObject.data;
                }
                else
                {
                    Console.WriteLine("Data is null");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<List<Library_desktop.Class.BorrowMapping>> SearchBorrowData(string search)
        {
            try
            {
                Console.WriteLine("Fetch Data");
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync(baseAPI + "borrows/"+search);
                string responseBody = await response.Content.ReadAsStringAsync();
                var respObject = JsonSerializer.Deserialize<ListBorrow>(responseBody);

                if (respObject != null)
                {
                    Console.WriteLine("Data coming");
                    return respObject.data;
                }
                else
                {
                    Console.WriteLine("Data is null");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }


        public async Task<String> UpdateBorrowData(BorrowUpdate updateBorrow)
        {
            try
            {

                string json = JsonSerializer.Serialize(updateBorrow);
                Console.WriteLine("Fetch Data");
                HttpClient client = new HttpClient();
                HttpContent content = new StringContent(json,Encoding.UTF8,"application/json");
                HttpResponseMessage response = await client.PatchAsync(baseAPI + "borrow",content);
                string responseBody = await response.Content.ReadAsStringAsync();
                
                JsonNode data = JsonNode.Parse(responseBody);

                return data["message"].ToString();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<String> ReturnBorrowData(BorrowReturn borrow)
        {
            try
            {
                string json = JsonSerializer.Serialize(borrow);

                HttpClient client = new HttpClient();

                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage resp = await client.PostAsync(baseAPI + "borrow/return", content);

                string respBody = await resp.Content.ReadAsStringAsync();

                JsonNode data = JsonNode.Parse(respBody);

                return data["message"].ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }


        public async Task<String> CreateBorrowData(BorrowCreate borrow)
        {
            try
            {
                string json = JsonSerializer.Serialize(borrow);

                HttpClient client = new HttpClient();

                HttpContent content = new StringContent (json,Encoding.UTF8,"application/json");
                HttpResponseMessage resp = await client.PostAsync(baseAPI + "borrow", content);

                string respBody = await resp.Content.ReadAsStringAsync();

                JsonNode data = JsonNode.Parse(respBody);

                return data["message"].ToString();

            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<StatsData> GetStats()
        {
            try
            {
                Console.WriteLine("Fetch Data");
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync(baseAPI + "stats");
                string responseBody = await response.Content.ReadAsStringAsync();
                var respObject = JsonSerializer.Deserialize<StatsData>(responseBody);

                if (respObject != null)
                {
                    Console.WriteLine("Data coming");
                    return respObject;
                }
                else
                {
                    Console.WriteLine("Data is null");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

       
  
    }
}
