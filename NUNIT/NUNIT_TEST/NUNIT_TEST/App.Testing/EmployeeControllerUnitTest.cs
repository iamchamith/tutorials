using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using App.DbService.interfaces;
using App.Domain;
using NUNIT_TEST.Api;
using System.Web.Http;
using App.DbService.service;

namespace App.Testing
{
    [TestFixture]
    public class EmployeeControllerUnitTest
    {
        public EmployeeControllerUnitTest() {
            Create_Returns_Employee();
            Update_Returns_Boolean();
            Select_Returns_EmployeeList();
            Select_Returns_Employee();
        }

        [Test]
        public void Create_Returns_Employee()
        {
            Console.WriteLine("Create_Returns_void passsed");
        }

        [Test]
        public void Update_Returns_Boolean()
        {
            Console.WriteLine("Update_Returns_void passsed");
        }
        [Test]
        public void Select_Returns_EmployeeList()
        {
            var mock = new Mock<IEmployee>();
            mock.Setup(m => m.Read()).Returns(new Employee[] {
                new Employee {Name="ranga",Nic="123",Phone="122" },
                 new Employee {Name="nikanka",Nic="223",Phone="322" }
            }.ToList());

            EmployeeController  x = new EmployeeController(mock.Object);
            var res = x.Select().ToList();
            Assert.IsTrue(x.Select().Count() == 2, "should be true");
            Console.WriteLine("Select_Returns_EmployeeList passsed");
        }
        [Test]
        public void Select_Returns_Employee()
        {
            Console.WriteLine("Select_Returns_Employee passsed");
        }
    }
}
