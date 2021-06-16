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

public partial class Contact_ContactAddEdit : System.Web.UI.Page
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
            
            FillDropDownListCountry();
            FillDroupDownListContactCategory();
            FillDropDownListBloodGroup();
            if (Request.QueryString["ContactID"] == null)
            {
                lblHeaderText.Text = "Contact Add";
            }
            else
            {
                lblHeaderText.Text = "Contact Edit";
                FillFormContact(Convert.ToInt32(Request.QueryString["ContactID"].ToString().Trim()));
            }
        }
    }
    #endregion Load Event
    #region SaveButton Event
    protected void btnSave_Click(object sender, EventArgs e)
    {
        ContactAddEdit();
    }
    #endregion SaveButton Event
    private void ContactAddEdit()
    {
        #region Local Variable
        string connectionString = ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString;
        string strErrorMessage = "";
        SqlString ContactName = SqlString.Null;
        SqlString MobileNo = SqlString.Null;
        SqlString Address = SqlString.Null;
        SqlInt32 CityID = SqlInt32.Null;
        SqlInt32 StateID = SqlInt32.Null;
        SqlInt32 CountryID = SqlInt32.Null;
        SqlInt32 ContactCategoryID = SqlInt32.Null;
        SqlInt32 BloodGroupID = SqlInt32.Null;
        SqlInt32 UserID = SqlInt32.Null;
        SqlString Twitter = SqlString.Null;
        SqlString LinkedIn = SqlString.Null;
        SqlString Facebook = SqlString.Null;
        SqlString Profession = SqlString.Null;
        #endregion Local Variable



        #region ServersideValidation
        if (txtContactName.Text.Trim() == "")
        {
            strErrorMessage += "-Enter Contact Name <br/>";
        }
        if (txtMobileNo.Text.Trim() == "")
        {
            strErrorMessage += "-Enter MobileNo <br/>";
        }
        if (txtAddress.Text.Trim() == "")
        {
            strErrorMessage += "-Enter Address<br/>";
        }
        if (ddlCityID.SelectedIndex == 0)
        {
            strErrorMessage += "-Select City <br/>";
        }
        if (ddlStateID.SelectedIndex == 0)
        {
            strErrorMessage += "-Select State <br/>";
        }
        if (ddlCountryID.SelectedIndex == 0)
        {
            strErrorMessage += "-Select Country <br/>";
        }
        if (ddlContactCategoryID.SelectedIndex == 0)
        {
            strErrorMessage += "-Select ContactCategory" +
                " <br/>";
        }
        if (ddlBloodGroupID.SelectedIndex == 0)
        {
            strErrorMessage += "-Select BloodGroup <br/>";
        }
        if (txtTwitter.Text.Trim() == "")
        {
            strErrorMessage += "-Enter Twitter <br/>";
        }
        if (txtLinkedIn.Text.Trim() == "")
        {
            strErrorMessage += "-Enter LinkedIn <br/>";
        }
        if (txtFacebook.Text.Trim() == "")
        {
            strErrorMessage += "-Enter Facebook <br/>";
        }
        if (txtProfession.Text.Trim() == "")
        {
            strErrorMessage += "-Enter Profession <br/>";
        }
        if (strErrorMessage.Trim() != "")
        {
            lblErrorMessage.Text = strErrorMessage;
            return;
        }
        #endregion ServersideValidation


        #region ReadData
        if (txtContactName.Text.Trim() != "")
        {
            ContactName = txtContactName.Text.Trim();
        }
        if (txtMobileNo.Text.Trim() != "")
        {
            MobileNo = txtMobileNo.Text.Trim();
        }
        if (txtAddress.Text.Trim() != "")
        {
            Address = txtAddress.Text.Trim();
        }
        if (ddlCityID.SelectedIndex > 0)
        {
            CityID = Convert.ToInt32(ddlCityID.SelectedValue);
        }
        if (ddlStateID.SelectedIndex > 0)
        {
            StateID = Convert.ToInt32(ddlStateID.SelectedValue);
        }
        if (ddlCountryID.SelectedIndex > 0)
        {
            CountryID = Convert.ToInt32(ddlCountryID.SelectedValue);
        }
        if (ddlContactCategoryID.SelectedIndex > 0)
        {
            ContactCategoryID = Convert.ToInt32(ddlContactCategoryID.SelectedValue);
        }
        if (ddlBloodGroupID.SelectedIndex > 0)
        {
            BloodGroupID = Convert.ToInt32(ddlBloodGroupID.SelectedValue);
        }
        if (txtTwitter.Text.Trim() != "")
        {
            Twitter = txtTwitter.Text.Trim();
        }
        if (txtLinkedIn.Text.Trim() != "")
        {
            LinkedIn = txtLinkedIn.Text.Trim();
        }
        if (txtFacebook.Text.Trim() != "")
        {
            Facebook = txtFacebook.Text.Trim();
        }
        if (txtProfession.Text.Trim() != "")
        {
            Profession = txtProfession.Text.Trim();
        }
        if (Session["UserID"] != null)
        {
            UserID = Convert.ToInt32(Session["UserID"]);
        }

        #endregion ReadData

        #region DataInsert
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
                    if (Request.QueryString["ContactID"] == null)
                    {
                        objCmd.CommandText = "PK_ContactTable_InsertMultiUserAddressBook";  
                    }
                    else
                    {
                        objCmd.CommandText = "PK_ContactTable_UpdateByPKJoin";
                        objCmd.Parameters.Add("@ContactID", SqlDbType.VarChar).Value = Request.QueryString["ContactID"].ToString().Trim();
                    }
                    objCmd.Parameters.Add("@ContactName", SqlDbType.VarChar).Value = ContactName;
                    objCmd.Parameters.Add("@MobileNo", SqlDbType.VarChar).Value = MobileNo;
                    objCmd.Parameters.Add("@Address", SqlDbType.VarChar).Value = Address;
                    objCmd.Parameters.Add("@CityID", SqlDbType.Int).Value = CityID;
                    objCmd.Parameters.Add("@StateID", SqlDbType.Int).Value = StateID;
                    objCmd.Parameters.Add("@CountryID", SqlDbType.Int).Value = CountryID;
                    objCmd.Parameters.Add("@ContactCategoryID", SqlDbType.Int).Value = ContactCategoryID;
                    objCmd.Parameters.Add("@BloodGroupID", SqlDbType.Int).Value = BloodGroupID;
                    objCmd.Parameters.Add("@Twitter", SqlDbType.VarChar).Value = Twitter;
                    objCmd.Parameters.Add("@LinkedIn", SqlDbType.VarChar).Value = LinkedIn;
                    objCmd.Parameters.Add("@Facebook", SqlDbType.VarChar).Value = Facebook;
                    objCmd.Parameters.Add("@Profession", SqlDbType.VarChar).Value = Profession;
                    objCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = UserID;
                    objCmd.ExecuteNonQuery();
                    if (Request.QueryString["ContactID"] == null)
                    {
                        lblErrorMessage.Text = "Data Inserted Successfully.";
                        txtContactName.Text = "";
                        txtMobileNo.Text = "";
                        txtAddress.Text = "";
                        ddlCityID.SelectedIndex = 0;
                        ddlStateID.SelectedIndex = 0;
                        ddlCountryID.SelectedIndex = 0;
                        ddlContactCategoryID.SelectedIndex = 0;
                        ddlBloodGroupID.SelectedIndex = 0;
                        txtTwitter.Text = "";
                        txtLinkedIn.Text = "";
                        txtFacebook.Text = "";
                        txtProfession.Text = "";
                    }
                    else
                    {
                        Response.Redirect("~/Contact/ContactList.aspx");
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


    #region CancelButton Event
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Contact/ContactList.aspx");
    }
    #endregion  CancelButton Event

    private void FillDroupDownListContactCategory()
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
                    objCmd.CommandText = "PR__ContactCategoryTableSelectForDropdownListUserID";
                    if(Session["UserID"]!=null)
                    {
                        objCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = Session["UserID"];
                    }
                    using (SqlDataReader objSDR = objCmd.ExecuteReader())
                    {
                        if (objSDR.HasRows)
                        {
                            ddlContactCategoryID.DataValueField = "ContactCategoryID";
                            ddlContactCategoryID.DataTextField = "ContactCategory";
                            ddlContactCategoryID.DataSource = objSDR;
                            ddlContactCategoryID.DataBind();
                            ddlContactCategoryID.Items.Insert(0, new ListItem("Select ContactCategory", "-1"));
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
    private void FillDropDownListCountry()
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
    private void FillDropDownListState(SqlInt32 CountryID)
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
                    objCmd.CommandText = "PR_StateTable_SelectForDropdownListUserIDCountryID";
                    objCmd.Parameters.AddWithValue("@CountryID",CountryID);
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
                        else
                        {
                            ddlStateID.Items.Clear();
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
    private void FillDropDownListCity(SqlInt32 StateID)
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
                    objCmd.CommandText = "PR_CityTable_SelectForDropdownListUserIDStateID";
                    objCmd.Parameters.AddWithValue("@StateID", StateID);
                    if (Session["UserID"] != null)
                    {
                        objCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = Session["UserID"];
                    }
                    using (SqlDataReader objSDR = objCmd.ExecuteReader())
                    {
                        if (objSDR.HasRows)
                        {
                            ddlCityID.DataValueField = "CityID";
                            ddlCityID.DataTextField = "CityName";
                            ddlCityID.DataSource = objSDR;
                            ddlCityID.DataBind();
                            ddlCityID.Items.Insert(0, new ListItem("Select City", "-1"));
                        }
                        else
                        {
                            ddlCityID.Items.Clear();
                            ddlCityID.Items.Insert(0, new ListItem("Select City", "-1"));
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
    private void FillDropDownListBloodGroup()
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
                    objCmd.CommandText = "PR__BloodGroupSelectForDropdownListUserID";
                    if (Session["UserID"] != null)
                    {
                        objCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = Session["UserID"];
                    }
                    using (SqlDataReader objSDR = objCmd.ExecuteReader())
                    {
                        if (objSDR.HasRows)
                        {
                            ddlBloodGroupID.DataValueField = "BloodGroupID";
                            ddlBloodGroupID.DataTextField = "BloodGroupName";
                            ddlBloodGroupID.DataSource = objSDR;
                            ddlBloodGroupID.DataBind();
                            ddlBloodGroupID.Items.Insert(0, new ListItem("Select BloodGroup", "-1"));
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
    private void FillFormContact(SqlInt32 ContactID)
    {
        #region Local Variable
        string ConnectionString = ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString;
        #endregion Local Variable
        #region Edit Contact
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
                    objCmd.CommandText = "PR_Contact_Table_SelectByPKJoin";
                    if (Session["UserID"] != null)
                    {
                        objCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = Session["UserID"];
                    }
                    objCmd.Parameters.Add("@ContactID", SqlDbType.Int).Value = ContactID;
                    using (SqlDataReader objSDR = objCmd.ExecuteReader())
                    {
                        if (objSDR.HasRows)
                        {
                            while (objSDR.Read())
                            {
                                if (!objSDR["ContactName"].Equals(DBNull.Value))
                                {
                                    txtContactName.Text = objSDR["ContactName"].ToString().Trim();
                                }
                                if (!objSDR["MobileNo"].Equals(DBNull.Value))
                                {
                                    txtMobileNo.Text = objSDR["MobileNo"].ToString().Trim();
                                }
                                if (!objSDR["Address"].Equals(DBNull.Value))
                                {
                                    txtAddress.Text = objSDR["Address"].ToString().Trim();
                                }
                                if (!objSDR["CountryName"].Equals(DBNull.Value))
                                {
                                    ddlCountryID.SelectedValue = objSDR["CountryName"].ToString().Trim();
                                }
                                
                                if (!objSDR["StateName"].Equals(DBNull.Value))
                                {
                                    ddlStateID.SelectedValue = objSDR["StateName"].ToString().Trim();
                                }
                                if (!objSDR["CityName"].Equals(DBNull.Value))
                                {
                                    ddlCityID.SelectedValue = objSDR["CityName"].ToString().Trim();
                                }
                                if (!objSDR["ContactCategory"].Equals(DBNull.Value))
                                {
                                    ddlContactCategoryID.SelectedValue = objSDR["ContactCategory"].ToString().Trim();
                                }
                                if (!objSDR["BloodGroupName"].Equals(DBNull.Value))
                                {
                                    ddlBloodGroupID.SelectedValue = objSDR["BloodGroupName"].ToString().Trim();
                                }
                                if (!objSDR["Twitter"].Equals(DBNull.Value))
                                {
                                    txtTwitter.Text = objSDR["Twitter"].ToString().Trim();
                                }
                                if (!objSDR["LinkedIn"].Equals(DBNull.Value))
                                {
                                    txtLinkedIn.Text = objSDR["LinkedIn"].ToString().Trim();
                                }
                                if (!objSDR["Facebook"].Equals(DBNull.Value))
                                {
                                    txtFacebook.Text = objSDR["Facebook"].ToString().Trim();
                                }
                                if (!objSDR["Profession"].Equals(DBNull.Value))
                                {
                                    txtProfession.Text = objSDR["Profession"].ToString().Trim();
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


    protected void ddlCountryID_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(ddlCountryID.SelectedIndex > 0)
        {
            FillDropDownListState(Convert.ToInt32(ddlCountryID.SelectedValue));
        }
        else
        {
            ddlStateID.Items.Clear();
            ddlStateID.Items.Insert(0, new ListItem("Select State", "-1"));
        }
    }

    protected void ddlStateID_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlStateID.SelectedIndex > 0)
        {
            FillDropDownListCity(Convert.ToInt32(ddlStateID.SelectedValue));
        }
        else
        {
            ddlCityID.Items.Clear();
            ddlCityID.Items.Insert(0, new ListItem("Select City", "-1"));
        }
    }
}