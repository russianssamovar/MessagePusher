using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MessagePusher.Models
{
    public class Message:IMessage
    {
        public string AppToken { get; set; }
        public string UserKey { get; set; }
        public string MessageString { get; set; }

        private static readonly HttpClient _client = new HttpClient();

        public async Task<string> SendMessage()
        {
            var values = new Dictionary<string, string>
            {
                { "token", AppToken },
                { "user", UserKey },
                { "message", MessageString}
            };

            var content = new FormUrlEncodedContent(values);
            var response = await _client.PostAsync("https://api.pushover.net/1/messages.json", content);

            return response.IsSuccessStatusCode ? "Sucsess" : "Something wrong";
        }
    }
}
