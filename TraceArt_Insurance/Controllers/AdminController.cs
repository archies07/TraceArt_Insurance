using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TraceArt_Insurance.Models;

namespace TraceArt_Insurance.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            InsuranceDBContext dbContext = new InsuranceDBContext();
            List<Bikeinsurance> obj = dbContext.GetBikeinsurances();
           
            return View(obj);
        }
        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create(Bikeinsurance bikeinsurance)
        {
            try
            {
                if (ModelState.IsValid == true)
                {
                    InsuranceDBContext context = new InsuranceDBContext();
                    bool check = context.Insert(bikeinsurance);
                    if (check == true)
                    {
                        TempData["InsertMessage"] = "Data Saved !!!";
                        ModelState.Clear();
                        return RedirectToAction("Index");
                    }
                }
                return View();
            }
            catch 
            {
                return View();

            }
            
        }
        public ActionResult Edit(int PolicyNo)
        {
            InsuranceDBContext context = new InsuranceDBContext();
            var row = context.GetBikeinsurances().Find(model => model.PolicyNo == PolicyNo);
            return View(row);
        }

        [HttpPost]
        public ActionResult Edit(int PolicyNo,Bikeinsurance bikeinsurance)
        {

            if (ModelState.IsValid == true)
            {
                InsuranceDBContext context = new InsuranceDBContext();
                var row = context.GetBikeinsurances().Find(model => model.PolicyNo == PolicyNo);
                bool check = context.Update(bikeinsurance);
                if (check == true)
                {
                    TempData["UpdateMessage"] = "Data Updated !!!";
                    ModelState.Clear();
                    return RedirectToAction("Index");
                }
            }
            return View();
        }
        public ActionResult Details(int PolicyNo)
        {
            InsuranceDBContext context = new InsuranceDBContext();
            var row = context.GetBikeinsurances().Find(model => model.PolicyNo == PolicyNo);
            return View(row);
        }
        public ActionResult Delete(int PolicyNo)
        {
            InsuranceDBContext context = new InsuranceDBContext();
            var row = context.GetBikeinsurances().Find(model => model.PolicyNo == PolicyNo);
            return View(row);
        }
        [HttpPost]
        public ActionResult Delete(int PolicyNo,Bikeinsurance bikeinsurance)
        {
            InsuranceDBContext context = new InsuranceDBContext();
            bool check = context.Delete(PolicyNo);
            if (check == true)
            {
                TempData["DeleteMessage"] = "Data Updated !!!";
                return RedirectToAction("Index");
            }
            return View();
        }
            
    }
}
