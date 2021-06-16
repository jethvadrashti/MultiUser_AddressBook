using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AddressBookMasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            if(Session["DisplayName"]!=null)
            {
                lblUserNameText.Text = "Hi! " + Session["DisplayName"].ToString().Trim();
            }
        }
    }

    protected void lbLogout_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Response.Redirect("~/LoginPage.aspx");
    }

    protected void Logout_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Response.Redirect("~/LoginPage.aspx");
    }
}
