using BrickWizard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace WizardDemo.Models
{
    public class PersonWizard : Wizard<PersonViewModel>
    {
        protected override int MaxNavSteps => 1;
        protected override Map Map
        {
            get
            {
                return
                new Map(new List<Route> {
                    new Route
                    {
                        RouteId = 1,
                        Steps = new Steps(new List<Step>
                        {
                            new Step("PostName","_Name","Name",1),
                            new Step("PostAge","_Age","Age",2),
                            new Step("PostWorkTitle","_WorkTitle", "Work data",3),
                            new Step("PostFamily","_Family", "Family",4),
                            new Step("PostAcceptTerms","_AcceptTerms", "Accept terms",5)
                        })
                    },
                    new Route
                    {
                        RouteId = 2,
                        Steps = new Steps( new List<Step>
                        {
                            new Step("PostName","_Name","Name",1),
                            new Step("PostAge","_Age","Age",2),
                            new Step("PostStudentAssert","_StudentAssert", "Student Assert",3),
                            new Step("PostStudentData","_StudentData", "Student data",4),
                            new Step("PostAcceptTerms","_AcceptTerms", "Accept terms",5)
                        })
                    },
                    new Route
                    {
                        RouteId = 3,
                        Steps = new Steps(new List<Step>
                        {
                            new Step("PostName","_Name","Name",1),
                            new Step("PostAge","_Age","Age",2),
                            new Step("PostStudentAssert","_StudentAssert", "Student Assert",3),
                            new Step("PostAcceptTerms","_AcceptTerms", "Accept terms",4)
                        })
                    }
                });
            }
        }
        protected override List<string> TriggerPoints => new List<string> { "PostAge", "PostStudentAssert" };
        protected override void Orchestrate()
        {
            if (!IsTriggerPointStep)
            {
                TryMoveNextStep();
            }
            else
            {
                switch (CurrentStep.ActionName)
                {
                    case "PostAge":
                        ManagePostAgeTriggerPoint();
                        break;
                    case "PostStudentAssert":
                        ManagePostStudentTriggerPoint();
                        break;
                    default:
                        break;
                }
            }
        }
        private void ManagePostStudentTriggerPoint()
        {
            if (IsStudent)
                FollowTheRoute(2);
            else
                FollowTheRoute(3);
        }
        private void ManagePostAgeTriggerPoint()
        {
            if (IsMajorAge)
                FollowTheRoute(1);
            else
                FollowTheRoute(2);
        }
        private bool IsMajorAge => (Model.PersonBirthday.BirthDay.AddYears(18) < DateTime.Today);
        private bool IsStudent => (Model.PersonIsStudent.IsStudent);   
    }

}