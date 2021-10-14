using Chat.API.Configuration;
using Chat.API.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Chat.API.Data
{
    public class ChatDbContext
    {
        private readonly IMongoDatabase _database;
        private readonly MongoClient _client;

        public ChatDbContext(IOptions<MongoConnection> options)
        {
            _client = new MongoClient(options.Value.ConnectionString);
            if (_client != null)
            {
                _database = _client.GetDatabase(options.Value.Database);
            }
        }

        public IMongoCollection<Record> Records
        {
            get
            {
                return _database.GetCollection<Record>("Record");
            }
        }
      
    }
}
