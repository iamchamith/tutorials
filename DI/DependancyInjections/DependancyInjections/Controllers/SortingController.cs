using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Linq.Expressions;
namespace DependancyInjections.Controllers
{
    public class SortingController : ApiController
    {

        public List<UserInfo> GetUser(string sort) {

            var x = new string[10];

            x[0] = "chamith";
            x[0] = "chamith";
            x[0] = "chamith";
            x[0] = "chamith";
            x[0] = "chamith";




            // return UserInfo.List().ToList().Sort(new [] { "name", "age"}).ToList();
            return null; 
        }
    }

    public class UserInfo
    {
        public string name { get; set; }
        public int age { get; set; }

        static Random rd = new Random();
        public static IEnumerable<UserInfo> List()
        {
            var x = new List<UserInfo>();
            for (int i = 0; i < 100; i++)
            {
                x.Add(new UserInfo
                {
                    age = rd.Next(1, 100),
                    name = "Chamith " + rd.Next(1, 100)
                });
            }
            return x;
        }
    }
}
