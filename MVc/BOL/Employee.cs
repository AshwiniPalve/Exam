namespace BOL;
public class Employee
{
public int Id{get;set;}
public string Name{get;set;}
public string Address{get;set;}

public Employee(){

}
public Employee(int Id,string Name,string Address){
    this.Id=Id;
    this.Name=Name;
    this.Address=Address;
}
}
