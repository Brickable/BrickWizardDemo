using BrickWizard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WizardDemo.HtmlHelpers
{
    public static class WizardNavBarHelper
    {
        public static MvcHtmlString WizardTab(this HtmlHelper htmlHelper, Tab tab, TabTime tabTime, NavBarType navBarType, string actionUrl = "")
        {
            switch (navBarType)
            {
                //TWEAK POINT
                //Description: add a case here case you want to add a new navBarType
                case NavBarType.NavBarDefault: return GetNavBarDefault(tab, tabTime, actionUrl);
                default: return GetNavBarDefault(tab, tabTime, actionUrl);
            }
        }

        private static MvcHtmlString GetNavBarDefault(Tab tab, TabTime tabTime, string actionUrl)
        {
            string html;
            if (tabTime == TabTime.Past)
            {
                if (tab.Enable)
                {
                    html = $"<li class='tab-enable'><a class='wizard-post-action' data-toggle='tab' data-post-action={actionUrl} href='javascript:void(0)'> <span class='badge'>{tab.Number}</span>{tab.Name}</a> </li>";
                }
                else
                {
                    html = $"<li class='tab-disable'><a href='javascript:void(0)'> <span class='badge'>{tab.Number}</span>{tab.Name}</a> </li>";
                }
                
            }
            else if (tabTime == TabTime.Present)
            {
                html = $"<li class='tab-active'> <a data-post-action={actionUrl} href='javascript:void(0)'>  <span class='badge'>{tab.Number}</span> {tab.Name}</a> </li>";
            }
            else
            {
                html = $"<li class='tab-disable'> <a href='javascript:void(0)'>  <span class='badge'>{tab.Number}</span> {tab.Name}</a> </li>";
            }
            return new MvcHtmlString(html);
        }
    }
    public enum TabTime
    {
        Past,
        Present,
        Future
    }

    public enum NavBarType
    {
        //TWEAK POINT
        //Description: add a new navBarType case you want to add a new one
        NavBarDefault
    }
}