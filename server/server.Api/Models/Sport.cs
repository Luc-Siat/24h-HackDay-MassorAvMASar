using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace server.Api.Models
{
    public class Sport
    {
        [Key]
        public int SportId {get; set;}
        [Required]
        public string? Name {get; set;}
        [JsonIgnore]
        public virtual List<Dog>? Dogs {get; set;}
    }
}