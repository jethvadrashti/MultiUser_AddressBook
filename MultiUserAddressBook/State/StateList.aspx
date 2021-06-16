<%@ Page Title="" Language="C#" MasterPageFile="~/AddressBookMasterPage.master" AutoEventWireup="true" CodeFile="StateList.aspx.cs" Inherits="State_StateList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageContent" Runat="Server">
     <section class="hero-wrap hero-wrap-2 embed-responsive"  style="background-image:url('~/Images/images-7.jpg');background-color:black"  data-stellar-background-ratio="1.0">
               
      <div class="overlay" style="background-color:black">
           <asp:Image runat="server" ImageUrl="~/Images/images-5.jpg" Width="2000px" Height="400px"/>
      </div>
         <br /><br /><br /><br />
      <div class="container responsive">
        <div class="row no-gutters slider-text align-items-end">
          <div class="col-md-9 ftco-animate pb-5">
          	<p class="breadcrumbs mb-2"><span class="mr-2"><a href="#">Login<i class="ion-ios-arrow-forward"></i></a></span> <span>StateList<i class="ion-ios-arrow-forward"></i></span></p>
            <h1 class="mb-0 bread">StateList</h1>
          </div>
        </div>
      </div>
    </section>
     <br /><br /><br /><br /><br /><br />
    <div class="container">
        
            <div class="row">
                <div class="col-md-12">
                    <asp:Label ID="lblMessage" runat="server" Text="" CssClass="text-danger"></asp:Label>
                </div>
            </div><br /><br />
        <div class="row">
            <div class="col-md-11"></div>
            <div class="col-md-1 text-right">
                <asp:Button ID="btnAddNew" runat="server" Text="Add New" CssClass="btn btn-info btn-sm" OnClick="Button1_Click" />
            </div>
        </div>
            <div class="row">
                <div class="col-md-12" style="overflow-x:auto">
                    <asp:GridView ID="gvState" runat="server" AutoGenerateColumns="false" CssClass="table bordered alert-success" OnRowCommand="gvState_RowCommand" style="overflow-x:auto"  >
                        <Columns>
                            <asp:BoundField DataField="StateID" HeaderText="StateID"  ControlStyle-Font-Bold="true"/>
                            <asp:BoundField DataField="StateName" HeaderText="StateName" />
                            <asp:BoundField DataField="CountryName" HeaderText="CountryName" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-danger btn-sm"  CommandName="DeleteRecord" CommandArgument='<%#Eval("StateID") %>'/>
                                    <asp:HyperLink ID="hlEdit" Text="Edit" CssClass="btn btn-success btn-sm" runat="server" NavigateUrl='<%# "~/State/StateAddEdit.aspx?StateID="+ Eval("StateID").ToString() %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
   
</asp:Content>

