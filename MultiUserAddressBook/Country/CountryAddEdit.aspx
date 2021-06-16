<%@ Page Title="" Language="C#" MasterPageFile="~/AddressBookMasterPage.master" AutoEventWireup="true" CodeFile="CountryAddEdit.aspx.cs" Inherits="Country_CountryAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageContent" Runat="Server">
     <br /><br /><br /><br /><br /><br />
    <div class="container responsive">
        <div class="row">
            <div class="col-md-6">
                <asp:Label ID="lblPageHeader" runat="server" Text="" Font-Bold="true" Font-Size="X-Large" CssClass="alert-info"></asp:Label>
            </div>
        </div>
            <div class="row">
                <br /><br />
                <div class="col-md-12">
                    <asp:Label ID="lblErrorMessage" runat="server" Text="" EnableViewState="false"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-md-2">
                    <asp:Label ID="lblCountryName" runat="server" Text="CountryName" Font-Bold="true"  Font-size="Large"></asp:Label>
                </div>
                <div class="col-md-2">
                    <asp:TextBox ID="txtCountryName" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvContryName" runat="server" ErrorMessage="Enter CountryName" ControlToValidate="txtCountryName" Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ValidationGroup="save"></asp:RequiredFieldValidator>
                </div>
            </div>
        <br />
            <div class="row">
                <div class="col-md-2">
                    <asp:Label ID="lblCountryCode" runat="server" Text="CountryCode" Font-Bold="true"  Font-size="Large"></asp:Label>
                </div>
                <div class="col-md-2">
                    <asp:TextBox ID="txtCountryCode" runat="server" CssClass="form-control"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="rfvContryCode" runat="server" ErrorMessage= "Enter CountryCode" ControlToValidate="txtCountryCode" Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ValidationGroup="save"></asp:RequiredFieldValidator>
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

