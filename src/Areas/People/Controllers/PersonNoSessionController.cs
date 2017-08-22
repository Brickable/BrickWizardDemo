using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using WizardDemo.Models;

namespace WizardDemo.Areas.People.Controllers
{
    public class PersonNoSessionController : Controller
    {
        // GET: People/PersonNoSession
        public ActionResult Index()
        {
            return View();
          
        }
    }
}