using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MessageBoardClient.Models
{
  public class Message
  {
    public int MessageId { get; set; }
    public string Comment { get; set; }
    public string Group { get; set; }
    public string UserName { get; set; }
    public DateTime Date { get; set; }

    public static List<Message> GetMessages()
    {
      var apiCallTask = ApiHelper.GetAll();
      var result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Message> messageList = JsonConvert.DeserializeObject<List<Message>>(jsonResponse.ToString());

      return messageList;
    }

    public static Message GetDetails(int id)
    {
      var apiCallTask = ApiHelper.Get(id);
      var result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      Message message = JsonConvert.DeserializeObject<Message>(jsonResponse.ToString());

      return message;
    }

    public static void Post(Message message)
    {
      message.Date = DateTime.Now;
      // this line will add current time before it hits the API
      string jsonMessage = JsonConvert.SerializeObject(message);
      ApiHelper.Post(jsonMessage);
    }

    public static void Put(Message message)
    {
      string jsonMessage = JsonConvert.SerializeObject(message);
      ApiHelper.Put(message.MessageId, jsonMessage);
    }

    public static void Delete(int id)
    {
      ApiHelper.Delete(id);
    }
  }
}