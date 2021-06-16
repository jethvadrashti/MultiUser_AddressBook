<%@ Page Title="" Language="C#" MasterPageFile="~/AddressBookMasterPage.master" AutoEventWireup="true" CodeFile="ContactAddEdit.aspx.cs" Inherits="Contact_ContactAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageContent" runat="Server">
     <br /><br /><br /><br /><br /><br />
  <div class="container">
    
      <div class="row">
            <div class="col-md-12">
                <asp:Label ID="lblHeaderText" runat="server" Text="" Font-Bold="true" CssClass="alert-info text-center" Font-Size="XX-Large"></asp:Label>
            </div>
     </div>
        <div class="row">
            <br />
            <br />
            <div class="col-md-12">
                <asp:Label ID="lblErrorMessage" runat="server" Text="" EnableViewState="false" CssClass="text-danger"></asp:Label>
            </div>
        </div>
        <div class="row">
            <div class="col-md-2">
                <asp:Label ID="lblContactName" runat="server" Text="Contact Name" Font-Bold="true"  Font-size="Large"></asp:Label>
            </div>
            <div class="col-md-2">
                <asp:TextBox ID="txtContactName" runat="server" CssClass="form-control" Columns="2" MaxLength="10" Width="500px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvContactName" runat="server" ErrorMessage="Enter ContactName" ControlToValidate="txtContactName" Display="Dynamic" ForeColor="Red" ValidationGroup="save"></asp:RequiredFieldValidator>
            </div>
        </div>
        <br />
         <div class="row">
            <div class="col-md-2">
                <asp:Label ID="lblMobileNo" runat="server" Text="Mobile No" Font-Bold="true"  Font-size="Large"></asp:Label>
            </div>
            <div class="col-md-2">
                <asp:TextBox ID="txtMobileNo" runat="server"  CssClass="form-control" Width="500px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvMobileNo" runat="server" ErrorMessage="Enter Mobile No" ControlToValidate="txtMobileNo" Display="Dynamic" ForeColor="Red"  ValidationGroup="save"></asp:RequiredFieldValidator>
            </div>
        </div>
        <br />
         <div class="row">
            <div class="col-md-2">
                <asp:Label ID="lblAddress" runat="server" Text="Address " Font-Bold="true"  Font-size="Large"></asp:Label>
            </div>
            <div class="col-md-2">
                <asp:TextBox ID="txtAddress" runat="server" Rows="4" TextMode="MultiLine"  CssClass="form-control" Width="500px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvAddress" runat="server" ErrorMessage="Enter Address" ControlToValidate="txtAddress" Display="Dynamic" ForeColor="Red"  ValidationGroup="save"></asp:RequiredFieldValidator>
            </div>
        </div>
        <br />
      <div class="row">
            <div class="col-md-2">
                <asp:Label ID="lblCountryID" runat="server" Text="Country Name" Font-Bold="true"  Font-size="Large"></asp:Label>
            </div>
            <div class="col-md-2">
                <asp:DropDownList ID="ddlCountryID" runat="server" CssClass="form-control" AutoPostBack="True"  Width="500px"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvCountryID" runat="server" ErrorMessage="Enter CountryName" ControlToValidate="ddlCountryID" Display="Dynamic" ForeColor="Red" InitialValue="-1"  ValidationGroup="save"></asp:RequiredFieldValidator>
            </div>
        </div>
      <br />
                <div class="row">
            <div class="col-md-2">
                <asp:Label ID="lblStateID" runat="server" Text="State Name" Font-Bold="true"  Font-size="Large"></asp:Label>
            </div>
            <div class="col-md-2">
                <asp:DropDownList ID="ddlStateID" runat="server" CssClass="form-control" AutoPostBack="True"  Width="500px"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvStateID" runat="server" ErrorMessage="Enter StateName" ControlToValidate="ddlStateID" Display="Dynamic" ForeColor="Red" InitialValue="-1"  ValidationGroup="save"></asp:RequiredFieldValidator>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-2">
                <asp:Label ID="lblCity" runat="server" Text="City Name" Font-Bold="true"  Font-size="Large"></asp:Label>
            </div>
            <div class="col-md-2">
                <asp:DropDownList ID="ddlCityID" runat="server" CssClass="form-control" Width="500px"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvCity" runat="server" ErrorMessage="Enter CityName" ControlToValidate="ddlCityID" Display="Dynamic" ForeColor="Red" InitialValue="-1"  ValidationGroup="save"></asp:RequiredFieldValidator>
            </div>
        </div>
        
         <br />
        <div class="row">
            <div class="col-md-2">
                <asp:Label ID="lblContactCategoryID" runat="server" Text="ContactCategory" Font-Bold="true"  Font-size="Large"></asp:Label>
            </div>
            <div class="col-md-2">
                <asp:DropDownList ID="ddlContactCategoryID" runat="server" CssClass="form-control" Width="500px"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvContactCategoryID" runat="server" ErrorMessage="Enter ContactCategory" ControlToValidate="ddlContactCategoryID" Display="Dynamic" ForeColor="Red" InitialValue="-1"  ValidationGroup="save"></asp:RequiredFieldValidator>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-2">
                <asp:Label ID="lblBloodGroupID" runat="server" Text="BloodGroup" Font-Bold="true"  Font-size="Large"></asp:Label>
            </div>
            <div class="col-md-2">
                <asp:DropDownList ID="ddlBloodGroupID" runat="server" CssClass="form-control" Width="500px"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvBloodGroupID" runat="server" ErrorMessage="Enter BloodGroup" ControlToValidate="ddlBloodGroupID" Display="Dynamic" ForeColor="Red" InitialValue="-1"  ValidationGroup="save"></asp:RequiredFieldValidator>
            </div>
        </div>
         <br />
         <div class="row">
            <div class="col-md-2">
                <asp:Label ID="lblTwitter" runat="server" Text="Twitter" Font-Bold="true"  Font-size="Large"></asp:Label>
            </div>
            <div class="col-md-2">
                <asp:TextBox ID="txtTwitter" runat="server"  CssClass="form-control" Width="500px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvTwitter" runat="server" ErrorMessage="Enter TwitterLink" ControlToValidate="txtTwitter" Display="Dynamic" ForeColor="Red"  ValidationGroup="save"></asp:RequiredFieldValidator>
            </div>
        </div>
        <br />
         <div class="row">
            <div class="col-md-2">
                <asp:Label ID="lblLinkedIn" runat="server" Text="LinkedIn" Font-Bold="true"  Font-size="Large"></asp:Label>
            </div>
            <div class="col-md-2">
                <asp:TextBox ID="txtLinkedIn" runat="server"  CssClass="form-control" Width="500px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvLinkedIn" runat="server" ErrorMessage="Enter LinkedInLink" ControlToValidate="txtLinkedIn" Display="Dynamic" ForeColor="Red"  ValidationGroup="save"></asp:RequiredFieldValidator>
            </div>
        </div>
        <br />
         <div class="row">
            <div class="col-md-2">
                <asp:Label ID="lblFacebook" runat="server" Text="Facebook" Font-Bold="true"  Font-size="Large"></asp:Label>
            </div>
            <div class="col-md-2">
                <asp:TextBox ID="txtFacebook" runat="server"  CssClass="form-control" Width="500px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvFacebook" runat="server" ErrorMessage="Enter Facebook" ControlToValidate="txtFacebook" Display="Dynamic" ForeColor="Red"  ValidationGroup="save"></asp:RequiredFieldValidator>
            </div>
        </div>
        <br />
         <div class="row">
            <div class="col-md-2">
                <asp:Label ID="lblProfession" runat="server" Text="Profession" Font-Bold="true"  Font-size="Large"></asp:Label>
            </div>
            <div class="col-md-2">
                <asp:TextBox ID="txtProfession" runat="server"  CssClass="form-control" Width="500px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvProfession" runat="server" ErrorMessage="Enter Profession" ControlToValidate="txtProfession" Display="Dynamic" ForeColor="Red"  ValidationGroup="save"></asp:RequiredFieldValidator>
            </div>
        </div>
        <br />



<div class="row ">
            <div class="col-md-2"></div>
            <div class="col-md-2">
                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-info" OnClick="btnSave_Click"  ValidationGroup="save"/>
            </div>
            <div class="col-md-2">
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-danger" OnClick="btnCancel_Click" />
            </div>
        </div>
         <br />
    </div>        
     
   
</asp:Content>

