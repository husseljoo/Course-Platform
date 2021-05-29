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
    public partial class AddTelephone : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void AddNumber(object sender, EventArgs e)
        {
            string number = txt_mobilenumber.Text;
            string connStr = ConfigurationManager.ConnectionStrings["GUCera_DB"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            if (number.Equals(""))
            {
                Response.Write("Number cannot be empty");
                return;
            }
            if(number.Length>11)
            {
                Response.Write("Number cannot be greater than 11 numbers");
                return;
            }
            SqlCommand cmd = new SqlCommand("checkNumber", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@number", number));
            cmd.Parameters.Add(new SqlParameter("@id", Session["user"]));
            SqlParameter output = cmd.Parameters.Add("@output", SqlDbType.Bit);
            output.Direction = ParameterDirection.Output;


            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            if(output.Value.ToString().Equals("True"))
            {
                Response.Write("Number already added");
                return;
            }


            //create a new connection
            

            /*create a new SQL command which takes as parameters the name of the stored procedure and
             the SQLconnection name*/
            SqlCommand cmd2 = new SqlCommand("addMobile", conn);
            cmd2.CommandType = CommandType.StoredProcedure;

            cmd2.Parameters.Add(new SqlParameter("@mobile_number", number));
            cmd2.Parameters.Add(new SqlParameter("@ID", Session["user"]));
            conn.Open();
            cmd2.ExecuteNonQuery();
            conn.Close();
           
            Response.Write("Number successfully added");
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