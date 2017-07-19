<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="DistributedWeb.Login" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<title>分布式管理系统</title>
<style type="text/css">
<!--
body {
	margin-left: 0px;
	margin-top: 0px;
	margin-right: 0px;
	margin-bottom: 0px;
}
-->
</style>
<link href="css/css.css" rel="stylesheet" type="text/css" />
</head>

<body>
<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td height="147" background="images/top02.gif"><img src="images/top03.gif" width="776" height="147" /></td>
  </tr>
</table>
<form runat="server">
<table width="562" border="0" align="center" cellpadding="0" cellspacing="0" class="right-table03">
  <tr>
    <td width="221"><table width="95%" border="0" cellpadding="0" cellspacing="0" class="login-text01">
      
      <tr>
        <td><table width="100%" border="0" cellpadding="0" cellspacing="0" class="login-text01">
          <tr>
            <td align="center"><img src="images/ico13.gif" width="107" height="97" /></td>
          </tr>
          <tr>
            <td height="40" align="center">&nbsp;</td>
          </tr>
          
        </table></td>
        <td><img src="images/line01.gif" width="5" height="292" /></td>
      </tr>
    </table></td>
    <td><table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td width="31%" height="35" class="login-text02">用户名称：<br /></td>
        <td width="69%"><input name="textfield" type="text" id="txtName" size="30" runat="server"/></td>
      </tr>
      <tr>
        <td height="35" class="login-text02">密　码：<br /></td>
        <td><input name="textfield2" type="password" size="33" id="txtPwd" runat="server" /></td>
      </tr>
      <tr>
        <td height="35">&nbsp;</td>
        <td>
        <asp:Button  ID="btnLogin" runat="server" Text="确认登陆"  CssClass="right-button01" 
                onclick="btnLogin_Click"/>
          <input name="Submit232" type="submit" class="right-button02" value="重 置" /></td>
      </tr>
    </table></td>
  </tr>
</table>
</form>
</body>
</html>
