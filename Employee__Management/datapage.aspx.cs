using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace Employee__Management
{
    public partial class datapage : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("data source=DESKTOP-EIES60D\\SQLEXPRESS01;initial catalog=Employeedb;integrated security=true");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCountry();
                BindDepartment();
                BindGender();
                ddlempstate.Items.Insert(0, new ListItem("---select---", "0"));
                ddlempstate.Enabled = false;
            }
        }

        public void BindGrid() //show data on page
        {
            
            
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from employee join tblgender on gender = genderid join tbldepartment on department = departmentid join tblcountry on country = countryid join tblempstate on empstate = empstateid", con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                con.Close();
                grdv.DataSource = dt;
                grdv.DataBind();
                
            
            
        }

        public void cleardata() // clear all boxes after submit and update data
        {
            txtname.Text = "";
            txtSalary.Text = "";
            txtemail.Text = "";
            txtpassword.Text = "";
            rblgender.ClearSelection();
            ddldepartment.SelectedValue = "0";
            ddlcountry.SelectedValue = "0";
            ddlempstate.SelectedValue = "0";
            btnsubmit.Text = "submit";
        }

        public void BindGender()  
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from tblgender", con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            rblgender.DataValueField = "genderid";
            rblgender.DataTextField = "gendername";
            rblgender.DataSource = dt;
            rblgender.DataBind();
        }

        public void BindCountry()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from tblcountry", con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            ddlcountry.DataValueField = "countryid";
            ddlcountry.DataTextField = "countryname";
            ddlcountry.DataSource = dt;
            ddlcountry.DataBind();
            ddlcountry.Items.Insert(0, new ListItem("---select---","0"));
        }

        public void BindDepartment()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from tbldepartment", con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            ddldepartment.DataValueField = "departmentid";
            ddldepartment.DataTextField = "departmentname";
            ddldepartment.DataSource = dt;
            ddldepartment.DataBind();
            ddldepartment.Items.Insert(0, new ListItem("---select---", "0"));
        }

        public void BindEmpState()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from tblempstate where countryid='"+ddlcountry.SelectedValue+"'", con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            ddlempstate.Enabled = true;
            ddlempstate.DataValueField = "empstateid";
            ddlempstate.DataTextField = "empstatename";
            ddlempstate.DataSource = dt;
            ddlempstate.DataBind();
            ddlempstate.Items.Insert(0, new ListItem("---select---", "0"));
        }

        protected void ddlcountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlcountry.SelectedValue == "0")
            {
                ddlempstate.Enabled = false;
                ddlempstate.SelectedValue= "0";
            }

            else
            {
                BindEmpState();
            }
            
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            if (btnsubmit.Text == "submit") // fetch data 
            { 
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into employee(name,email,password,salary,gender,department,country,empstate)values('"+txtname.Text+ "','"+txtemail.Text+"','"+txtpassword.Text+"','" + txtSalary.Text+"','"+rblgender.SelectedValue+"','"+ddldepartment.SelectedValue+"','"+ddlcountry.SelectedValue+"','"+ddlempstate.SelectedValue+"')", con);
            cmd.ExecuteNonQuery();
            con.Close();
            BindGrid();
            cleardata();
            }
            else if (btnsubmit.Text == "update") // update data 
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("update employee set name='" + txtname.Text + "',email='" + txtemail.Text +"',password='" + txtpassword.Text +"',salary='" + txtSalary.Text + "',gender='" + rblgender.SelectedValue + "',department='" + ddldepartment.SelectedValue + "',country='" + ddlcountry.SelectedValue + "',empstate='" + ddlempstate.SelectedValue + "' where id='" + ViewState["id"] + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                BindGrid();
                cleardata();
                btnsubmit.Text = "submit";
            }

        }

        protected void grdv_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName== "delete_data")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("delete from employee where id='" + e.CommandArgument + "'",con);
                cmd.ExecuteNonQuery();
                con.Close();
                BindGrid();
            }
            else if(e.CommandName == "edit_data")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select *from employee where id='" + e.CommandArgument + "'", con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                con.Close();
                txtname.Text = dt.Rows[0]["name"].ToString();
                txtemail.Text = dt.Rows[0]["email"].ToString();
                txtpassword.Text = dt.Rows[0]["password"].ToString();
                txtSalary.Text= dt.Rows[0]["salary"].ToString();
                rblgender.SelectedValue = dt.Rows[0]["gender"].ToString();
                ddldepartment.SelectedValue = dt.Rows[0]["department"].ToString();
                ddlcountry.SelectedValue = dt.Rows[0]["country"].ToString();
                BindEmpState();
                ddlempstate.SelectedValue = dt.Rows[0]["empstate"].ToString();
                btnsubmit.Text = "update";
                ViewState["id"]=e.CommandArgument;
                BindGrid();
            }
        }

        protected void grdv_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}