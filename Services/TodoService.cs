using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongoDB.Bson;

namespace api.Services
{
    public class TodoService
    {
        public TodoService(MongoService mongo)
        {
            DataBase = mongo.CreateDBConnection();
        }
        private string CollectionName = "lists";
        private IMongoDatabase DataBase;

        public void AddItem(TodoAddModel v)
        {
            var collection = DataBase.GetCollection<TodoModel>(this.CollectionName);
            collection.InsertOne(new TodoModel()
            {
                // Type = v.Type,
                Value = v.Value,
                Date = DateTime.Now.ToLocalTime().ToString("yyyy/MM/dd HH:mm")
            });
        }

        public dynamic GetItems()
        {
            var collection = DataBase.GetCollection<TodoModel>(this.CollectionName);
            return collection.AsQueryable().Select(x => new
            {
                x.Date,
                x.Value,
                x.Id
            }).ToList();
        }

        public void RemoveItem(string[] v)
        {
            var collection = DataBase.GetCollection<TodoModel>(this.CollectionName);
            for (int i = 0, max = v.Length; i < max; i++)
            {
                ObjectId _id;
                if (ObjectId.TryParse(v[i], out _id)) collection.FindOneAndDelete(x => x.Id == _id);
            }
        }
    }
}