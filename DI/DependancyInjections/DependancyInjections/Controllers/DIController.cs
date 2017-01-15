using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Practices.Unity;
namespace DependancyInjections.Controllers
{
    // ui
    public class DIController : ApiController
    {

        /*
         -> techniq that helps to inject dependant objects to the class.
         -> why di
            -> reduce tide cupling. and be a losely cuple archi.
            -> core of decuppling in two layers are interface.
         */

        private ICustomer cus;
        public DIController(ICustomer _cus) {
            cus = _cus;
        }
        /// <summary>
        /// Add Customer
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public string Add()
        {
            cus.Add();
            return "added";
        }
    }

    // bl

    public interface ICustomer {

        void Add();
    }

    public class Customer:ICustomer
    {
        public string CustomerName { get; set; }

        private IDal obj;
        public Customer(IDal iobj)
        {
            obj = iobj;
        }
        public void Add()
        {
            obj.Add();

        }
    }

    // dal

    public interface IDal
    {
        void Add();
    }

    public class SqlDal : IDal
    {

        public void Add()
        {

            Console.WriteLine("recode inserted to sql server");
        }
    }

    public class OracleDal : IDal
    {

        public void Add()
        {

            Console.WriteLine("recode inserted to oracle server");
        }

    }
}
