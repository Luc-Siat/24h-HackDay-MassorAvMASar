using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace server.Api.Models
{
    // public enum Gender
    // {
    //    Male,
    //    Female 
    // }
    public class Dog
    {
        [Key]
        public int DogId {get; set;} 
        [Required]
        public string? Name {get; set;}
        public string? ImageUrl {get; set;}
        [Required]
        public int? Age {get; set;}
        [Required]
        public string? Gender {get; set;}
        public string? Race {get; set;}
        public string? Location {get; set;}
        public string? Description {get; set;}
        [Required]
        public int? SportId {get; set;}
        [JsonIgnore]
        public virtual Sport? Sport {get; set;}
        [Required]
        public int UserId {get; set;}
        [JsonIgnore]
        public virtual User? User {get; set;}
    }
}