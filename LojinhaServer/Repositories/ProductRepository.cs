using LojinhaServer.Collections;
using MongoDB.Driver;

namespace LojinhaServer.Repositories;
                                    // para declarar qual é a interface 
    public class ProductRepository : IProductRepository
    {
        private readonly IMongoCollection<Product> _collection;

        public ProductRepository(IMongoDatabase mongoDatabase)
        {
            _collection = mongoDatabase.GetCollection<Product>("products");
        }
    }
