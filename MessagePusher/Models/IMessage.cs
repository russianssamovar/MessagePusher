using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessagePusher.Models
{
    public interface IMessage
    {
        string AppToken { get; set; }
        string UserKey { get; set; }
        string MessageString { get; set; }

        Task<string> SendMessage();
    }
}
