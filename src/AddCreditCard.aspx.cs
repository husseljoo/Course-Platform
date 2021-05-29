using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions;

namespace GUCera_Web
{
    public partial class AddCreditCard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }



        protected void CreditCardAdd(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["GUCera_DB"].ToString();

            SqlConnection conn = new SqlConnection(connStr);

            int sid = Int32.Parse((String)Session["user"]);
            string CardNumber = txt_Cardnumber.Text;
            string HolderName = txt_HolderName.Text;
            string ExpiryDate = txt_ExpiryDate.Text;
            string cvv = txt_cvv.Text;



            if (CardNumber.Equals("") || HolderName.Equals("") || ExpiryDate.Equals("") || cvv.Equals(""))
            {
                Response.Write("Fields cannot be empty");
                return;
            }
            if (CardNumber.Length > 15)
            {
                Response.Write("Cardnumber cannot be greater than 15 characters");
                return;
            }
            if (HolderName.Length > 16)
            {
                Response.Write("CardholderName cannot be greater than 16 characters");
                return;
            }
            if (cvv.Length > 3)
            {
                Response.Write("CVV cannot be greater than 3 characters");
                return;
            }
            if (!CardNumber.All(char.IsDigit))
            {
                Response.Write("CreditCard number must consist of numbers only!");
                return;
            }

            if (!Regex.IsMatch(HolderName, @"^[a-zA-Z ]+$"))
            {
                Response.Write("Cardholder name must consist of letters only!");
                return;
            }
            DateTime temp;
            if (!DateTime.TryParse(ExpiryDate, out temp))
            {
                Response.Write("Datetime format of Expiry Date is incorrect!");
                return;
            }



            SqlCommand cmd = new SqlCommand("checkCreditCardDuplicate", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@sid", sid));
            cmd.Parameters.Add(new SqlParameter("@number", CardNumber));
            SqlParameter output = cmd.Parameters.Add("@output", SqlDbType.Bit);
            output.Direction = ParameterDirection.Output;


            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            if (output.Value.ToString().Equals("True"))
            {
                Response.Write("Credit Card already added");
                return;
            }


            SqlCommand cmd2 = new SqlCommand("addCreditCard", conn);
            cmd2.CommandType = CommandType.StoredProcedure;

            cmd2.Parameters.Add(new SqlParameter("@sid", sid));
            cmd2.Parameters.Add(new SqlParameter("@number", CardNumber));
            cmd2.Parameters.Add(new SqlParameter("@cardHolderName", HolderName));
            cmd2.Parameters.Add(new SqlParameter("@expiryDate", ExpiryDate));
            cmd2.Parameters.Add(new SqlParameter("@cvv", cvv));

            conn.Open();
            cmd2.ExecuteNonQuery();
            conn.Close();
            Response.Write("Credit card added successfully");
        }

        protected void GoBack(object sender, EventArgs e)
        {
            Response.Redirect("StudentPage.aspx");
        }


    }
}