<%@ Page Title="" Language="C#" MasterPageFile="~/AddressBookMasterPage.master" AutoEventWireup="true" CodeFile="CityAddEdit.aspx.cs" Inherits="City_CityAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageContent" Runat="Server">
     <br /><br /><br /><br /><br /><br />
    <div class="container">
        <div class="row">
            <div class="col-md-6">
                <asp:Label ID="lblPageHeader" runat="server" Text="" Font-Bold="true" CssClass="alert-info text-center" Font-Size="XX-Large"></asp:Label>
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
                    <asp:Label ID="lblStateName" runat="server" Text="StateName" Font-size="Large" Font-Bold="true"></asp:Label>
                </div>
                <div class="col-md-2">
                    <asp:DropDownList ID="ddlStateID" runat="server" CssClass="form-control"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvddlStateID" runat="server" ErrorMessage="Select StateName" ControlToValidate="ddlStateID" Display="Dynamic" ForeColor="Red" InitialValue="-1" ValidationGroup="save"></asp:RequiredFieldValidator>
                </div>
            </div>
        <br />
            <div class="row">
                <div class="col-md-2">
                    <asp:Label ID="lblCityName" runat="server" Text="CityName" Font-size="Large" Font-Bold="true"></asp:Label>
                </div>
                <div class="col-md-2">
                    <asp:TextBox ID="txtCityName" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvCityName" runat="server" ErrorMessage="Enter CityName" ControlToValidate="txtCityName" Display="Dynamic" ForeColor="Red" ValidationGroup="save"></asp:RequiredFieldValidator>
                </div>
            </div>
        <br />
              <div class="row">
                <br />
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

