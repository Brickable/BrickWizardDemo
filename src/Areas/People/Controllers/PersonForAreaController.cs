using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WizardDemo.Areas.People.Models;
using WizardDemo.Models;

namespace WizardDemo.Areas.People.Controllers
{
    public class PersonForAreaController : Controller
    {
        public PersonForAreaWizard SessionPersonWizard
        {
            get
            {
                if ((PersonForAreaWizard)Session["SessionPersonForAreaWizard"] == null)
                    Session["SessionPersonForAreaWizard"] =
                        new PersonForAreaWizard("PersonForArea", "People", new string[] { PersonForAreaWizardSteps.Family });
                return (PersonForAreaWizard)Session["SessionPersonForAreaWizard"];
            }
            set
            {
                Session["SessionPersonForAreaWizard"] = value;
            }
        }
        public void DestroySessionPersonWizard()
        {
            Session.Remove("SessionPersonForAreaWizard");
        }


        public ActionResult PersonWizard()
        {
            DestroySessionPersonWizard();
            return View(SessionPersonWizard.CurrentStep.ViewName, SessionPersonWizard.Model);
        }
        [HttpPost]
        public ActionResult PostName(PersonViewModel model)
        {
            SessionPersonWizard.TryCommitAndSync(PersonForAreaWizardSteps.Name, model.PersonName);
            return PartialView(SessionPersonWizard.CurrentStep.ViewName, SessionPersonWizard.Model);
        }
        [HttpPost]
        public ActionResult PostAge(PersonViewModel model)
        {
            SessionPersonWizard.TryCommitAndSync(PersonForAreaWizardSteps.Age, model.PersonBirthday);
            return PartialView(SessionPersonWizard.CurrentStep.ViewName, SessionPersonWizard.Model);
        }
        [HttpPost]
        public ActionResult PostWorkTitle(PersonViewModel model)
        {
            SessionPersonWizard.TryCommitAndSync(PersonForAreaWizardSteps.WorkTitle, model.PersonWorkInfo);
            return PartialView(SessionPersonWizard.CurrentStep.ViewName, SessionPersonWizard.Model);
        }
        [HttpPost]
        public ActionResult PostFamily(PersonViewModel model)
        {
            SessionPersonWizard.TryCommitAndSync(PersonForAreaWizardSteps.Family, model.PersonFamily);
            return PartialView(SessionPersonWizard.CurrentStep.ViewName, SessionPersonWizard.Model);
        }
        [HttpPost]
        public ActionResult PostAcceptTerms(PersonViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return PartialView(SessionPersonWizard.CurrentStep.ViewName, SessionPersonWizard.Model);
            }
            SessionPersonWizard.TryCommitAndSync(PersonForAreaWizardSteps.AcceptTerms, model.PersonAcceptTerms);
            SessionPersonWizard.ClearUnusedSteps();
            var m = new PersonResult { ViewModel = SessionPersonWizard.Model };
            return PartialView("_PersonResult", m);
        }
        [HttpPost]
        public ActionResult PostStudentAssert(PersonViewModel model)
        {
            SessionPersonWizard.TryCommitAndSync(PersonForAreaWizardSteps.StudentAssert, model.PersonIsStudent);
            return PartialView(SessionPersonWizard.CurrentStep.ViewName, SessionPersonWizard.Model);
        }
        [HttpPost]
        public ActionResult PostStudentData(PersonViewModel model)
        {
            SessionPersonWizard.TryCommitAndSync(PersonForAreaWizardSteps.StudentData, model.PersonStudentInfo);
            return View(SessionPersonWizard.CurrentStep.ViewName, SessionPersonWizard.Model);
        }
    }
}