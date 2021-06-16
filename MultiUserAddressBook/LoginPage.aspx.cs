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

public partial class LoginPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnAddNewUser_Click(object sender, EventArgs e)
    {
        #region Local Variable
        string ConnectionString = ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString;
        SqlString strUserName = SqlString.Null;
        SqlString strPassword = SqlString.Null;
        SqlString strDisplayName = SqlString.Null;
        SqlString strMobileNo = SqlString.Null;
        string strErrorMessage = "";
        #endregion Local Variable

        #region ServerSideValidation
        if (txtUserName.Text.Trim() == "")
        {
            strErrorMessage += "-Enter UserName + <br>";
        }
        if (txtPassword.Text.Trim() == "")
        {
            strErrorMessage += "-Enter Password + <br>";
        }
        if (txtDisplayName.Text.Trim() == "")
        {
            strErrorMessage += "-Enter DisplayName + <br>";
        }
        if (txtMobileNo.Text.Trim() == "")
        {
            strErrorMessage += "-Enter MobileNo + <br>";
        }
        if (strErrorMessage.Trim() != "")
        {
            lblRegisterMessage.Text = strErrorMessage;
            return;
        }
        if (txtUserName.Text.Trim() != "")
        {
            strUserName = txtUserName.Text.Trim();
        }
        if (txtPassword.Text.Trim() != "")
        {
            strPassword = txtPassword.Text.Trim();
        }
        if (txtDisplayName.Text.Trim() != "")
        {
            strDisplayName = txtDisplayName.Text.Trim();
        }
        if (txtMobileNo.Text.Trim() != "")
        {
            strMobileNo = txtMobileNo.Text.Trim();
        }

        #endregion ServerSideValidation


        #region Add_User
        using (SqlConnection objConn = new SqlConnection(ConnectionString))
        {
            try
            {
                if (objConn.State != ConnectionState.Open)
                    objConn.Open();

                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    objCmd.CommandType = CommandType.StoredProcedure;
                    objCmd.CommandText = "PR_UserTable_Insert";
                    objCmd.Parameters.Add("@UserName", SqlDbType.VarChar).Value = strUserName;
                    objCmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = strPassword;
                    objCmd.Parameters.Add("@DisplayName", SqlDbType.VarChar).Value = strDisplayName;
                    objCmd.Parameters.Add("@MobileNo", SqlDbType.VarChar).Value = strMobileNo;
                    objCmd.ExecuteNonQuery();
                    lblRegisterMessage.Text = "Data Inserted Successfully.";
                    txtUserName.Text = "";
                    txtPassword.Text = "";
                    txtDisplayName.Text = "";
                    txtMobileNo.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblRegisterMessage.Text = ex.Message;
            }
            finally
            {
                if (objConn.State == ConnectionState.Open)
                    objConn.Close();

            }
        }
        #endregion Add_User
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        #region Local Variable
        string connetionString = ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString;
        string strErrorMessage = "";
        SqlString strLoginUserName = SqlString.Null;
        SqlString strLoginPassword = SqlString.Null;
        #endregion Local Variable
        #region Serverside Validation
        if (txtLoginUserName.Text.Trim() == "")
        {
            strErrorMessage += "-Enter UserName";
        }
        if (txtLoginPassword.Text.Trim() == "")
        {
            strErrorMessage += "-Enter Password";
        }
        if (strErrorMessage != "")
        {
            lblErrorMessage.Text = strErrorMessage;
            return;
        }
        #endregion Serverside Validation

        #region  Data Read
        if (txtLoginUserName.Text != " ")
        {
            strLoginUserName = txtLoginUserName.Text.Trim();
        }
        if (txtLoginPassword.Text != " ")
        {
            strLoginPassword = txtLoginPassword.Text.Trim();
        }
        #endregion Data Read

        #region Check Valid
        using (SqlConnection objConn = new SqlConnection(connetionString))
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
                    objCmd.CommandText = "PR_User_SelectByUserNamePassword";
                    objCmd.Parameters.Add("@UserName", SqlDbType.VarChar).Value = strLoginUserName;
                    objCmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = strLoginPassword;
                    using (SqlDataReader objSDR = objCmd.ExecuteReader())
                    {
                        if (objSDR.HasRows)
                        {
                            lblErrorMessage.Text = "Valid User";
                            while (objSDR.Read())
                            {
                                if (!objSDR["UserID"].Equals(DBNull.Value))
                                {
                                    Session["UserID"] = objSDR["UserID"].ToString().Trim();
                                }
                                if (!objSDR["DisplayName"].Equals(DBNull.Value))
                                {
                                    Session["DisplayName"] = objSDR["DisplayName"].ToString().Trim();
                                }
                                Response.Redirect("~/Country/CountryList.aspx");
                            }

                        }
                        else
                        {
                            lblErrorMessage.Text = "Invalid User";
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
        #endregion Check Valid
    }
}
