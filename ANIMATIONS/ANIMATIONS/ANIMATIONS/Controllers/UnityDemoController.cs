using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ANIMATIONS.Service;
namespace ANIMATIONS.Controllers
{
    public class UnityDemoController : Controller
    {

        // without di

        //ILocalWettherServiceProvider _wether;

        //public UnityDemoController()
        //{

        //    _wether = new LocalWettherServiceProvider();
        //}

        /*
         UnityDemo controller depend on the ILocationWettherServerProvider to full fill there task.
         ILocationWettherServiceProvider depend on the LocationServiceProvider by using new Keyword.
         there for cuppling between "unityDemo" and LocationWetther service is hight.
         there for new Keyword call like glue.
         out side users do not know what methods/dependency use UnityDemoController.
             */

        //public ActionResult Index2()
        //{

        //    _wether.GetTemprage("Ganemulla");
        //    return View();
        //}

        // with di

        // call to outside 
        //"hay i am depend on ther ILocationServiceProvider only"
        ILocalWettherServiceProvider _wether;
        public UnityDemoController(ILocalWettherServiceProvider wetther)
        {

            this._wether = wetther;
        }

        public ActionResult Index()
        {
            string result = this._wether.GetTemprage("ganemulla");
            return View();
        }
    }
}