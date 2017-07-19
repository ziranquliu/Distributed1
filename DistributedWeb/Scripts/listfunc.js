$(document).ready(function () {
    $("#btnadd").click(function () {
        window.location = "AddFunction.aspx";
    });
    $(".btlink").click(function () {
        var showid = $(this).attr("showid");
        var obj = $(".show" + showid);
        if (obj.css("display") == "none") {
            obj.css("display", "");
        }
        else {
            obj.css("display", "none");
        }
    });
    $(".del").click(function () {
        if (confirm("确定要删除吗？")) {
            var id = $(this).attr("id");
            $.getJSON("/Hander/hander.ashx?act=funcdel&jsoncallback=?", { id: id }, function (data) {
                if (data.status == "1") {
                    alert(data.html);
                    window.location = "listfunction.aspx";
                }
                else {
                    alert(data.html);
                }
            });
        }
    });
});