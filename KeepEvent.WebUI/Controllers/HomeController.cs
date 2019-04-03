using KeepEvent.BLL.Repositories;
using KeepEvent.BOL.Entities;
using KeepEvent.DAL.Contexts;
using KeepEvent.WebUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace KeepEvent.WebUI.Controllers
{
    public class HomeController : Controller
    {
        SqlDbContext db = new SqlDbContext();

        Repository<Admin> repoAdmin = new Repository<Admin>();
        Repository<Slider> repoSlider = new Repository<Slider>();
        Repository<Category> repoCategory = new Repository<Category>();
        Repository<City> repoCity = new Repository<City>();
        Repository<Header> repoHeader = new Repository<Header>();
        Repository<PlaceEvent> repoPlaceEvent = new Repository<PlaceEvent>();
        Repository<Event> repoEvent = new Repository<Event>();
        Repository<Place> repoPlace = new Repository<Place>();
        Repository<TContent> repoTContent = new Repository<TContent>();
       

        public ActionResult Index()
        {
            //ViewBag.Category = new SelectList(db.Category.ToList(), "ID", "Name");
            ViewBag.Category = new SelectList(repoCategory.GetAll().Where(w => w.ParentID == null), "ID", "Name");

            CategoryCityVM categorycityVM = new CategoryCityVM
            {
                Categories = repoCategory.GetAll().Take(5).ToList(),
                Cities = repoCity.GetAll().ToList(),
                Headers = repoHeader.GetAll().ToList(),

                PlaceEvents = repoPlaceEvent.GetAll().Include(i => i.Event).Include(i => i.Place).Include(i => i.Event.Category).ToList(),
                TContents = repoTContent.GetAll().ToList(),
            };
            return View(categorycityVM);
            //return View(repoSlider.GetAll().OrderBy(o => o.PIndex));
        }
        public ActionResult Login(string ReturnUrl)
        {
            if (User.Identity.IsAuthenticated) FormsAuthentication.SignOut();
            ViewBag.rtn = ReturnUrl;
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Login(string kullaniciAdi, string pass, string rURL)
        {
            if (!string.IsNullOrEmpty(kullaniciAdi) && !string.IsNullOrEmpty(pass))
            {
                Admin admin = repoAdmin.GetBy(a => a.KullaniciAdi == kullaniciAdi && a.Sifre == pass);
                if (admin != null)
                {
                    FormsAuthentication.SetAuthCookie(kullaniciAdi, true);
                    Session["AdSoyad"] = admin.AdSoyad;
                    if (!string.IsNullOrEmpty(rURL)) return Redirect(rURL);
                    else return Redirect("/admin");
                }
                else
                {
                    ViewBag.Hata = "Kullanıcı Adı veya Şifre Hatalı";
                }
            }
            else ViewBag.Hata = "Kullanıcı Adı ve Şifre Gerekli";
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Explore()
        {
            return View();
        }
        public ActionResult Listing()
        {
            return View();
        }
        public ActionResult SingleListing()
        {
            return View();
        }
        public ActionResult EventDetails(int? EventID)
        {
            CategoryCityVM categorycityVM = new CategoryCityVM
            {
                PlaceEvents = repoPlaceEvent.GetAll().Include(i => i.Event).Where(f => f.EventID == EventID).Include(i => i.Place).Include(i => i.Event.Category).ToList(),
            };
            return View(categorycityVM);
        }
   
    }
}