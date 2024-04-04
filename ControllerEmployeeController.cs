using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Coding_CRUD.Models;
using MVC_Coding_CRUD.SQL_Database;

namespace MVC_Coding_CRUD.Controllers
{
    public class ControllerEmployeeController : Controller
    {
        SqlData _obj = new SqlData();
        // GET: ControllerEmployee
        public ActionResult Index()  //list view
        {
            return View(_obj.GetAll());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(EmployeeClass emp)
        {
            if(ModelState.IsValid)
            {
                _obj.EmpInsert(emp);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            return View(_obj.GetAll().Find(m => m.Id == Id)); 
        }

        [HttpPost]
        public ActionResult Edit(EmployeeClass ob)
        {
             //= new EmployeeClass();
            _obj.EmpUpdate(ob);
            //return View(obj);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(int Id)
        {
            return View(_obj.GetAll().Find(m => m.Id == Id));
        }

        [HttpGet]
        public ActionResult Delete(int Id)
        {
            return View(_obj.GetAll().Find(m => m.Id == Id));
        }

        [HttpPost]
        public ActionResult Delete(int Id,EmployeeClass es)
        {
            _obj.EmpDelete(Id);
            return RedirectToAction("Index");

        }
    }
}