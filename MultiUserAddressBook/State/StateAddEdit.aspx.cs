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

public partial class State_StateAddEdit : System.Web.UI.Page
{
    #region LoadEvent
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
            if (Request.QueryString["StateID"] == null)
            {
                lblPageHeader.Text = "State Add";
            }
            else
            {
                lblPageHeader.Text = "State Edit";
                FillFormState(Convert.ToInt32(Request.QueryString["StateID"].ToString().Trim()));
            }
        }
    }
    #endregion LoadEvent

    private void Insert_StateName()
    {
        #region LocalVariable
        string ConnectionString = ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString;
        string strErrorMessage = "";
        SqlInt32 CountryID = SqlInt32.Null;
        SqlString StateName = SqlString.Null;
        SqlInt32 UserID = SqlInt32.Null;
        #endregion LocalVariable

        #region ServersideValidation
        if (ddlCountryID.SelectedIndex == 0)
        {
            strErrorMessage += "-Select Country <br/>";
        }
        if (txtStateName.Text.Trim() == "")
        {
            strErrorMessage += "-Enter State Name <br/>";
        }
        if (strErrorMessage.Trim() != "")
        {
            lblErrorMessage.Text = strErrorMessage;
            return;
        }
        #endregion ServersideValidation

        #region ReadData
        if (ddlCountryID.SelectedIndex > 0)
        {
            CountryID = Convert.ToInt32(ddlCountryID.SelectedValue);
        }
        if (txtStateName.Text.Trim() != "")
        {
            StateName = txtStateName.Text.Trim();
        }
        if(Session["UserID"]!=null)
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
                    if (Request.QueryString["StateID"] == null)
                    {
                        objCmd.CommandText = "PR_StateTable_InsertUserID";
                        objCmd.Parameters.Add("@CountryID", SqlDbType.Int).Value = CountryID;
                    }
                    else
                    {
                        objCmd.CommandText = "PR_StateTable_UpdateByPKUserID";
                        objCmd.Parameters.Add("@StateID", SqlDbType.VarChar).Value = Request.QueryString["StateID"].ToString().Trim();
                    }
                    objCmd.Parameters.Add("@StateName", SqlDbType.VarChar).Value = StateName;
                    objCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = UserID;
                    objCmd.ExecuteNonQuery();
                    if (Request.QueryString["StateID"] == null)
                    {
                        lblErrorMessage.Text = "Data Inserted Successfully.";
                        ddlCountryID.SelectedIndex = 0;
                        txtStateName.Text = "";
                    }
                    else
                    {
                        Response.Redirect("~/State/StateList.aspx");
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
    private void FillDroupDownList()
    {
        #region FillDropdownList
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
                    objCmd.CommandText = "PR_CountryTable_SelectForDropdownListUserID";
                    if(Session["UserID"]!=null)
                    {
                        objCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = Session["UserID"];
                    }
                    using (SqlDataReader objSDR = objCmd.ExecuteReader())
                    {
                        if (objSDR.HasRows)
                        {
                            ddlCountryID.DataValueField = "CountryID";
                            ddlCountryID.DataTextField = "CountryName";
                            ddlCountryID.DataSource = objSDR;
                            ddlCountryID.DataBind();
                            ddlCountryID.Items.Insert(0, new ListItem("Select Country", "-1"));
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
    private void FillFormState(SqlInt32 StateID)
    {
        #region Local Variable
        string ConnectionString = ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString;
        #endregion Local Variable
        #region Edit State
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
                    objCmd.CommandText = "PR_StateTable_SelectByPKUserID";
                    objCmd.Parameters.Add("@StateID", SqlDbType.Int).Value = StateID;
                    if(Session["UserID"]!=null)
                    {
                        objCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = Session["UserID"];
                    }
                    using (SqlDataReader objSDR = objCmd.ExecuteReader())
                    {
                        if(objSDR.HasRows)
                        {
                            while(objSDR.Read())
                            {
                                if (!objSDR["StateName"].Equals(DBNull.Value))
                                {
                                    txtStateName.Text = objSDR["StateName"].ToString().Trim();
                                }
                                if (!objSDR["CountryID"].Equals(DBNull.Value))
                                {
                                    ddlCountryID.SelectedValue = objSDR["CountryID"].ToString().Trim();
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


    #region SaveButton Event
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Insert_StateName();
    }
    #endregion SaveButton Event

    #region CancelButton Event
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/State/StateList.aspx");
    }
    #endregion CancelButton Event
}