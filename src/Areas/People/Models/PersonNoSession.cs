using BrickWizard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WizardDemo.Models;

namespace WizardDemo.Areas.People.Models
{
    public static class PersonNoSessionWizardSteps
    {
        public const string Name = "PostName";
        public const string Age = "PostAge";
        public const string WorkTitle = "PostWorkTitle";
        public const string Family = "PostFamily";
        public const string AcceptTerms = "PostAcceptTerms";
        public const string StudentAssert = "PostStudentAssert";
        public const string StudentData = "PostStudentData";
    }

    public class PersonNoSession : Wizard<PersonViewModel>
    {
        public PersonNoSession(string controllerName, string areaName,int startAtRouteId, string startAtStepActionName,
            string[] frozenSteps = null) : base(controllerName, startAtRouteId,startAtStepActionName, areaName, frozenSteps) { }

        protected override Steps Steps
        {
            get
            {
                return new Steps
                (
                    new List<Step>
                    {
                        new Step(PersonNoSessionWizardSteps.Name, "_Name", "Name", new string[] { "PersonName" }),
                        new Step(PersonNoSessionWizardSteps.Age, "_Age", "Age","", ManagePostAgeTriggerPoint ,new string[] { "PersonBirthday" } ),
                        new Step(PersonNoSessionWizardSteps.WorkTitle , "_WorkTitle", "Work data", new string[] { "PersonWorkInfo" }  ),
                        new Step(PersonNoSessionWizardSteps.Family, "_Family", "Family", new string[] { "PersonFamily" } ),
                        new Step(PersonNoSessionWizardSteps.AcceptTerms, "_AcceptTerms", "Accept terms", new string[] { "PersonAcceptTerms" } ),
                        new Step(PersonNoSessionWizardSteps.StudentAssert,"_StudentAssert", "Student Assert",ManagePostStudentTriggerPoint, new string[]{ "PersonIsStudent" } ),
                        new Step(PersonNoSessionWizardSteps.StudentData,"_StudentData", "Student data", new string[] { "PersonStudentInfo" } )
                    }
                );
            }
        }
        protected override Map Map
        {
            get
            {
                return
                new Map(new List<Route> {
                     new Route(
                         1,
                         new List<StepReference>
                         {
                            new StepReference(PersonNoSessionWizardSteps.Name),
                            new StepReference(PersonNoSessionWizardSteps.Age),
                            new StepReference(PersonNoSessionWizardSteps.WorkTitle),
                            new StepReference(PersonNoSessionWizardSteps.Family),
                            new StepReference(PersonNoSessionWizardSteps.AcceptTerms),

                         }),
                    new Route(
                         2,
                         new List<StepReference>
                         {
                            new StepReference(PersonNoSessionWizardSteps.Name),
                            new StepReference(PersonNoSessionWizardSteps.Age),
                            new StepReference(PersonNoSessionWizardSteps.StudentAssert),
                            new StepReference(PersonNoSessionWizardSteps.StudentData),
                            new StepReference(PersonNoSessionWizardSteps.AcceptTerms),

                         }),
                     new Route(
                         3,
                         new List<StepReference>
                         {
                            new StepReference(PersonNoSessionWizardSteps.Name),
                            new StepReference(PersonNoSessionWizardSteps.Age),
                            new StepReference(PersonNoSessionWizardSteps.StudentAssert),
                            new StepReference(PersonNoSessionWizardSteps.AcceptTerms),

                         }),
                });
            }
        }

        private int ManagePostStudentTriggerPoint()
        {
            return IsStudent ? 2 : 3;
        }
        private int ManagePostAgeTriggerPoint()
        {
            return IsMajorAge ? 1 : 2;
        }
        private bool IsMajorAge => (Model.PersonBirthday?.BirthDay != null && Model.PersonBirthday.BirthDay.AddYears(18) < DateTime.Today);
        private bool IsStudent => (Model.PersonIsStudent?.IsStudent != null && Model.PersonIsStudent.IsStudent);
    }
}
