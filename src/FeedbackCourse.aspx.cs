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
    public partial class FeedbackCourse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AddFeedback(object sender, EventArgs e)
        {
            string comment = txt_comment.Text;
            string cid = txt_cid.Text;
            string id = Session["user"].ToString();

            if(cid.Equals("")|| comment.Equals(""))
            {
                Response.Write("Comment and course id cannot be empty");
                return;
            }

            string connStr = ConfigurationManager.ConnectionStrings["GUCera_DB"].ToString();

            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand cmd2 = new SqlCommand("feedbackVerify", conn);
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.Parameters.Add(new SqlParameter("@id", Int32.Parse(id)));
            cmd2.Parameters.Add(new SqlParameter("@cid", Int32.Parse(cid)));
            SqlParameter output = cmd2.Parameters.Add("@output", SqlDbType.Int);
            output.Direction = ParameterDirection.Output;

            conn.Open();
            cmd2.ExecuteNonQuery();
            conn.Close();

            if (output.Value.ToString().Equals("0"))
            {
                Response.Write("You are not enrolled in this course OR you already added a feedback");
                return;
            }

            SqlCommand cmd = new SqlCommand("addFeedback", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@comment", comment));
            cmd.Parameters.Add(new SqlParameter("@cid",Int32.Parse(cid)));
            cmd.Parameters.Add(new SqlParameter("@sid", Int32.Parse(id)));
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            Response.Write("Feedback added successfully");
        }
    }
}