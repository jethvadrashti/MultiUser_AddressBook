using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Contact_ContactList : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        #region Check Valid User
        if (Session["UserID"] == null)
        {
            Response.Redirect("~/LoginPage.aspx");
        }
        #endregion Check Valid User
        if (!Page.IsPostBack)
        {
            Contact();
        }
    }
    #endregion Load Event
    private void Contact()
    { 
    #region Local Variable
    string connectionString = ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString;
        #endregion Local Variable
        #region All Contact
        using (SqlConnection objConn = new SqlConnection(connectionString))
        {
            try
            {
                if (objConn.State != ConnectionState.Open)
                {
                    objConn.Open();
                }
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    objCmd.CommandType = CommandType.StoredProcedure;
                    objCmd.CommandText = "PR_ContactTable_Jon2";
                    if (Session["UserID"] != null)
                    {
                        objCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = Session["UserID"];
                    }
                    using (SqlDataReader objSDR = objCmd.ExecuteReader())
                    {
                        if (objSDR.HasRows)
                        {
                            gvContact.DataSource = objSDR;
                            gvContact.DataBind();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
            finally
            {
                if (objConn.State == ConnectionState.Open)
                {
                    objConn.Close();
                }
            }
        }
        #endregion All Contact
    }


    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Contact/ContactAddEdit.aspx");
    }
    #region Row Command Event
    protected void gvContact_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if(e.CommandName == "DeleteRecord")
        {
            if(e.CommandArgument != null)
            {
                DeleteContact(Convert.ToInt32(e.CommandArgument.ToString().Trim()));
            }
        }
    }
    #endregion Row Command Event
    #region DeleteContactList
    private void DeleteContact(SqlInt32 ContactID)
    {
        #region Local Variable
        string ConnectionString = ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString;
        #endregion Local Variable

        #region DeleteContactPart
        using (SqlConnection objConn = new SqlConnection(ConnectionString))
        {
            try
            {
                if (objConn.State != ConnectionState.Open)
                {
                    objConn.Open();
                }
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    objCmd.CommandType = CommandType.StoredProcedure;
                    objCmd.CommandText = "PK_Contact_Table_DeleteByPKUserID";
                    if (Session["UserID"] != null)
                    {
                        objCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = Session["UserID"];
                    }
                    objCmd.Parameters.Add("@ContactID", SqlDbType.Int).Value = ContactID;
                    objCmd.ExecuteNonQuery();
                    Contact();
                }
            }
            catch (SqlException sqlex)
            {
                lblMessage.Text = sqlex.Message;
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
            finally
            {
                if (objConn.State == ConnectionState.Open)
                {
                    objConn.Close();
                }
            }
        }
        #endregion ContactPart
    }
    #endregion DeleteContactList

    protected void btnAddNew_Click1(object sender, EventArgs e)
    {
        Response.Redirect("~/Contact/ContactAddEdit.aspx");
    }
}
