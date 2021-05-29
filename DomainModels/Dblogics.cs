using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieRenderApp.Models;
using System.Data.SqlClient;
using System.Data;

namespace MovieRenderApp.DomainModels
{
    public class Dblogics
    {
        string constring = @"Data Source=FLAIRDEV-PC;Initial Catalog=FirstApp;Integrated Security=True";
        DataTable dt = new DataTable();
        string Query;

        public DataTable GetCustomer()
        {
            using (SqlConnection sqlcon = new SqlConnection(constring))
            {
                sqlcon.Open();
                Query = "SELECT * FROM Customer";
                SqlDataAdapter sqldt = new SqlDataAdapter(Query, sqlcon);
                sqldt.Fill(dt);

            }
            return dt;

        }
        public string GetName(int id)
        {
            string name = null;
            using (SqlConnection sqlcon=new SqlConnection(constring))
            {

                sqlcon.Open();
                var Query = "SELECT * FROM Customer WHERE Id=@id";
                SqlDataAdapter sqldt = new SqlDataAdapter(Query, sqlcon);
                sqldt.SelectCommand.Parameters.AddWithValue("@id", id);
                sqldt.Fill(dt);
               
            }
            if (dt.Rows.Count != 0)
            {
                name = dt.Rows[0][1].ToString();
            }

            return name;
        }
        public void UpdateName(Customer customer)
        {
            using (SqlConnection sqlcon=new SqlConnection(constring))
            {
                sqlcon.Open();
                Query = "UPDATE Customer SET Name=@name WHERE Id=@id";
                SqlCommand sql = new SqlCommand(Query, sqlcon);
                sql.Parameters.AddWithValue("@id", customer.Id);
                sql.Parameters.AddWithValue("@name", customer.Name);
                sql.ExecuteNonQuery();
            }
           
        }
        public void DeleteCustomer(int id)
        {
            using (SqlConnection sqlcon=new SqlConnection(constring))
            {
                sqlcon.Open();
                Query = "DELETE FROM Customer Where Id=@id";
                SqlCommand sql = new SqlCommand(Query, sqlcon);
                sql.Parameters.AddWithValue("@id", id);
                sql.ExecuteNonQuery();
            }
        }
        public DataTable GetMovies()
        {
            using (SqlConnection sqlcon = new SqlConnection(constring))
            {
                sqlcon.Open();
                var Query = "SELECT * FROM Movie";
                SqlDataAdapter sqldt = new SqlDataAdapter(Query, sqlcon);
                sqldt.Fill(dt);

               
            }
            return dt;
        }
        public void AddNewMovie(Movie movi)
        {
            using (SqlConnection sqlcon=new SqlConnection(constring))
            {
                sqlcon.Open();
                Query = "INSERT INTO Movie VALUES(@name,@Rdate,@Ddate,@stock,@category)";
                SqlCommand sql = new SqlCommand(Query, sqlcon);
                sql.Parameters.AddWithValue("@name", movi.Name);
                sql.Parameters.AddWithValue("@Rdate", movi.ReleaseData);
                sql.Parameters.AddWithValue("@Ddate", DateTime.Now.Date);
                sql.Parameters.AddWithValue("@stock", movi.Stocks);
                sql.Parameters.AddWithValue("@category", movi.Category);
                sql.ExecuteNonQuery();
            }
        }
        public DataTable GetMOvieDetails(int id)
        {
            using (SqlConnection sqlcon = new SqlConnection(constring))
            {
                sqlcon.Open();
                var Query = "SELECT * FROM Movie WHERE Id=@id";
                SqlDataAdapter sqldt = new SqlDataAdapter(Query, sqlcon);
                sqldt.SelectCommand.Parameters.AddWithValue("@id", id);
                sqldt.Fill(dt);


            }


            return dt;
        }

        public void DeleteMovie(int id)
        {
            using (SqlConnection sqlcon=new SqlConnection(constring))
            {
                sqlcon.Open();
                Query = "DELETE FROM Movie WHERE ID=@id";
                SqlCommand sql = new SqlCommand(Query, sqlcon);
                sql.Parameters.AddWithValue("@id", id);
                sql.ExecuteNonQuery();

            }
        }
        public int AddCustomer(Customer cu)
        {
            string temp;

            switch (cu.MembershipTypeId)
            {
                case 1: temp = "Pay As You Go";
                    break;
                case 2: temp = "Monthly";
                    break;
                case 3: temp = "Quartly";
                    break;
                case 4: temp = "Annul";
                    break;
                default: temp = null;
                    break;
            }

            using (SqlConnection sqlcon = new SqlConnection(constring))
            {
                sqlcon.Open();
                Query = "INSERT INTO Customer VALUES(@name,@birthdate,@issub,@type,@id)";

                SqlCommand Sc = new SqlCommand(Query, sqlcon);
                Sc.Parameters.AddWithValue("@name", cu.Name);
                Sc.Parameters.AddWithValue("@birthdate", cu.Birthdate);
                Sc.Parameters.AddWithValue("@issub", cu.isSubscribedTonewsletter);
                Sc.Parameters.AddWithValue("@type", temp);
                Sc.Parameters.AddWithValue("@id", cu.MembershipTypeId);

                Sc.ExecuteNonQuery();
            }
            return 1;
        }
        public IEnumerable<Customer> CustomerFilter(DataTable dt)
        {
            var listcum = new List<Customer>();


            foreach(DataRow dr in dt.Rows)
            {

                listcum.Add(new Customer
                {
                    Name = dr["Name"].ToString()

                });         
            }

            return listcum;
        }
        public IEnumerable<Movie> MovieFilter(DataTable dt)
        {

            var Movilist = new List<Movie>();

            foreach(DataRow dr in dt.Rows)
            {
                Movilist.Add(new Movie
                {
                    Name = dr["Name"].ToString()

                });
            }

            return Movilist;
        }


    }
}