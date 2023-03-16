using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace server.Api.Models
{
    public class Dog
    {
        [Key]
        public int DogId {get; set;} 
        [Required]
        public string? Name {get; set;}
        public int Age {get; set;}
        [Required]
        public string? Location {get; set;}
        public string? Description {get; set;}
        [Required]
        public string? Email {get; set;}
        public int? SportId {get; set;}
        public virtual Sport? Sport {get; set;}
        [Required]
        public int UserId {get; set;}
        [Required]
        public virtual User? User {get; set;}

       
    }
}