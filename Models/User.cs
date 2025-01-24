using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Pokedex.Models
{
    [DataContract]
    public class TableUsuario
    {
        [Key]
        public long id { get; set; }
        [DataMember]
        public required string name { get; set; }
        [DataMember]
        public required string email { get; set; }
        [DataMember]
        public required string password { get; set; }
        [DataMember]
        public required string hash { get; set; }
        [DataMember]
        public required string typeUser { get; set; }
    }
}
