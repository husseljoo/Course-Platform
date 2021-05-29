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
    
    public partial class Assignments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label2.Visible = false;
            Label3.Visible = false;
            txt_type.Enabled = false;
            txt_assignnum.Enabled = false;
            Submit.Enabled = false;
            Submit.Visible = false;
            ViewGrades.Enabled = false;
            ViewGrades.Visible = false;
        }
        protected void getAssign(object sender, EventArgs e)
        {
            string cid = txt_cid.Text;
            if(cid.Equals(""))
            {
                Response.Write("Course id cannot be empty");
                return;
            }

            string connStr = ConfigurationManager.ConnectionStrings["GUCera_DB"].ToString();

            //create a new connection
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand cmd2 = new SqlCommand("courseVerify", conn);
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.Parameters.Add(new SqlParameter("@id", Session["user"]));
            cmd2.Parameters.Add(new SqlParameter("@cid", Int32.Parse(cid)));
            SqlParameter output = cmd2.Parameters.Add("@output", SqlDbType.Int);
            output.Direction = ParameterDirection.Output;

            conn.Open();
            cmd2.ExecuteNonQuery();
            conn.Close();

            if(output.Value.ToString().Equals("0"))
            {
                Response.Write("Invalid Course ID, Course id doesn't exist or you don't take this course");
                return;
            }

            /*create a new SQL command which takes as parameters the name of the stored procedure and
             the SQLconnection name*/
            SqlCommand cmd = new SqlCommand("viewAssign", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@courseId", Int32.Parse(cid)));
            cmd.Parameters.Add(new SqlParameter("@Sid", Session["user"]));

            conn.Open();
            SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                string s = "";
                for (int i =0;i<rdr.FieldCount;i++)
                {
                    s += rdr.GetName(i) +":" +rdr.GetValue(i).ToString() + " ";
                }
                Label l = new Label();
                l.Text = s;
                PlaceHolder1.Controls.Add(new LiteralControl("<br />"));
                PlaceHolder1.Controls.Add(l);
                PlaceHolder1.Controls.Add(new LiteralControl("<br />"));
            }
            conn.Close();
            Label2.Visible = true;
            Label3.Visible = true;
            txt_assignnum.Enabled = true;
            txt_type.Enabled = true;
            Submit.Enabled = true;
            Submit.Visible = true;
            ViewGrades.Visible = false;
            ViewGrades.Enabled = false;
        }
        protected void SubmitAssign(object sender, EventArgs e)
        {
            string number = txt_assignnum.Text;
            string type = txt_type.Text.ToLower();
            string cid = txt_cid.Text;
            string id = Session["user"].ToString();
            string connStr = ConfigurationManager.ConnectionStrings["GUCera_DB"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            if (number.Equals("") || type.Equals(""))
            {
                Response.Write("Assignment number or type cannot be empty");
                return;
            }
            SqlCommand cmd2 = new SqlCommand("assignVerify", conn);
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.Parameters.Add(new SqlParameter("@type", type));
            cmd2.Parameters.Add(new SqlParameter("@number", Int32.Parse(number)));
            SqlParameter output = cmd2.Parameters.Add("@output", SqlDbType.Int);
            output.Direction = ParameterDirection.Output;

            conn.Open();
            cmd2.ExecuteNonQuery();
            conn.Close();

            if (output.Value.ToString().Equals("0"))
            {
                Response.Write("Invalid assign number or type. Please check your list for the correct info.");
                return;
            }


            SqlCommand cmd = new SqlCommand("submitAssign", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@assignType", type));
            cmd.Parameters.Add(new SqlParameter("@sid", Int32.Parse(id)));
            cmd.Parameters.Add(new SqlParameter("@cid", cid));
            cmd.Parameters.Add(new SqlParameter("@assignnumber", number));

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            Response.Write("Assignment submitted successfully");
        }
        protected void WantToViewGrade(object sender, EventArgs e)
        {
            string cid = txt_cid.Text;
            if (cid.Equals(""))
            {
                Response.Write("Course id cannot be empty");
                return;
            }
            string connStr = ConfigurationManager.ConnectionStrings["GUCera_DB"].ToString();

            //create a new connection
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand cmd2 = new SqlCommand("courseVerify", conn);
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.Parameters.Add(new SqlParameter("@id", Session["user"]));
            cmd2.Parameters.Add(new SqlParameter("@cid", Int32.Parse(cid)));
            SqlParameter output = cmd2.Parameters.Add("@output", SqlDbType.Int);
            output.Direction = ParameterDirection.Output;

            conn.Open();
            cmd2.ExecuteNonQuery();
            conn.Close();

            if (output.Value.ToString().Equals("0"))
            {
                Response.Write("Invalid Course ID, Course id doesn't exist or you don't take this course");
                return;
            }
            Label2.Visible = true;
            Label3.Visible = true;
            txt_assignnum.Enabled = true;
            txt_type.Enabled = true;
            Submit.Enabled = false;
            Submit.Visible = false;
            ViewGrades.Visible = true;
            ViewGrades.Enabled = true;
        }

        protected void ViewAssignGrade(object sender, EventArgs e)
        {
            string number = txt_assignnum.Text;
            string type = txt_type.Text.ToLower();
            string cid = txt_cid.Text;
            string id = Session["user"].ToString();
            if (number.Equals("") || type.Equals(""))
            {
                Response.Write("Assignment number or type cannot be empty");
                return;
            }
            string connStr = ConfigurationManager.ConnectionStrings["GUCera_DB"].ToString();

            //create a new connection
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand cmd2 = new SqlCommand("GradeVerify", conn);
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.Parameters.Add(new SqlParameter("@sid", Int32.Parse(id)));
            cmd2.Parameters.Add(new SqlParameter("@cid", Int32.Parse(cid)));
            cmd2.Parameters.Add(new SqlParameter("@type", type));
            cmd2.Parameters.Add(new SqlParameter("@number", Int32.Parse(number)));
            SqlParameter output2 = cmd2.Parameters.Add("@output", SqlDbType.Int);
            output2.Direction = ParameterDirection.Output;

            conn.Open();
            cmd2.ExecuteNonQuery();
            conn.Close();

            if (output2.Value.ToString().Equals("0"))
            {
                Response.Write("You didn't submit this assignment in this course OR Instructor still did not grade it");
                return;
            }


            SqlCommand cmd = new SqlCommand("viewAssignGrades", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@assignType", type));
            cmd.Parameters.Add(new SqlParameter("@sid", Int32.Parse(id)));
            cmd.Parameters.Add(new SqlParameter("@cid", Int32.Parse(cid)));
            cmd.Parameters.Add(new SqlParameter("@assignnumber",Int32.Parse(number)));
            SqlParameter output = cmd.Parameters.Add("@assignGrade", SqlDbType.Decimal);
            output.Direction = ParameterDirection.Output;

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            Label l = new Label();
            l.Text = "Your grade is: " + output.Value.ToString();
            form1.Controls.Add(l);
        }
    }
}