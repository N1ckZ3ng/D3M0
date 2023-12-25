<%@ Page Language="C#" AutoEventWireup="true" CodeFile="viewstate_test.aspx.cs" Inherits="_Default2" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .output-label {
            font-size: 20px; 
            display: block; 
            margin-top: 10px; 
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="txtInput" runat="server"></asp:TextBox>
            <asp:Button ID="btnSave" runat="server" Text="submit" OnClick="btnSave_Click" />
            <span class="output-label">Previous: </span>
            <asp:Label ID="lblOutput" runat="server" Text="" CssClass="output-label"></asp:Label>
        </div>
    </form>
</body>
</html>
