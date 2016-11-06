using FluentValidation;
using FluentValidation.Results;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluantValidation
{

    public class Student {

        public string Name { get; set; } // requted
        public string Email { get; set; } // email
        public string Password { get; set; } // length 3-5
        public string ConfirmPassword { get; set; } // same to password
        public DateTime DOB { get; set; } // past date
        public string Nic { get; set; } // 880240684V
        public int Age { get; set; }
        public string PasswordHint { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Login();

            Register();

            Console.Read();
        }

        private static void Login()
        {
            var x = new StudentLoginValidation().Validate(new Student
            {
                Email = "",
                Password = "123"
            });

            if (!x.IsValid)
            {
                foreach (var item in x.Errors)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("model is valied");
            }
        }

        private static void Register()
        {
            var x = new RegisterValidation().Validate(new Student
            {
                Email = "",
                Password = "123",
                PasswordHint = "123",
                ConfirmPassword="1234",
                Age= -1,
                DOB = new DateTime(2016,1,1),
                Nic="880240684V",
                Name=""
            });

            if (!x.IsValid)
            {
                foreach (var item in x.Errors)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("model is valied");
            }
        }
    }

    public class StudentLoginValidation: AbstractValidator<Student> {

        public StudentLoginValidation()
        {
            RuleFor(p => p.Email).NotNull().NotEmpty().WithMessage("email requred");
            RuleFor(p => p.Password).NotNull().NotEmpty().WithMessage("email requred");
        }
    }

    public class RegisterValidation : AbstractValidator<Student>
    {

        public RegisterValidation()
        {
            RuleFor(p => p.Email).EmailAddress().WithMessage("enter valied email address");
            RuleFor(p => p.Password).Length(3, 10).WithMessage("password must be char 3-10");
            RuleFor(p => p.Name).NotEmpty().NotNull().WithMessage("name must be there");
            RuleFor(p => p.Password).Equal(p => p.ConfirmPassword).WithMessage("2 password are not same");
            RuleFor(p => p.Age).GreaterThan(0).WithMessage("age must be gratter than 0");
            RuleFor(p => p.PasswordHint).Equal(p => p.Password)
                .WithMessage("password hint not must be password {0}", p => p.PasswordHint);

            RuleFor(p => p.Nic).Must(IsNic).WithMessage("invalied nic");

        }

        private bool IsNic(string nic)
        {
            bool isvalied = true;
            double tempVal = 0.0;
            if (nic.Length != 10)
            {
                isvalied = false;
            }
            else if (double.TryParse(nic.Substring(0, nic.Length - 1), out tempVal))
            {
                isvalied = false;
            }
            else if (nic.Substring(nic.Length - 1, 1).ToLower() != "v")
            {
                isvalied = false;
            }

            return isvalied;
        }
    }

    
}
