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

public partial class State_StateList : System.Web.UI.Page
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
            All_State();
        }
    }
    #endregion Load Event
    private void All_State()
    {
        #region Local Variable
        string connectionString = ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString;
        #endregion Local Variable

        #region All_StateName
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
                    objCmd.CommandText = "PR_StateTable_JOINUserID";
                    if (Session["UserID"] != null)
                    {
                        objCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = Session["UserID"];
                    }
                    using (SqlDataReader objSDR = objCmd.ExecuteReader())
                    {
                        if (objSDR.HasRows)
                        {
                            gvState.DataSource = objSDR;
                            gvState.DataBind();
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
    }
    #endregion All_StateName




    protected void gvState_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if(e.CommandName=="DeleteRecord")
        {
            if(e.CommandArgument!=null)
            {
                DeleteState(Convert.ToInt32(e.CommandArgument.ToString().Trim()));
            }
        }
    }
    private void DeleteState(SqlInt32 StateID)
    {
        #region Local Vabiable
        string ConnectionString = ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString;
        #endregion Local Variable

        #region DeleteStateName
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
                    objCmd.CommandText = "PR_StateTable_DeleteByPKUserID";
                    objCmd.Parameters.Add("@StateID", SqlDbType.Int).Value = StateID;
                    if (Session["UserID"] != null)
                    {
                        objCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = Session["UserID"];
                    }
                    objCmd.ExecuteNonQuery();
                    All_State();
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
        #endregion StateName
    }
    #region AddNewButton Click Event
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/State/StateAddEdit.aspx");
    }
    #endregion AddNewButton Click Event

 
}


