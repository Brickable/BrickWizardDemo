using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;


namespace WizardDemo.HtmlHelpers
{
    public static class BrickWizardSubmitActionsHelper
    {

        //<div class  ="btn-group" role="group" aria-label="...">
        //    <a class    ="btn btn-default wizard-post-action" data-post-action="@Url.Action(Model.PreviousStep.ActionName, Model.ControllerName)">
        //        <i class="glyphicon glyphicon-chevron-left"></i> PREVIOUS
        //    </a>

        //    <button type = "submit" class="btn btn-primary">
        //        NEXT<i class="glyphicon glyphicon-chevron-right"></i>
        //    </button>
        //</div> 

        public static MvcHtmlString BrickWizardSubmitActions(this HtmlHelper htmlHelper, ButtonsToRender buttonsToRender,
            SubmitStyle submitStyle, string backPostAction = "")
        {
            var mainDiv = new TagBuilder("div");
            mainDiv.AddCssClass("btn-group");
            mainDiv.Attributes.Add("role", "group");
            mainDiv.Attributes.Add("aria-label", "...");

            var backButton = new TagBuilder("a");
            if (buttonsToRender == ButtonsToRender.Both)
            {
                backButton.AddCssClass("btn btn-default wizard-post-action");
                backButton.Attributes.Add("data-post-action", backPostAction);
                var backIcon = new TagBuilder("i");
                backIcon.AddCssClass("glyphicon glyphicon-chevron-left");
                var backButtonText = " PREVIOUS ";
                backButton.InnerHtml = backIcon.ToString(TagRenderMode.Normal) + backButtonText;
            }
            var submitButton = new TagBuilder("button");
            submitButton.AddCssClass("btn btn-primary");
            submitButton.Attributes.Add("type", "submit");
            var submitIcon = new TagBuilder("i");
            var submitIconClass = (submitStyle == SubmitStyle.Next) ? "glyphicon glyphicon-chevron-right" : "glyphicon glyphicon-floppy-disk";
            submitIcon.AddCssClass(submitIconClass);
            var submitButtonText = (submitStyle == SubmitStyle.Next) ? " NEXT " : " SUBMIT ";
            submitButton.InnerHtml = submitButtonText + submitIcon.ToString(TagRenderMode.Normal);

            mainDiv.InnerHtml = (buttonsToRender == ButtonsToRender.Both) ?
                backButton.ToString(TagRenderMode.Normal) + submitButton.ToString(TagRenderMode.Normal) :
                submitButton.ToString();
            return MvcHtmlString.Create(mainDiv.ToString(TagRenderMode.Normal));

        }
    }
   
    public enum ButtonsToRender
    {
        Both,
        JustSubmit
    };
    public enum SubmitStyle
    {
        Save,
        Next
    };



}