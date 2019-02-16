using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoginRegistration.Models
{
    public class MyModel
    {
       [Key]
       public int MyModelId {get; set;}
       [Required]
       [MinLength(2)]
       [Display(Name = "First Name")]
       public string FirstName {get; set;}
       [Required]
       [MinLength(2)]
       [Display(Name = "Last Name")]
       public string LastName {get; set;}
       [Required]
       [EmailAddress]
       [Display(Name = "Email Address")]
       public string Email {get; set;}
       [DataType(DataType.Password)]
       [Required]
       [MinLength(8, ErrorMessage=" Must be at least 8 characters")]
       public string Password{get; set;}
       public DateTime CreatedAt {get; set;}
       public DateTime UpdatedAt {get; set;}

       [NotMapped]
       [Compare("Password")]
       [DataType(DataType.Password)]
       public string cPassword {get; set;}
    }
}