using BrickWizard;
using System.Web.Mvc;
using WizardDemo.Models;

namespace WizardDemo.Controllers
{
    public class PersonController : Controller
    {
        public PersonWizard SessionPersonWizard
        {
            get
            {
                if ((PersonWizard)Session["SessionPersonWizard"] == null)
                    Session["SessionPersonWizard"] = new PersonWizard();
                return (PersonWizard)Session["SessionPersonWizard"];
            }
            set
            {
                Session["SessionPersonWizard"] = value;
            }
        }
        private void DestroySessionPersonWizard()
        {
            Session.Remove("SessionPersonWizard");
        }

        public ActionResult PersonWizard()
        {
            ViewBag.PATHLOG = $"{SessionPersonWizard.CurrentRoute.RouteId} - {SessionPersonWizard.CurrentStep.StepNumber}";
            return View(SessionPersonWizard.CurrentStep.ViewName, SessionPersonWizard.Model);
        }
        [HttpPost]
        public ActionResult PostName(PersonViewModel model)
        {
            SessionPersonWizard.Sync(model.PersonName);
            ViewBag.PATHLOG = $"{SessionPersonWizard.CurrentRoute.RouteId} - {SessionPersonWizard.CurrentStep.StepNumber}";
            return PartialView(SessionPersonWizard.CurrentStep.ViewName, SessionPersonWizard.Model);
        }
        [HttpPost]
        public ActionResult PostAge(PersonViewModel model)
        {
            SessionPersonWizard.Sync(model.PersonBirthday);
            ViewBag.PATHLOG = $"{SessionPersonWizard.CurrentRoute.RouteId} - {SessionPersonWizard.CurrentStep.StepNumber}";
            return PartialView(SessionPersonWizard.CurrentStep.ViewName, SessionPersonWizard.Model);
        }
        [HttpPost]
        public ActionResult PostWorkTitle(PersonViewModel model)
        {
            SessionPersonWizard.Sync(model.PersonWorkInfo);
            ViewBag.PATHLOG = $"{SessionPersonWizard.CurrentRoute.RouteId} - {SessionPersonWizard.CurrentStep.StepNumber}";
            return PartialView(SessionPersonWizard.CurrentStep.ViewName, SessionPersonWizard.Model);
        }
        [HttpPost]
        public ActionResult PostFamily(PersonViewModel model)
        {
            SessionPersonWizard.Sync(model.PersonFamily);
            ViewBag.PATHLOG = $"{SessionPersonWizard.CurrentRoute.RouteId} - {SessionPersonWizard.CurrentStep.StepNumber}";
            return PartialView(SessionPersonWizard.CurrentStep.ViewName, SessionPersonWizard.Model);
        }
        [HttpPost]
        public ActionResult PostAcceptTerms(PersonViewModel model)
        {
            SessionPersonWizard.Sync(model.PersonAcceptTerms);
            ViewBag.PATHLOG = $"{SessionPersonWizard.CurrentRoute.RouteId} - {SessionPersonWizard.CurrentStep.StepNumber}";
            return PartialView(SessionPersonWizard.CurrentStep.ViewName, SessionPersonWizard.Model);
        }
        [HttpPost]
        public ActionResult PostStudentAssert(PersonViewModel model)
        {
            SessionPersonWizard.Sync(model.PersonIsStudent);
            ViewBag.PATHLOG = $"{SessionPersonWizard.CurrentRoute.RouteId} - {SessionPersonWizard.CurrentStep.StepNumber}";
            return PartialView(SessionPersonWizard.CurrentStep.ViewName, SessionPersonWizard.Model);
        }
        [HttpPost]
        public ActionResult PostStudentData(PersonViewModel model)
        {
            SessionPersonWizard.Sync(model.PersonStudentInfo);
            ViewBag.PATHLOG = $"{SessionPersonWizard.CurrentRoute.RouteId} - {SessionPersonWizard.CurrentStep.StepNumber}";
            return View(SessionPersonWizard.CurrentStep.ViewName, SessionPersonWizard.Model);
        }
    }
}