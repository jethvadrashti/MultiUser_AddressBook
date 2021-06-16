<%@ Page Title="" Language="C#" MasterPageFile="~/AddressBookMasterPage.master" AutoEventWireup="true" CodeFile="ContactCategoryList.aspx.cs" Inherits="ContactCategory_ContactCategoryList" %>

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
          	<p class="breadcrumbs mb-2"><span class="mr-2"><a href="index.html">Login<i class="ion-ios-arrow-forward"></i></a></span> <span>ContactCategoryList<i class="ion-ios-arrow-forward"></i></span></p>
            <h1 class="mb-0 bread">Category</h1>
          </div>
        </div>
      </div>
    </section>
    <div class="container">
            
     <br /><br /><br /><br /><br />
            <div class="row">
                <div class="col-md-12">
                    <asp:Label ID="lblMessage" runat="server" Text="" CssClass="text-danger"></asp:Label>
                </div>
            </div>
        <br /><br />
            <div class="row">
                <div class="col-md-11"></div>
                <div class="col-md-1 text-Right">
                    <asp:Button ID="btnAddNew" runat="server" Text="Add New" CssClass="btn btn-info btn-sm" OnClick="btnAddNew_Click"/>
                </div>
            </div>
             <div class="row">
                <div class="col-md-12" style="overflow-x:auto">
                    <asp:GridView ID="gvContactCategory" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered alert-success" OnRowCommand="gvContactCategory_RowCommand" style="overflow-x:auto">
                        <Columns>
                            <asp:BoundField DataField="ContactCategoryID" HeaderText="ContactCategoryID" ControlStyle-Font-Bold="true" />
                            <asp:BoundField DataField="ContactCategory" HeaderText="ContactCategory" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-danger btn-sm" CommandName="DeleteRecord" CommandArgument='<%# Eval("ContactCategoryID") %>' />
                                    <asp:HyperLink ID="hlEdit" Text="Edit" CssClass="btn btn-success btn-sm" runat="server" NavigateUrl='<%# "~/ContactCategory/ContactCategoryAddEdit.aspx?ContactCategoryID="+ Eval("ContactCategoryID").ToString() %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    
                </div>
            </div>
        </div>
</asp:Content>

