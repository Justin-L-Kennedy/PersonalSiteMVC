﻿using System;
using System.Web.Mvc;
using PersonalSiteMVC.UI.MVC.Models;
using System.Net.Mail;
using System.Net;

namespace PersonalSiteMVC.UI.MVC.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult About()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Resume()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Projects()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CurtainCall_Details()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Links()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact(ContactViewModel cvm)
        {
            if (!ModelState.IsValid)
            {
                return View(cvm);
            }

            string emailBody = $"You have received an email from {cvm.Name} with a subject {cvm.Subject}. Please respond to {cvm.Email} with your response to the following message: <br /> <br />{cvm.Message}";
            MailMessage msg = new MailMessage(
                "no-reply@justinlkennedy.com",
                "justin.l.kennedy@outlook.com",
                "Email from JustinLKennedy.com",
                emailBody);
            msg.IsBodyHtml = true;
            msg.Priority = MailPriority.High;
            SmtpClient client = new SmtpClient("mail.justinlkennedy.com");
            client.Credentials = new NetworkCredential("no-reply@justinlkennedy.com", "C3ntr!q");
            try
            {
                client.Send(msg);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = $"Sorry, something went wrong. Error message: {ex.Message}<br />{ex.StackTrace}";
                return View(cvm);
            }
            return View("EmailConfirmation", cvm);
        }
    }
}
