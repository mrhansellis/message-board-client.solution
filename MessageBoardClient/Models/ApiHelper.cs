using System.Threading.Tasks;
using RestSharp;

namespace MessageBoardClient.Models
{
  public class ApiHelper
  {
    public static async Task<string> GetAll()
    {
      RestClient client = new RestClient("http://localhost:1986/");
      RestRequest request = new RestRequest($"api/v2/messages", Method.Get);
      RestResponse response = await client.GetAsync(request);
      return response.Content;
    }

    public static async Task<string> Get(int id)
    {
      RestClient client = new RestClient("http://localhost:1986/");
      RestRequest request = new RestRequest($"api/v2/messages/{id}", Method.Get);
      RestResponse response = await client.GetAsync(request);
      return response.Content;
    }

    public static async void Post(string newMessage)
    {
      RestClient client = new RestClient("http://localhost:1986/");
      RestRequest request = new RestRequest($"api/v2/messages", Method.Post);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newMessage);
      await client.PostAsync(request);
    }

    public static async void Put(int id, string newMessage)
    {
      RestClient client = new RestClient("http://localhost:1986/");
      RestRequest request = new RestRequest($"api/v2/messages/{id}", Method.Put);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newMessage);
      await client.PutAsync(request);
    }

    public static async void Delete(int id)
    {
      RestClient client = new RestClient("http://localhost:1986/");
      RestRequest request = new RestRequest($"api/v2/messages/{id}", Method.Delete);
      request.AddHeader("Content-Type", "application/json");
      await client.DeleteAsync(request);
    }
  }
}