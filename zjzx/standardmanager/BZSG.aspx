<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BZSG.aspx.cs" Inherits="zjzx.standardmanager.BZSG" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link href="../css/global.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery-1.8.0.js" type="text/javascript"></script>
    <script src="../js/global.js" type="text/javascript"></script>
</head>
<body>
    <form id="form" runat="server">
    <div id="search">
        <ul>
            <li>标准名称：<input type="text" /></li>
            <li>标准代码：<input type="text" /></li>
            <li><input type="button" value="搜索"/></li>
        </ul>
    </div>
    <div id="function">
        <ul>
            <li><input type="button" value="增加"/></li>
            <li><input type="button" value="删除"/></li>
        </ul>
    </div>
    <div id="list">
        <table id="mytable">
            <tr>
                <th width="8%">
                    <input type="checkbox" onclick="checkAll(this);" />选择
                </th>
                <th>序号</th>
                <th>标题</th>
                <th>替换文字</th>
                <th>链接</th>
                <th>排序号</th>
                <th>显示</th>
                <th>操作</th>
             </tr>
            <asp:Repeater ID="rData" runat="server">
                <ItemTemplate>
                    <tr>
                        <td><input type="checkbox" name="checkRow" /></td>
                        <td><%#Container.ItemIndex+1 %></td>
                        <td title='<%#Eval("link_name") %>' style="cursor:pointer"></td>
                        <td><%#Eval("alt")%></td>
                        <td><%#Eval("url")%></td>
                        <td><%#Eval("order_by") %></td>
                        <td><%#bool.Parse(Eval("is_show").ToString())?"是":"否"%></td>
                        <td>
                            <asp:LinkButton ID="btnUpdate" runat="server" Text="修改" CommandName="update" CommandArgument='<%#Eval("Id") %>' />&nbsp;
                            <asp:LinkButton ID="btnDelete" runat="server" Text="删除" CommandName="delete" CommandArgument='<%#Eval("Id") %>' OnClientClick="return ask()" />
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            <tr>
                <td colspan="8" align="center">
                    <asp:Literal ID="lempty" runat="server" Text="未找到任何数据记录！"></asp:Literal>
                </td>
            </tr>
        </table>
    </div>
    <div id="page">
        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CustomInfoHTML="第%CurrentPageIndex%页，共%PageCount%页，共%RecordCount%条记录"
                CustomInfoTextAlign="left" FirstPageText="首页" LastPageText="尾页" LayoutType="Table" 
                NextPageText="下一页" PagingButtonLayoutType="Span" PrevPageText="上一页" ShowPageIndex="false"
                ShowCustomInfoSection="left" SubmitButtonText="Go" TextAfterPageIndexBox="页"
                TextBeforePageIndexBox="跳转到" PageSize="10" AlwaysShow="true" ShowPageIndexBox="Always" Width="450"
                OnPageChanged="AspNetPager1_PageChanged"></webdiyer:AspNetPager>  
         
    </div>
    </form>
</body>
</html>
