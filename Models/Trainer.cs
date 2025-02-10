using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Pokedex.Models
{
    public class Trainer
    {
        [Key]
        public long id { get; set; }
        [DataMember]
        public long userId { get; set; }
        public virtual User? user { get; set; }
        [DataMember]
        public required string name { get; set; }
        [DataMember]
        public required string region { get; set; }
        [DataMember]
        public string? initialPokemon {  get; set; }
        [DataMember]
        public DateTime? creationDate { get; set; }
        [DataMember]
        public DateTime? dateDelete { get; set; }
    }
}
