namespace BLL;
using BOL;
using DAL.Disconnected;
using System.Collections.Generic;

public class IDBManager
{

    public static List<Employee> GetAllEmployee()
    {

        List<Employee> list = DBManager.GetEmployee();
        return list;
    }

    public static List<Employee> GetEmployee(int id)
    {

        List<Employee> list = DBManager.GetEmployee(id);
        return list;
    }

     public static List<Employee> DeleteEmployee(int id){
        
        List<Employee> list =DBManager.DeleteEmployee(id);
        return list;
    }

    public static void InsertEmployee(Employee employee){
        
        DBManager.InsertEmployee(employee);
    }
}
