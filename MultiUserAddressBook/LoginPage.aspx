<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LoginPage.aspx.cs" Inherits="LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
   <link href="~/Bootstrape/css/bootstrap.min.css" rel="stylesheet" />
    <link href="~/Bootstrape/css/bootstrap-theme.min.css" rel="stylesheet" />
    <script src="~/Bootstrape/js/bootstrap.min.js"></script>
    
</head>
<body class="bg-info">
    <form id="form1" runat="server">
         <div class="container bg-success">
        <div class="row">
            <div class="col-md-6 alert-info">
                <br /><br /><br /><br /><br /><br /> <br /><br /><br />
                <h1>Login</h1>
            </div>
        </div>
            <br />
        <div class="row">
            <div class="col-md-12">
                <asp:Label ID="lblErrorMessage" runat="server" Text="" CssClass="danger" EnableViewState="false"></asp:Label>
            </div>
        </div>
        <div class="row">
            <div class="col-md-2">
                UserName
            </div>
            <div class="col-md-4">
                <asp:TextBox ID="txtLoginUserName" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvUserName" runat="server" ErrorMessage="Enter UserName" ControlToValidate="txtLoginUserName" Display="Dynamic" ForeColor="Red" ValidationGroup="Login"></asp:RequiredFieldValidator>
            </div>
        </div>
            <br />
        <div class="row">
            <div class="col-md-2">
                Password
            </div>
            <div class="col-md-4">
                <asp:TextBox ID="txtLoginPassword" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ErrorMessage="Enter Password" ControlToValidate="txtLoginPassword" Display="Dynamic" ForeColor="Red" ValidationGroup="Login"></asp:RequiredFieldValidator>
            </div>
        </div>
            <br />
            <div class="row">
                <div class="col-md-2"></div>
                <div class="col-md-2">
                    <asp:Button ID="btnLogin" runat="server" Text="Login"  CssClass="btn btn-info" ValidationGroup="Login" OnClick="btnLogin_Click"/>
                </div>
            </div><br />
            <div class="row">
                <div class="col-md-2"></div>
                <div class="col-md-4">
                    <asp:HyperLink ID="hpCreteAC" runat="server" CssClass="text-info" NavigateUrl="~/LoginPage.aspx"><u>Create New User</u></asp:HyperLink>
                </div>
            </div>
            </div>
        <div class="container bg-success">
        <div class="row">
            <div class="col-md-6 alert-info">
                <h1>Register New User</h1>
            </div>
        </div>
            <br />
            <div class="row">
                <div class="col-md-12">
                    <asp:Label ID="lblRegisterMessage" runat="server" Text="" EnableViewState="false"></asp:Label>
                </div>
            </div>
        <div class="row">
            <div class="col-md-12">
                <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
            </div>
        </div>
        <div class="row">
            <div class="col-md-2">
                UserName
            </div>
            <div class="col-md-4">
                <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvRegUserName" runat="server" ErrorMessage="Enter UserName" ControlToValidate="txtUserName" Display="Dynamic" ForeColor="Red" ValidationGroup="Register"></asp:RequiredFieldValidator>
            </div>
        </div>
            <br />
        <div class="row">
            <div class="col-md-2">
                Password
            </div>
            <div class="col-md-4">
                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvRegPassword" runat="server" ErrorMessage="Enter Password" ControlToValidate="txtPassword" Display="Dynamic" ForeColor="Red" ValidationGroup="Register"></asp:RequiredFieldValidator>
            </div>
        </div>
            <br />
            <div class="row">
            <div class="col-md-2">
                DisplayName
            </div>
            <div class="col-md-4">
                <asp:TextBox ID="txtDisplayName" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvRegDisplayName" runat="server" ErrorMessage="Enter DisplayName" ControlToValidate="txtDisplayName" Display="Dynamic" ForeColor="Red" ValidationGroup="Register"></asp:RequiredFieldValidator>
            </div>
        </div>
            <br />
        <div class="row">
            <div class="col-md-2">
                MobileNo
            </div>
            <div class="col-md-4">
                <asp:TextBox ID="txtMobileNo" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvRegMobileNo" runat="server" ErrorMessage="Enter MobileNo" ControlToValidate="txtMobileNo" Display="Dynamic" ForeColor="Red" ValidationGroup="Register"></asp:RequiredFieldValidator>
            </div>
        </div>
            <br />
            <div class="row">
                <div class="col-md-2"></div>
                <div class="col-md-2">
                    <asp:Button ID="btnAddNewUser" runat="server" Text="Add New"  CssClass="btn btn-info" OnClick="btnAddNewUser_Click" ValidationGroup="Register"/>
                </div>
            </div><br />
           </div> 
    </form>
</body>
</html>
