using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc.Ajax;

namespace WizardDemo.HtmlHelpers
{
    public static class StandardHtmlAttributes
    {
        public static AjaxOptions AjaxOptions => new AjaxOptions
        {
            HttpMethod = "POST",
            InsertionMode = InsertionMode.Replace,
            UpdateTargetId = "form-container"
        };
        public static object Label => new { @class = "horizontal-form-label" }; 
        public static object Input => new { @class = "form-control form-control-inline" };
        public static object ErrorMessage => new { @class = "validation-error-inline" };
        public static object CheckBox = new { @class = "checkbox checkbox-error-inline" };

        public static object BrickWizardForm() => new { id = "form", @class = "brick-wizard-form" };
        public static object BrickWizardForm(string id) => new { id = id, @class = "brick-wizard-form" };
    }
}