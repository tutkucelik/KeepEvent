using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KeepEvent.BLL.Repositories;
using KeepEvent.BOL.Entities;
using KeepEvent.DAL.Contexts;

namespace KeepEvent.WebUI.Areas.admin.Controllers
{
    public class HeaderController : Controller
    {
        Repository<Header> repoHeader = new Repository<Header>();

        // GET: admin/Header
        public ActionResult Index()
        {
            return View(repoHeader.GetAll());
        }

        // GET: admin/Header/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Header header = repoHeader.GetBy(g => g.ID == id);
            if (header == null)
            {
                return HttpNotFound();
            }
            return View(header);
        }

        // GET: admin/Header/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Header header, HttpPostedFileBase Picture, HttpPostedFileBase Logo)
        {
            if (ModelState.IsValid)
            {
                if (Picture != null || Logo!=null)
                {
                    if (!Directory.Exists(Server.MapPath("~/Content/img/header"))) Directory.CreateDirectory(Server.MapPath("~/Content/img/header"));
                    Picture.SaveAs(Server.MapPath("~/Content/img/header/" + Picture.FileName));
                    header.Picture = "/Content/img/header/" + Picture.FileName;
                    Logo.SaveAs(Server.MapPath("~/Content/img/header/" + Logo.FileName));
                    header.Logo = "/Content/img/header/" + Logo.FileName;
                    header.UpdateDate = DateTime.Now;
                }
                repoHeader.Add(header);
                return RedirectToAction("Index");
            }

            return View(header);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Header header = repoHeader.GetBy(g => g.ID == id);
            if (header == null)
            {
                header.UpdateDate = DateTime.Now;
                return HttpNotFound();
            }
            return View(header);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Logo,Picture,Title,SubTitle,UpdateDate")] Header header)
        {
            if (ModelState.IsValid)
            {
                header.UpdateDate = DateTime.Now;
                repoHeader.Update(header);
                return RedirectToAction("Index");
            }
            return View(header);
        }

        // GET: admin/Header/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Header header = repoHeader.GetBy(g => g.ID == id);
            if (header == null)
            {
                return HttpNotFound();
            }
            return View(header);
        }

        // POST: admin/Header/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Header header = repoHeader.GetBy(g => g.ID == id);
            repoHeader.Remove(header);
            return RedirectToAction("Index");
        }

      
    }
}
