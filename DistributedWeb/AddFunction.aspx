<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddFunction.aspx.cs" Inherits="DistributedWeb.AddFunction" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<title>例子添加</title>
<link rel="stylesheet" rev="stylesheet" href="/css/style.css" type="text/css" media="all" /> 
    <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="Scripts/add.js" type="text/javascript"></script>
</head>

<body class="ContentBody">
    <form id="Form1" runat="server">
<div class="MainDiv">
<table width="99%" border="0" cellpadding="0" cellspacing="0" class="CContent">
  <tr>
      <th class="tablestyle_title" >添加用户</th>
  </tr>
  <tr>
    <td class="CPanel">
		
		<table border="0" cellpadding="0" cellspacing="0" style="width:100%">
		<tr>
			<td align="left">
				　			
				<input type="button" name="Submit2" value="返回" class="button" onclick="window.history.go(-1);"/>			</td>
		</tr>
		<tr align="center">
			<td class="TablePanel">添加功能</td>
		</tr>
			<TR>
			<TD width="100%">
				<fieldset style="height:100%;">
				<legend>添加功能</legend>
					  <table border="0" cellpadding="2" cellspacing="1" style="width:100%">
					  
					  <tr>
                        <td align="right">所在菜单:</td>
					    <td>  
                          <select id="ddlMenu" runat="server">
                          <option value="0">根目录</option>
                          </select>
                          </td>
					    </tr>
                     <tr>
					    <td nowrap align="right" width="15%">功能名称:</td>
					    <td width="35%"><input name='txt3' type="text" class="text" style="width:154px" value="" id="txtFuncName" runat="server"/>
				         
                            <asp:RequiredFieldValidator ID="requireFuncName" runat="server" 
                                ControlToValidate="txtFuncName" ErrorMessage="*" ForeColor="#FF3300"></asp:RequiredFieldValidator>
				         
                          </td>
					  </tr>
                      <%--<tr>
					    <td nowrap align="right" width="15%">功能路径:</td>
					    <td width="35%"><input name='txt3' type="text" class="text" style="width:154px" value="" id="txtFuncPath"  runat="server"/>
                          </td>
					  </tr>


					  <tr>
					    <td nowrap align="right" width="15%">功能图标:</td>
					    <td width="35%"> 
                        <input type="file" id="uploadIcon" name="uploadIcon" accept="image/gif, image/jpeg, image/png" value=''/>
                        <input name='txt3' type="text" class="text" style="width:154px" value="" id="txtFuncIcon"   runat="server"/>
                         </td>
					  </tr>--%>
					    
					    
					  <tr>
					    <td nowrap="nowrap" align="right">是否启用:</td>
					    <td>
                         <input id="ckIsEnable" type="checkbox" checked="checked" runat="server"/>
                        </td>
                          
					  </tr>
					   
					  
					 
					  </table>
			  <br />
				</fieldset>			</TD>
		</TR>
		</TABLE>
	
	
	 </td>
  </tr>
  
  
		
		
		
		<TR>
			<TD colspan="2" align="center" height="50px">
			 
                <asp:Button ID="btnOk" runat="server" CommandName="add" Text="添加" CssClass="button" 
                    onclick="btnOk_Click"/>
			<input type="button" name="Submit2" value="返回" class="button" onclick="window.history.go(-1);"/></TD>
		</TR>
		</TABLE>
	
	
	 </td>
  </tr>
  
  
  
  </table>

</div>

    </form>
</body>
</html>


