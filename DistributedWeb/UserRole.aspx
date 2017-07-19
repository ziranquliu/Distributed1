<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserRole.aspx.cs" Inherits="DistributedWeb.UserRole" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>例子</title>
    <link href="/css/css.css" rel="stylesheet" type="text/css" />
     
    <link href="/css/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="Form1"  runat="server">
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td height="30">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td height="62" background="/images/nav04.gif">
                            <table width="98%" border="0" align="center" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                       <table  style="display: " width="100%" border="0" cellspacing="0" cellpadding="0">
                                       <tr>
                                       <td>&nbsp;</td>
                                        
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
                                            
                                            <td width="5%">用户名称</td>
                                            <td width="5%">分配角色</td>
                                            </tr>
                                            
                                            <tr bgcolor="#FFFFFF">
                                            <td height="30"><%=userName%></td>
                                            
                                             <td width="5%">
                                              <ul>
                                             <%
                                                  
                                                 if (rlist.Any())
                                                 {
                                                     //循环所有的角色列表
                                                     foreach (var r in rlist)
                                                     {
                                                         //roleids即通过传递过来的userId查找其所具有的角色id的list<int>集合
                                                         if (roleids.Contains(r.ID))
                                                         { 
                                             %>
                                            
                                             <li><input type="checkbox" name="cked" value="<%=r.ID %>" checked="checked"/><%=r.RoleName%></li>   
                                             <%}
                                                         else
                                                         { %>  
                                                     <li><input type="checkbox" name="ck" value="<%=r.ID %>"/><%=r.RoleName%></li>                                                
                                             <%
}
                                                 }
                                                 } %>
                                                 </ul>
                                             </td>
                                          
                                                </td>
                                            </tr>
                                            
                                        </table>
                                    </td>
                                </tr>
                                <tr><td colspan="3" align="center">
                                    <asp:Button ID="btnOK" runat="server" Text="提交" onclick="btnOK_Click" /></td></tr>
                            </table>
                            <table width="95%" border="0" align="center" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td height="6">
                                        <img src="../images/spacer.gif" width="1" height="1" />
                                    </td>
                                </tr>
                                <tr>
                                    <td height="33">
                                         
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                 
    </form>
    <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".del").click(function () {
                if (confirm("确定要删除吗？")) {
                    var id = $(this).attr("id");
                    $.getJSON("/Hander/hander.ashx?act=roledel&jsoncallback=?", { id: id }, function (data) {
                        if (data.status == "1") {
                            alert(data.html);
                            window.location = "addlistrole.aspx";
                        }
                        else {
                            alert(data.html);
                        }
                    });
                }
            });
        });
    </script>
</body>
</html>

