using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Library_desktop.Class;

namespace Library_desktop.Service
{
    class BookService
    {

        public static readonly string baseAPI = "http://localhost:5050/api/";

        public async Task<List<Library_desktop.Class.Book>> FetchBookData()
        {
            try
            {
                Console.WriteLine("Fetch Data");
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync(baseAPI+ "books");
                string responseBody = await response.Content.ReadAsStringAsync();
                var respObject = JsonSerializer.Deserialize<Library_desktop.Class.RootBook>(responseBody);

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

        public async Task<String> UpdateBookData(Library_desktop.Class.Book book, String bid)
        {
            HttpClient client = new HttpClient();
            string json = JsonSerializer.Serialize(book);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PatchAsync(baseAPI + "book/" + bid, content);
            string responseBody = await response.Content.ReadAsStringAsync();

            JsonNode data = JsonNode.Parse(responseBody);

            return data["message"].ToString();
        }

        public async Task<String> DeleteBookData(String bid)
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.DeleteAsync("http://localhost:5050/api/book/" + bid);
            string responseBody = await response.Content.ReadAsStringAsync();

            JsonNode data = JsonNode.Parse(responseBody);

            return data["message"].ToString();
        }

        public async Task<String> CreateBookData(Library_desktop.Class.Book book)
        {
            HttpClient httpClient = new HttpClient();
            string json = JsonSerializer.Serialize(book);
            HttpContent content = new StringContent(json,Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.PostAsync(baseAPI + "book", content);
            string responseBody = await response.Content.ReadAsStringAsync();

            JsonNode data = JsonNode.Parse(responseBody);

            return data["message"].ToString();
        }



    }


}

