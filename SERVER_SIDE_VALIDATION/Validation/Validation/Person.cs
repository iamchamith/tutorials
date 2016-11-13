using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Validation
{
    public class Person
    {
        [Required(ErrorMessage = "please insert the first name")]
        [StringLength(10, ErrorMessage = "First name must be less than 10")]
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

        [Required(ErrorMessage = "password requred")]
        public string Password { get; set; }

        [Required]
        [MaxWords(10, ErrorMessage = "what is fuking this")]
        public string MyError { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (LastName != null && LastName.Split(' ').Length > 10)
            {
                yield return new ValidationResult("The last name has too many words!",
                new[] { "LastName" });
            }
        }
    }
    // custom validation header
    public class MaxWordsAttribute : ValidationAttribute
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
