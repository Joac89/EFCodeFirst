$(document).ready(function () {
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
});