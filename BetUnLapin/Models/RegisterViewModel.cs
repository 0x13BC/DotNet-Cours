using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BetUnLapin.Models
{
    public class RegisterViewModel
    {

        public string Name { get; set; }

        public string  FirstName{ get; set; }

        [Display(Name="Adresse email", Prompt ="Lapin@carotte.fr")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "{0} obligatoire")]
        [EmailAddress(ErrorMessage ="{0} n'est pas au bon format")]
        public string Email { get; set; }

        [Display(Name = "Mot de passe")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage ="{0} obligatoire")]
        //[RegularExpression("expression", ErrorMessage ="")]
        [StringLength(18,MinimumLength =6,ErrorMessage ="{0} doit contenir entree {2} et {1} caractères.")]
        public string Password { get; set; }

        [Display(Name = "Confirmation de mot de passe")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage = "{0} pas pareil que {1}")]
        public string ConfirmedPassword { get; set; }


        [Display(Name = "Date de naissance")]
        [DataType(DataType.Date)]
        [CustomDateValidator]
        public DateTime BirthDate { get; set; }
        public int Age { get; set; }



        
    }

    public class CustomDateValidator : ValidationAttribute
    {
        public int Age { get; set; }

        public void SoustractDate(DateTime BirthDate)
        {
            Age =  DateTime.Now.Year - BirthDate.Year;

        }
        public Boolean ValidateDate()
        {
            if (Age > 18)
            {
                return true;
            }

            return false;
        }

        public override bool IsValid(object value)
        {
            DateTime BirthDate = Convert.ToDateTime(value);
            SoustractDate(BirthDate);
            return ValidateDate();
        }
    }
}
