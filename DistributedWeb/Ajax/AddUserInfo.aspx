<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddUserInfo.aspx.cs" Inherits="DistributedWeb.AddUserInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<title>例子添加</title>
<link rel="stylesheet" rev="stylesheet" href="/css/style.css" type="text/css" media="all" /> 
    <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="Scripts/adduser.js" type="text/javascript"></script>
</head>

<body class="ContentBody">
<form id="Form1"  >
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
			<td class="TablePanel">添加用户</td>
		</tr>
			<TR>
			<TD width="100%">
				<fieldset style="height:100%;">
				<legend>添加信息</legend>
					  <table border="0" cellpadding="2" cellspacing="1" style="width:100%">
					 
                     <tr>
					    <td nowrap align="right" width="15%">登陆用户名:</td>
					    <td width="35%"><input name='txt3' type="text" class="text" style="width:154px" value="" id="txtLoginUserName" />
				         
                          </td>
					    <td width="16%" align="right" nowrap="nowrap">用户状态:</td>
					    <td width="34%">
                          <select id="ddlUserStatus">
                          <option value="0">正常</option>
                          <option value="1">冻结</option>
                          <option value="2">删除</option>
                          <option value="3">禁用</option>
                          </select>
                          </td>
					  </tr>
                      <tr>
					    <td nowrap align="right" width="15%">登陆密码:</td>
					    <td width="35%"><input name='txt3' type="text" class="text" style="width:154px" value="" id="txtPwd" />
				         
                          </td>
					    <td width="16%" align="right" nowrap="nowrap">登陆类型:</td>
					    <td width="34%">
                          <select id="ddlLoginType">
                          <option value="0">超级用户</option>
                          <option value="1">Web端登录用户</option>
                          <option value="2">客户端登录用户</option>
                          <option value="3">服务端用户</option>
                           <option value="4">移动端用户</option>
                          </select>
                          </td>
					  </tr>


					  <tr>
					    <td nowrap align="right" width="15%">用户名称:</td>
					    <td width="35%"><input name='txt3' type="text" class="text" style="width:154px" value="" id="txtUserName" />
				         
                          </td>
					    <td width="16%" align="right" nowrap="nowrap">用户性别:</td>
					    <td width="34%">
                          <select id="ddlGender">
                          <%=GetOptions(GenderList)%>
                          </select>
                          </td>
					  </tr>
					    
					    
					  <tr>
					    <td nowrap="nowrap" align="right">手机号:</td>
					    <td><input class="text" name='datevalue21' style="width:154px" value="" id="txtPhone"/>
                            
                          </td>
					    <td align="right">生肖:</td>
					    <td>
                          <select id="ddlZodiac">
                          <%=GetOptions(ZodiacList)%>
                          </select>
                          </td>
					  </tr>
					  <tr>
					    <td align="right">所在省:</td>
						<td>
                            <select id="ddlProv">
                          <%=GetOptions(ProvList)%>
                          </select>
						</td>
					    <td align="right">所在市:</td>
					    <td>
                             <select id="ddlCity">
                          <%=GetOptions(CityList)%>
                          </select>
						</td>
					  </tr>
					  <tr>
                        <td align="right">星座:</td>
					    <td>
                          <select id="ddlConstellation">
                          <%=GetOptions(ConstellationList)%>
                          </select>
						</td>
					    <td align="right">学历:</td>
					    <td>
                          <select id="ddlDegree">
                          <%=GetOptions(DegreeList)%>
                          </select>
						</td>
					    </tr>
					  <tr>
                        <td align="right">民族:</td>
					    <td>  
                          <select id="ddlNation">
                          <%=GetOptions(NationList)%>
                          </select>
                          </td>
					    <td align="right"></td>
					    <td>
                       
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
			 
               <input type="button" name="Submit2" value="添加" class="button" id="btnsave" />
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

