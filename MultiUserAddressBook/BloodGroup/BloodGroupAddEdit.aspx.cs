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

public partial class BloodGroup_BloodGroupAddEdit : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        #region Check Valid User
        if(Session["UserID"]==null)
        {
            Response.Redirect("~/LoginPage.aspx");
        }
        #endregion Check Valid User
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["BloodGroupID"] == null)
            {
                lblPageHeader.Text = "BloodGroup Add";
            }
            else
            {
                lblPageHeader.Text = "BloodGroup Edit";
                FillBloodGroupForm(Convert.ToInt32(Request.QueryString["BloodGroupID"].ToString().Trim()));
            }
        }
    }
    #endregion Load Event

    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region Local Variable
        string connectionString = ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString;
        string strMessage = "";
        SqlString BloodGroupName = SqlString.Null;
        SqlInt32 UserID = SqlInt32.Null;
        #endregion Local Variable

        #region ServerSideValidation
        if (txtBloodGroup.Text == "")
        {
            strMessage += "-Enter BloodGroup";
        }
        if (strMessage != "")
        {
            lblErrorMessage.Text = strMessage;
            return;
        }
        if (txtBloodGroup.Text.Trim() != "")
        {
            BloodGroupName = txtBloodGroup.Text;
        }
        if(Session["UserID"] != null)
        {
            UserID = Convert.ToInt32(Session["UserID"]);
        }
        #endregion ServerSideValidation

        #region Insert BloodGroup
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
                    if (Request.QueryString["BloodGroupID"] == null)
                    {
                        objCmd.CommandText = "PR_BloodGroup_InsertByUserID";

                    }
                    else
                    {
                        objCmd.CommandText = "PR_BloodGroup_UpdateByPKUserID";
                        objCmd.Parameters.Add("@BloodGroupID", SqlDbType.Int).Value = Request.QueryString["BloodGroupID"].ToString().Trim();
                    }
                    objCmd.Parameters.Add("@BloodGroupName", SqlDbType.VarChar).Value = BloodGroupName;
                    objCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = UserID;
                    objCmd.ExecuteNonQuery();
                    if(Request.QueryString["BloodGroupID"] == null)
                    {
                        lblErrorMessage.Text = "Data Inserted Successfully.";
                        txtBloodGroup.Text = "";
                        txtBloodGroup.Focus();
                    }
                    else
                    {
                        Response.Redirect("~/BloodGroup/BloodGroupList.aspx");
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
        #endregion Insert BloodGroup


    }
    #region CancelButton Event
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/BloodGroup/BloodGroupList.aspx");
    }
    #endregion CancelButton Event
    #region BloodGroup
    private void FillBloodGroupForm(SqlInt32 BloodGroupID)
    {
        #region Local Variable
        string ConnectionString = ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString;
        #endregion Local Variable
        #region Edit BloodGroup
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
                    objCmd.CommandText = "PR_BloodGroup_SelectByPKUserID";
                    if (Session["UserID"] != null)
                    {
                        objCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = Session["UserID"];
                    }
                    objCmd.Parameters.Add("@BloodGroupID", SqlDbType.Int).Value = BloodGroupID;
                    using (SqlDataReader objSDR = objCmd.ExecuteReader())
                    {
                        if (objSDR.HasRows)
                        {
                            while (objSDR.Read())
                            {
                                if (!objSDR["BloodGroupName"].Equals(DBNull.Value))
                                {
                                    txtBloodGroup.Text = objSDR["BloodGroupName"].ToString().Trim();
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
        #endregion Edit BloodGroup
    }
    #endregion BloodGroup
}