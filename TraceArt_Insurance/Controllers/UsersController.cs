using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TraceArt_Insurance.Models;

namespace TraceArt_Insurance.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult Index()
        {
            InsuranceDBContext dbContext = new InsuranceDBContext();
            List<Bikeinsurance> obj = dbContext.GetBikeinsurances();
            return View();
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
                    UserDBContext context = new UserDBContext();
                   // InsuranceDBContext context = new InsuranceDBContext();
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
    }
}