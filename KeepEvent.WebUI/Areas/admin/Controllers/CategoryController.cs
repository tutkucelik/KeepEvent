﻿using System;
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


namespace KeepEvent.WebUI.Areas.admin.Controllers
{
    //[Authorize(Roles = "admin")]
    public class CategoryController : Controller
    {
        Repository<Category> repoCategory = new Repository<Category>();

        public ActionResult Index()
        {
            return View(repoCategory.GetAll());
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = repoCategory.GetBy(g => g.ID == id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }
        public ActionResult Create()
        {
            ViewBag.Kategoriler = repoCategory.GetAll().Where(w => w.ParentID == null);
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create(Category category, HttpPostedFileBase Icon)
        {
            if (ModelState.IsValid)
            {
                if (Icon != null)
                {
                    if (!Directory.Exists(Server.MapPath("/Content/img/cat"))) Directory.CreateDirectory(Server.MapPath("/Content/img/cat"));
                    Icon.SaveAs(Server.MapPath("/Content/img/cat/" + Icon.FileName));
                    category.Icon = "/Content/img/cat/" + Icon.FileName;
                }
                repoCategory.Add(category);
                return RedirectToAction("Index");
            }

            return View(category);
        }

        // GET: admin/Category/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.Kategoriler = repoCategory.GetAll().Where(w => w.ParentID == null);
            Category category = repoCategory.GetBy(g => g.ID == id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: admin/Category/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category category, HttpPostedFileBase Icon)
        {
            if (ModelState.IsValid)
            {
                if (Icon != null)
                {
                    if (!Directory.Exists(Server.MapPath("/Content/img/cat"))) Directory.CreateDirectory(Server.MapPath("/Content/img/cat"));
                    Icon.SaveAs(Server.MapPath("/Content/img/cat/" + Icon.FileName));
                    category.Icon = "/Content/img/cat/" + Icon.FileName;
                }
                repoCategory.Update(category);
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET: admin/Category/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = repoCategory.GetBy(g => g.ID == id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: admin/Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category category = repoCategory.GetBy(g => g.ID == id);
            repoCategory.Remove(category);
            return RedirectToAction("Index");
        }
    }
}