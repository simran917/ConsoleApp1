using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

namespace ConsoleApp1
{
    class Program
    {
        public void saveEmp()
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-2EKSH59\SQLEXPRESS;" + "Initial Catalog= AdventureWorks2017; Integrated Security=True");
                con.Open();
                if (con.State == System.Data.ConnectionState.Open)
                {
                    Console.WriteLine("Connection open");
                    for (int i = 0; i < 3; i++)
                    {
                        string query = "insert into employeeinfo values (@dept, @designation, @salary) ";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.Add("@dept", SqlDbType.NVarChar);
                        cmd.Parameters.Add("@designation", SqlDbType.NVarChar);
                        cmd.Parameters.Add("@salary", SqlDbType.Money);
                        string dept = Console.ReadLine();
                        string designation = Console.ReadLine();
                        double salary = Convert.ToDouble(Console.ReadLine());
                        cmd.Parameters["@dept"].Value = dept;
                        cmd.Parameters["@designation"].Value = designation;
                        cmd.Parameters["@salary"].Value = salary; int result = cmd.ExecuteNonQuery();
                        Console.WriteLine("No of rows inserted" + result);
                        Console.ReadKey();
                    }

                }

            }


            catch (Exception e)
            {
                Console.WriteLine("Invalid connection");
                Console.WriteLine(e);
                Console.ReadKey();
            }

        }

        static void Main(string[] args)
        {
            Program obj = new Program();
            obj.saveEmp();


        }
    }
}