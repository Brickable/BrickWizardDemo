
$.validator.addMethod("dategreaterthan", function (value, element, params) {
    var dateToCompare = $(params).val();
    if (dateToCompare === "" || value === "") {
        return true;
    }
    else {
        return Date.parse(value) > Date.parse($(params).val());
    }
});

$.validator.unobtrusive.adapters.add("dategreaterthan", ["propertynametocompare"], function (options) {
    //"el" Condition necessary to deal with nested objects (the Id of those will be always prefixed with parent object_)
    var el = ($(el).val() === undefined) ?
        "#" + options.element.id.substring(0, options.element.id.lastIndexOf("_") + 1) + options.params.propertynametocompare:
        "#" + options.params.propertynametocompare;
    options.rules["dategreaterthan"] = el;
    options.messages["dategreaterthan"] = options.message;
});