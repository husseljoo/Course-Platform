using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace GUCera_Web
{
    public partial class ViewPromocode : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["GUCera_DB"].ToString();

            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand cmd = new SqlCommand("viewPromocode", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            int sid = Int32.Parse((String)Session["user"]);
            cmd.Parameters.Add(new SqlParameter("@sid", sid));
            conn.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();


            dt.Load(reader);
            ViewPromocodes.DataSource = dt;
            ViewPromocodes.DataBind();
            conn.Close();

        }



        protected void GoBack(object sender, EventArgs e)
        {
            Response.Redirect("StudentPage.aspx");
        }
    }


}