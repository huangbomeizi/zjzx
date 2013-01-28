<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="zjzx._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>首页</title>
    <script src="js/jquery-1.8.0.js" type="text/javascript"></script>
    <script type="text/javascript">
    $(document).ready(function(){
        var h = $(document).height();
        $('#menu,#right').height(h-20);
    });
    </script>
</head>
<body>
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td width="15%" style="border-right:1px solid gray">
                <iframe id="menu" name="menu" src="menu.aspx" scrolling="no" frameborder="0" style="width:150px; border:0px; overflow:hidden"></iframe>
            </td>
            <td width="85%">
                <iframe id="right" name="right" scrolling="no" src="" frameborder="0" style="width:100%; border:0px;overflow:hidden"></iframe>
            </td>
        </tr>
    </table>
</body>
</html>
