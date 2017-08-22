using BrickWizard;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WizardDemo.Filters;

namespace WizardDemo.Models
{
    public class Person
    {
        //========================================  STEP - NAMES
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //========================================  STEP - BIRTHDAY
        public DateTime BirthDay { get; set; }
        public bool Genre { get; set; }
        //========================================  STEP - ADDRESS
        public string Address { get; set; }
        public string MobileNumber { get; set; }
        //========================================  STEP - ISSTUDENT
        public bool IsStudent { get; set; }
        //========================================  STEP - STUDENT INFO
        public int SchoolYear { get; set; }
        public string SchoolName { get; set; }
        //========================================  STEP - WORKINFO
        public string WorkTitle { get; set; }
        public string Company { get; set; }
        //========================================  STEP - FAMILY
        public string SocialStatus { get; set; }
        public int ChildNumbers { get; set; }
        //========================================  STEP - ACCEPT TERMS
        public bool AcceptTerms { get; set; }
    }
    public class PersonViewModel : WizardModelBaseClass
    {
        public PersonNameViewModel PersonName { get; set; } = new PersonNameViewModel();
        public PersonBirthdayViewModel PersonBirthday { get; set; }
        public PersonAddressViewModel PersonAddress { get; set; }
        public PersonIsStudentViewModel PersonIsStudent { get; set; }
        public PersonStudentInfoViewModel PersonStudentInfo { get; set; }
        public PersonWorkInfoViewModel PersonWorkInfo { get; set; }
        public PersonFamilyViewModel PersonFamily { get; set; }
        public PersonAcceptTermsViewModel PersonAcceptTerms { get; set; }
    }
    [Serializable]
    public class PersonResult
    {
        public Person Model { get; set; }
        public PersonViewModel ViewModel { get; set; }
    }
    public class PersonNameViewModel
    {
        public int PersonId { get; set; }
        [Required, DisplayName("First Name")]
        public string PersonFirstName { get; set; }
        [Required, DisplayName("Last Name")]
        public string PersonLastName { get; set; }
    }
    public class PersonBirthdayViewModel
    {
        [Required, DisplayName("Birthday")]
        //[DataType(DataType.Date, ErrorMessage = "Date only")]

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BirthDay { get; set; }
        public bool Genre { get; set; }
    }
    public class PersonAddressViewModel
    {
        [Required]
        public string Address { get; set; }
        [Required, DisplayName("Mobile Phone")]
        public string MobileNumber { get; set; }
    }
    public class PersonIsStudentViewModel
    {
        [Required, DisplayName("Is Student")]
        public bool IsStudent { get; set; }
    }
    public class PersonStudentInfoViewModel
    {
        [Required, DisplayName("School Year")]
        public int SchoolYear { get; set; }
        [DisplayName("School Name")]
        public string SchoolName { get; set; }
        [DisplayName("Begin date")]
        public DateTime? From { get; set; }
        [DisplayName("End Date")]
        [DateGreaterThan("From","Need to be greater than begin date")]
        public DateTime? To { get; set; }
    }
    public class PersonWorkInfoViewModel
    {
        [Required, DisplayName("Work Title")]
        public string WorkTitle { get; set; }
        [Required]
        public string Company { get; set; }
    }
    public class PersonFamilyViewModel
    {
        [Required, DisplayName("Socia Status")]
        public string SocialStatus { get; set; }
        [Required, DisplayName("Child Number")]
        public int ChildNumbers { get; set; }
    }
    public class PersonAcceptTermsViewModel
    {
        [Required, DisplayName("Accept Terms")]
        [Range(typeof(bool), "true", "true", ErrorMessage = "You need to tick the Accept Terms checkbox")]
        public bool AcceptTerms { get; set; }
    }

}