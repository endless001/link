using System;
using MongoDB.Bson.Serialization.Attributes;

namespace Chat.API.Models
{
    [BsonIgnoreExtraElements]
    public class Record
    {
        public string Content { get; set; }
        public DateTime Timestamp { get; set; }
        public int FromUserId { get; set; }
        public int ToReceiverId { get; set; }
        public int MessageType { get; set; }
        public int ReceiverType { get; set; }
    }
}
