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

public partial class BloodGroup_BloodGroupList : System.Web.UI.Page
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
            BloodGroup();
        }
    }
    #endregion Load Event
    private void BloodGroup()
    { 
        #region Local Variable
        string connectionString = ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString;
        #endregion Local Variable
        #region All BloodGroup
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
                    objCmd.CommandText = "PR_BloodGroup_SelectAllByUserID";
                    if(Session["UserID"]!=null)
                    {
                        objCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = Session["UserID"];
                    }
                    using (SqlDataReader objSDR = objCmd.ExecuteReader())
                    {
                        if (objSDR.HasRows)
                        {
                            gvBloodGroup.DataSource = objSDR;
                            gvBloodGroup.DataBind();
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
        #endregion All BloodGroup
    }

    protected void gvBloodGroup_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if(e.CommandName=="DeleteRecord")
        {
            if(e.CommandArgument!=null)
            {
                DeleteBloodGroup(Convert.ToInt32(e.CommandArgument.ToString().Trim()));
            }
        }
    }
    private void DeleteBloodGroup(SqlInt32 BloodGroupID)
    {
        #region Local Vabiable
        string ConnectionString = ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString;
        #endregion Local Variable

        #region DeleteBloodGroupName
        using (SqlConnection objConn = new SqlConnection(ConnectionString))
        {
            try
            {
                if(objConn.State != ConnectionState.Open)
                {
                    objConn.Open();
                }
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    objCmd.CommandType = CommandType.StoredProcedure;
                    objCmd.CommandText = "PR_BloodGroup_DeleteByPKUserID";
                    if(Session["UserID"]!=null)
                    {
                        objCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = Session["UserID"];
                    }
                    objCmd.Parameters.Add("@BloodGroupID", SqlDbType.Int).Value = BloodGroupID;
                    objCmd.ExecuteNonQuery();
                    BloodGroup();
                }
            }
            catch(SqlException sqlex)
            {
                lblMessage.Text = sqlex.Message;
            }
            catch(Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
            finally
            {
                if(objConn.State == ConnectionState.Open)
                {
                    objConn.Close();
                }
            }
        }
        #endregion BloodGroupName
    }
    #region AddNewButton Click Event
    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/BloodGroup/BloodGroupAddEdit.aspx");
    }
    #endregion AddNewButton Click Event
}