$(document).ready(function () {
    $("#ddlProv").change(function () {
        $.getJSON("/Hander/hander.ashx?act=address&jsoncallback=?", { proid: $("#ddlProv").val() }, function (data) {

            if (data.status == 1) {

                var citys = data.html;
                var options = "";
                for (var i = 0; i < citys.length; i++) {
                    options += "<option value=\"" + citys[i].ID + "\">" + citys[i].Name + "</option>";
                }
                $("#ddlCity").html(options);
            }
        });
    });
});