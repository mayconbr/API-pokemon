using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Pokedex.Models
{
    [DataContract]
    public class Pokemon
    {
        [Key]
        public long id { get; set; }
        [DataMember]
        public long treinerId { get; set; }
        public  virtual Treiner? treiner { get; set; }
        [DataMember]
        public required string? name { get; set; }
        [DataMember]
        public required string pokemon { get; set; }
        [DataMember]
        public required string type { get; set; }
        [DataMember]
        public required string pokedexNumber { get; set; }
    }
}
