using Chat.API.Configuration;
using Chat.API.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Chat.API.Data
{
    public class ChatDbContext
    {
        private readonly IMongoDatabase _database;

        public ChatDbContext(IOptions<MongoConnection> options)
        {
          var client = new MongoClient(options.Value.ConnectionString);
          _database = client.GetDatabase(options.Value.Database);
        }

        public IMongoCollection<Record> Records => _database.GetCollection<Record>("Record");
    }
}
