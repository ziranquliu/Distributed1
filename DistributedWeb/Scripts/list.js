$('.del').click(function () {
    if (confirm("确定要删除吗？")) {
        var id = $(this).attr("id");
        $.getJSON("/Hander/hander.ashx?act=del&jsoncallback=?", { id: id }, function (data) {
            if (data.status == "1") {
                alert(data.html);
                window.location = "list.aspx";
            }
            else {
                alert(data.html);
            }
        });
    }
});
$("#btnadd").click(function () {
    window.location = "AddUser.aspx";
});