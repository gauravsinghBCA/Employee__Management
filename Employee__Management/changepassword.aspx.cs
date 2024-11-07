using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;


namespace Employee__Management
{
    public partial class changepassword : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("data source=DESKTOP-EIES60D\\SQLEXPRESS01;initial catalog=Employeedb;integrated security=true");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnlogin_Click(object sender, EventArgs e)
        {

        }
    }
}