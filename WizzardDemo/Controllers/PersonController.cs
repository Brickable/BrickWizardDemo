using BrickWizard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WizardDemo.Models;

namespace WizardDemo.Controllers
{
    public class PersonController : Controller
    {
        public Wizard<PersonViewModel> SessionPersonWizard
        {
            get
            {
                if ((Wizard<PersonViewModel>)Session["SessionPersonWizard"] == null)
                    Session["SessionPersonWizard"] = new Wizard<PersonViewModel>(new PersonWorkflow());
                return (Wizard<PersonViewModel>)Session["SessionPersonWizard"];
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
            ViewBag.PATHLOG = $"{SessionPersonWizard.WF.CurrentRoute.RouteId} - {SessionPersonWizard.WF.CurrentStep.StepNumber}";
            return View(SessionPersonWizard.WF.CurrentStep.ViewName, SessionPersonWizard.WF.Model);
        }
        [HttpPost]
        public ActionResult PostName(PersonViewModel model)
        {
            SessionPersonWizard.Sync(model.PersonName);
            ViewBag.PATHLOG = $"{SessionPersonWizard.WF.CurrentRoute.RouteId} - {SessionPersonWizard.WF.CurrentStep.StepNumber}";
            return PartialView(SessionPersonWizard.WF.CurrentStep.ViewName, SessionPersonWizard.WF.Model);
        }
        [HttpPost]
        public ActionResult PostAge(PersonViewModel model)
        {
            SessionPersonWizard.Sync(model.PersonBirthday);
            ViewBag.PATHLOG = $"{SessionPersonWizard.WF.CurrentRoute.RouteId} - {SessionPersonWizard.WF.CurrentStep.StepNumber}";
            return PartialView(SessionPersonWizard.WF.CurrentStep.ViewName, SessionPersonWizard.WF.Model);
        }
        [HttpPost]
        public ActionResult PostWorkTitle(PersonViewModel model)
        {
            SessionPersonWizard.Sync(model.PersonWorkInfo);
            ViewBag.PATHLOG = $"{SessionPersonWizard.WF.CurrentRoute.RouteId} - {SessionPersonWizard.WF.CurrentStep.StepNumber}";
            return PartialView(SessionPersonWizard.WF.CurrentStep.ViewName, SessionPersonWizard.WF.Model);
        }
        [HttpPost]
        public ActionResult PostFamily(PersonViewModel model)
        {
            SessionPersonWizard.Sync(model.PersonFamily);
            ViewBag.PATHLOG = $"{SessionPersonWizard.WF.CurrentRoute.RouteId} - {SessionPersonWizard.WF.CurrentStep.StepNumber}";
            return PartialView(SessionPersonWizard.WF.CurrentStep.ViewName, SessionPersonWizard.WF.Model);
        }
        [HttpPost]
        public ActionResult PostAcceptTerms(PersonViewModel model)
        {
            SessionPersonWizard.Sync(model.PersonAcceptTerms);
            ViewBag.PATHLOG = $"{SessionPersonWizard.WF.CurrentRoute.RouteId} - {SessionPersonWizard.WF.CurrentStep.StepNumber}";
            return PartialView(SessionPersonWizard.WF.CurrentStep.ViewName, SessionPersonWizard.WF.Model);
        }
        [HttpPost]
        public ActionResult PostStudentAssert(PersonViewModel model)
        {
            SessionPersonWizard.Sync(model.PersonIsStudent);
            ViewBag.PATHLOG = $"{SessionPersonWizard.WF.CurrentRoute.RouteId} - {SessionPersonWizard.WF.CurrentStep.StepNumber}";
            return PartialView(SessionPersonWizard.WF.CurrentStep.ViewName, SessionPersonWizard.WF.Model);
        }
        [HttpPost]
        public ActionResult PostStudentData(PersonViewModel model)
        {
            SessionPersonWizard.Sync(model.PersonStudentInfo);
            ViewBag.PATHLOG = $"{SessionPersonWizard.WF.CurrentRoute.RouteId} - {SessionPersonWizard.WF.CurrentStep.StepNumber}";
            return View(SessionPersonWizard.WF.CurrentStep.ViewName, SessionPersonWizard.WF.Model);
        }
    }
}