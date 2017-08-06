using BrickWizard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WizardDemo.Models;

namespace WizardDemo.Areas.People.Models
{
    public class PersonForAreaWizard : Wizard<PersonViewModel>
    {
        public PersonForAreaWizard(string controllerName, string areaName) : base(controllerName, areaName) { }

        const string Name = "PostName";
        const string Age = "PostAge";
        const string WorkTitle = "PostWorkTitle";
        const string Family = "PostFamily";
        const string AcceptTerms = "PostAcceptTerms";
        const string StudentAssert = "PostStudentAssert";
        const string StudentData = "PostStudentData";

        protected override int MaxTabs => 10;
        protected override Steps Steps
        {
            get
            {
                return new Steps
                (
                    new List<Step>
                    {
                        new Step(Name, "_Name", "Name", new string[] {"PersonName"}),
                        new Step(Age, "_Age", "Age","",new string[] {"PersonBirthday"}),
                        new Step(WorkTitle , "_WorkTitle", "Work data", new string[] {"PersonWorkInfo"}),
                        new Step(Family, "_Family", "Family", new string[] {"PersonFamily"}),
                        new Step(AcceptTerms, "_AcceptTerms", "Accept terms", new string[] {"PersonAcceptTerms"}),
                        new Step(StudentAssert,"_StudentAssert", "Student Assert", new string[] {"PersonIsStudent"}),
                        new Step(StudentData,"_StudentData", "Student data", new string[] {"PersonStudentInfo"})
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
                            new StepReference(StudentAssert,5),
                            new StepReference(StudentData,6),
                            new StepReference(AcceptTerms,7),

                         })
                });
            }
        }

    }
}
