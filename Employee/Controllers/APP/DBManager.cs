namespace DAL.Disconnected;
using BOL;
using System.Data;
using System.Collections.Generic;
using MySql.Data.MySqlClient;


public class DBManager
{

    public static string conString = @"server=localhost;port=3306;user=root;
    password=root123;database=Employee";

    public static List<Employee> GetEmployees()
    {

        List<Employee> list = new List<Employee>();
        MySqlConnection conn = new MySqlConnection(conString);

        try
        {
            conn.Open();
            string query = "Select * from Employee";
            DataSet ds = new DataSet();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            da.Fill(ds);

            DataTable dt = ds.Tables[0];
            DataRowCollection rows = dt.Rows;
            foreach (DataRow row in rows)
            {
                int Id = int.Parse(row["Id"].ToString());
                string Name = row["Name"].ToString();
                string Address = row["Address"].ToString();

                Employee employee = new Employee(Id, Name, Address);
                list.Add(Employee);
            };



        }


        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return list;
    }

    public static List<Employee> GetEmployee(int id1)
    {

        List<Employee> list = new List<Employee>();
        MySqlConnection conn = new MySqlConnection(conString);

        try
        {
            conn.Open();
            string query = "Select * from Employee where id=" + id1;
            DataSet ds = new DataSet();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            da.Fill(ds);

            DataTable dt = ds.Tables[0];
            DataRowCollection rows = dt.Rows;
            foreach (DataRow row in rows){
             int Id = int.Parse(row["Id"].ToString());
                string Name = row["Name"].ToString();
                string Address = row["Address"].ToString();

                Employee employee = new Employee(Id, Name, Address);
                list.Add(Employee);
            };

        }


        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return list;
    }

    public static List<Employee> DeleteEmployee(int id1)
    {

        List<Employee> list = new List<Employee>();
        MySqlConnection conn = new MySqlConnection(conString);

        try
        {
            conn.Open();
            string query = "Delete from Employee where id=" + id1;
            DataSet ds = new DataSet();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            da.Fill(ds);

            DataTable dt = ds.Tables[0];
            DataRowCollection rows = dt.Rows;
            foreach (DataRow row in rows){
             int Id = int.Parse(row["Id"].ToString());
                string Name = row["Name"].ToString();
                string Address = row["Address"].ToString();

                Employee employee = new Employee(Id, Name, Address);
                list.Add(Employee);
        };
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return list;
    }

     public static void InsertUser(Employee employee )
    {

        
        MySqlConnection conn = new MySqlConnection(conString);

        try
        {

            //
            conn.Open();
            string query = $"Insert into Employee (name,addr) values ('{user.Name}','{user.Addr}')";
            DataSet ds = new DataSet();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            da.Fill(ds);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        
    }
}