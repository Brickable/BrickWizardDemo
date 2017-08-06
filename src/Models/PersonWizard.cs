using BrickWizard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;


namespace WizardDemo.Models
{
    public class PersonWizard : Wizard<PersonViewModel>
    {
        public PersonWizard(string controllerName) : base(controllerName) { }

        const string Name = "PostName";
        const string Age = "PostAge";
        const string WorkTitle = "PostWorkTitle";
        const string Family = "PostFamily";
        const string AcceptTerms = "PostAcceptTerms";
        const string StudentAssert = "PostStudentAssert";
        const string StudentData = "PostStudentData";

        protected override int MaxTabs => 5;
        protected override Steps Steps
        {
            get
            {
                return new Steps
                (
                    new List<Step>
                    {
                        new Step(Name, "_Name", "Name", new string[] { "PersonName" }),
                        new Step(Age, "_Age", "Age","", ManagePostAgeTriggerPoint ,new string[] { "PersonBirthday" } ),
                        new Step(WorkTitle , "_WorkTitle", "Work data", new string[] { "PersonWorkInfo" }  ),
                        new Step(Family, "_Family", "Family", new string[] { "PersonFamily" } ),
                        new Step(AcceptTerms, "_AcceptTerms", "Accept terms", new string[] { "PersonAcceptTerms" } ),
                        new Step(StudentAssert,"_StudentAssert", "Student Assert",ManagePostStudentTriggerPoint, new string[] { "PersonIsStudent" } ),
                        new Step(StudentData,"_StudentData", "Student data", new string[] { "PersonStudentInfo" } )
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
                            new StepReference(Name,1),
                            new StepReference(Age,2),
                            new StepReference(WorkTitle,3),
                            new StepReference(Family,4),
                            new StepReference(AcceptTerms,5),

                         }),
                    new Route(
                         2,
                         new List<StepReference>
                         {
                            new StepReference(Name,1),
                            new StepReference(Age,2),
                            new StepReference(StudentAssert,3),
                            new StepReference(StudentData,4),
                            new StepReference(AcceptTerms,5),

                         }),
                     new Route(
                         3,
                         new List<StepReference>
                         {
                            new StepReference(Name,1),
                            new StepReference(Age,2),
                            new StepReference(StudentAssert,3),
                            new StepReference(AcceptTerms,4),

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