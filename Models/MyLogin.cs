using System.ComponentModel.DataAnnotations;

namespace LoginRegistration.Models
{
    public class MyLogin
    {
       [Required]
       [EmailAddress]
       [Display(Name = "Email Address")]
       public string LEmail {get; set;}
       [DataType(DataType.Password)]
       [Required]
       [Display(Name = "Password")]
       [MinLength(8, ErrorMessage=" Must be at least 8 characters")]
       public string LPassword{get; set;}

       public MyLogin ()
       {

       }
    }
}