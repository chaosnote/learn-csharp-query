using MongoDB.Bson;
using MongoDB.Driver;

namespace api.Services
{
    public class MongoService
    {
        public MongoClient Client { get; set; }

        public IMongoDatabase CreateDBConnection(string dbName = "todos")
        {
            return Client.GetDatabase(dbName);
        }
    }
}