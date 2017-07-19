<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListFunction.aspx.cs" Inherits="DistributedWeb.ListFunction" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>功能管理</title>
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
                                        <input name="btnadd" id="btnadd" type="button" class="right-button08" value="添加功能" />
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
                                            <td width="5%">功能名称</td>
                                           <%-- <td width="5%">功能地址</td>
                                            <td width="5%">图标</td> --%>
                                            <td width="5%">状态</td>   
                                            <td width="12%">操作</td>
                                            </tr>
                                            <% if (funclist.Any())
                                               {
                                                   var funcalllist = bll.FindALL();
                                                   foreach (var f in funclist)
                                                   {
                                                   %>
                                            <tr bgcolor="#ffffcc">
                                            <td height="30"><%=f.ID%></td>
                                            <td>
                                            <a href="javascript:;" showid="<%=f.ID %>" class="btlink">
                                            <%=f.FunctionName%>
                                            </a>
                                            </td>
                                           <%-- <td><%=f.FunctionPath%></td>
                                            <td><%=f.Icon%></td>--%>
                                            <td><input type="checkbox" checked="<%=f.IsEnable%>"  disabled="disabled"/></td>
                                            <td><a href="AddFunction.aspx?id=<%=f.ID %>">编辑|</a> 
                                               <a href="#" id="<%=f.ID %>" class="del">删除</a></td>
                                                 
                                            </tr>
                                                    <%
                                                        var list = funcalllist.Where(func => func.ParentId == f.ID);
                                                        if (list.Any())
                                                        {
                                                            foreach (var s in list)
                                                            {          
                                                     %>
                                                              <tr bgcolor="#FFFFFF"  class="show<%=f.ID %>">
                                                              <td height="30"><%=s.ID%></td>
                                                              <td><%=s.FunctionName%></td>
                                                             <%-- <td><%=s.FunctionPath%></td>
                                                              <td><%=s.Icon%></td>--%>
                                                              <td><input type="checkbox" checked="<%=s.IsEnable%>"  disabled="disabled"/></td>
                                                              <td><a href="AddFunction.aspx?id=<%=s.ID %>">编辑|</a> 
                                                              <a href="#" id="<%=s.ID %>" class="del">删除</a></td>
                                                              </tr>

                                            <%               }
                                                        }
                                                   }
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
                                                    [<a href="ListFunction.aspx?pageIndex=1" class="right-font08" id="first">首页</a> | <a href="ListFunction.aspx?pageIndex=<%=previosPgIndex %>" id="previous" class="right-font08">
                                                        上一页</a> | <a href="ListFunction.aspx?pageIndex=<%=nextPgIndex %>" id="next" class="right-font08">下一页</a> | <a href="ListFunction.aspx?pageIndex=<%=totalPage %>" id="end"
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
    <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="Scripts/listfunc.js" type="text/javascript"></script>
</body>
</html>
