<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoleFunction.aspx.cs" Inherits="DistributedWeb.RoleFunction" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>����</title>
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
                                            <td width="5%" height="30">ID</td>
                                            <td width="5%">����</td>
                                            <td width="5%">����</td>
                                            </tr>
                                            <% if (funclist.Any())
                                               {
                                                   //������ѭ������Ȩ���б�ʱ��ȡ���е�Ȩ���б�  ������ѭ��ʱ����  �����ظ��������ݿ�
                                                   var funcalllist = fucbll.FindALL();
                                                   foreach (var f in funclist)
                                                   {
                                                   %>
                                            <tr bgcolor="#FFFFFF">
                                            <td height="30"><%=f.ID%></td>
                                            <td><%=f.FunctionName%></td>
                                             <td width="5%">
                                              <ul>
                                             <%
                                                 //ÿ��ѭ��ֻ�����ڴ��н���linq��ѯ �����˶���������ݿ�
                                                 var list = funcalllist.Where(func => func.ParentId == f.ID);
                                                 if (list.Any())
                                                 {
                                                     foreach (var s in list)
                                                     {
                                                         //�жϽ�ɫ�Ƿ�ӵ�и�Ȩ�ޡ�ӵ����checked ����no checked
                                                         if (funids.Contains(s.ID))
                                                         {       
                                             %>
                                            
                                             <li><input type="checkbox" checked="checked" name="cked" value="<%=s.ID %>"/><%=s.FunctionName%></li>                                             
                                             <%}
                                                         else
                                                         { %>
                                             <li><input type="checkbox" name="ck" value="<%=s.ID %>"/><%=s.FunctionName%></li>                                             
                                             <%}
                                                    }
                                                 } %>
                                                 </ul>
                                             </td>
                                          
                                                </td>
                                            </tr>
                                            <%}
                                               }%>
                                        </table>
                                    </td>
                                </tr>
                                <tr><td colspan="3" align="center">
                                    <asp:Button ID="btnOK" runat="server" Text="�ύ" onclick="btnOK_Click" /></td></tr>
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
                                                    ��<span class="right-text09" id="totalcounts"><%=totalcounts %></span>����¼ ÿҳ��ʾ<span class="right-text09"
                                                        id="pagesize"><%=pageSize %></span>����¼ | ��<span class="right-text09" id="totalpage"><%=totalPage %></span>
                                                    ҳ | �� <span class="right-text09" id="pageIndex"><%=pgindex %></span>ҳ
                                                </td>
                                                <td width="49%" align="right">
                                                    [<a href="RoleFunction.aspx?pageIndex=1" class="right-font08" id="first">��ҳ</a> | <a href="RoleFunction.aspx?pageIndex=<%=previosPgIndex %>" id="previous" class="right-font08">
                                                        ��һҳ</a> | <a href="RoleFunction.aspx?pageIndex=<%=nextPgIndex %>" id="next" class="right-font08">��һҳ</a> | <a href="RoleFunction.aspx?pageIndex=<%=totalPage %>" id="end"
                                                            class="right-font08">βҳ</a>]
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
    <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".del").click(function () {
                if (confirm("ȷ��Ҫɾ����")) {
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
