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
                    <asp:TextBox ID="txtSGDH" runat="server"></asp:TextBox>
                </td>
                <th width="140px" class="top"><span style="color:Red">*</span>申购人：</th>
                <td class="top">
                    <asp:TextBox ID="txtSGR" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>标准：</th>
                <td colspan="3">
                    标准号：<asp:TextBox ID="txtBZH" runat="server"></asp:TextBox>
                    &nbsp;
                    标准名称：<asp:TextBox ID="txtBZMC" runat="server"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td></td>
                <td colspan="3">
                    标准号：<asp:TextBox ID="txtBZH2" runat="server"></asp:TextBox>
                    &nbsp;
                    标准名称：<asp:TextBox ID="txtBZMC2" runat="server"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td></td>
                <td colspan="3">
                    标准号：<asp:TextBox ID="txtBZH3" runat="server"></asp:TextBox>
                    &nbsp;
                    标准名称：<asp:TextBox ID="txtBZMC3" runat="server"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td></td>
                <td colspan="3">
                    标准号：<asp:TextBox ID="txtBZH4" runat="server"></asp:TextBox>
                    &nbsp;
                    标准名称：<asp:TextBox ID="txtBZMC4" runat="server"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td></td>
                <td colspan="3">
                    标准号：<asp:TextBox ID="txtBZH5" runat="server"></asp:TextBox>
                    &nbsp;
                    标准名称：<asp:TextBox ID="txtBZMC5" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td></td>
                <td colspan="3">
                    标准号：<asp:TextBox ID="txtBZH6" runat="server"></asp:TextBox>
                    &nbsp;
                    标准名称：<asp:TextBox ID="txtBZMC6" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td></td>
                <td colspan="3">
                    标准号：<asp:TextBox ID="txtBZH7" runat="server"></asp:TextBox>
                    &nbsp;
                    标准名称：<asp:TextBox ID="txtBZMC7" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td></td>
                <td colspan="3">
                    标准号：<asp:TextBox ID="txtBZH8" runat="server"></asp:TextBox>
                    &nbsp;
                    标准名称：<asp:TextBox ID="txtBZMC8" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td></td>
                <td colspan="3">
                    标准号：<asp:TextBox ID="txtBZH9" runat="server"></asp:TextBox>
                    &nbsp;
                    标准名称：<asp:TextBox ID="txtBZMC9" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td></td>
                <td colspan="3">
                    标准号：<asp:TextBox ID="txtBZH10" runat="server"></asp:TextBox>
                    &nbsp;
                    标准名称：<asp:TextBox ID="txtBZMC10" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>申购原因：</th>
                <td colspan="3">
                    <asp:TextBox ID="txtSGYY" runat="server"  Width="525px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>部长：</th>
                <td>
                    <asp:TextBox ID="txtBuZhang" runat="server"></asp:TextBox>
                </td>
                <th>是否同意：</th>
                <td>
                    <asp:DropDownList ID="ddlBuZhangeTongYi" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <th>部长意见：</th>
                <td colspan="3">
                    <asp:TextBox ID="txtBuZhangeYiJian" runat="server"  Width="525px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>执行情况：</th>
                <td colspan="3">
                    <asp:TextBox ID="txtZXQK" runat="server"  Width="525px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                
                <td colspan="4" align="center" style="height:35px">
                    <asp:Button ID="btnSave" runat="server" Text="保 存" CssClass="button" />&nbsp;
                    <asp:Button ID="btnCancle" runat="server" Text="取 消" CssClass="button"/>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
