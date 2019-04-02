using KeepEvent.BLL.Repositories;
using KeepEvent.BOL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KeepEvent.WebUI.Controllers
{
    public class ContactController : Controller
    {
        Repository<Contact> repoContact = new Repository<Contact>();
        // GET: Contact
        public ActionResult Index()
        {
            return View(repoContact.GetAll().ToList());
        }

        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Contact(Contact model)
        {
            model.PostDate = DateTime.Now;
            repoContact.Add(model);
            return View();
        }
        public ActionResult Gonder(Contact model)
        {
            model.PostDate = DateTime.Now;
            repoContact.Add(model);
            //Mail Gönderme işlemleri
            TempData["Gönderildi"] = "Mesajınız Başarıyla Gönderildi";
            return RedirectToAction("Contact");
        }
    }
}