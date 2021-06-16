<%@ Page Title="" Language="C#" MasterPageFile="~/AddressBookMasterPage.master" AutoEventWireup="true" CodeFile="CityList.aspx.cs" Inherits="City_CityList" %>

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
          	<p class="breadcrumbs mb-2"><span class="mr-2"><a href="index.html">Login<i class="ion-ios-arrow-forward"></i></a></span> <span>CityList<i class="ion-ios-arrow-forward"></i></span></p>
            <h1 class="mb-0 bread">CityList</h1>
          </div>
        </div>
      </div>
    </section>
    
                <br /><br /><br />
     <div class="container">
          <br /><br /><br /><br /><br /><br />
            <div class="row">
                <div class="col-md-12">
                    <asp:Label ID="lblMessage" runat="server" Text="" CssClass="text-danger"></asp:Label>
                </div>
            </div><br /><br />
              <div class="row">
            <div class="col-md-11"></div>
            <div class="col-md-1 text-right">
                <asp:Button ID="btnAddNew" runat="server" Text="Add New" CssClass="btn btn-info btn-sm" onclick="btnAddNew_Click" />
            </div>
        </div>
            <div class="row">
                <div class="col-md-12" style="overflow-x:auto">
                    <asp:GridView ID="gvCity" runat="server" AutoGenerateColumns="false"  CssClass="table bordered alert-info" OnRowCommand="gvCity_RowCommand" style="overflow-x:auto">
                        <Columns>
                            <asp:BoundField DataField="CityID" HeaderText="CityID" ControlStyle-Font-Bold="true" ControlStyle-CssClass="glyphicon-font"/>
                            <asp:BoundField DataField="CityName" HeaderText="CityName" />
                            <asp:BoundField DataField="StateName" HeaderText="StateName" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-danger btn-sm"  CommandName="DeleteRecord" CommandArgument='<%#Eval("CityID") %>'/>
                                     <asp:HyperLink ID="hlEdit" Text="Edit" CssClass="btn btn-success btn-sm" runat="server" NavigateUrl='<%# "~/City/CityAddEdit.aspx?CityID="+ Eval("CityID").ToString() %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
</asp:Content>

