<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="DistributedWeb_MG.List" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>例子</title>
    <link href="/css/css.css" rel="stylesheet" type="text/css" />
    <script type="text/JavaScript">

    </script>
    <link href="/css/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form name="fom" id="fom" method="post" action="" runat="server">
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td height="30">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td height="62" background="/images/nav04.gif">
                            <table width="98%" border="0" align="center" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td width="21">
                                        <img src="/images/ico07.gif" width="20" height="18" />
                                    </td>
                                    <td width="538">
                                        搜索
                                        <select id="ddltype" runat="server">
                                            <option value="1">名称</option>
                                            <option value="2">ID</option>
                                        </select>
                                        <input name="txtKey" id="txtKey" type="text" size="12" runat="server"/>
                                        <asp:Button ID="btnsearch" runat="server" CommandArgument="8" CssClass="right-button02" Text="搜索" 
                                            onclick="btnsearch_Click" />
                                        <input name="btnadd" id="btnadd" type="button" class="right-button08" value="添加用户" />
                                    </td>
                                    <td width="144" align="left">
                                        <a href="#" onclick="sousuo()">&nbsp;</a>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table id="subtree1" style="display: " width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td>
                            <table width="95%" border="0" align="center" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td height="20">
                                    </td>
                                </tr>
                                <tr>
                                    <td height="40" class="font42">
                                        <table width="100%" border="0" id="listShow" cellpadding="4" cellspacing="1" bgcolor="#464646"
                                            class="newfont03">
                                            <tr bgcolor="#EEEEEE">
                                            <td width="5%" height="30">ID</td>
                                            <td width="5%">登陆用户名</td>
                                            <td width="5%">登录密码</td>
                                            <td width="5%">用户状态</td>
                                            <td width="5%">注册IP</td> 
                                            <td width="5%">登录类型</td>
                                            <td width="5%">用户名称</td>
                                            <td width="5%">性别</td>
                                            <td width="12%">操作</td>
                                            </tr>
                                            <% if (ulist!=null)
                                               {
                                                   foreach (DistributedModel.Mongodb.User.LoginUserInfo_MG u in ulist)
                                                   {
                                                       DistributedModel.User.UserInfo_MG info = u.GetExData<DistributedModel.User.UserInfo_MG>("UserInfo");
                                                   %>
                                            <tr bgcolor="#FFFFFF">
                                            <td height="30"><%=u.UID%></td>
                                            <td><%=u.UserName%></td>
                                            <td><%=u.UserPwd%></td>
                                            <td><%=u.UserStatus%></td>
                                            <td><%=u.LoginIp%></td>
                                            <td><%=u.LoginType%></td>
                                            <td><%=info.Name%></td>
                                            <td><%=info.GetSex()%></td>
                                            <td>
                                            <a href="AddUser.aspx?id=<%=u.UID %>">编辑|</a> 
                                               <a href="#" id="<%=u.UID %>"  class="del">删除</a></td>
                                                </td>
                                            </tr>
                                            <%}
                                               }%>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                            <table width="95%" border="0" align="center" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td height="6">
                                        <img src="../images/spacer.gif" width="1" height="1" />
                                    </td>
                                </tr>
                                <tr>
                                    <td height="33">
                                        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" class="right-font08">
                                            <tr>
                                                <td width="50%">
                                                    共<span class="right-text09" id="totalcounts"><%=totalcounts %></span>条记录 每页显示<span class="right-text09"
                                                        id="pagesize"><%=pageSize %></span>条记录 | 共<span class="right-text09" id="totalpage"><%=totalPage %></span>
                                                    页 | 第 <span class="right-text09" id="pageIndex"><%=pgindex %></span>页
                                                </td>
                                                <td width="49%" align="right">
                                                    [<a href="list.aspx?pageIndex=1" class="right-font08" id="first">首页</a> | <a href="list.aspx?pageIndex=<%=previosPgIndex %>" id="previous" class="right-font08">
                                                        上一页</a> | <a href="list.aspx?pageIndex=<%=nextPgIndex %>" id="next" class="right-font08">下一页</a> | <a href="list.aspx?pageIndex=<%=totalPage %>" id="end"
                                                            class="right-font08">尾页</a>]
                                                </td>
                                                <td width="1%">
                                                    <table width="20" border="0" cellspacing="0" cellpadding="0">
                                                        <tr>
                                                            <td width="1%">
                                                            </td>
                                                            <td width="87%">
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                 
    </form>
    <script src="/Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $('.del').click(function () {
            if (confirm("确定要删除吗？")) {
                var id = $(this).attr("id");
                $.getJSON("/Hander/hander.ashx?act=mgdel&jsoncallback=?", { id: id }, function (data) {
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
    </script>
</body>
</html>
