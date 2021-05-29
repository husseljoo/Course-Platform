using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace GUCera_Web
{
    public partial class ProfileInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string connStr = ConfigurationManager.ConnectionStrings["GUCera_DB"].ToString();

            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand cmd = new SqlCommand("viewMyProfileModified", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            int id = Int32.Parse((String)Session["user"]);
            cmd.Parameters.Add(new SqlParameter("@id", id));


            conn.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();

            dt.Load(reader);
            bool genderBoolean = (bool)dt.Rows[0][6];

            //dtCloned is created because gender was displayed as checked Box rather than a string 
            DataTable dtCloned = dt.Clone();
            dtCloned.Columns[6].DataType = typeof(String);

            foreach (DataRow row in dt.Rows)
            {
                dtCloned.ImportRow(row);
            }

            if (genderBoolean)
                dtCloned.Rows[0][6] = "Male";
            else
                dtCloned.Rows[0][6] = "Female";


            ViewProfileInfo.DataSource = dtCloned;
            ViewProfileInfo.DataBind();
            conn.Close();


        }
        protected void GoBack(object sender, EventArgs e)
        {
            Response.Redirect("StudentPage.aspx");
        }

    }
}