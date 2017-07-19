
/// <reference path="jquery-1.4.1.js" />

$(document).ready(function () {
    myPager.getList(myPager.listuri);
    $("#first").click(function () {
        if (myPager.pageIndex != 1) {
            myPager.pageIndex = 1;
            myPager.getList(myPager.listuri);
        }
    });
    $("#next").click(function () {
        if (myPager.pageIndex + 1 <= myPager.totalPage) {
            myPager.pageIndex += 1;
            myPager.getList(myPager.listuri);
        }
    });
    $("#previous").click(function () {
        if (myPager.pageIndex - 1 > 0) {
            myPager.pageIndex -= 1;
            myPager.getList(myPager.listuri);
        }
    });
    $("#end").click(function () {
        if (myPager.pageIndex != myPager.totalPage) {
            myPager.pageIndex = myPager.totalPage;
            myPager.getList(myPager.listuri);
        }
    });
    $('.del').live("click", function () {
        if(confirm("确定要删除吗？"))
        {
            var id = $(this).attr("id");
            myPager.del(myPager.deleteuri + "&id=" + id);
       }
    });
    $("#btnsearch").click(function () {
        var key = $("#txtKey").val();
        myPager.pageIndex = 1;
        myPager.getList(myPager.searchuri + "&key=" + key + "&type=" + $("#type").val());
    });
    $("#btnadd").click(function () {
        window.location = "AddUserInfo.aspx";
    });
});

var myPager = {
    pageIndex: 1,
    pageSize: 3,
    totalPage: 0,
    listuri: "Hander/user.ashx?act=list&jsoncallback=?",
    deleteuri: "Hander/user.ashx?act=del&jsoncallback=?",
    searchuri: "Hander/user.ashx?act=search&jsoncallback=?",
    del: function (uri) {
        $.getJSON(uri, function (data) {
            if (data.status == "1") {
                alert(data.html);
                myPager.getList(myPager.listuri);
            }
            else {
                alert(data.html);
            }
        });
    },
    getList: function (uri) {
        $.getJSON(uri, { pageIndex: myPager.pageIndex, pageSize: myPager.pageSize }, function (data) {
            var tb = " <tr class=\"CTitle\" >"
                  + " <td height=\"22\" colspan=\"14\" align=\"center\" style=\"font-size:16px\">用户详细列表</td>"
                  + "</tr><tr bgcolor=\"#EEEEEE\" >"
                  + " <td width=\"5%\" height=\"30\">ID</td>"
			      + "<td width=\"5%\">登陆用户名</td>"
                  + " <td width=\"5%\">登录密码</td>"
			      + "<td width=\"5%\">用户状态</td>"
				  + "<td width=\"5%\">注册IP</td>"
                  + " <td width=\"5%\">登录类型</td>"
                  + " <td width=\"5%\">用户名称</td>"
                  + " <td width=\"5%\">性别</td>"
				  + "<td width=\"12%\">操作</td></tr>";
            if (data.status == "1") {
                var ulist = data.html;
                var total = data.total;
                var totalpage = Math.ceil(total / myPager.pageSize);
                myPager.totalPage = totalpage;
                var strhtml = "";
                for (var i = 0; i < ulist.length; i++) {
                    strhtml += "<tr bgcolor=\"#FFFFFF\" ><td height=\"30\">" + ulist[i].ID + "</td><td>" + ulist[i].UserName + "</td><td>" + ulist[i].UserPwd + "</td>";
                    strhtml += "<td>" + myPager.GetStatus(ulist[i].UserStatus) + "</td><td>" + ulist[i].LoginIp + "</td><td>" + myPager.GetLoginType(ulist[i].LoginType) + "</td>";
                    strhtml += "<td>" + ulist[i].ExData.UserInfo.Name + "</td><td>" +myPager.GetSex(ulist[i].ExData.UserInfo.Sex) + "</td>";
                    strhtml += "<td><a href=\"AddUserInfo.aspx?id=" + ulist[i].ID + "\">编辑|</a><a href=\"#\" id=" + ulist[i].ID + " class=\"del\">删除</a></td></tr>";
                }
                $("#listShow").html(tb + strhtml);
                $("#totalcounts").text(total);
                $("#totalpage").text(totalpage);
                $("#pageIndex").text(myPager.pageIndex);
                $("#pagesize").text(myPager.pageSize);
            }
            else {
                $("#listShow").html(tb);
                $("#totalcounts").text(0);
                $("#totalpage").text(0);
                $("#pageIndex").text(myPager.pageIndex);
                $("#pagesize").text(myPager.pageSize);
                alert(data.html);
            }


        });
    },
    GetSex: function (sex) { 
    var ret="";
     switch(sex)
     {
        case 1:
        ret="男";
        break;
        case 2:
        ret="女";
        break;
     }
     return ret;
    },
    GetStatus: function (s) { 
    var ret="";
     switch(s)
     {
        case 0:
        ret="正常";
        break;
        case 1:
        ret="冻结";
        break;
         case 2:
        ret="删除";
        break;
        case 3:
        ret="禁用";
        break;
     }
     return ret;
    },
    GetLoginType: function (t) { 
    var ret="";
     switch(t)
     {
        case 0:
        ret="超级用户";
        break;
        case 1:
        ret="Web端登录用户";
        break;
         case 2:
        ret="客户端登录用户";
        break;
        case 3:
        ret="服务端用户";
        break;
        case 4:
        ret="移动端用户";
        break;
     }
     return ret;
    },

};