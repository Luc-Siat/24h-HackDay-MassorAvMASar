using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace server.Api.Models
{
    public class User
    {
        [Key]
        public int UserId {get;set;}
        [Required]
        public string? Username {get; set;}
        [Required]
        public string? Password {get; set;}
        [JsonIgnore]
        public virtual List<Dog>? Dogs {get; set;}
    }
}