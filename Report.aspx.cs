using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.DirectoryServices;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Report : System.Web.UI.Page
{

    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["viplist"].ConnectionString);

    string Con = ConfigurationManager.ConnectionStrings["viplist"].ToString();



    SqlCommand sqlcmd;
    SqlDataAdapter da;
    DataTable dt = new DataTable();
    string email = null;
    string cc;
    string[] CCId;
    string SearchString = "";
    string country;

    protected void Page_Load(object sender, EventArgs e)
    {

        
        if (!IsPostBack)
        {

            try
            {


                //  GridView1.DataBind();

                con.Open();
                // SqlCommand cmd = new SqlCommand("SELECT [TRANS_TYPE],[EQUI_NO],[USER_ID],[Status],[RSA],[RSA_SERIL],[JABRA],[DATA_CARD],[DATA_EQP],[MIFI],[MIFI_EQP],[UNI_ADUP],[PRIV_FIL],[OTHER_Des],[R_Status],BUILDING from[NewEquipment].[dbo].[ROP]", con);
                //   SqlCommand cmd = new SqlCommand("SELECT distinct [Schema_Identifier],[Category],[Category_Description] FROM[Category_search].[dbo].[new_Category_search] ", con);

                SqlCommand cmd = new SqlCommand("SELECT distinct   [Schema_Identifier1],[Category],[Category_Description],Ticket_category FROM[Category_search].[dbo].[new_category] ", con);

                SqlDataAdapter da = new SqlDataAdapter();
                // con.Close();
                DataSet ds = new DataSet();
                DataTable table = new DataTable();

                // da.SelectCommand = cmd;
                table.Load(cmd.ExecuteReader());
                //da.Fill(ds);
                GridView1.DataSource = table;
                GridView1.DataBind();
                con.Close();


            }
            catch (Exception ex)
            {

            }

            BindListBox();



        }

        
    }


    public void BindListBox()
    {  
      SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["viplist"].ConnectionString);  
       SqlDataAdapter da = new SqlDataAdapter("Select distinct Ticket_category From new_Category_search order by Ticket_category Asc ", con);  
       DataSet ds = new DataSet();  
       da.Fill(ds);  
      ListBox1.DataSource = ds;
        ListBox1.DataTextField = "Ticket_category";
        ListBox1.DataValueField = "Ticket_category";
        ListBox1.DataBind();  
    }


