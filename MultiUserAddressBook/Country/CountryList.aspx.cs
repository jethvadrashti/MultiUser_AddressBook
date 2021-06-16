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

public partial class Country_CountryList : System.Web.UI.Page
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
            All_Country();
        }
    }
    #endregion LoadEvent
    private void All_Country()
    {
        #region Local Variable
        string connectionString = ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString;
        #endregion Local Variable

        #region All_CountryName
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
                    objCmd.CommandText = "PR_CountryTable_SelectAllUserID";
                    if(Session["UserID"]!=null)
                    {
                        objCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = Session["UserID"];
                    }
                    using (SqlDataReader objSDR = objCmd.ExecuteReader())
                    {
                        if (objSDR.HasRows)
                        {
                            gvCountry.DataSource = objSDR;
                            gvCountry.DataBind();
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
    #endregion All_CountryName

    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        #region AddNewButton Event
        Response.Redirect("~/Country/CountryAddEdit.aspx");
        #endregion AddNewButton Event
    }

    private void DeleteCountry(SqlInt32 CountryID)
    {
        #region Local Variable
        string ConnectionString = ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString;
        #endregion Local Variable

        #region DeleteCountryPart
        using (SqlConnection objConn = new SqlConnection(ConnectionString))
        {
            try
            {
                if(objConn.State!= ConnectionState.Open)
                {
                    objConn.Open();
                }
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    objCmd.CommandType = CommandType.StoredProcedure;
                    objCmd.CommandText = "PR_CountryTable_DeleteByPKUserID";
                    if(Session["UserID"]!=null)
                    {
                        objCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = Session["UserID"];
                    }
                    objCmd.Parameters.Add("@CountryID", SqlDbType.Int).Value = CountryID;
                    objCmd.ExecuteNonQuery();
                    All_Country();
                }
            }
            catch(SqlException sqlex)
            {
                lblMessage.Text = sqlex.Message;
            }
            catch (Exception ex)
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
        #endregion DeleteCountryPart
    }






    protected void gvCountry_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        #region CommandArgument
        if(e.CommandName=="DeleteRecord")
        {
            if(e.CommandArgument!=null)
            {
                DeleteCountry(Convert.ToInt32(e.CommandArgument.ToString().Trim()));
            }
        }
        #endregion CommandArgument
    }
}