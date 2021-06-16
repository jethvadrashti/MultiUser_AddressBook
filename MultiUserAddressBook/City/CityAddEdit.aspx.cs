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

public partial class City_CityAddEdit : System.Web.UI.Page
{
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
            FillDroupDownList();
            if (Request.QueryString["CityID"] == null)
            {
                lblPageHeader.Text = "City Add";
            }
            else
            {
                lblPageHeader.Text = "City Edit";
                FillFormCity(Convert.ToInt32(Request.QueryString["CityID"].ToString().Trim()));
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        Insert_CityName();
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/City/CityList.aspx");
    }
    private void Insert_CityName()
    {
        #region LocalVariable
        string ConnectionString = ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString;
        string strErrorMessage = "";
        SqlInt32 StateID = SqlInt32.Null;
        SqlString CityName = SqlString.Null;
        SqlInt32 UserID = SqlInt32.Null;
        #endregion LocalVariable

        #region ServersideValidation
        if (ddlStateID.SelectedIndex == 0)
        {
            strErrorMessage += "-Select State <br/>";
        }
        if (txtCityName.Text.Trim() == "")
        {
            strErrorMessage += "-Enter City Name <br/>";
        }
        if (strErrorMessage.Trim() != "")
        {
            lblErrorMessage.Text = strErrorMessage;
            return;
        }
        #endregion ServersideValidation

        #region ReadData
        if (ddlStateID.SelectedIndex > 0)
        {
            StateID = Convert.ToInt32(ddlStateID.SelectedValue);
        }
        if (txtCityName.Text.Trim() != "")
        {
            CityName = txtCityName.Text.Trim();
        }
        if (Session["UserID"] != null)
        {
            UserID = Convert.ToInt32(Session["UserID"]);
        }
        #endregion ReadData

        #region DataInsert
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
                    if (Request.QueryString["CityID"] == null)
                    {
                        objCmd.CommandText = "PR_CityTable_InsertUserID";
                        objCmd.Parameters.Add("@StateID", SqlDbType.Int).Value = StateID;
                    }
                    else
                    {
                        objCmd.CommandText = "PR_CityTable_UpdateByPKUserID";
                        objCmd.Parameters.Add("@CityID", SqlDbType.VarChar).Value = Request.QueryString["CityID"].ToString().Trim();
                    }
                    objCmd.Parameters.Add("@CityName", SqlDbType.VarChar).Value = CityName;
                    objCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = UserID;
                    objCmd.ExecuteNonQuery();
                    if (Request.QueryString["CityID"] == null)
                    {
                        lblErrorMessage.Text = "Data Inserted Successfully.";
                        ddlStateID.SelectedIndex = 0;
                        txtCityName.Text = "";
                    }
                    else
                    {
                        Response.Redirect("~/City/CityList.aspx");
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
        #endregion DataInsert
    }
    #region FillDropdownList
    private void FillDroupDownList()
    {
        string ConnectionString = ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString;
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
                    objCmd.CommandText = "PR_StateTable_SelectForDropdownListUserID";
                    if (Session["UserID"] != null)
                    {
                        objCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = Session["UserID"];
                    }
                    using (SqlDataReader objSDR = objCmd.ExecuteReader())
                    {
                        if (objSDR.HasRows)
                        {
                            ddlStateID.DataValueField = "StateID";
                            ddlStateID.DataTextField = "StateName";
                            ddlStateID.DataSource = objSDR;
                            ddlStateID.DataBind();
                            ddlStateID.Items.Insert(0, new ListItem("Select State", "-1"));
                        }
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
        #endregion FillDropdownList
    }
    private void FillFormCity(SqlInt32 CityID)
    {
        #region Local Variable
        string ConnectionString = ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString;
        #endregion Local Variable
        #region Edit City
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
                    objCmd.CommandText = "PR_CityTable_SelectByPKUserID";
                    if (Session["UserID"] != null)
                    {
                        objCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = Session["UserID"];
                    }
                    objCmd.Parameters.Add("@CityID", SqlDbType.Int).Value = CityID;
                    using (SqlDataReader objSDR = objCmd.ExecuteReader())
                    {
                        if (objSDR.HasRows)
                        {
                            while (objSDR.Read())
                            {
                                if (!objSDR["CityName"].Equals(DBNull.Value))
                                {
                                    txtCityName.Text = objSDR["CityName"].ToString().Trim();
                                }
                                if (!objSDR["StateID"].Equals(DBNull.Value))
                                {
                                    ddlStateID.SelectedValue = objSDR["StateID"].ToString().Trim();
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
        #endregion Edit City

    }

}