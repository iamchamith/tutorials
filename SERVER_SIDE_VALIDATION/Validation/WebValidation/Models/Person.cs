using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebValidation.Models
{
    public class Person
    {
        [Required(ErrorMessage = "please insert the first name")]
        [MaxLength(10, ErrorMessage = "First name must be less than 10")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "please insert the last name")]
        public string LastName { get; set; }
        [Range(18, 44)]
        public int Age { get; set; }

        [Required(ErrorMessage = "email requred")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "invalied email address")]
        public string Email { get; set; }
        [Range(typeof(decimal), "0.00", "49.99")]
        public decimal Price { get; set; }

        [System.ComponentModel.DataAnnotations.Compare("Email", ErrorMessage = "email address must be same")]
        public string EmailConfirm { get; set; }

        [MinLength(5, ErrorMessage = "password must be gratter than 5 chars")]
        [MaxLength(10, ErrorMessage = "password must be less than 10 chars")]
        [Required(ErrorMessage = "password requred")]
        public string Password { get; set; }

        [Required]


        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Password must be same")]
        public string ConfirmPassword { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (LastName != null && LastName.Split(' ').Length > 10)
            {
                yield return new ValidationResult("The last name has too many words!",
                new[] { "LastName" });
            }
        }

        [MaxWords(10, ErrorMessage = "what is fuking this")]
        public string Discription { get; set; }
    }
    // custom validation header
    public class MaxWordsAttribute : System.ComponentModel.DataAnnotations.ValidationAttribute
    {
        private readonly int _maxWords;
        public MaxWordsAttribute(int maxWords) : base("{0} has too many words.")
        {
            _maxWords = maxWords;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                var valueAsString = value.ToString();
                if (valueAsString.Length < _maxWords)
                {
                    var errorMessage = FormatErrorMessage(validationContext.DisplayName);
                    return new ValidationResult(errorMessage);
                }
            }
            return ValidationResult.Success;
        }
    }
}