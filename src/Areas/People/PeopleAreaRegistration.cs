﻿using System.Web.Mvc;

namespace WizardDemo.Areas.People
{
    public class PeopleAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "People";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "People_default",
                "People/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}