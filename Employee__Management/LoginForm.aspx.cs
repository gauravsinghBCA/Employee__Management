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
    public partial class LoginForm : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("data source=DESKTOP-EIES60D\\SQLEXPRESS01;initial catalog=Employeedb;integrated security=true");


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnlogin_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from employee where email='"+txtmail.Text+"' and password='"+txtepassword.Text+"' ",con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            if(dt.Rows.Count == 0)
            {
                lblmassage.Text = "Login failed!!";
            }
             else {
                Session["uid"] = dt.Rows[0]["id"];
                Response.Redirect("home.aspx");
            }
        }
    }
}