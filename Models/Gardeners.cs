using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Please enter your first name within 30 characters, or less.")]
        [RegularExpression("^[a-zA-Z]*$", ErrorMessage = "Only Letters are allowed.")]
        [Display(Name = "First Name")]
        [Column("FirstName")]
        public string? FirstName { get; set; }
        [Required]
        [StringLength(30, ErrorMessage = "Please enter your last name within 30 characters, or less.")]
        [RegularExpression("^[a-zA-Z]*$", ErrorMessage = "Only Letters are allowed.")]
        [Display(Name = "Last Name")]
        [Column("LastName")]
        public string? LastName { get; set; }
        public Gender? GenderIdentity { get; set; }
        [StringLength(30, ErrorMessage = "Please enter your address within 50 characters, or less.")]
        public string? Address { get; set; }
        [StringLength(30, ErrorMessage = "Please enter your city within 30 characters, or less.")]
        public string? City { get; set; }
        [StringLength(2, ErrorMessage = "Please enter the state using 2 characters. Ex. MI")]
        public string? State { get; set; }
        [Range(0000000000, 9999999999, ErrorMessage = "Zip must be 10 characters or less.")]
        public int? Zip {  get; set; }
        [DataType(DataType.EmailAddress)]
        [Required]
        public string Email {  get; set; }
        [DataType(DataType.PhoneNumber)]
        public string? Cell {  get; set; }
        [Display(Name = "Favorite Crop")]
        public TopCrop? TopCrop { get; set; }
    }
}
