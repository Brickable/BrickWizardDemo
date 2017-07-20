//Conventions
//- add css class "wizard-post-action" and attribute "data-post-action" to every archors that intend to submit
//  and assign to it the post action path

function brickWizardHandlerInit() {
    $("a[class$='wizard-post-action']").on("click", function (e) {
        e.preventDefault();
        var form = $(".brick-wizard-form");
        form.removeData("validator");
        form.removeData("unobtrusiveValidation");
        form.validate().cancelSubmit = true;
        var url = $(this).data("post-action");
        form.attr("action", url).submit();
    });

    var form = $(".brick-wizard-form");
    $.validator.unobtrusive.parse(form);

    var defaultRangeValidator = $.validator.methods.range;
    $.validator.methods.range = function (value, element, param) {
        if (element.type === 'checkbox') {
            // if it's a checkbox return true if it is checked
            return element.checked;
        } else {
            // otherwise run the default validation function
            return defaultRangeValidator.call(this, value, element, param);
        }
    }
}





