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
    class MemberService
    {
        public static readonly string baseAPI = "http://localhost:5050/api/";

        public async Task<List<Library_desktop.Class.Member>> FetchMemberData()
        {
            try
            {
                Console.WriteLine("Fetch Data");
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync(baseAPI + "members");
                string responseBody = await response.Content.ReadAsStringAsync();
                var respObject = JsonSerializer.Deserialize<Library_desktop.Class.ListMember>(responseBody);

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

        public async Task<String> CreateMemberData(Library_desktop.Class.Member member)
        {
            HttpClient httpClient = new HttpClient();
            string json = JsonSerializer.Serialize(member);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.PostAsync(baseAPI + "member", content);
            string responseBody = await response.Content.ReadAsStringAsync();

            JsonNode data = JsonNode.Parse(responseBody);

            return data["message"].ToString();
        }

        public async Task<String> UpdateMemberData(Library_desktop.Class.Member member, String muser)
        {
            HttpClient client = new HttpClient();
            string json = JsonSerializer.Serialize(member);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PatchAsync(baseAPI+"member/" + muser, content);
            string responseBody = await response.Content.ReadAsStringAsync();

            JsonNode data = JsonNode.Parse(responseBody);

            return data["message"].ToString();
        }


        public async Task<String> DeleteMemberData(String muser)
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.DeleteAsync(baseAPI + "member/" + muser);
            string responseBody = await response.Content.ReadAsStringAsync();

            JsonNode data = JsonNode.Parse(responseBody);

            return data["message"].ToString();
        }


    }
}
