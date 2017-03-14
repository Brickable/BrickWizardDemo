using BrickWizard;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

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
    public class PersonNameViewModel
    {
        
        public int PersonId { get; set; }
        [Required,DisplayName("First Name")]
        public string PersonFirstName { get; set; }
        [Required, DisplayName("Last Name")]
        public string PersonLastName { get; set; }
    }
    public class PersonBirthdayViewModel
    {

        [Required, DisplayName("Birthday")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime BirthDay { get; set; }
        public bool Genre { get; set; }
    }
    public class PersonAddressViewModel
    {
        public string Address { get; set; }
        [DisplayName("Mobile Phone")]
        public string MobileNumber { get; set; }
    }
    public class PersonIsStudentViewModel
    {
        public bool IsStudent { get; set; }
    }
    public class PersonStudentInfoViewModel
    {
        public int SchoolYear { get; set; }
        public string SchoolName { get; set; }
    }
    public class PersonWorkInfoViewModel
    {
        public string WorkTitle { get; set; }
        public string Company { get; set; }
    }
    public class PersonFamilyViewModel
    {
        public string SocialStatus { get; set; }
        public int ChildNumbers { get; set; }
    }
    public class PersonAcceptTermsViewModel
    {
        public bool AcceptTerms { get; set; }
    }
   
    public class PersonViewModel : WizardModelBaseClass
    {
        public PersonNameViewModel PersonName { get; set; }
        public PersonBirthdayViewModel PersonBirthday { get; set; }
        public PersonAddressViewModel PersonAddress { get; set; }
        public PersonIsStudentViewModel PersonIsStudent { get; set; }
        public PersonStudentInfoViewModel PersonStudentInfo { get; set; }
        public PersonWorkInfoViewModel PersonWorkInfo { get; set; }
        public PersonFamilyViewModel PersonFamily { get; set; }
        public PersonAcceptTermsViewModel PersonAcceptTerms { get; set; }

    }
}