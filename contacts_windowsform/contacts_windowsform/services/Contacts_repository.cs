using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace contacts_windowsform
{
    class Contacts_repository : IContacts_repository
    {

        private string connect = "Data Source=.;Initial Catalog=Contact_DB;Integrated Security=true";
        

        public bool del(int contact_id)
        {
            SqlConnection connection = new SqlConnection(connect);
            try
            {
             
                string query = $"delete from Contact_table where contact_id=(@contact_id) ";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@contact_id", contact_id);
                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch
            {
                
                return false;
            }
            finally
            {
                connection.Close();
            }
         
        }

        
        public DataTable select_all()
        {
            string query = "Select * From Contact_table";
            return extractsql(query);

        }

        private DataTable extractsql(string query)
        {
            SqlConnection connection = new SqlConnection(connect);
            
            
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
            
           
        }

        public DataTable select_row(int contact_id)
        {
            string query = $"select * from Contact_table where contact_id={contact_id}";
            return extractsql(query);
        }

        public bool update(int contact_id, string name, string mobile, string email, int age)
        {
            SqlConnection connection = new SqlConnection(connect);
            
            {
                string query = "update Contact_table set Name=(@Name),Mobile=(@Mobile),Email=(@Email),Age=(@Age)  where contact_id=(@contact_id)";
                SqlCommand command = new SqlCommand(query,connection);
                command.Parameters.AddWithValue("@contact_id", contact_id);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Mobile", mobile);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Age", age);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                return true;
            }
           
            
        }

        

        public bool insert(string name, string mobile, string email, int age)
        {
            SqlConnection connection = new SqlConnection(connect);
            
            try
            {
           
                string query = "insert into Contact_table (Name,Mobile,Email,Age) values (@Name,@Mobile,@Email,@Age)";
                SqlCommand command = new SqlCommand(query, connection);
                
                command.Parameters.AddWithValue("@Name",name);
                command.Parameters.AddWithValue("@Mobile", mobile);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Age", age);
                connection.Open();
                command.ExecuteNonQuery();
                
                return true;
                
            }
            catch
            {

                return false ;
            }
            finally
            {

                connection.Close();
            }
            
        }

        

        public DataTable select_byname(string name)
        {

            string query = "select * from Contact_table where Name like @name ";

            return search(name, query);

        }

        private DataTable search(string name, string query)
        {
            SqlConnection connection = new SqlConnection(connect);


            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);

            adapter.SelectCommand.Parameters.AddWithValue("@name", "%" + name + "%");


            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }

        public DataTable select_bymobile(string mobile)
        {
            string query = "select * from Contact_table where Mobile like @mobile";

            SqlConnection connection = new SqlConnection(connect);


            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);

            adapter.SelectCommand.Parameters.AddWithValue("@mobile", "%" + mobile + "%");


            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }

        
        
    }
}
