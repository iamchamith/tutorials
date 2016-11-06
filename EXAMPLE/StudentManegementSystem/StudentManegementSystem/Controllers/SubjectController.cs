using AutoMapper;
using EF.Domain;
using StudentManegementSystem.Models;
using StudentManegementSystem.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace StudentManegementSystem.Controllers
{
    public class SubjectController : BaseController
    {
        // GET api/Subject/SubjectRead
        [CompressContent]
        [HttpGet]
        public ActionResult SubjectRead()
        {
            try
            {
                return ActionResultProcess.Success(subjectService.Read().Select(x => AutoMapper.Mapper.Map<SubjectViewModel>(x)).ToList());
            }
            catch (Exception ex)
            {
                return ActionResultProcess.Error(ex);
            }
        }
        // GET api/Subject/SubjectRead
        [CompressContent]
        [HttpGet]
        public ActionResult SubjectReadSingle(int id)
        {
            try
            {
                var result = new SubjectViewViewModel()
                {
                    subjectVieModel = Mapper.Map<SubjectViewModel>(subjectService.Read(id)),
                    subjectModuleList = subjectModuleServivice.Read(id)
                };

                return ActionResultProcess.Success(result);
            }
            catch (Exception ex)
            {
                return ActionResultProcess.Error(ex);
            }
        }

        // POST api/Subject/SubjectCreate
        [HttpPost]
        public ActionResult SubjectCreate(SubjectViewViewModel item)
        {
            var dto = HttpContext.Current.Request.Form["item"];
            try
            {
                Subject s = subjectService.Create(Mapper.Map<Subject>(item.subjectVieModel));
                List<string> subjectModuleNames = item.subjectModuleList;
                var subjectModuleList = new List<SubjectModules>();
                foreach (var val in subjectModuleNames)
                {
                    subjectModuleList.Add(new SubjectModules { ModuleName = val, SubjectId = item.subjectVieModel.SubjectId });
                } 
                subjectModuleServivice.Create(subjectModuleList);
                return ActionResultProcess.Success();
            }
            catch (Exception ex)
            {
                return ActionResultProcess.Error(ex);
            }
        }
        // POST api/Subject/SubjectCreate
        [HttpPost]
        public ActionResult StudentUpdate(SubjectViewViewModel item)
        {
            try
            {
                subjectService.Update(Mapper.Map<Subject>(item.subjectVieModel), item.subjectVieModel.SubjectId);
                List<string> subjectModuleNames = item.subjectModuleList;
                var subjectModuleList = new List<SubjectModules>();
                foreach (var val in subjectModuleNames)
                {
                    subjectModuleList.Add(new SubjectModules { ModuleName = val, SubjectId = item.subjectVieModel.SubjectId });
                }
                subjectModuleServivice.Update(subjectModuleList, item.subjectVieModel.SubjectId);
                return ActionResultProcess.Success();
            }
            catch (Exception ex)
            {
                return ActionResultProcess.Error(ex);
            }
        }
        // POST api/Subject/StudentDelete
        [HttpPost]
        public ActionResult SubjectDelete(int id)
        {
            try
            {
                subjectService.Delete(id);
                subjectModuleServivice.Delete(id);
                return ActionResultProcess.Success();
            }
            catch (Exception ex)
            {
                return ActionResultProcess.Error(ex);
            }
        }
       

    }
}
