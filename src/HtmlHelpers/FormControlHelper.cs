using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace WizardDemo.HtmlHelpers
{
    public static class FormControlHelper
    {
        //    //<div class="form-group">
        //    //  @Html.LabelFor(model => model.PersonAcceptTerms.AcceptTerms, StandardHtmlAttributes.Label)
        //    //  @Html.CheckBoxFor(model => model.PersonAcceptTerms.AcceptTerms, StandardHtmlAttributes.CheckBox)
        //    //  @Html.ValidationMessageFor(model => model.PersonAcceptTerms.AcceptTerms, "", StandardHtmlAttributes.ErrorMessage)
        //    //</div>

        public static MvcHtmlString FormControl<TModel, TValue>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression, TypeOfInput inputType)
        {
            var mainDiv = new TagBuilder("div");
            mainDiv.AddCssClass("form-group");

            var label = LabelExtensions.LabelFor(htmlHelper, expression, StandardHtmlAttributes.Label).ToHtmlString();
            var input = InputFor(htmlHelper, expression, inputType);
            var errorMessage = ValidationExtensions.ValidationMessageFor(htmlHelper, expression, "", StandardHtmlAttributes.ErrorMessage);

            var checkBoxContainer = new TagBuilder("div");
            checkBoxContainer.InnerHtml = string.Empty + input + errorMessage;
            mainDiv.InnerHtml = label + checkBoxContainer;
            return MvcHtmlString.Create(mainDiv.ToString(TagRenderMode.Normal));
        }

        public static MvcHtmlString InputFor<TModel, TValue>(HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression, TypeOfInput inputType)
        {
            var a = NameExtensions.IdFor(htmlHelper,expression).ToHtmlString();
            switch (inputType)
            {
                case TypeOfInput.CheckBox:
                    var exp = (Expression<Func<TModel, bool>>)(object)expression;
                    return InputExtensions.CheckBoxFor(htmlHelper, exp, StandardHtmlAttributes.CheckBox);
                case TypeOfInput.DateTime:
                    var element = EditorExtensions.EditorFor(htmlHelper, expression, new { htmlAttributes = StandardHtmlAttributes.Input }).ToHtmlString();
                    var script = DateTimePluginInitializer(NameExtensions.IdFor(htmlHelper, expression).ToHtmlString());
                    return MvcHtmlString.Create(element+script);
                default:
                    return InputExtensions.TextBoxFor(htmlHelper, expression, StandardHtmlAttributes.Input);
            }
        }

        private static MvcHtmlString DateTimePluginInitializer(string id)
        {
           var scriptBlock = new TagBuilder("script");
           var script =
            $"var hadp{id} = new HaDateTimePicker('#{id}');"+
            $"hadp{id}.options.disableTime = true;"+
            $"document.getElementById('{id}').addEventListener('click', function() {{"+
            $"hadp{id}.show();}});";
            scriptBlock.InnerHtml = script;
            return MvcHtmlString.Create(scriptBlock.ToString(TagRenderMode.Normal));
        }
    }
    public enum TypeOfInput
    {
        Text,
        DateTime,
        CheckBox
    }
}
  
