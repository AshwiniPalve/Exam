
show databases;

create database Employee;

use Employee;

show tables;

 create table Employee(
 Id int primary key auto_increment,
 Name  varchar(100) unique,
 Address varchar(100) );
 

 Insert into Employee(Name,Address) values("Ashwini","Akurdi");
 Insert into Employee(Name,Address) values("Neha","Nagar");
 Insert into Employee(Name,Address) values("Swati","Hadapsar");
 Insert into Employee(Name,Address) values("Chetan","Wakad");
 Insert into Employee(Name,Address) values("Yuvraj","Hinjewadi");
 
 select * from Employee;
 