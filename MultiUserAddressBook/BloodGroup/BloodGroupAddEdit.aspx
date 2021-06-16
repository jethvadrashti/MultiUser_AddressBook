<%@ Page Title="" Language="C#" MasterPageFile="~/AddressBookMasterPage.master" AutoEventWireup="true" CodeFile="BloodGroupAddEdit.aspx.cs" Inherits="BloodGroup_BloodGroupAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageContent" Runat="Server">
     <br /><br /><br /><br /><br /><br />
    <div class="container">
        <div class="row">
            <div class="col-md-6">
                <asp:Label ID="lblPageHeader" runat="server" Text="" Font-Bold="true" CssClass="alert-danger text-center" Font-Size="XX-Large"></asp:Label>
            </div>
            
            </div>
            <div class="row">
                <br /><br />
                <div class="col-md-12">
                    <asp:Label ID="lblErrorMessage" runat="server" Text="" EnableViewState="false" CssClass="text-danger"></asp:Label>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-md-2">
                    <asp:Label ID="lblBloodGroup" runat="server" Text="BloodGroup" Font-size="Large" Font-Bold="true"></asp:Label>
                </div>
                <br /><br />
                <div class="col-md-2">
                    <asp:TextBox ID="txtBloodGroup" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvBloodGroup" runat="server" ErrorMessage="Enter BloodGroup" ControlToValidate="txtBloodGroup" Display="Dynamic" ForeColor="Red" ValidationGroup="save"></asp:RequiredFieldValidator>
                </div>
             </div>
            <br />
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
    </div></div>
</asp:Content>

