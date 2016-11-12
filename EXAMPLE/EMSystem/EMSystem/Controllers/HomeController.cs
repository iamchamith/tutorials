using EMSystem.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EMSystem.Helpers;
using AutoMapper;
using EMSystem.Models;
using EMSystem.Core.Domain;

namespace EMSystem.Controllers
{
    public class HomeController : BaseController
    {
        IEmployeeService _service;
        IMapper _mapper;
        public HomeController(IEmployeeService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Add()
        {
            var employee = new EmployeeEditViewModel { DateOfJoin = DateTime.Now, DateOfBirth= DateTime.Now};
            return View(employee);
        }

        public ActionResult Detail(int empId)
        {
            var c = _service.GetById(empId);
            var employee = _mapper.Map<EmployeeViewModel>(c);
            return View(employee);
        }

        [HttpGet]
        public ActionResult Edit(int empId)
        {
            var c = _service.GetById(empId);
            var employee = _mapper.Map<EmployeeEditViewModel>(c);
            return View(employee);
        }

        [HttpPost]
        public ActionResult Edit(EmployeeEditViewModel employee)
        {
            var dto = _mapper.Map<Employee>(employee);

            _service.Update(dto);
            return RedirectToAction("Detail", new { empId = dto.Id });
        }

        [HttpPost]
        public ActionResult Save(EmployeeEditViewModel employee)
        {
            var dto = _mapper.Map<Employee>(employee);
            _service.Save(dto);
            return RedirectToAction("Index");
        }


        [HttpPost]
        public ActionResult Delete(EmployeeViewModel employee)
        {
            var dto = _mapper.Map<Employee>(employee);
            _service.Delete(dto);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [AjaxOnly]
        public JsonResult DeleteAjax(EmployeeViewModel employee)
        {
            var dto = _mapper.Map<Employee>(employee);
            _service.Delete(dto);
            return Json(new { status = 1 });
        }

        [HttpGet]
        [AjaxOnly]
        public JsonResult GetEmployees()
        {
            var employees = _service.All()?.Select(employee => _mapper.Map<EmployeeViewModel>(employee));
            return Json(new { employees = employees }, JsonRequestBehavior.AllowGet);

        }


    }
}