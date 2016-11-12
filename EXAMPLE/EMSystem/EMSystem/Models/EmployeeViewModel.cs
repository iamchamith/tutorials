using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EMSystem.Models
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfJoin { get; set; }
        public string Salary { get; set; }
        public string Position { get; set; }
        public string Division { get; set; }
        public string Office { get; set; }
        public string FullName { get; set; }
        public string Period { get; set; }
    }
}