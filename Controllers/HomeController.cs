using System;
using System.Web.Mvc;
using PersonalSiteMVC.Models;
using System.Net;
using System.Net.Mail;

namespace PersonalSiteMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(ContactViewModel cvm)
        {
            if (!ModelState.IsValid)
            {
                return View(cvm);
            }

            string message = $"You received a message from: {cvm.Name}<br/>Subject: {cvm.Subject}<br/>Respond to: {cvm.Email}<br/>Message:<br/> {cvm.Message}";

            MailMessage mailMessage = new MailMessage("admin@ryaneutsler.com", "ryan.eutsler@outlook.com", cvm.Subject, message);

            mailMessage.IsBodyHtml = true;

            mailMessage.Priority = MailPriority.High;

            mailMessage.ReplyToList.Add(cvm.Email);

            SmtpClient client = new SmtpClient("mail.ryaneutsler.com");

            client.Credentials = new NetworkCredential("admin@ryaneutsler.com", "Yearoftheknife219!!");

            client.Port = 8889;

            try
            {
                client.Send(mailMessage);
            }
            catch (Exception excpt)
            {
                ViewBag.CustomerMessage = $"We're sorry your request could not be completed at this time. Please try again later.<br/>Error Message:<br/>{excpt.StackTrace}";
                return View(cvm);
            }

            return View("EmailConfirmation", cvm);
        }

        public ActionResult Resume()
        {
            return View();
        }

        public ActionResult Links()
        {
            return View();
        }

        public ActionResult Projects()
        {
            return View();
        }

    }
}