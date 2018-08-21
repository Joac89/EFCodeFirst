var app = {

    getAjaxData: function (field, path, json) {
        $.getJSON(path, json,
            function (results) {
                if (results.Code == 200) {
                    $("#" + field).empty();
                    $("#" + field).append(
                        $("<option></option>").text("Seleccione").val(0)
                    );
                    $.each(results.Data, function (i, item) {
                        $("#" + field).append(
                            $("<option></option>").text(item.Description).val(item.Id)
                        );
                    });
                }
            });
    },

    resultAjaxMessage: function (field, form, result) {
        var css = result.Code = 200 ? "alert alert-success form-alert" : "alert alert-danger form-alert";

        $("#" + field).attr("class", css);
        $("#" + field).attr("style", "display: block");
        $("#" + field + " div").empty();
        $("#" + field + " div").append(result.Message);
        $("#" + form)[0].reset();
    }
}
