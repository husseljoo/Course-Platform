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
    public partial class DefineAssignment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void AddAssignment(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["GUCera_DB"].ToString();

            //create a new connection
            SqlConnection conn = new SqlConnection(connStr);

            /*create a new SQL command which takes as parameters the name of the stored procedure and
             the SQLconnection name*/
            SqlCommand cmd = new SqlCommand("DefineAssignmentOfCourseOfCertianType", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            //To read the input from the user
            string courseID = txt_courseID.Text;
            string number = txt_number.Text;
            string type = txt_type.Text;
            string grade = txt_grade.Text;
            string weight = txt_weight.Text;
            string deadline = txt_deadline.Text;
            string content = txt_content.Text;
            string id = Session["user"].ToString();

            if (courseID.Equals("") || number.Equals("") || type.Equals("") || grade.Equals("") || weight.Equals("") || deadline.Equals("") || content.Equals(""))
            {
                Response.Write("Fields cannot be empty");
                return;
            }
            if (type.Length > 10)
            {
                Response.Write("Type cannot be more than 10 characters");
                return;
            }
            if (content.Length > 10)
            {
                Response.Write("Content cannot be more than 200 characters");
                return;
            }
            if (Double.Parse(weight) > 100.0)
            {
                Response.Write("Weight should be between 0 and 100.0");
                return;
            }
            if (!(type.Equals("quiz") || type.Equals("project") || type.Equals("exam")))
            {
                Response.Write("Type needs to be either quiz or project or exam");
                return;
            }
            try
            {
                cmd.Parameters.Add(new SqlParameter("@instId", Int32.Parse(id)));
                cmd.Parameters.Add(new SqlParameter("@number", Int32.Parse(number)));
                cmd.Parameters.Add(new SqlParameter("@type", type));
                cmd.Parameters.Add(new SqlParameter("@fullGrade", Int32.Parse(grade)));
                cmd.Parameters.Add(new SqlParameter("@weight", decimal.Parse(weight)));
                cmd.Parameters.Add(new SqlParameter("@content", content));
                cmd.Parameters.Add(new SqlParameter("@deadline", Convert.ToDateTime(deadline)));
                cmd.Parameters.Add(new SqlParameter("@cid", Int32.Parse(courseID)));


                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                Response.Write("Assignment added successfully!");
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