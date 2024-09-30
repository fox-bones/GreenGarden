using System;
using System.ComponentModel.DataAnnotations;

namespace GreenGarden.Models
{
    public enum Gender
    {
        Male, 
        Female,
        Other
    }
    public class Gardeners
    {
        public int ID { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Please enter your first name within 30 characters, or less.")]
        public string? FirstName { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Please enter your last name within 30 characters, or less.")]
        public string? LastName { get; set; }

        public Gender? GenderIdentity { get; set; }

        [StringLength(30, ErrorMessage = "Please enter your address within 50 characters, or less.")]
        public string? Address { get; set; }

        [StringLength(30, ErrorMessage = "Please enter your city within 30 characters, or less.")]
        public string? City { get; set; }

        [StringLength(2, ErrorMessage = "Please enter the state using 2 characters. Ex. MI")]
        public string? State { get; set; }

        [StringLength(10, ErrorMessage = "Zipcode has a maximum length of 10 numbers.")]
        public string? Zip {  get; set; }

        public string? Email {  get; set; }

        public string? Cell {  get; set; }
    }
}
