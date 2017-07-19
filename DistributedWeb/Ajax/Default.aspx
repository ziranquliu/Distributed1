<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DistributedWeb.Default" %>

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
    <form name="fom" id="fom" method="post" action="">
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
                                        <select id="type">
                                            <option value="1">名称</option>
                                            <option value="2">ID</option>
                                        </select>
                                        <input name="txtKey" id="txtKey" type="text" size="12" />
                                        <input name="btnsearch" id="btnsearch" type="button" class="right-button02" value="搜索" />
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
                                                    共<span class="right-text09" id="totalcounts">0</span>条记录 每页显示<span class="right-text09"
                                                        id="pagesize">0</span>条记录 | 共<span class="right-text09" id="totalpage">0</span>
                                                    页 | 第 <span class="right-text09" id="pageIndex">0</span>页
                                                </td>
                                                <td width="49%" align="right">
                                                    [<a href="#" class="right-font08" id="first">首页</a> | <a href="#" id="previous" class="right-font08">
                                                        上一页</a> | <a href="#" id="next" class="right-font08">下一页</a> | <a href="#" id="end"
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
                <script src="/Scripts/jquery-1.4.1.js" type="text/javascript"></script>
                <script src="Scripts/default.js" type="text/javascript"></script>
    </form>
</body>
</html>
