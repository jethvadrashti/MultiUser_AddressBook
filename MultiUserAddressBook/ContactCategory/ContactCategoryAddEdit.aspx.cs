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

public partial class ContactCategory_ContactCategoryAddEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        #region Check Valid User
        if (Session["UserID"] == null)
        {
            Response.Redirect("~/LoginPage.aspx");
        }
        #endregion Check Valid User
        if (Request.QueryString["ContactCategoryID"] == null)
        {
            lblHeader.Text = "CoutactCategory Add";
        }
        else
        {
            lblHeader.Text = "ContactCategory Edit";
            FillContactCategoryForm(Convert.ToInt32(Request.QueryString["ContactCategoryID"].ToString().Trim()));
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region Local Variable
        string connectionString = ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString;
        string strMessage = "";
        SqlString ContactCategory = SqlString.Null;
        SqlInt32 UserID = SqlInt32.Null;
        #endregion Local Variable

        #region ServerSideValidation
        if (txtContactCategory.Text == "")
        {
            strMessage += "-Enter ContactCategory";
        }
        if (strMessage != "")
        {
            lblErrorMessage.Text = strMessage;
            return;
        }
        if (txtContactCategory.Text.Trim() != "")
        {
            ContactCategory = txtContactCategory.Text;
        }
        if(Session["UserID"]!=null)
        {
            UserID = Convert.ToInt32(Session["UserID"]);
        }
        #endregion ServerSideValidation

        #region Insert ContactCategoryGroup
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
                    if(Request.QueryString["ContactCategoryID"]==null)
                    {
                        objCmd.CommandText = "PR_ContactCategoryTable_InsertUserID";
                    }
                    else
                    {
                        objCmd.CommandText = "PR_ContactCategoryTable_UpdateByPKUserID";
                        objCmd.Parameters.Add("@ContactCategoryID", SqlDbType.Int).Value = Request.QueryString["ContactCategoryID"].ToString().Trim();
                    }
                    objCmd.Parameters.Add("@ContactCategory", SqlDbType.VarChar).Value = ContactCategory;
                    objCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = UserID;
                    objCmd.ExecuteNonQuery();
                    if (Request.QueryString["ContactCategoryID"] == null)
                    {
                        lblErrorMessage.Text = "Data Inserted Successfully.";
                        txtContactCategory.Text = "";
                        txtContactCategory.Focus();
                    }
                    else
                    {
                        Response.Redirect("~/ContactCategory/ContactCategoryList.aspx");
                    }
                }
            }
            catch (Exception ex)
            {
                lblErrorMessage.Text = ex.Message;
            }
            finally
            {
                if (objConn.State == ConnectionState.Open)
                {
                    objConn.Close();
                }
            }
        }
        #endregion Insert ContactCategoryGroup
    }
    #region CancelButton Event
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/ContactCategory/ContactCategoryList.aspx");
    }
    #endregion CancelButton Event

    private void FillContactCategoryForm(SqlInt32 ContactCategoryID)
    {
        #region Local Variable
        string ConnectionString = ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString;
        #endregion Local Variable
        #region Edit Country
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
                    objCmd.CommandText = "PR_ContactCategoryTable_SelectByPKUserID";
                    if(Session["UserID"]!=null)
                    {
                        objCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = Session["UserID"];
                    }
                    objCmd.Parameters.Add("@ContactCategoryID", SqlDbType.Int).Value = ContactCategoryID;
                    using (SqlDataReader objSDR = objCmd.ExecuteReader())
                    {
                        if (objSDR.HasRows)
                        {
                            while (objSDR.Read())
                            {
                                if (!objSDR["ContactCategory"].Equals(DBNull.Value))
                                {
                                    txtContactCategory.Text = objSDR["ContactCategory"].ToString().Trim();
                                }
                            }
                        }
                    }
                }
            }
            catch (SqlException sqlex)
            {
                lblErrorMessage.Text = sqlex.Message;
            }
            catch (Exception ex)
            {
                lblErrorMessage.Text = ex.Message;
            }
            finally
            {
                if (objConn.State == ConnectionState.Open)
                {
                    objConn.Close();
                }
            }
        }
        #endregion Edit Country
    }
}