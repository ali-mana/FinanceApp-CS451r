using FinancingApp.ADODataAcess.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FinancingApp.ADODataAcess
{
    public class CustomerRepository
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["FinancingApp"].ConnectionString;

        //Disconnected Mode
        public Customer GetCustomerID_DataSet(int customerId)
        {

            var connection = new SqlConnection(_connectionString);
            try
            {
                connection.Open();
                var command = new SqlCommand
                {
                    Connection = connection,
                    CommandType = System.Data.CommandType.Text,
                    CommandText = string.Format("Select CustomerId, FirstName, LastName, SSN, AddressId FROM Customer Where CustomerId = {0}", customerId),
                };


                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;

                DataSet ds = new DataSet();
                adapter.Fill(ds, "Customer");

                DataTable dt = ds.Tables["Customer"];

                var customer = new Customer();
                customer.CustomerId = Convert.ToInt32(dt.Rows[0]["CustomerId"].ToString());
                customer.FirstName = dt.Rows[0]["FirstName"].ToString();


                connection.Close();

                return customer;


            }
            catch (Exception ex)
            {
                throw;
            }

        }

        //Connected Mode
        public Customer GetCustomerID_DataReader(int customerId)
        {

            var connection = new SqlConnection(_connectionString);
            try
            {
                connection.Open();
                var command = new SqlCommand
                {
                    Connection = connection,
                    CommandType = System.Data.CommandType.Text,
                    CommandText = string.Format("Select CustomerId, FirstName, LastName, SSN, AddressId FROM Customer Where CustomerId = {0}", customerId),
                };

                var dataReader = command.ExecuteReader();


             
                long testing = 23;

                int temp2 = (int)testing;
                
                var customer = new Customer();
                
                if(dataReader.HasRows)
                {
                    if(dataReader.Read())
                    {
                        customer.CustomerId = (long)dataReader[0];
                        customer.FirstName = dataReader[1].ToString();
                    }
                }
                
              

                connection.Close();

                return customer;


            }
            catch (Exception ex)
            {
                throw;
            }

        }


        public bool Insert()
        {
            var connection = new SqlConnection(_connectionString);
            try
            {
                connection.Open();
                var command = new SqlCommand
                {
                    Connection = connection,
                    CommandType = System.Data.CommandType.StoredProcedure,
                    CommandText = "uspInsertCustomer"
                };


                command.Parameters.Add(new SqlParameter("FirstName", SqlDbType.VarChar) { Value = "Praneeth" });
                command.Parameters.Add(new SqlParameter("LastName", SqlDbType.VarChar) { Value = "Jonna" });
                command.Parameters.Add(new SqlParameter("SSN", SqlDbType.VarChar) { Value = "344344345" });
                command.Parameters.Add(new SqlParameter("AddressId", SqlDbType.Int) { Value = null });

                command.ExecuteNonQuery();

                connection.Close();

                return true;


            }
            catch (Exception ex)
            {
                throw;
            }


        }
    }
}
