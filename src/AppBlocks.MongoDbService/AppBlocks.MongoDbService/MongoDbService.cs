using AppBlocks.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBlocks.MongoDbService
{
    public class MongoDbService : IMongoDbService
    {
        private readonly IMongoCollection<Item> _items;

        public MongoDbService(IDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _items = database.GetCollection<Item>(settings.CollectionName);
        }
        public Item Create(Item item)
        {
            _items.InsertOne(item);
            return item;
        }

        public List<Item> Get()
        {
            return _items.Find(item => true).ToList();
        }

        public Item Get(string id)
        {
            return _items.Find(item => item.Id == id).FirstOrDefault();
        }

        public void Remove(string id)
        {
            _items.DeleteOne(item => item.Id == id);
        }

        public void Update(string id, Item item)
        {
            _items.ReplaceOne(item => item.Id == id, item);
        }
    }
}
