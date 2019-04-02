using KeepEvent.DAL.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KeepEvent.WebUI.Controllers
{
    public class AJAXController : Controller
    {
        SqlDbContext db = new SqlDbContext();
        // GET: AJAX
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Cities()
        {
            return Json(db.City.Select(s => new { s.ID, s.Name }), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Categories()
        {
            return Json(db.Category.Where(w=>w.ParentID == null), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Categoriess(int cID)
        {

            return Json(db.Category.Where(w => w.ParentID == cID).Select(s=>new { s.ID,s.Name}), JsonRequestBehavior.AllowGet);

            //return Json(db.Category.Select(s => new { s.ID, s.Name }), JsonRequestBehavior.AllowGet);
        }


        //public ActionResult SubCategories(int categoryID)
        //{
        //    return Json(db.SubCategory.Where(w => w.CategoryID == categoryID), JsonRequestBehavior.AllowGet);
        //}

    }
}