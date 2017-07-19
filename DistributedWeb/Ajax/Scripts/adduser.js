/// <reference path="jquery-1.4.1.min.js" />
$(document).ready(function () {
//判断是否有参数id
    if (MyAdder.GetRequset("id")) {
        var id = MyAdder.GetRequset("id");
        //执行初始化操作
        $.getJSON("Hander/user.ashx?act=load&jsoncallback=?", { id: id }, function (data) {

            if (data.status == 1) {
                var loginuser = data.html;
                var userinfo = loginuser.ExData.UserInfo;

                $("#txtUserName").val(userinfo.Name);
                $("#ddlGender").val(userinfo.Sex);
                $("#txtPhone").val(userinfo.Phone);
                $("#ddlZodiac").val(userinfo.ZodiacId);
                $("#ddlProv").val(userinfo.ProvinceId);
                $("#ddlCity").val(userinfo.CityId);
                $("#ddlConstellation").val(userinfo.ConstellationId);
                $("#ddlDegree").val(userinfo.DegreeId);
                $("#ddlNation").val(userinfo.NationId);

                $("#txtLoginUserName").val(loginuser.UserName);
                $("#ddlUserStatus").val(loginuser.UserStatus);
                $("#txtPwd").val(loginuser.UserPwd);
                $("#ddlLoginType").val(loginuser.LoginType);

                $.getJSON("Hander/user.ashx?act=address&jsoncallback=?", { proid: userinfo.ProvinceId }, function (data) {

                    if (data.status == 1) {

                        var citys = data.html;
                        var options = "";
                        for (var i = 0; i < citys.length; i++) {
                            if (userinfo.CityId == citys[i].ID) {
                                options += "<option value=\"" + citys[i].ID + "\" selected>" + citys[i].Name + "</option>";
                            }
                            else {
                                options += "<option value=\"" + citys[i].ID + "\">" + citys[i].Name + "</option>";
                            }
                        }
                        $("#ddlCity").html(options);
                    }
                });

            }
        });
        //点击绑定修改操作
        $("#btnsave").click(function () {
            MyAdder.Update(id);
        });

    }
    else {//点击绑定添加操作
        $("#btnsave").click(function () {
            MyAdder.Add();
        });

    }

    //
    $("#ddlProv").change(function () {
        $.getJSON("Hander/user.ashx?act=address&jsoncallback=?", { proid: $("#ddlProv").val() }, function (data) {

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
var MyAdder = {
    Add: function () {
        if (MyAdder.Check()) {
            MyAdder.Do("Hander/user.ashx?act=add&jsoncallback=?");
        }
    },
    Update: function (id) {
        if (MyAdder.Check()) {
            MyAdder.Do("Hander/user.ashx?act=up&jsoncallback=?&id=" + id);
        }
    },
    Check: function () {
        var userName = $("#txtUserName").val();
        var phone = $("#txtPhone").val();
        if ($.trim(userName) == "") {
            alert("请输入名称！");
            return false;
        }
        else if (!(new RegExp(/(^1[34578]\d{9}$)|(^0[1-9]\d{8,11}$)/g)).test(phone)) {
            alert("手机号不合法！");
            return false;
        }
        return true;
    },
    Do: function (uri) {
        var LoginUser = $("#txtLoginUserName").val();
        var UserStatus = $("#ddlUserStatus").val();
        var Pwd = $("#txtPwd").val();
        var LoginType = $("#ddlLoginType").val();
        var UserName = $("#txtUserName").val();
        var Gender = $("#ddlGender").val();
        var Phone = $("#txtPhone").val();
        var Zodiac = $("#ddlZodiac").val();
        var Prov = $("#ddlProv").val();
        var City = $("#ddlCity").val();
        var Constellation = $("#ddlConstellation").val();
        var Degree = $("#ddlDegree").val();
        var Nation = $("#ddlNation").val();
        $.getJSON(uri,
            {LoginUser:LoginUser,UserStatus:UserStatus,Pwd:Pwd,LoginType:LoginType, UserName: UserName, Gender: Gender, Phone: Phone, Zodiac: Zodiac, Prov: Prov, City: City, Constellation: Constellation, Degree: Degree, Nation: Nation },
            function (data) {
                if (data.status == 1) {
                    alert(data.html);
                    window.location = "Default.aspx";
                }
            });
    },
    GetRequset: function (name) {
        var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
        var r = window.location.search.substr(1).match(reg);
        if (r != null) return unescape(r[2]); return null;
    }
};