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
            SessionPersonWizard.CommitAndSync(model);
            return PartialView(SessionPersonWizard.CurrentStep.ViewName, SessionPersonWizard.Model);
        }
        [HttpPost]
        public ActionResult PostAge(PersonViewModel model)
        {
            SessionPersonWizard.CommitAndSync(model);
            return PartialView(SessionPersonWizard.CurrentStep.ViewName, SessionPersonWizard.Model);
        }
        [HttpPost]
        public ActionResult PostWorkTitle(PersonViewModel model)
        {
            SessionPersonWizard.CommitAndSync(model);
            return PartialView(SessionPersonWizard.CurrentStep.ViewName, SessionPersonWizard.Model);
        }
        [HttpPost]
        public ActionResult PostFamily(PersonViewModel model)
        {
            SessionPersonWizard.CommitAndSync(model);
            return PartialView(SessionPersonWizard.CurrentStep.ViewName, SessionPersonWizard.Model);
        }
        [HttpPost]
        public ActionResult PostAcceptTerms(PersonViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return PartialView(SessionPersonWizard.CurrentStep.ViewName, SessionPersonWizard.Model);
            }
            SessionPersonWizard.CommitAndSync(model);
            SessionPersonWizard.ClearUnusedSteps();
            var m = new PersonResult { ViewModel = SessionPersonWizard.Model };
            return PartialView("_PersonResult", m);
        }
        [HttpPost]
        public ActionResult PostStudentAssert(PersonViewModel model)
        {
            SessionPersonWizard.CommitAndSync(model);
            return PartialView(SessionPersonWizard.CurrentStep.ViewName, SessionPersonWizard.Model);
        }
        [HttpPost]
        public ActionResult PostStudentData(PersonViewModel model)
        {
            SessionPersonWizard.CommitAndSync(model);
            return View(SessionPersonWizard.CurrentStep.ViewName, SessionPersonWizard.Model);
        }
    }
}