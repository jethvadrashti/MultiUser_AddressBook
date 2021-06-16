<%@ Page Title="" Language="C#" MasterPageFile="~/AddressBookMasterPage.master" AutoEventWireup="true" CodeFile="ContactList.aspx.cs" Inherits="Contact_ContactList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageContent" Runat="Server">
  <section class="hero-wrap hero-wrap-2 embed-responsive"  style="background-image:url('~/Images/images-7.jpg');background-color:black"  data-stellar-background-ratio="1.0">
               
      <div class="overlay" style="background-color:black">
           <asp:Image runat="server" ImageUrl="~/Images/images-5.jpg" Width="2000px" Height="400px"/>
      </div> <br /><br /><br /><br /><br /><br />
      <div class="container">
        <div class="row no-gutters slider-text align-items-end">
          <div class="col-md-9 ftco-animate pb-5">
          	<p class="breadcrumbs mb-2"><span class="mr-2"><a href="index.html">Login<i class="ion-ios-arrow-forward"></i></a></span> <span>ContactList<i class="ion-ios-arrow-forward"></i></span></p>
            <h1 class="mb-0 bread">ContactList</h1>
          </div>
        </div>
      </div>
    </section>
     <br /><br /><br /><br /><br /><br />
            <div class="row">
                <div class="col-md-12">
                    <asp:Label ID="lblMessage" runat="server" Text="" CssClass="text-danger"></asp:Label>
                </div>
            </div>
    <br /><br />
        <div class="row">
            <div class="col-md-11"></div>
            <div class="col-md-1 text-right">
                <asp:Button ID="btnAddNew" runat="server" Text="Add New"  CssClass="btn btn-info btn-sm" OnClick="btnAddNew_Click1"/>
            </div>
        </div>
             <div class="row">
                <div class="col-md-12" style="overflow-x:auto">
                    <asp:GridView ID="gvContact" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered alert-info" OnRowCommand="gvContact_RowCommand" style="overflow-x:auto">
                        <Columns>
                            <asp:BoundField DataField="ContactID" HeaderText="ContactID" />
                            <asp:BoundField DataField="ContactName" HeaderText="ContactName" />
                            <asp:BoundField DataField="MobileNo" HeaderText="MobileNo" />
                            <asp:BoundField DataField="Address" HeaderText="Address" />
                            <asp:BoundField DataField="CityName" HeaderText="CityName" />
                             <asp:BoundField DataField="StateName" HeaderText="StateName" />
                             <asp:BoundField DataField="CountryName" HeaderText="CountryName" />
                            <asp:BoundField DataField="ContactCategory" HeaderText="ContactCategory" />
                            <asp:BoundField DataField="BloodGroupName" HeaderText="BloodGroup" />
                             <asp:BoundField DataField="Twitter" HeaderText="Twitter" />
                             <asp:BoundField DataField="LinkedIn" HeaderText="LinkedIn" />
                             <asp:BoundField DataField="Facebook" HeaderText="Facebook" />
                             <asp:BoundField DataField="Profession" HeaderText="Profession" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-danger btn-sm" CommandName="DeleteRecord" CommandArgument='<%# Eval("ContactID") %>' />
                                    <asp:HyperLink ID="hlEdit3" Text="Edit" CssClass="btn btn-success btn-sm" runat="server" NavigateUrl='<%# "~/Contact/ContactAddEdit.aspx?ContactID="+ Eval("ContactID").ToString() %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    
                </div>
            </div>
</asp:Content>

