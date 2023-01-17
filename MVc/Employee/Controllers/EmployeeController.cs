using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

using BOL;
using BLL;

namespace EmpApp.Controllers;

public class EmployeeController : Controller
{
    private readonly ILogger<EmployeeController> _logger;

    public EmployeeController(ILogger<EmployeeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        EmployeeManager em= new EmployeeManager();
        List<BOL.Employee> employees = em.GetAllEmployees();
       // List<Employee> employees=em.GetAllEmployees();
        this.ViewData["employees"]=employees;

        return View();
    }

    public IActionResult Details(int id)
    {
        EmployeeManager em=new EmployeeManager();
        BOL.Employee emp =em.GetEmployee(id);
        this.ViewData["employee"]=emp;
        return View();
    }
      public IActionResult Insert()
    {
        BOL.Employee emp = new BOL.Employee();
        return View(emp);
    }
    [HttpPost]
    public IActionResult Insert(BOL.Employee emp)
    {
        EmployeeManager em=new EmployeeManager();
        // Employee employee =em.Update(emp);
        // this.ViewData["employee"]=employee;
        // return View();
        if(em.Insert(emp)){
            return RedirectToAction("Index");
        }
        return View();
         
        
    }
     public IActionResult Login()
    {
        
        return View();
    }
    [HttpPost]
     public IActionResult Login(string Email,string Password)
    {
        EmployeeManager em= new EmployeeManager();
        List<BOL.Employee>employees=em.GetAllEmployees();
       foreach (BOL.Employee emp in employees)
       {
         // if(emp.Email.Equals(Email)&&emp.Password.Equals(Password)){
            return RedirectToAction("Index");
         // }
       }
       return View();
    }
    public IActionResult Delete()
    {
        
        return View();
    }
    [HttpPost]
    public IActionResult Delete(int id)
    {
        EmployeeManager em= new EmployeeManager();
       if(em.Delete(id)){
            return RedirectToAction("Index");
       }
        
        return View();
    }
      public IActionResult Update()   {
        BOL.Employee emp = new BOL.Employee();
        return View(emp);
    }
    [HttpPost]
      public IActionResult Update(BOL.Employee emp)
    {
        EmployeeManager em= new EmployeeManager();
        if(em.Update(emp)){
            return RedirectToAction("Index");
        }
        return View();
       
    }

}
