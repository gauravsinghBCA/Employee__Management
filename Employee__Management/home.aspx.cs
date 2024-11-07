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
    public partial class home : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("data source=DESKTOP-EIES60D\\SQLEXPRESS01;initial catalog=Employeedb;integrated security=true");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) { 
            
                BindGrid();
            }
        }


        public void BindGrid() //show data on page
        {


            con.Open();
            SqlCommand cmd = new SqlCommand("select * from employee join tblgender on gender = genderid join tbldepartment on department = departmentid join tblcountry on country = countryid join tblempstate on empstate = empstateid where id='" + Session["uid"] + "'", con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            grdv.DataSource = dt;
            grdv.DataBind();

            lblname.Text = dt.Rows[0]["Name"].ToString();

        }
    }
}