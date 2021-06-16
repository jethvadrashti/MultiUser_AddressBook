<%@ Page Title="" Language="C#" MasterPageFile="~/AddressBookMasterPage.master" AutoEventWireup="true" CodeFile="ContactCategoryAddEdit.aspx.cs" Inherits="ContactCategory_ContactCategoryAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageContent" Runat="Server">
     <br /><br /><br /><br /><br /><br />
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <asp:Label ID="lblHeader" runat="server" Text="" Font-Bold="true" CssClass="alert-success text-center" Font-Size="XX-Large"></asp:Label>
            </div>
        </div>
       
            <div class="row">
                <br /><br />
                <div class="col-md-12">
                    <asp:Label ID="lblErrorMessage" runat="server" Text="" EnableViewState="false" CssClass="text-danger"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-md-2">
                    <asp:Label ID="lblContactCategory" runat="server" Text="ContactCategory"  Font-size="Large" Font-Bold="true"></asp:Label>
                </div>
                <div class="col-md-2">
                    <asp:TextBox ID="txtContactCategory" runat="server" ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvContactCategory" runat="server" ErrorMessage="Enter Category" ControlToValidate="txtContactCategory" Display="Dynamic" ForeColor="Red" ValidationGroup="save"></asp:RequiredFieldValidator>
                </div>
             </div>
        <div class="row">
                <br />
                <div class="col-md-2"></div>
                <div class="col-md-1"><br />
                    <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-info" Onclick="btnSave_Click" ValidationGroup="save"/>
                </div>
                <div class="col-md-1"><br />
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-danger" OnClick="btnCancel_Click"/>
                </div>
            </div>
    </div>

    
</asp:Content>

