using BrickWizard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WizardDemo.Models;

namespace WizardDemo.Areas.People.Models
{
    public static class PersonForAreaWizardSteps
    {
        public const string Name = "PostName";
        public const string Age = "PostAge";
        public const string WorkTitle = "PostWorkTitle";
        public const string Family = "PostFamily";
        public const string AcceptTerms = "PostAcceptTerms";
        public const string StudentAssert = "PostStudentAssert";
        public const string StudentData = "PostStudentData";
    }
    public static class PersonForAreaWizardViews
    {
        public const string EntryPoint = "PersonForAreaWizardEntryPoint";
        public const string Partial = "PersonForAreaWizardPartialView";

    }

    public class PersonForAreaWizard : Wizard<PersonViewModel>
    {
        public PersonForAreaWizard(string controllerName, string areaName) : base(controllerName, areaName) { }



        protected override int MaxTabs => 10;
        protected override Steps Steps
        {
            get
            {
                return new Steps
                (
                    new List<Step>
                    {
                        new Step(PersonForAreaWizardSteps.Name, PersonForAreaWizardViews.EntryPoint, "Name", new string[] {"PersonName"}),
                        new Step(PersonForAreaWizardSteps.Age, PersonForAreaWizardViews.Partial, "Age","",new string[] {"PersonBirthday"}),
                        new Step(PersonForAreaWizardSteps.WorkTitle , PersonForAreaWizardViews.Partial, "Work data", new string[] {"PersonWorkInfo"}),
                        new Step(PersonForAreaWizardSteps.Family, PersonForAreaWizardViews.Partial, "Family", new string[] {"PersonFamily"}),
                        new Step(PersonForAreaWizardSteps.AcceptTerms, PersonForAreaWizardViews.Partial, "Accept terms", new string[] {"PersonAcceptTerms"}),
                        new Step(PersonForAreaWizardSteps.StudentAssert,PersonForAreaWizardViews.Partial, "Student Assert", new string[] {"PersonIsStudent"}),
                        new Step(PersonForAreaWizardSteps.StudentData,PersonForAreaWizardViews.Partial, "Student data", new string[] {"PersonStudentInfo"})
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
                            new StepReference(PersonForAreaWizardSteps.Name,1),
                            new StepReference(PersonForAreaWizardSteps.Age,2),
                            new StepReference(PersonForAreaWizardSteps.WorkTitle,3),
                            new StepReference(PersonForAreaWizardSteps.Family,4),
                            new StepReference(PersonForAreaWizardSteps.StudentAssert,5),
                            new StepReference(PersonForAreaWizardSteps.StudentData,6),
                            new StepReference(PersonForAreaWizardSteps.AcceptTerms,7),

                         })
                });
            }
        }

    }
}
