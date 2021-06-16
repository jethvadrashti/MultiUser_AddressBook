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

public partial class Country_CountryAddEdit : System.Web.UI.Page
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
            if(Request.QueryString["CountryID"]==null)
            {
                lblPageHeader.Text = "Country Add";
            }
            else
            {
                lblPageHeader.Text = "Country Edit";
                FillCountryForm(Convert.ToInt32(Request.QueryString["CountryID"].ToString().Trim()));
            }
        }

    }
    #endregion Load Event

    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region Local Variable
        string ConnectionString = ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString;
        SqlString strCountryName = SqlString.Null;
        SqlString strCountryCode = SqlString.Null;
        SqlInt32 UserID = SqlInt32.Null;
        string strErrorMessage = "";
        #endregion Local Variable

        #region ServerSideValidation
        if (txtCountryName.Text.Trim() == "")
        {
            strErrorMessage += "-Enter CountryName + <br>";
        }
        if (txtCountryCode.Text.Trim() == "")
        {
            strErrorMessage += "-Enter CountryCode + <br>";
        }
        if (strErrorMessage.Trim() != "")
        {
            lblErrorMessage.Text = strErrorMessage;
            return;
        }
        if (txtCountryName.Text.Trim() != "")
        {
            strCountryName = txtCountryName.Text.Trim();
        }
        if (txtCountryCode.Text.Trim() != "")
        {
            strCountryCode = txtCountryCode.Text.Trim();
        }
        if(Session["UserID"]!= null)
        {
            UserID = Convert.ToInt32(Session["UserID"]);
        }
        #endregion ServerSideValidation


        #region Add_Country
        using (SqlConnection objConn = new SqlConnection(ConnectionString))
        {
            try
            {
                if (objConn.State != ConnectionState.Open)
                    objConn.Open();

                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    objCmd.CommandType = CommandType.StoredProcedure;

                    if (Request.QueryString["CountryID"] == null)
                    {
                        objCmd.CommandText = "PR_CountryTable_Insert_UserID";
                    }
                    else
                    {
                        objCmd.CommandText = "PR_CountryTable_UpdateByPKUserID";
                        objCmd.Parameters.Add("@CountryID", SqlDbType.Int).Value = Request.QueryString["CountryID"].ToString().Trim();
                    }
                    objCmd.Parameters.Add("@CountryName", SqlDbType.VarChar).Value = strCountryName;
                    objCmd.Parameters.Add("@CountryCode", SqlDbType.VarChar).Value = strCountryCode;
                    objCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = UserID;
                    objCmd.ExecuteNonQuery();
                    if (Request.QueryString["CountryID"] == null)
                    {
                        lblErrorMessage.Text = "Data Inserted Successfully.";
                        txtCountryName.Text = "";
                        txtCountryCode.Text = "";
                        txtCountryName.Focus();
                    }
                    else
                    {
                        Response.Redirect("~/Country/CountryList.aspx");
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
                    objConn.Close();

            }
        }
        #endregion Add_Country
    }
    #region CancelButton Event
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Country/CountryList.aspx");
    }
    #endregion CancelButton Event

    private void FillCountryForm(SqlInt32 CountryID)
    {
        #region Local Variable
        string ConnectionString = ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString;
        #endregion Local Variable
        #region Edit Country
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
                    objCmd.CommandText = "PR_CountryTable_SelectByPKUserID";
                    if(Session["UserID"]!=null)
                    {
                        objCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = Session["UserID"];
                    }
                    objCmd.Parameters.Add("@CountryID", SqlDbType.Int).Value= CountryID;
                    using (SqlDataReader objSDR = objCmd.ExecuteReader())
                    {
                        if(objSDR.HasRows)
                        {
                            while(objSDR.Read())
                            {
                                if(!objSDR["CountryName"].Equals(DBNull.Value))
                                {
                                    txtCountryName.Text = objSDR["CountryName"].ToString().Trim();
                                }
                                if (!objSDR["CountryCode"].Equals(DBNull.Value))
                                {
                                    txtCountryCode.Text = objSDR["CountryCode"].ToString().Trim();
                                }
                            }
                        }
                    }
                }
            }
            catch(SqlException sqlex)
            {
                lblErrorMessage.Text = sqlex.Message;
            }
            catch(Exception ex)
            {
                lblErrorMessage.Text = ex.Message;
            }
            finally
            {
                if(objConn.State == ConnectionState.Open)
                {
                    objConn.Close();
                }
            }
        }
        #endregion Edit Country
    }
}