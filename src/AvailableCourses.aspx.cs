using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.WebControls;

namespace GUCera_Web
{
    public partial class AvailableCourses : System.Web.UI.Page
    {
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["GUCera_DB"].ToString();

            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand cmd = new SqlCommand("availableCoursesModified", conn); //"availableCoursesModified"
            cmd.CommandType = CommandType.StoredProcedure;

            int sid = Int32.Parse((String)Session["user"]);
            cmd.Parameters.Add(new SqlParameter("@sid", sid));

            conn.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            //DataTable dt = new DataTable();


            dt.Load(reader);
            GridViewCourses.DataSource = dt;
            GridViewCourses.DataBind();
            conn.Close();

            if (dt.Rows.Count == 0)
                Response.Write("There are no available Courses at the moment!");
        }

        protected void viewCourseInfo(object sender, EventArgs e)
        {
            int sid = Int32.Parse((String)Session["user"]); //newly added 
            string cid = txt_cid.Text;
            string connStr = ConfigurationManager.ConnectionStrings["GUCera_DB"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            if (dt.Rows.Count == 0)
            {
                Response.Write("Try a later time:)");
                return;
            }
            if (cid.Equals(""))
            {
                Response.Write("Field cannot be empty");
                return;
            }
            if (cid.Length > 5)
            {
                Response.Write("Number cannot be greater than 5 numbers");
                return;
            }
            if (!cid.All(char.IsDigit))
            {
                Response.Write("Please enter a number only!");
                return;
            }
            SqlCommand cmd = new SqlCommand("cidExists", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@sid", sid)); //newly added
            cmd.Parameters.Add(new SqlParameter("@cid", cid));
            SqlParameter output = cmd.Parameters.Add("@valid", SqlDbType.Bit);
            output.Direction = ParameterDirection.Output;

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();


            if (output.Value.ToString().Equals("False"))
            {
                Response.Write("Please enter a valid CID that is in the above table!");
                return;
            }



            Session["courseInfo"] = cid;
            Response.Redirect("CourseInfoExtended.aspx");
        }




        protected void GoBack(object sender, EventArgs e)
        {
            Response.Redirect("StudentPage.aspx");
        }





    }
}