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
    public partial class IssueCertificate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void issueCertificate(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["GUCera_DB"].ToString();

            //create a new connection
            SqlConnection conn = new SqlConnection(connStr);

            /*create a new SQL command which takes as parameters the name of the stored procedure and
             the SQLconnection name*/
            SqlCommand cmd = new SqlCommand("InstructorIssueCertificateToStudent", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            string id = Session["user"].ToString();
            string courseID = txt_courseID.Text;
            string studentID = txt_studentID.Text;
            string date = txt_issueDate.Text;

            if (courseID.Equals("") || studentID.Equals("") || date.Equals(""))
            {
                Response.Write("Fields cannot be empty");
                return;
            }
            try
            {
                cmd.Parameters.Add(new SqlParameter("@insId", Int32.Parse(id)));
                cmd.Parameters.Add(new SqlParameter("@cid", Int32.Parse(courseID)));
                cmd.Parameters.Add(new SqlParameter("@sid", Int32.Parse(studentID)));
                cmd.Parameters.Add(new SqlParameter("@issueDate", Convert.ToDateTime(date)));

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                Response.Write("Certificate issued successfully");
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