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
    }
}
