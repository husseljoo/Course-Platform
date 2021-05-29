using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace GUCera_Web
{
    public partial class CourseInfoExtended : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["GUCera_DB"].ToString();

            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand cmd = new SqlCommand("courseInformation", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            int cid = Int32.Parse((String)Session["courseInfo"]);
            cmd.Parameters.Add(new SqlParameter("@id", cid));

            conn.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();


            dt.Load(reader);
            GridViewCourses.DataSource = dt;
            GridViewCourses.DataBind();
            conn.Close();

        }







        protected void EnrollInCourse(object sender, EventArgs e)
        {
            int sid = Int32.Parse((String)Session["user"]);
            int cid = Int32.Parse((String)Session["courseInfo"]);




            string connStr = ConfigurationManager.ConnectionStrings["GUCera_DB"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand("courseInstId", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@cid", cid));
            SqlParameter output = cmd.Parameters.Add("@instId", SqlDbType.Int);
            output.Direction = ParameterDirection.Output;
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            int instId = Convert.ToInt32(cmd.Parameters["@instId"].Value);
            //int instid =Int32.Parse(output);
            //Response.Write(instid);
            //return;



            SqlCommand cmd2 = new SqlCommand("enrollInCourse", conn);
            cmd2.CommandType = CommandType.StoredProcedure;

            cmd2.Parameters.Add(new SqlParameter("@sid", sid));
            cmd2.Parameters.Add(new SqlParameter("@cid", cid));
            cmd2.Parameters.Add(new SqlParameter("@instr", instId));





            conn.Open();
            cmd2.ExecuteNonQuery();
            conn.Close();

            Response.Redirect("AvailableCourses.aspx");





        }


        protected void GoBackAvailableCourses(object sender, EventArgs e)
        {
            Response.Redirect("AvailableCourses.aspx");
        }
        protected void GoBackHomepage(object sender, EventArgs e)
        {

            Response.Redirect("StudentPage.aspx");
        }

    }
}