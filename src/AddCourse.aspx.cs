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
    public partial class AddCourse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Add(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["GUCera_DB"].ToString();

            //create a new connection
            SqlConnection conn = new SqlConnection(connStr);

            /*create a new SQL command which takes as parameters the name of the stored procedure and
             the SQLconnection name*/
            SqlCommand cmd = new SqlCommand("InstAddCourse", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            //To read the input from the user
            string credit = txt_credit.Text;
            string price = txt_price.Text;
            string name = txt_courseName.Text;
            string id = Session["user"].ToString();

            if (credit.Equals("") || name.Equals("") || price.Equals(""))
            {
                Response.Write("Fields cannot be empty");
                return;
            }
            if (name.Length > 10)
            {
                Response.Write("Name cannot be more than 10 characters");
                return;
            }
            if (Double.Parse(price) > 9999.99)
            {
                Response.Write("Price should be between 0 and 9999.99");
                return;
            }
            try
            {
                cmd.Parameters.Add(new SqlParameter("@instructorId", Int32.Parse(id)));
                cmd.Parameters.Add(new SqlParameter("@creditHours", Int32.Parse(credit)));
                cmd.Parameters.Add(new SqlParameter("@name", name));
                cmd.Parameters.Add(new SqlParameter("@price", Double.Parse(price)));

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                Response.Write("Course added successfully!");
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