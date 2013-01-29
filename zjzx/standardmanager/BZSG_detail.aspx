<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BZSG_detail.aspx.cs" Inherits="zjzx.standardmanager.BZSG_detail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>标准申购单</title>
    <link href="../css/global.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <br />
        <table width="700px" cellpadding="0" cellspacing="0" class="detailtable">
            <tr>
                <th width="140px" class="top"><span style="color:Red">*</span>申购单号：</th>
                <td width="200px" class="top">
                    <asp:TextBox ID="txtSbmc" runat="server"></asp:TextBox>
                </td>
                <th width="140px" class="top"><span style="color:Red">*</span>申购人：</th>
                <td class="top">
                    <asp:TextBox ID="txtSgr" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>标准：</th>
                <td colspan="3">
                    标准号：<asp:TextBox ID="txtSbxh" runat="server"></asp:TextBox>
                    &nbsp;
                    标准名称：<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td></td>
                <td colspan="3">
                    标准号：<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                    &nbsp;
                    标准名称：<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td></td>
                <td colspan="3">
                    标准号：<asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                    &nbsp;
                    标准名称：<asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td></td>
                <td colspan="3">
                    标准号：<asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                    &nbsp;
                    标准名称：<asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td></td>
                <td colspan="3">
                    标准号：<asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
                    &nbsp;
                    标准名称：<asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>申购原因：</th>
                <td colspan="3">
                    <asp:TextBox ID="txtSgyy" runat="server"  Width="525px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                
                <td colspan="4" align="center" style="height:35px">
                <asp:Button ID="Button1" runat="server" Text="保 存" CssClass="button" />
                <asp:Button ID="Button2" runat="server" Text="取 消" CssClass="button"/>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
