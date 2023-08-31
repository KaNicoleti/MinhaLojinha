using MongoDB.Bson;
// bson é o json com mais dados
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LojinhaServer.Collections;

// especificando o nome da tabela

[Table("products")]
// caso sua classe n tenha todas as coisas da collection
[BsonIgnoreExtraElements]
    public class Product
    {
      [BsonId]
      [BsonRepresentation(BsonType.ObjectId)]
        public string Id {get; set;}

      [BsonElement("name")]
      // espefica qual vai ser o nome da saida
      [JsonPropertyName("Nome")]
        public string Name {get; set;}

        [BsonElement("description")]
        [JsonPropertyName("Descrição")]
        public string Description {get; set;}

        [BsonElement("price")]
        [JsonPropertyName("Preço")]
        public decimal Prince {get; set;}

        [BsonElement("offPrice")]
        [JsonPropertyName("Preço Atual")]
        public decimal OffPrice {get; set;}

        [BsonElement("categories")]
        [JsonPropertyName("Categorias")]
        public List<string> Categories {get; set;}

        [BsonElement("tags")]
        [JsonPropertyName("Tags")]
        public List<string> tags {get; set;}

        [BsonElement("brand")]
        [JsonPropertyName("Marcas")]
        public string Brand {get; set;}

    }
