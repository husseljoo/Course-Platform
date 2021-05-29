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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void login(object sender, EventArgs e)
        {
            //Get the information of the connection to the database
            string connStr = ConfigurationManager.ConnectionStrings["GUCera_DB"].ToString();

            //create a new connection
            SqlConnection conn = new SqlConnection(connStr);

            /*create a new SQL command which takes as parameters the name of the stored procedure and
             the SQLconnection name*/
            SqlCommand cmd = new SqlCommand("userLogin", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            //To read the input from the user
            string id = txt_id.Text;
            string password = txt_password.Text;
            if (id.Equals("") || password.Equals(""))
            {
                Response.Write("Username or password cannot be empty");
                return;
            }
            if (password.Length > 20)
            {
                Response.Write("Password is incorrect");
                return;
            }
            try
            {
                //pass parameters to the stored procedure
                cmd.Parameters.Add(new SqlParameter("@id", Int32.Parse(id)));
                cmd.Parameters.Add(new SqlParameter("@password", password));

                //Save the output from the procedure
                SqlParameter success = cmd.Parameters.Add("@success", SqlDbType.Int);
                success.Direction = ParameterDirection.Output;
                SqlParameter type = cmd.Parameters.Add("@type", SqlDbType.Int);
                type.Direction = ParameterDirection.Output;

                //Executing the SQLCommand
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                if (success.Value.ToString().Equals("1"))
                {
                    Session["user"] = id;
                    if (type.Value.ToString().Equals("0"))
                    {
                        Session["type"] = "instructor";
                        Response.Redirect("InstructorPage.aspx");
                    }
                    else if (type.Value.ToString().Equals("1"))
                    {
                        Session["type"] = "admin";
                        Response.Redirect("AdminPage.aspx");
                    }
                    else if (type.Value.ToString().Equals("2"))
                    {
                        Session["type"] = "student";
                        Response.Redirect("StudentPage.aspx");
                    }
                }
                else
                    Response.Write("Wrong ID or password");
            }
            catch
            {
                Response.Write("Make sure the input is written correctly");
            }
        }
        protected void RegisterInstructor(object sender, EventArgs e)
        {
            Response.Redirect("RegisterInstructor.aspx");
        }
        protected void RegisterStudent(object sender, EventArgs e)
        {
            Response.Redirect("RegisterStudent.aspx");
        }
    }
}