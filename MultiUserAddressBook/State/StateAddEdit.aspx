<%@ Page Title="" Language="C#" MasterPageFile="~/AddressBookMasterPage.master" AutoEventWireup="true" CodeFile="StateAddEdit.aspx.cs" Inherits="State_StateAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageContent" Runat="Server">
    <br /><br /><br /><br /><br /><br />
    <div class="container">
        <div class="row">
            <div class="col-md-6">
                <asp:Label ID="lblPageHeader" runat="server" Text="" Font-Bold="true" Font-Size="X-Large" CssClass="alert-success"></asp:Label>
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
                    <asp:Label ID="lblCountryName" runat="server" Text="CountryName" Font-Bold="true"  Font-size="Large"></asp:Label>
                </div>
                <div class="col-md-2">
                    <asp:DropDownList ID="ddlCountryID" runat="server" CssClass="form-control"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvddlCountryID" runat="server" ErrorMessage="Select CountryName" ControlToValidate="ddlCountryID" Display="Dynamic" ForeColor="Red" InitialValue="-1" ValidationGroup="save"></asp:RequiredFieldValidator>
                </div>
            </div>
        <br />
            <div class="row">
                <div class="col-md-2">
                    <asp:Label ID="lblStateName" runat="server" Text="StateName" Font-Bold="true"  Font-size="Large"></asp:Label>
                </div>
                <div class="col-md-2">
                    <asp:TextBox ID="txtStateName" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvStateName" runat="server" ErrorMessage="Enter StateName" ControlToValidate="txtStateName" Display="Dynamic" ForeColor="Red" ValidationGroup="save"></asp:RequiredFieldValidator>
                </div>
            </div>
        <br />
            <div class="row">
                <div class="col-md-2"></div>
                <div class="col-md-1">
                    <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-info" Onclick="btnSave_Click" ValidationGroup="save"/>
                </div>
               
                <div class="col-md-1">
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-danger" OnClick="btnCancel_Click"/>
                </div>
            </div>
        </div>
      
</asp:Content>