public override void VerifyRenderingInServerForm(Control control)
    {
        /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
           server control at run time. */
    }

    protected void Submit(object sender, EventArgs e)
    {

        if (txtcategory.Text != "")
        {
            string conString = ConfigurationManager.ConnectionStrings["viplist"].ConnectionString;
            string query = "SELECT distinct [Schema_Identifier1],[Category],[Category_Description],Ticket_category  FROM[Category_search].[dbo].[new_Category] ";

            string condition = string.Empty;
            foreach (ListItem item in lstFruits.Items)
            {
                condition += item.Selected ? string.Format("'{0}',", item.Value) : "";
            }
            if (condition == "")
            {
                con.Open();
                // SqlCommand cmd = new SqlCommand("SELECT [TRANS_TYPE],[EQUI_NO],[USER_ID],[Status],[RSA],[RSA_SERIL],[JABRA],[DATA_CARD],[DATA_EQP],[MIFI],[MIFI_EQP],[UNI_ADUP],[PRIV_FIL],[OTHER_Des],[R_Status],BUILDING from[NewEquipment].[dbo].[ROP]", con);
                SqlCommand cmd = new SqlCommand("SELECT  [Schema_Identifier1],[Category],[Category_Description],Ticket_category  FROM[Category_search].[dbo].[new_Category] where Category='" + txtcategory.Text + "' ", con);

                SqlDataAdapter da = new SqlDataAdapter();
                // con.Close();
                DataSet ds = new DataSet();
                DataTable table = new DataTable();

                // da.SelectCommand = cmd;
                table.Load(cmd.ExecuteReader());
                //da.Fill(ds);
                GridView1.DataSource = table;
                GridView1.DataBind();
                con.Close();
            }
            else
            {



                if (!string.IsNullOrEmpty(condition))
                {
                    condition = string.Format(" WHERE [Schema_Identifier] IN ({0}) and Category like'%" + txtcategory.Text + "%'", condition.Substring(0, condition.Length - 1));
                }

                using (SqlConnection con = new SqlConnection(conString))
                {
                    using (SqlCommand cmd = new SqlCommand(query + condition))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            cmd.Connection = con;
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                GridView1.DataSource = dt;
                                GridView1.DataBind();
                            }
                        }
                    }
                }

            }
        }

        else if (txtdescription.Text != "")
        {
            string conString = ConfigurationManager.ConnectionStrings["viplist"].ConnectionString;
            string query = "SELECT [Schema_Identifier1],[Category],[Category_Description],Ticket_category  FROM[Category_search].[dbo].[new_Category] ";

            string condition = string.Empty;
            foreach (ListItem item in lstFruits.Items)
            {
                condition += item.Selected ? string.Format("'{0}',", item.Value) : "";
            }
            if (condition == "")
            {
                con.Open();
                // SqlCommand cmd = new SqlCommand("SELECT [TRANS_TYPE],[EQUI_NO],[USER_ID],[Status],[RSA],[RSA_SERIL],[JABRA],[DATA_CARD],[DATA_EQP],[MIFI],[MIFI_EQP],[UNI_ADUP],[PRIV_FIL],[OTHER_Des],[R_Status],BUILDING from[NewEquipment].[dbo].[ROP]", con);
                SqlCommand cmd = new SqlCommand("SELECT [Schema_Identifier1],[Category],[Category_Description],Ticket_category  FROM[Category_search].[dbo].[new_Category] where Category_Description like '%" + txtdescription.Text + "%'", con);

                SqlDataAdapter da = new SqlDataAdapter();
                // con.Close();
                DataSet ds = new DataSet();
                DataTable table = new DataTable();

                // da.SelectCommand = cmd;
                table.Load(cmd.ExecuteReader());
                //da.Fill(ds);
                GridView1.DataSource = table;
                GridView1.DataBind();
                con.Close();
            }
            else
            {



                if (!string.IsNullOrEmpty(condition))
                {
                    condition = string.Format(" WHERE [Schema_Identifier] IN ({0}) and Category_Description like '%" + txtdescription.Text + "%'", condition.Substring(0, condition.Length - 1));
                }

                using (SqlConnection con = new SqlConnection(conString))
                {
                    using (SqlCommand cmd = new SqlCommand(query + condition))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            cmd.Connection = con;
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                GridView1.DataSource = dt;
                                GridView1.DataBind();
                            }
                        }
                    }
                }

            }
        }
        else
        {


          

            string conString = ConfigurationManager.ConnectionStrings["viplist"].ConnectionString;
            string query = "SELECT distinct [Schema_Identifier1],[Category],[Category_Description],Ticket_category  FROM[Category_search].[dbo].[new_Category] ";

            string condition = string.Empty;
            string condition2 = string.Empty;
            foreach (ListItem item in lstFruits.Items)
            {
                condition += item.Selected ? string.Format("'{0}',", item.Value) : "";
            }

            foreach (ListItem item in ListBox1.Items)
            {
                condition2 += item.Selected ? string.Format("'{0}',", item.Value) : "";
            }

             if (!string.IsNullOrEmpty(condition) && !string.IsNullOrEmpty(condition2))
            {
                condition = string.Format(" WHERE [Schema_Identifier] IN ({0})", condition.Substring(0, condition.Length - 1));
                condition2 = string.Format(" and [Ticket_category] IN ({0})", condition2.Substring(0, condition2.Length - 1));


                using (SqlConnection con = new SqlConnection(conString))
                {
                    using (SqlCommand cmd = new SqlCommand(query + condition + condition2))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            cmd.Connection = con;
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                GridView1.DataSource = dt;
                                GridView1.DataBind();
                            }
                        }
                    }
                }
            }

            else  if (!string.IsNullOrEmpty(condition))
            {
                condition = string.Format(" WHERE [Schema_Identifier] IN ({0})", condition.Substring(0, condition.Length - 1));
            

            using (SqlConnection con = new SqlConnection(conString))
            {
                using (SqlCommand cmd = new SqlCommand(query + condition))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        cmd.Connection = con;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            GridView1.DataSource = dt;
                            GridView1.DataBind();
                        }
                    }
                }
            }
            }

         
        }

    }

    protected void OnSelectedIndexChanged(object sender, EventArgs e)
    {
        //string id = GridView1.SelectedRow.Cells[8].Text;
        //string id1 = GridView1.SelectedRow.Cells[5].Text;
        GridViewRow row1 = GridView1.SelectedRow;
        string id = (row1.FindControl("Label2") as Label).Text;
        string id1 = (row1.FindControl("Label2") as Label).Text;

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["viplist"].ConnectionString);
        SqlCommand cmd = new SqlCommand("SELECT distinct t, SLA,[SP_IRT_Very_High] ,  [SP_IRT_High]  ,[SP_IRT_Medium] ,[SP_IRT_Low] ,[SP_MPT_Very_High] ,[SP_MPT_High] ,[SP_MPT_Medium] ,[SP_MPT_Low]  FROM [Category_search].[dbo].[slaview] WHERE [Category_des]='" + id + "' and t is not null and sla is not null", con);
        cmd.Parameters.AddWithValue("@Service_Provider_SLA", id);
        //cmd.Parameters.AddWithValue("@Service_Provider_SLA1", id1);
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        GridView3.DataSource = dt;
        if (dt.Rows.Count > 0)
        {
            GridView3.DataBind();
            GridView3.Visible = true;
        }
        else if (dt.Rows.Count == 0)
        {
            GridView3.Visible = false;
        }

            // GridView3.Visible = true;


            GridViewRow row = GridView1.SelectedRow;
        string id5 = (row.FindControl("Label2") as Label).Text;

        string category = (row.FindControl("Label1") as Label).Text;

        

        //  string id5 = GridView1.SelectedRow.Cells[2].Text;
        SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["viplist"].ConnectionString);
        SqlCommand cmd1 = new SqlCommand("SELECT distinct Service_Team,Receiver FROM [Category_search].[dbo].[new_Category] WHERE  [Category_Description]= '" + id5 + "' and Category ='"+category+"' ", con);
        //cmd1.Parameters.AddWithValue("@Service_Team", id3);
        //cmd1.Parameters.AddWithValue("@Receiver", id4);
        SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
        DataTable dt1 = new DataTable();
        sda1.Fill(dt1);
        GridView2.DataSource = dt1;
        GridView2.DataBind();

    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
       
    }

    private void BindGrid()
    {


        if (txtdescription.Text != "" && txtcategory.Text != "")
        {
            string conString = ConfigurationManager.ConnectionStrings["viplist"].ConnectionString;
            string query = "SELECT distinct   [Schema_Identifier1],[Category],[Category_Description],Ticket_category FROM[Category_search].[dbo].[new_category] ";

            string condition = string.Empty;
            foreach (ListItem item in lstFruits.Items)
            {
                condition += item.Selected ? string.Format("'{0}',", item.Value) : "";
            }
            if (condition == "")
            {
                con.Open();
                // SqlCommand cmd = new SqlCommand("SELECT [TRANS_TYPE],[EQUI_NO],[USER_ID],[Status],[RSA],[RSA_SERIL],[JABRA],[DATA_CARD],[DATA_EQP],[MIFI],[MIFI_EQP],[UNI_ADUP],[PRIV_FIL],[OTHER_Des],[R_Status],BUILDING from[NewEquipment].[dbo].[ROP]", con);
                SqlCommand cmd = new SqlCommand("SELECT distinct [Schema_Identifier1],[Category],[Category_Description],Ticket_category  FROM[Category_search].[dbo].[new_Category] where  Category like'%" + txtcategory.Text + "%' and Category_Description like'%" + txtdescription.Text + "%' ", con);

                SqlDataAdapter da = new SqlDataAdapter();
                // con.Close();
                DataSet ds = new DataSet();
                DataTable table = new DataTable();

                // da.SelectCommand = cmd;
                table.Load(cmd.ExecuteReader());
                //da.Fill(ds);
                GridView1.DataSource = table;
                GridView1.DataBind();
                con.Close();

                Session["Name"] = txtcategory.Text;
                Session["Name1"] = txtdescription.Text;
                // Response.Redirect("~/catdescription.ashx");
            }
            else
            {



                if (!string.IsNullOrEmpty(condition))
                {
                    condition = string.Format(" WHERE [Schema_Identifier] IN ({0}) and Category_Description like'%" + txtdescription.Text + "%' and Category like'%" + txtcategory.Text + "%'", condition.Substring(0, condition.Length - 1));
                }

                using (SqlConnection con = new SqlConnection(conString))
                {
                    using (SqlCommand cmd = new SqlCommand(query + condition))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            cmd.Connection = con;
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                GridView1.DataSource = dt;
                                GridView1.DataBind();
                            }
                        }
                    }
                }

                Session["Name"] = txtcategory.Text;

            }
        }
        else if (txtcategory.Text != "")
        {
            string conString = ConfigurationManager.ConnectionStrings["viplist"].ConnectionString;
            string query = "SELECT distinct [Schema_Identifier1],[Category],[Category_Description],Ticket_category  FROM[Category_search].[dbo].[new_Category] ";

            string condition = string.Empty;
            foreach (ListItem item in lstFruits.Items)
            {
                condition += item.Selected ? string.Format("'{0}',", item.Value) : "";
            }
            if (condition == "")
            {
                con.Open();
                // SqlCommand cmd = new SqlCommand("SELECT [TRANS_TYPE],[EQUI_NO],[USER_ID],[Status],[RSA],[RSA_SERIL],[JABRA],[DATA_CARD],[DATA_EQP],[MIFI],[MIFI_EQP],[UNI_ADUP],[PRIV_FIL],[OTHER_Des],[R_Status],BUILDING from[NewEquipment].[dbo].[ROP]", con);
                SqlCommand cmd = new SqlCommand("SELECT distinct [Schema_Identifier1],[Category],[Category_Description],Ticket_category  FROM[Category_search].[dbo].[new_Category] where Category like'" + txtcategory.Text + "%' ", con);

                SqlDataAdapter da = new SqlDataAdapter();
                // con.Close();
                DataSet ds = new DataSet();
                DataTable table = new DataTable();

                // da.SelectCommand = cmd;
                table.Load(cmd.ExecuteReader());
                //da.Fill(ds);
                GridView1.DataSource = table;
                GridView1.DataBind();
                con.Close();
            }
            else
            {



                if (!string.IsNullOrEmpty(condition))
                {
                    condition = string.Format(" WHERE [Schema_Identifier] IN ({0}) and Category like'%" + txtcategory.Text + "%'", condition.Substring(0, condition.Length - 1));
                }

                using (SqlConnection con = new SqlConnection(conString))
                {
                    using (SqlCommand cmd = new SqlCommand(query + condition))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            cmd.Connection = con;
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                GridView1.DataSource = dt;
                                GridView1.DataBind();
                            }
                        }
                    }
                }

            }
        }

        else if (txtdescription.Text != "")
        {
            string conString = ConfigurationManager.ConnectionStrings["viplist"].ConnectionString;
            string query = "SELECT distinct [Schema_Identifier1],[Category],[Category_Description],Ticket_category  FROM[Category_search].[dbo].[new_Category] ";

            string condition = string.Empty;
            foreach (ListItem item in lstFruits.Items)
            {
                condition += item.Selected ? string.Format("'{0}',", item.Value) : "";
            }
            if (condition == "")
            {
                con.Open();
                // SqlCommand cmd = new SqlCommand("SELECT [TRANS_TYPE],[EQUI_NO],[USER_ID],[Status],[RSA],[RSA_SERIL],[JABRA],[DATA_CARD],[DATA_EQP],[MIFI],[MIFI_EQP],[UNI_ADUP],[PRIV_FIL],[OTHER_Des],[R_Status],BUILDING from[NewEquipment].[dbo].[ROP]", con);
                SqlCommand cmd = new SqlCommand("SELECT distinct [Schema_Identifier1],[Category],[Category_Description],Ticket_category  FROM[Category_search].[dbo].[new_Category]where Category_Description like '%" + txtdescription.Text + "%' ", con);

                SqlDataAdapter da = new SqlDataAdapter();
                // con.Close();
                DataSet ds = new DataSet();
                DataTable table = new DataTable();

                // da.SelectCommand = cmd;
                table.Load(cmd.ExecuteReader());
                //da.Fill(ds);
                GridView1.DataSource = table;
                GridView1.DataBind();
                con.Close();
            }
            else
            {



                if (!string.IsNullOrEmpty(condition))
                {
                    condition = string.Format(" WHERE [Schema_Identifier] IN ({0}) and Category_Description like '%" + txtdescription.Text + "%'", condition.Substring(0, condition.Length - 1));
                }

                using (SqlConnection con = new SqlConnection(conString))
                {
                    using (SqlCommand cmd = new SqlCommand(query + condition))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            cmd.Connection = con;
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                GridView1.DataSource = dt;
                                GridView1.DataBind();
                            }
                        }
                    }
                }

            }
        }
        else
        {


            //var message = ;
            //foreach (ListItem item in lstFruits.Items)
            //{
            //    if (item.Selected)
            //    {
            //        //message +=  item.Value + "'" + ",";
            //        var val = "'" + item.Value + "'" ;
            //    }
            //}



            //string first = "";

            //SqlCommand cmd = new SqlCommand("SELECT [RID],[Schema_Identifier],[Category],[Category_Description] ,[Category_Status],[Selectable],[Mandatory_Eqt] ,[SLA],[Service_Team],[Receiver],[Service_Provider_SLA],case when[IRT_Very High] = '0' then '-' else [IRT_Very High] end as IRT_Very_High ,case when[IRT_High] = '0' then '-' else [IRT_High]end as IRT_High,case when[IRT_Medium]='0' then '-' else [IRT_Medium] end as IRT_Medium ,case when[IRT_Low]='0' then '-' else [IRT_Low] end as IRT_Low ,case when[MPT_Very_High]='0' then '-' else [MPT_Very_High] end as MPT_Very_High ,case when[MPT_High]='0' then '-' else [MPT_High] end as MPT_High ,case when[MPT_Medium]='0' then '-' else [MPT_Medium]end as MPT_Medium  ,case when[MPT_Low]='0' then '-' else [MPT_Low] end as MPT_Low FROM[Category_search].[dbo].[new_Category_search] where Category='"+ message + "' order by[Service_Team] asc'", con);

            //SqlDataAdapter da = new SqlDataAdapter();
            //// con.Close();
            //DataSet ds = new DataSet();
            //DataTable table = new DataTable();

            //// da.SelectCommand = cmd;
            //table.Load(cmd.ExecuteReader());
            ////da.Fill(ds);
            //GridView1.DataSource = table;
            //GridView1.DataBind();
            //con.Close();

            //ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('" + message + "');", true);

            string conString = ConfigurationManager.ConnectionStrings["viplist"].ConnectionString;
            string query = "SELECT distinct [Schema_Identifier1],[Category],[Category_Description],Ticket_category  FROM[Category_search].[dbo].[new_Category] ";

            string condition = string.Empty;
            foreach (ListItem item in lstFruits.Items)
            {
                condition += item.Selected ? string.Format("'{0}',", item.Value) : "";
            }

            if (!string.IsNullOrEmpty(condition))
            {
                condition = string.Format(" WHERE [Schema_Identifier] IN ({0})", condition.Substring(0, condition.Length - 1));
            }

            using (SqlConnection con = new SqlConnection(conString))
            {
                using (SqlCommand cmd = new SqlCommand(query + condition))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        cmd.Connection = con;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            GridView1.DataSource = dt;
                            GridView1.DataBind();
                        }
                    }
                }
            }
        }

    }

    protected void txtcategory_TextChanged(object sender, EventArgs e)
    {

       
        if (txtdescription.Text != "" && txtcategory.Text != "")
        {
            string conString = ConfigurationManager.ConnectionStrings["viplist"].ConnectionString;
            string query = "SELECT distinct [Schema_Identifier1],[Category],[Category_Description],Ticket_category  FROM[Category_search].[dbo].[new_Category]";

            string condition = string.Empty;
            string condition1 = string.Empty;
            string condition2 = string.Empty;
            foreach (ListItem item in lstFruits.Items)
            {
                condition += item.Selected ? string.Format("'{0}',", item.Value) : "";
                condition1 += item.Selected ? string.Format("'{0}',", item.Value) : "";
            }
            foreach (ListItem item in ListBox1.Items)
            {
                condition2 += item.Selected ? string.Format("'{0}',", item.Value) : "";
            }


            if (condition == "")
            {
                con.Open();
                // SqlCommand cmd = new SqlCommand("SELECT [TRANS_TYPE],[EQUI_NO],[USER_ID],[Status],[RSA],[RSA_SERIL],[JABRA],[DATA_CARD],[DATA_EQP],[MIFI],[MIFI_EQP],[UNI_ADUP],[PRIV_FIL],[OTHER_Des],[R_Status],BUILDING from[NewEquipment].[dbo].[ROP]", con);
                SqlCommand cmd = new SqlCommand("SELECT distinct [Schema_Identifier1],[Category],[Category_Description],Ticket_category  FROM[Category_search].[dbo].[new_Category] where Category_Description like'%" + txtdescription.Text + "%' and Category like'%" + txtcategory.Text + "%' ", con);

                SqlDataAdapter da = new SqlDataAdapter();
                // con.Close();
                DataSet ds = new DataSet();
                DataTable table = new DataTable();

                // da.SelectCommand = cmd;
                table.Load(cmd.ExecuteReader());
                //da.Fill(ds);
                GridView1.DataSource = table;
                GridView1.DataBind();
                con.Close();

                Session["Name"] = txtdescription.Text;
                Session["Name3"] = condition1;
                Session["Name1"] = txtcategory.Text;
                Session["Name4"] = condition1 + condition2;
                //  Response.Redirect("~/catagory.ashx");
            }
            else
            {

                if (!string.IsNullOrEmpty(condition) && !string.IsNullOrEmpty(condition2))
                {
                    condition = string.Format(" WHERE [Schema_Identifier] IN ({0})", condition.Substring(0, condition.Length - 1));
                    condition2 = string.Format(" and [Ticket_category] IN ({0})", condition2.Substring(0, condition2.Length - 1));

                    condition1 = string.Format(" WHERE [Schema_Identifier] IN ({0}) and Category_Description like'%" + txtdescription.Text + "%' ", condition1.Substring(0, condition1.Length - 1));

                    using (SqlConnection con = new SqlConnection(conString))
                    {
                        using (SqlCommand cmd = new SqlCommand(query + condition + condition2))
                        {
                            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                            {
                                cmd.Connection = con;
                                using (DataTable dt = new DataTable())
                                {
                                    sda.Fill(dt);
                                    GridView1.DataSource = dt;
                                    GridView1.DataBind();
                                }
                            }
                        }
                    }

                    Session["Name"] = txtdescription.Text;
                    Session["Name3"] = "";
                    Session["Name1"] = txtcategory.Text;
                    Session["Name4"] = condition1 + condition2;
                    

                    // Response.Redirect("catagory.ashx");
                }


              else  if (!string.IsNullOrEmpty(condition) && string.IsNullOrEmpty(condition2))
                {
                    condition = string.Format(" WHERE [Schema_Identifier] IN ({0}) and Category_Description like'%" + txtdescription.Text + "%' and Category like'%" + txtcategory.Text + "%'", condition.Substring(0, condition.Length - 1));
                    condition1 = string.Format(" WHERE [Schema_Identifier] IN ({0}) and Category_Description like'%" + txtdescription.Text + "%' ", condition1.Substring(0, condition1.Length - 1));


                    using (SqlConnection con = new SqlConnection(conString))
                    {
                        using (SqlCommand cmd = new SqlCommand(query + condition))
                        {
                            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                            {
                                cmd.Connection = con;
                                using (DataTable dt = new DataTable())
                                {
                                    sda.Fill(dt);
                                    GridView1.DataSource = dt;
                                    GridView1.DataBind();
                                }
                            }
                        }
                    }

                    Session["Name"] = txtdescription.Text;
                    Session["Name3"] = condition1;
                    Session["Name1"] = txtcategory.Text;
                    Session["Name4"] = "";
                }
            }
        }

        else if (txtcategory.Text != "")
        {
            string conString = ConfigurationManager.ConnectionStrings["viplist"].ConnectionString;
            string query = "SELECT distinct [Schema_Identifier1],[Category],[Category_Description],Ticket_category  FROM[Category_search].[dbo].[new_Category] ";

            string condition = string.Empty;
            string condition1 = string.Empty;
            string condition2 = string.Empty;

            foreach (ListItem item in lstFruits.Items)
            {
                condition += item.Selected ? string.Format("'{0}',", item.Value) : "";
                condition1 += item.Selected ? string.Format("'{0}',", item.Value) : "";
            }
            foreach (ListItem item in ListBox1.Items)
            {
                condition2 += item.Selected ? string.Format("'{0}',", item.Value) : "";
            }
            if (condition == "")
            {
                con.Open();
                // SqlCommand cmd = new SqlCommand("SELECT [TRANS_TYPE],[EQUI_NO],[USER_ID],[Status],[RSA],[RSA_SERIL],[JABRA],[DATA_CARD],[DATA_EQP],[MIFI],[MIFI_EQP],[UNI_ADUP],[PRIV_FIL],[OTHER_Des],[R_Status],BUILDING from[NewEquipment].[dbo].[ROP]", con);
                SqlCommand cmd = new SqlCommand("SELECT distinct [Schema_Identifier1],[Category],[Category_Description],Ticket_category  FROM[Category_search].[dbo].[new_Category] where Category like'%" + txtcategory.Text+"%'", con);

                SqlDataAdapter da = new SqlDataAdapter();
                // con.Close();
                DataSet ds = new DataSet();
                DataTable table = new DataTable();

                // da.SelectCommand = cmd;
                table.Load(cmd.ExecuteReader());
                //da.Fill(ds);
                GridView1.DataSource = table;
                GridView1.DataBind();
                con.Close();

                Session["Name"] = txtdescription.Text;
                Session["Name1"] = txtcategory.Text;
                Session["Name3"] = condition1;
                Session["Name4"] = condition1 + condition2;
                //Response.Redirect("~/catagory.ashx");
            }
            else
            {


                if (!string.IsNullOrEmpty(condition) && !string.IsNullOrEmpty(condition2))
                {
                    condition = string.Format(" WHERE [Schema_Identifier] IN ({0})", condition.Substring(0, condition.Length - 1));
                    condition2 = string.Format(" and [Ticket_category] IN ({0})", condition2.Substring(0, condition2.Length - 1));

                    condition1 = string.Format(" WHERE [Schema_Identifier] IN ({0}) and Category like'%" + txtcategory.Text + "%' ", condition1.Substring(0, condition1.Length - 1));

                    using (SqlConnection con = new SqlConnection(conString))
                    {
                        using (SqlCommand cmd = new SqlCommand(query + condition1 + condition2))
                        {
                            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                            {
                                cmd.Connection = con;
                                using (DataTable dt = new DataTable())
                                {
                                    sda.Fill(dt);
                                    GridView1.DataSource = dt;
                                    GridView1.DataBind();
                                }
                            }
                        }
                    }

                    Session["Name"] = txtdescription.Text;
                    Session["Name3"] = "";
                    Session["Name1"] = txtcategory.Text;
                    Session["Name4"] = condition + condition2;

                   // Response.Redirect("catagory.ashx");
                }


              else  if (!string.IsNullOrEmpty(condition) && string.IsNullOrEmpty(condition2))
                {
                    condition = string.Format(" WHERE [Schema_Identifier] IN ({0}) and Category like '%" + txtcategory.Text + "%'", condition.Substring(0, condition.Length - 1));
                    condition1 = string.Format(" WHERE [Schema_Identifier] IN ({0}) ", condition1.Substring(0, condition1.Length - 1));
                

                using (SqlConnection con = new SqlConnection(conString))
                {
                    using (SqlCommand cmd = new SqlCommand(query + condition))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            cmd.Connection = con;
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                GridView1.DataSource = dt;
                                GridView1.DataBind();
                            }
                        }
                    }
                }

                Session["Name"] = txtdescription.Text;
                Session["Name3"] = condition1;
                Session["Name1"] = txtcategory.Text;
                Session["Name4"] = "";
                    //  Response.Redirect("~/catagory.ashx");
                }
            }
        }

        else if (txtdescription.Text != "")
        {
            string conString = ConfigurationManager.ConnectionStrings["viplist"].ConnectionString;
            string query = "SELECT distinct [Schema_Identifier1],[Category],[Category_Description],Ticket_category  FROM[Category_search].[dbo].[new_Category] ";

            string condition = string.Empty;
            foreach (ListItem item in lstFruits.Items)
            {
                condition += item.Selected ? string.Format("'{0}',", item.Value) : "";
            }
            if (condition == "")
            {
                con.Open();
                // SqlCommand cmd = new SqlCommand("SELECT [TRANS_TYPE],[EQUI_NO],[USER_ID],[Status],[RSA],[RSA_SERIL],[JABRA],[DATA_CARD],[DATA_EQP],[MIFI],[MIFI_EQP],[UNI_ADUP],[PRIV_FIL],[OTHER_Des],[R_Status],BUILDING from[NewEquipment].[dbo].[ROP]", con);
                SqlCommand cmd = new SqlCommand("SELECT distinct [Schema_Identifier1],[Category],[Category_Description],Ticket_category  FROM[Category_search].[dbo].[new_Category] where Category_Description like '%" + txtdescription.Text + "%' ", con);

                SqlDataAdapter da = new SqlDataAdapter();
                // con.Close();
                DataSet ds = new DataSet();
                DataTable table = new DataTable();

                // da.SelectCommand = cmd;
                table.Load(cmd.ExecuteReader());
                //da.Fill(ds);
                GridView1.DataSource = table;
                GridView1.DataBind();
                con.Close();

                Session["Name"] = txtdescription.Text;
                //  Response.Redirect("~/catagory.ashx");
            }
            else
            {




                if (!string.IsNullOrEmpty(condition))
                {
                    condition = string.Format(" WHERE [Schema_Identifier] IN ({0}) and Category_Description like'%" + txtdescription.Text + "%'", condition.Substring(0, condition.Length - 1));
                }

                using (SqlConnection con = new SqlConnection(conString))
                {
                    using (SqlCommand cmd = new SqlCommand(query + condition))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            cmd.Connection = con;
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                GridView1.DataSource = dt;
                                GridView1.DataBind();
                            }
                        }
                    }
                }

                Session["Name"] = txtdescription.Text;

            }
        }
        else
        {


            string conString = ConfigurationManager.ConnectionStrings["viplist"].ConnectionString;
            string query = "SELECT distinct [Schema_Identifier1],[Category],[Category_Description],Ticket_category  FROM[Category_search].[dbo].[new_Category] ";

            string condition = string.Empty;
            foreach (ListItem item in lstFruits.Items)
            {
                condition += item.Selected ? string.Format("'{0}',", item.Value) : "";
            }

            if (!string.IsNullOrEmpty(condition))
            {
                condition = string.Format(" WHERE [Schema_Identifier] IN ({0})", condition.Substring(0, condition.Length - 1));
            }

            using (SqlConnection con = new SqlConnection(conString))
            {
                using (SqlCommand cmd = new SqlCommand(query + condition))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        cmd.Connection = con;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            GridView1.DataSource = dt;
                            GridView1.DataBind();
                        }
                    }
                }
            }
         //  Response.Redirect("catagory.ashx");
        }
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridView1, "Select$" + e.Row.RowIndex);
            e.Row.ToolTip = "Click to check Service team and SLA details.";
        }

    }

  

    protected void ImageButton1_Click1(object sender, ImageClickEventArgs e)
    {
        Page.Response.Redirect(HttpContext.Current.Request.Url.ToString(), true);
    }

    protected void txtdescription_TextChanged(object sender, EventArgs e)
  {

        //con.Open();
        //SqlCommand cmd = new SqlCommand("SELECT [RID],[Schema_Identifier],[Category],[Category_Description] ,case when[Category_Status]='No' then 'Active' else 'inactive' end as Category_Status,[Selectable],[Mandatory_Eqt] ,[SLA],case when [Service_Team]='0' then '-' else [Service_Team] end as Service_Team,[Receiver],[Service_Provider_SLA],case when[IRT_Very High] = '0' then '-' else [IRT_Very High] end as IRT_Very_High ,case when[IRT_High] = '0' then '-' else [IRT_High]end as IRT_High,case when[IRT_Medium]='0' then '-' else [IRT_Medium] end as IRT_Medium ,case when[IRT_Low]='0' then '-' else [IRT_Low] end as IRT_Low ,case when[MPT_Very_High]='0' then '-' else [MPT_Very_High] end as MPT_Very_High ,case when[MPT_High]='0' then '-' else [MPT_High] end as MPT_High ,case when[MPT_Medium]='0' then '-' else [MPT_Medium]end as MPT_Medium  ,case when[MPT_Low]='0' then '-' else [MPT_Low] end as MPT_Low FROM[Category_search].[dbo].[new_Category_search] where Category_Description like'%" + txtdescription.Text.Trim() + "%' order by[Service_Team] asc ", con);
        //SqlDataAdapter da = new SqlDataAdapter();
        //con.Close();
        //DataSet ds = new DataSet();
        //da.SelectCommand = cmd;
        //da.Fill(ds);
        //GridView1.DataSource = ds;
        //GridView1.DataBind();

        if (txtdescription.Text != "" && txtcategory.Text != "")
        {
            string conString = ConfigurationManager.ConnectionStrings["viplist"].ConnectionString;
            string query = "SELECT distinct [Schema_Identifier1],[Category],[Category_Description]  FROM[Category_search].[dbo].[new_Category] ";

            string condition = string.Empty;
            string condition1 = string.Empty;
            string condition2 = string.Empty;

            foreach (ListItem item in lstFruits.Items)
            {
                condition += item.Selected ? string.Format("'{0}',", item.Value) : "";
                condition1 += item.Selected ? string.Format("'{0}',", item.Value) : "";
            }

            foreach (ListItem item in ListBox1.Items)
            {
                condition2 += item.Selected ? string.Format("'{0}',", item.Value) : "";
            }

            if (condition == "")
            {
                con.Open();
                // SqlCommand cmd = new SqlCommand("SELECT [TRANS_TYPE],[EQUI_NO],[USER_ID],[Status],[RSA],[RSA_SERIL],[JABRA],[DATA_CARD],[DATA_EQP],[MIFI],[MIFI_EQP],[UNI_ADUP],[PRIV_FIL],[OTHER_Des],[R_Status],BUILDING from[NewEquipment].[dbo].[ROP]", con);
                SqlCommand cmd = new SqlCommand("SELECT distinct [Schema_Identifier1],[Category],[Category_Description],Ticket_category  FROM[Category_search].[dbo].[new_Category] where  Category like'%" + txtcategory.Text + "%' and Category_Description like'%" + txtdescription.Text + "%'  ", con);

                SqlDataAdapter da = new SqlDataAdapter();
                // con.Close();
                DataSet ds = new DataSet();
                DataTable table = new DataTable();

                // da.SelectCommand = cmd;
                table.Load(cmd.ExecuteReader());
                //da.Fill(ds);
                GridView1.DataSource = table;
                GridView1.DataBind();
                con.Close();

                Session["Name"] = txtcategory.Text;
                Session["Name1"] = txtdescription.Text;
                Session["Name3"] = "";
                Session["Name4"] = "";
                // Response.Redirect("~/catdescription.ashx");
            }
            else
            {

                if (!string.IsNullOrEmpty(condition) && !string.IsNullOrEmpty(condition2))
                {
                    condition = string.Format(" WHERE [Schema_Identifier] IN ({0})", condition.Substring(0, condition.Length - 1));
                    condition2 = string.Format(" and [Ticket_category] IN ({0})", condition2.Substring(0, condition2.Length - 1));

                    condition1 = string.Format(" WHERE [Schema_Identifier] IN ({0}) and Category like'%" + txtcategory.Text + "%' ", condition1.Substring(0, condition1.Length - 1));

                    using (SqlConnection con = new SqlConnection(conString))
                    {
                        using (SqlCommand cmd = new SqlCommand(query + condition1 + condition2))
                        {
                            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                            {
                                cmd.Connection = con;
                                using (DataTable dt = new DataTable())
                                {
                                    sda.Fill(dt);
                                    GridView1.DataSource = dt;
                                    GridView1.DataBind();
                                }
                            }
                        }
                    }

                    Session["Name"] = txtdescription.Text;
                    Session["Name3"] = "";
                    Session["Name1"] = txtcategory.Text;
                    Session["Name4"] = condition1 + condition2;

                    // Response.Redirect("catagory.ashx");
                }


                else if (!string.IsNullOrEmpty(condition) && string.IsNullOrEmpty(condition2))
                {
                    condition = string.Format(" WHERE [Schema_Identifier] IN ({0}) and Category_Description like'%" + txtdescription.Text + "%' and Category like'%" + txtcategory.Text + "%'", condition.Substring(0, condition.Length - 1));

                    condition1 = string.Format(" WHERE [Schema_Identifier] IN ({0}) and Category like'%" + txtcategory.Text + "%'  ", condition1.Substring(0, condition1.Length - 1));


                    using (SqlConnection con = new SqlConnection(conString))
                    {
                        using (SqlCommand cmd = new SqlCommand(query + condition))
                        {
                            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                            {
                                cmd.Connection = con;
                                using (DataTable dt = new DataTable())
                                {
                                    sda.Fill(dt);
                                    GridView1.DataSource = dt;
                                    GridView1.DataBind();
                                }
                            }
                        }
                    }

                    Session["Name3"] = condition1;
                    Session["Name"] = txtcategory.Text;
                    Session["Name1"] = txtdescription.Text;
                    Session["Name4"] = "";
                }
            }
        }

        else if (txtdescription.Text != "")
        {
            string conString = ConfigurationManager.ConnectionStrings["viplist"].ConnectionString;
            string query = "SELECT distinct [Schema_Identifier1],[Category],[Category_Description],Ticket_category  FROM[Category_search].[dbo].[new_Category] ";

            string condition = string.Empty;
            string condition1 = string.Empty;
            string condition2 = string.Empty;

            foreach (ListItem item in lstFruits.Items)
            {
                condition += item.Selected ? string.Format("'{0}',", item.Value) : "";
                condition1 += item.Selected ? string.Format("'{0}',", item.Value) : "";
            }
            foreach (ListItem item in ListBox1.Items)
            {
                condition2 += item.Selected ? string.Format("'{0}',", item.Value) : "";
            }
            if (condition == "")
            {
                con.Open();
                // SqlCommand cmd = new SqlCommand("SELECT [TRANS_TYPE],[EQUI_NO],[USER_ID],[Status],[RSA],[RSA_SERIL],[JABRA],[DATA_CARD],[DATA_EQP],[MIFI],[MIFI_EQP],[UNI_ADUP],[PRIV_FIL],[OTHER_Des],[R_Status],BUILDING from[NewEquipment].[dbo].[ROP]", con);
                SqlCommand cmd = new SqlCommand("SELECT distinct [Schema_Identifier1],[Category],[Category_Description],Ticket_category   FROM[Category_search].[dbo].[new_Category] where Category_Description like '%" + txtdescription.Text + "%' ", con);

                SqlDataAdapter da = new SqlDataAdapter();
                // con.Close();
                DataSet ds = new DataSet();
                DataTable table = new DataTable();

                // da.SelectCommand = cmd;
                table.Load(cmd.ExecuteReader());
                //da.Fill(ds);
                GridView1.DataSource = table;
                GridView1.DataBind();
                con.Close();

                Session["Name"] = txtcategory.Text;
                Session["Name3"] = "";
                Session["Name1"] = txtdescription.Text;
                Session["Name4"] = "";
                // Response.Redirect("~/catdescription.ashx");
            }
            else
            {

                if (!string.IsNullOrEmpty(condition) && !string.IsNullOrEmpty(condition2))
                {
                    condition = string.Format(" WHERE [Schema_Identifier] IN ({0} ) and Category_Description like '%" + txtdescription.Text + "%'", condition.Substring(0, condition.Length - 1));
                    condition2 = string.Format(" and [Ticket_category] IN ({0})", condition2.Substring(0, condition2.Length - 1));

                    condition1 = string.Format(" WHERE [Schema_Identifier] IN ({0} ) and Category_Description like '%" + txtdescription.Text + "%'", condition1.Substring(0, condition1.Length - 1));

                    using (SqlConnection con = new SqlConnection(conString))
                    {
                        using (SqlCommand cmd = new SqlCommand(query + condition + condition2))
                        {
                            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                            {
                                cmd.Connection = con;
                                using (DataTable dt = new DataTable())
                                {
                                    sda.Fill(dt);
                                    GridView1.DataSource = dt;
                                    GridView1.DataBind();
                                }
                            }
                        }
                    }

                    Session["Name"] = txtdescription.Text;
                    Session["Name3"] = "";
                    Session["Name1"] = txtcategory.Text;
                    Session["Name4"] = condition1 + condition2;

                    // Response.Redirect("catagory.ashx");
                }


              else  if (!string.IsNullOrEmpty(condition) && string.IsNullOrEmpty(condition2))
                {
                    condition = string.Format(" WHERE [Schema_Identifier] IN ({0}) and Category_Description like'%" + txtdescription.Text + "%'", condition.Substring(0, condition.Length - 1));
                   // condition2 = string.Format(" and [Ticket_category] IN ({0})", condition2.Substring(0, condition2.Length - 1));
                    condition1 = string.Format(" WHERE [Schema_Identifier] IN ({0} Category_Description like '%" + txtdescription.Text + "%')", condition1.Substring(0, condition1.Length - 1));


                    using (SqlConnection con = new SqlConnection(conString))
                    {
                        using (SqlCommand cmd = new SqlCommand(query + condition))
                        {
                            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                            {
                                cmd.Connection = con;
                                using (DataTable dt = new DataTable())
                                {
                                    sda.Fill(dt);
                                    GridView1.DataSource = dt;
                                    GridView1.DataBind();
                                }
                            }
                        }
                    }

                    Session["Name"] = txtcategory.Text;
                    Session["Name3"] = condition1;
                    Session["Name1"] = txtdescription.Text;
                    Session["Name4"] = "";
                    //Response.Redirect("~/catdescription.ashx");

                }
            }
        }
    }

    protected void ddcity_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
       
    }

    protected void GridView3_DataBound(object sender, EventArgs e)
    {
       

    }

    protected void GridView3_RowCreated(object sender, GridViewRowEventArgs e)
    {

        
    }

    protected void GridView1_RowCommand1(object sender, GridViewCommandEventArgs e)
    {
        //string id = GridView1.SelectedRow.Cells[8].Text;
        //string id1 = GridView1.SelectedRow.Cells[5].Text;
        GridViewRow row1 = GridView1.SelectedRow;
        string id = (row1.FindControl("Label2") as Label).Text;
        string id1 = (row1.FindControl("Label2") as Label).Text;

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["viplist"].ConnectionString);
        SqlCommand cmd = new SqlCommand("SELECT distinct t, SLA,[SP_IRT_Very_High] ,  [SP_IRT_High]  ,[SP_IRT_Medium] ,[SP_IRT_Low] ,[SP_MPT_Very_High] ,[SP_MPT_High] ,[SP_MPT_Medium] ,[SP_MPT_Low]  FROM [Category_search].[dbo].[slaview] WHERE [Category_des]='" + id + "'", con);
        cmd.Parameters.AddWithValue("@Service_Provider_SLA", id);
        //cmd.Parameters.AddWithValue("@Service_Provider_SLA1", id1);
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        GridView3.DataSource = dt;
        if (dt.Rows.Count > 0)
        {
            GridView3.DataBind();
            GridView3.Visible = true;
        }
        else if (dt.Rows.Count == 0)
        {
            GridView3.Visible = false;
        }

        // GridView3.Visible = true;


        GridViewRow row = GridView1.SelectedRow;
        string id5 = (row.FindControl("Label2") as Label).Text;

        //  string id5 = GridView1.SelectedRow.Cells[2].Text;
        SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["viplist"].ConnectionString);
        SqlCommand cmd1 = new SqlCommand("SELECT distinct Service_Team,Receiver FROM [Category_search].[dbo].[new_Category_search] WHERE  [Category_Description]= '" + id5 + "' ", con);
        //cmd1.Parameters.AddWithValue("@Service_Team", id3);
        //cmd1.Parameters.AddWithValue("@Receiver", id4);
        SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
        DataTable dt1 = new DataTable();
        sda1.Fill(dt1);
        GridView2.DataSource = dt1;
        GridView2.DataBind();
    }

    protected void GridView2_RowCreated(object sender, GridViewRowEventArgs e)
    {
        }

    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {



            GridViewRow gvr = e.Row;

            if (gvr.RowType == DataControlRowType.Header)
            {
                GridViewRow row = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);

                TableCell cell = new TableCell();
                cell.ColumnSpan = 2;
                cell.HorizontalAlign = HorizontalAlign.Center;
                cell.Text = "Service Team";
                row.Cells.Add(cell);

                row.BackColor = ColorTranslator.FromHtml("#fff");
                row.ForeColor = ColorTranslator.FromHtml("black");

                GridView2.Controls[0].Controls.AddAt(0, row);
            }

            }
        catch (Exception ex)
        {

        }
    }

    protected void lstFruits_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(txtcategory.Text=="" && txtdescription.Text == "")
        {

            string conString = ConfigurationManager.ConnectionStrings["viplist"].ConnectionString;
            string query = "SELECT distinct [Schema_Identifier1],[Category],[Category_Description],Ticket_category  FROM[Category_search].[dbo].[new_Category] ";

            string condition = string.Empty;
            string condition2 = string.Empty;
            foreach (ListItem item in lstFruits.Items)
            {
                condition += item.Selected ? string.Format("'{0}',", item.Value) : "";
            }

            foreach (ListItem item in ListBox1.Items)
            {
                condition2 += item.Selected ? string.Format("'{0}',", item.Value) : "";
            }

            if (!string.IsNullOrEmpty(condition) && !string.IsNullOrEmpty(condition2))
            {
                condition = string.Format(" WHERE [Schema_Identifier] IN ({0})", condition.Substring(0, condition.Length - 1));
                condition2 = string.Format(" and [Ticket_category] IN ({0})", condition2.Substring(0, condition2.Length - 1));


                using (SqlConnection con = new SqlConnection(conString))
                {
                    using (SqlCommand cmd = new SqlCommand(query + condition + condition2))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            cmd.Connection = con;
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                GridView1.DataSource = dt;
                                GridView1.DataBind();
                            }
                        }
                    }
                }
            }
            else if (!string.IsNullOrEmpty(condition) )
            {
                condition = string.Format(" WHERE [Schema_Identifier] IN ({0})", condition.Substring(0, condition.Length - 1));
               // condition2 = string.Format(" and [Ticket_category] IN ({0})", condition2.Substring(0, condition2.Length - 1));


                using (SqlConnection con = new SqlConnection(conString))
                {
                    using (SqlCommand cmd = new SqlCommand(query + condition ))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            cmd.Connection = con;
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                GridView1.DataSource = dt;
                                GridView1.DataBind();
                            }
                        }
                    }
                }
            }
        }
    }

    protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (txtcategory.Text == "" && txtdescription.Text == "")
        {

            string conString = ConfigurationManager.ConnectionStrings["viplist"].ConnectionString;
            string query = "SELECT distinct [Schema_Identifier1],[Category],[Category_Description],Ticket_category  FROM[Category_search].[dbo].[new_Category] ";

            string condition = string.Empty;
            string condition2 = string.Empty;
            foreach (ListItem item in lstFruits.Items)
            {
                condition += item.Selected ? string.Format("'{0}',", item.Value) : "";
            }

            foreach (ListItem item in ListBox1.Items)
            {
                condition2 += item.Selected ? string.Format("'{0}',", item.Value) : "";
            }

            if (!string.IsNullOrEmpty(condition) && !string.IsNullOrEmpty(condition2))
            {
                condition = string.Format(" WHERE [Schema_Identifier] IN ({0})", condition.Substring(0, condition.Length - 1));
                condition2 = string.Format(" and [Ticket_category] IN ({0})", condition2.Substring(0, condition2.Length - 1));


                using (SqlConnection con = new SqlConnection(conString))
                {
                    using (SqlCommand cmd = new SqlCommand(query + condition + condition2))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            cmd.Connection = con;
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                GridView1.DataSource = dt;
                                GridView1.DataBind();
                            }
                        }
                    }
                }
            }
            else if (!string.IsNullOrEmpty(condition))
            {
                condition = string.Format(" WHERE [Schema_Identifier] IN ({0})", condition.Substring(0, condition.Length - 1));
                // condition2 = string.Format(" and [Ticket_category] IN ({0})", condition2.Substring(0, condition2.Length - 1));


                using (SqlConnection con = new SqlConnection(conString))
                {
                    using (SqlCommand cmd = new SqlCommand(query + condition))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            cmd.Connection = con;
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                GridView1.DataSource = dt;
                                GridView1.DataBind();
                            }
                        }
                    }
                }
            }

            else if (!string.IsNullOrEmpty(condition2))
            {
                //condition = string.Format(" WHERE [Schema_Identifier] IN ({0})", condition.Substring(0, condition.Length - 1));
                 condition2 = string.Format(" WHERE [Ticket_category] IN ({0})", condition2.Substring(0, condition2.Length - 1));


                using (SqlConnection con = new SqlConnection(conString))
                {
                    using (SqlCommand cmd = new SqlCommand(query + condition2))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            cmd.Connection = con;
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                GridView1.DataSource = dt;
                                GridView1.DataBind();
                            }
                        }
                    }
                }
            }
        }
    }

    protected void ImageButton1_Click1(object sender, EventArgs e)
    {
        Page.Response.Redirect(HttpContext.Current.Request.Url.ToString(), true);
    }
}
