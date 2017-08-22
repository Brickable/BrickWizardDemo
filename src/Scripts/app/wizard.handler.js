//Conventions
//- add css class "wizard-post-action" and attribute "data-post-action" to every archors that intend to submit
//  and assign to it the post action path

function brickWizardHandlerInit() {
   
    $("a[class$='wizard-post-action']").on("click", function (e) {
        e.preventDefault();       
        var form = $(".brick-wizard-form")
        form.validate().settings.ignore = "*";
        var url = $(this).data("post-action");
        form.attr("action", url).submit();
    });

    $(".brick-wizard-form").on("submit", function (e) {     
        var form = $(".brick-wizard-form");
        if (form.valid()) {
            e.preventDefault();
            var data = form.serialize();
            var url = form.attr("action");
            $.ajax({
                type: "POST",
                url: url,
                data: data,
                success: function (data) {
                    replaceContent(data);
                }
            });
        }
    });

    function replaceContent(data) {
        var replaceableEl = form.data("replace-target-selector");
        $(replaceableEl).html(data);
    }

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





