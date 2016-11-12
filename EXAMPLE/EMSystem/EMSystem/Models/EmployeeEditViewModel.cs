using EMSystem.Core.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EMSystem.Models
{
    public class EmployeeEditViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Title TitleOfEmployee { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfJoin { get; set; }
        public Position Position { get; set; }
        public Division Division { get; set; }
        public Office Office { get; set; }
        public string Salary { get; set; }
        public string FullName { get; set; }
        public string Period { get; set; }
    }
}