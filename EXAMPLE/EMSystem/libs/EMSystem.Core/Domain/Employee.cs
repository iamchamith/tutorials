using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMSystem.Core.Domain
{
    [Table("Employee")]
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfJoin { get; set; }
        public string Position { get; set; }
        public string Division { get; set; }
        public string Office { get; set; }
        public decimal Salary { get; set; }
    }

   
}
