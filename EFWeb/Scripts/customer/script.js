var app = new app();

$("#CountryId").change(function () {
    app.getAjaxData(
        "DepartmentId",
        "/Customer/GetDepartments",
        {
            countryId: $("#CountryId").val()
        }
    );
});

$("#DepartmentId").change(function () {
    app.getAjaxData(
        "CityId",
        "/Customer/GetCities",
        {
            countryId: $("#CountryId").val(),
            departmentId: $("#DepartmentId").val()
        }
    );
});

function ajaxFormResult(result) {
    app.resultAjaxMessage("message_result", result);
    $("#form_create")[0].reset();
}
