namespace DAL;
using BOL;
using System.Data;
using MySql.Data.MySqlClient;

public class DBManager{
        public static string conString=@"server=localhost;port=3306;user=root;password=root123;database=Employee";
        public static List<Employee> GetAllEmployees(){
            List<Employee> allEmployees = new List<Employee>();
             MySqlConnection con = new MySqlConnection();
             con.ConnectionString=conString;
             try{
                DataSet ds = new DataSet();
                MySqlCommand cmd= new MySqlCommand();
                cmd.Connection=con;
                string query ="SELECT * FROM Employee";
                cmd.CommandText=query;
                MySqlDataAdapter da=new MySqlDataAdapter();
                da.SelectCommand=cmd;
                da.Fill(ds);
                DataTable dt =ds.Tables[0];
                DataRowCollection rows=dt.Rows;
                foreach(DataRow row in rows){
                    int id=int.Parse(row["Id"].ToString());
                    string name=row["Name"].ToString();
                    string addr=row["Address"].ToString();
                    
                    Employee emp=new Employee{
                                                Id=id,
                                                Name=name,
                                               Address=addr
                                               
                    };
                    allEmployees.Add(emp);


                }
             }
             catch(Exception ee){
                Console.WriteLine(ee.Message);
             }
            return allEmployees;
        }
        public static Employee GetEmployee(int id){
            Employee emp=null;
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString=conString;
            try{
                string query="SELECT * FROM Employee WHERE id=" + id;
                con.Open();
                MySqlCommand command=new MySqlCommand(query,con);
                MySqlDataReader reader = command.ExecuteReader();
                if(reader.Read()){
                    int Id=int.Parse(reader["Id"].ToString());
                    string Name=reader["Name"].ToString();
                    string addr=reader["Address"].ToString();
                    
                    Employee employee=new Employee{
                                                Id=Id,
                                                Name=Name,
                                               Address=addr
                    };
                }
            }
            catch(Exception ee){
                Console.WriteLine(ee.Message);
            }
            finally{
                con.Close();
            }

            return emp;
        }
        public static bool Insert(Employee emp){
            bool status=false;
            string query="INSERT INTO Employee (Id,Name,Address)"+"VALUES("+emp.Id+",'"+emp.Name+"','"+emp.Address+"')";
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString=conString;
            try{
                con.Open();
                  MySqlCommand command=new MySqlCommand(query,con);
                command.ExecuteNonQuery();
                status=true;

            }
            catch(Exception e){
                Console.WriteLine(e.Message);
            }
            finally{
                con.Close();
            }
            return status;
        }
        public static bool Update(Employee emp){
            bool status = false;
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString=conString;
            try{
                string query="UPDATE Employee SET Id='"+emp.Id+"',Name='"+emp.Name+"',Address='"+emp.Address +"' WHERE Id=" +  emp.Id;
                    MySqlCommand command= new MySqlCommand(query,con);
                con.Open();
                command.ExecuteNonQuery();
                status=true;

            }
            catch(Exception e){
                Console.WriteLine(e.Message);

            }
            finally{
                con.Close();
            }
            return status;
        }
        public static bool Delete(int id){
            bool status=false;
            MySqlConnection con=new MySqlConnection();
            con.ConnectionString=conString;
            try{
                string query="DELETE FROM Employee WHERE Id=" +id;
                MySqlCommand command= new MySqlCommand(query,con);
                con.Open();
                command.ExecuteNonQuery();
                status=true;
            }
            catch(Exception e){
                Console.WriteLine(e.Message);
            }
            finally{
                con.Close();
            }

            return status;
        }
}