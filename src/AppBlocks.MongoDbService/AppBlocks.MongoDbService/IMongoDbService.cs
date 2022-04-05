using AppBlocks.Models;

namespace AppBlocks.MongoDbService
{
    public interface IMongoDbService
    {
        List<Item> Get();
        Item Get(string id);
        Item Create(Item student);
        void Update(string id, Item student);
        void Remove(string id);
    }
}