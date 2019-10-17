<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="SageItemCat.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="Scripts/jquery-3.0.0.min.js"></script>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="align-content-center">
            <asp:Button runat="server" CssClass="btn btn-success" Text="Get Data" ID="btnGet" OnClick="btnGet_Click" />
            <asp:Label ID="fv" runat="server"></asp:Label>

            <asp:Label ID="sv" runat="server" ></asp:Label>
        </div>
    </form>
</body>
</html>
