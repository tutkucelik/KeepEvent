using KeepEvent.BLL.Repositories;
using KeepEvent.BOL.Entities;
using KeepEvent.DAL.Contexts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace KeepEvent.WebUI.Controllers
{
    public class ContactController : Controller
    {
        Repository<Contact> repoContact = new Repository<Contact>();
        // GET: Contact
        SqlDbContext db = new SqlDbContext();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Contact modelim, HttpPostedFileBase Dosya)
        {


            modelim.PostDate = DateTime.Now;

            repoContact.Add(modelim);
            MailGonder(modelim);

            return View();
        }
        void MailGonder(Contact model)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("denemeexploreworld@gmail.com");
                mail.To.Add(new MailAddress("denemeexploreworld@gmail.com"));
                mail.Subject = model.Subject;
                //sb.Append("<br/>Mesajınızı Aldık. En Kısa Sürede Size Dönüş Yapacağız. <br/>");
                sb.Append("Aşağıda bilgileri bulunan bir ziyaretçinizden mesaj aldınız.<br/>");
                sb.Append("Adı Soyadı: " + model.Name + "<br/>");
                sb.Append("Mail Adresi: " + model.Email + "<br/>");
                sb.Append("Mesajı: " + model.Message);
                mail.Body = sb.ToString();
                mail.IsBodyHtml = true;
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                //SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                smtpClient.EnableSsl = true; //GMAIL için
                smtpClient.Credentials = new NetworkCredential("denemeexploreworld@gmail.com", "Test123456-");
                smtpClient.Send(mail);
            }
            catch (Exception ex)
            {
                //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "key_mailGonderilemedi", "<script>alert('Mesajınız mail olarak gönderilemedi, Hata:" + ex.Message + "')</script>", false);
            }
        }
    }
}
    