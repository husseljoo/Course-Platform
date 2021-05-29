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
    public partial class RegisterStudent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Registering(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["GUCera_DB"].ToString();

            //create a new connection
            SqlConnection conn = new SqlConnection(connStr);

            /*create a new SQL command which takes as parameters the name of the stored procedure and
             the SQLconnection name*/
            SqlCommand cmd = new SqlCommand("studentRegister", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            string firstname = txt_firstname.Text;
            string lastname = txt_lastname.Text;
            string email = txt_email.Text;
            string address = txt_address.Text;
            string password = txt_password.Text;
            bool isMale = Male.Checked;
            bool isFemale = Female.Checked;
            int gender = 0;

            if(firstname.Equals("") || lastname.Equals("") || email.Equals("") || address.Equals("")|| password.Equals("") || (!isFemale&&!isMale))
            {
                Response.Write("Fields cannot be empty");
                return;
            }
            if(firstname.Length>20)
            {
                Response.Write("First name cannot be greater than 20 characters");
                return;
            }
            if (lastname.Length > 20)
            {
                Response.Write("Last name cannot be greater than 20 characters");
                return;
            }
            if (password.Length > 20)
            {
                Response.Write("Password cannot be greater than 20 characters");
                return;
            }
            if (email.Length > 50)
            {
                Response.Write("Email cannot be greater than 50 characters");
                return;
            }
            if (address.Length > 10)
            {
                Response.Write("Address cannot be greater than 10 characters");
                return;
            }
            cmd.Parameters.Add(new SqlParameter("@first_name", firstname));
            cmd.Parameters.Add(new SqlParameter("@last_name", lastname));
            cmd.Parameters.Add(new SqlParameter("@email", email));
            cmd.Parameters.Add(new SqlParameter("@address", address));
            cmd.Parameters.Add(new SqlParameter("@password", password));
            if (isMale)
                gender = 1;
            cmd.Parameters.Add(new SqlParameter("@gender", gender));


            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            //need to show id
            SqlCommand idGetter = new SqlCommand("getLastID", conn);
            idGetter.CommandType = CommandType.StoredProcedure;
            idGetter.Parameters.Add(new SqlParameter("@tablename", "Users"));
            SqlParameter output = idGetter.Parameters.Add("@id", SqlDbType.Int);
            output.Direction = ParameterDirection.Output;

            conn.Open();
            idGetter.ExecuteNonQuery();
            conn.Close();

            Label id = new Label();
            id.Text = "Your id is: " + output.Value.ToString();
            form1.Controls.Add(id);

            Register.Enabled = false;
        }
        protected void ReturnToLogin(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}