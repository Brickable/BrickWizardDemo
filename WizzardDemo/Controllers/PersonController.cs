using BrickWizard;
using System.Linq;
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
                    Session["SessionPersonWizard"] = new PersonWizard("Person");
                return (PersonWizard)Session["SessionPersonWizard"];
            }
            set
            {
                Session["SessionPersonWizard"] = value;
            }
        }
        public void DestroySessionPersonWizard()
        {
            Session.Remove("SessionPersonWizard");
        }

        
        public ActionResult PersonWizard()
        {
            DestroySessionPersonWizard();           
            return View(SessionPersonWizard.CurrentStep.ViewName, SessionPersonWizard.Model);
        }
        [HttpPost]
        public ActionResult PostName(PersonViewModel model)
        {
            SessionPersonWizard.Sync(model.PersonName);
            return PartialView(SessionPersonWizard.CurrentStep.ViewName, SessionPersonWizard.Model);
        }
        [HttpPost]
        public ActionResult PostAge(PersonViewModel model)
        {
            SessionPersonWizard.Sync(model.PersonBirthday);
            return PartialView(SessionPersonWizard.CurrentStep.ViewName, SessionPersonWizard.Model);
        }
        [HttpPost]
        public ActionResult PostWorkTitle(PersonViewModel model)
        {
            SessionPersonWizard.Sync(model.PersonWorkInfo);
            return PartialView(SessionPersonWizard.CurrentStep.ViewName, SessionPersonWizard.Model);
        }
        [HttpPost]
        public ActionResult PostFamily(PersonViewModel model)
        {
            SessionPersonWizard.Sync(model.PersonFamily);
            return PartialView(SessionPersonWizard.CurrentStep.ViewName, SessionPersonWizard.Model);
        }
        [HttpPost]
        public ActionResult PostAcceptTerms(PersonViewModel model)
        {
            SessionPersonWizard.Sync(model.PersonAcceptTerms);
            SessionPersonWizard.ClearUnusedSteps();
            var m = new PersonResult { ViewModel = SessionPersonWizard.Model };
            return PartialView("_PersonResult",m );
        }
        [HttpPost]
        public ActionResult PostStudentAssert(PersonViewModel model)
        {
            SessionPersonWizard.Sync(model.PersonIsStudent);
            return PartialView(SessionPersonWizard.CurrentStep.ViewName, SessionPersonWizard.Model);
        }
        [HttpPost]
        public ActionResult PostStudentData(PersonViewModel model)
        {
            SessionPersonWizard.Sync(model.PersonStudentInfo);
            return View(SessionPersonWizard.CurrentStep.ViewName, SessionPersonWizard.Model);
        }
    }
}