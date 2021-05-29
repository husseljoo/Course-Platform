using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace GUCera_Web
{
    public partial class ViewFeedback : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void ViewFeedbacks(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["GUCera_DB"].ToString();

            //create a new connection
            SqlConnection conn = new SqlConnection(connStr);

            /*create a new SQL command which takes as parameters the name of the stored procedure and
             the SQLconnection name*/
            SqlCommand cmd = new SqlCommand("ViewFeedbacksAddedByStudentsOnMyCourse", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            string id = Session["user"].ToString();
            string courseID = txt_courseID.Text;

            try
            {
                cmd.Parameters.Add(new SqlParameter("@instrId", Int32.Parse(id)));
                cmd.Parameters.Add(new SqlParameter("@cid", Int32.Parse(courseID)));

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                GridView1.DataSource = reader;
                GridView1.DataBind();
                conn.Close();
            }
            catch
            {
                Response.Write("Make sure the input is correct");
            }
        }
        protected void GoBack(object sender, EventArgs e)
        {
            if (Session["type"].ToString().Equals("instructor"))
                Response.Redirect("InstructorPage.aspx");
            else if (Session["type"].ToString().Equals("student"))
                Response.Redirect("StudentPage.aspx");
        }
    }
}