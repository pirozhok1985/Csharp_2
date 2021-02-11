using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace WpfEmployeesDepartments.Model
{
  static class dbOperations
   {
       public static IConfiguration AppSettings { get; } =
           new ConfigurationBuilder().AddXmlFile("appconfig.xml").Build();
       public static string ConnectionString { get; set; }
       public static SqlConnection Connection { get; set; }
       public static SqlCommand Command { get; set; }

       public static ObservableCollection<Department> GetDepartments()
       {
           ObservableCollection<Department> d = new ObservableCollection<Department>();
           ConnectionString = AppSettings["connectionString"];
           Connection = new SqlConnection(ConnectionString);
           Connection.Open();
           string sqlQuery = "Select * From Departments";
           using (Command = new SqlCommand(sqlQuery, Connection))
           {
               SqlDataReader reader = Command.ExecuteReader(CommandBehavior.CloseConnection);
               while (reader.Read())
               {
                   d.Add(new Department
                   {
                       Name = (string)reader["Name"],
                       Emp = new ObservableCollection<Employee>()
                   });
               }
               reader.Close();
           }

           Connection.Open();
           sqlQuery = "Select Employees.Name, Employees.SName, Employees.Id, Employees.Salary," +
                             " Departments.Name as DepName From Employees Join Departments on Departments.Id = Employees.DepId";
           using (Command = new SqlCommand(sqlQuery, Connection))
           {
               SqlDataReader reader = Command.ExecuteReader(CommandBehavior.CloseConnection);
               while (reader.Read())
               {
                   foreach (var item in d)
                   {
                       if ((string)reader["DepName"] == item.Name)
                       {
                           item.Emp.Add(new Employee
                           {
                               Id = (int)reader["Id"],
                               Name = (string)reader["Name"],
                               SName = (string)reader["SName"],
                               Salary = (decimal)reader["Salary"]
                           });
                       }
                   }
               }
               reader.Close();
           }
           return d;
       }

       public static void InsertEmployee(Employee e, Department d)
       {
           ConnectionString = AppSettings["connectionString"];
           Connection = new SqlConnection(ConnectionString);
           Connection.Open();
           string sqlQuery = $"Insert Into Employees (Name, Sname, Salary, DepId) Values ('{e.Name}', '{e.SName}', '{e.Salary}')"; // DepId не прислюнить, пока не пойму как реализовать
           using (Command = new SqlCommand(sqlQuery, Connection))
           {
               Command.ExecuteNonQuery();
           }
        }

       public static void UpdateEmployee(Employee e)
       {
           throw new NotImplementedException(); //Нужно разбираться, как подписаться на событие INotifyPropertyChanged
       }

       public static void RemoveEmployee(Employee e)
       {
           ConnectionString = AppSettings["connectionString"];
           Connection = new SqlConnection(ConnectionString);
           Connection.Open();
           string sqlQuery = $"Delete From Employees where Id={e.Id}";
           using (Command = new SqlCommand(sqlQuery,Connection))
           {
               Command.ExecuteNonQuery();
           }
        }

       public static void InsertDepartment(Department e)
       {
           ConnectionString = AppSettings["connectionString"];
           Connection = new SqlConnection(ConnectionString);
           Connection.Open();
           string sqlQuery = $"Insert Into Departments (Name) Values ('{e.Name}')"; 
           using (Command = new SqlCommand(sqlQuery, Connection))
           {
               Command.ExecuteNonQuery();
           }
        }

       public static void UpdateDepartment(Department e)
       {
           throw new NotImplementedException(); //Нужно разбираться, как подписаться на событие INotifyPropertyChanged
        }

       public static void RemoveDepartment(Department e)
       {
           ConnectionString = AppSettings["connectionString"];
           Connection = new SqlConnection(ConnectionString);
           Connection.Open();
           string sqlQuery = $"Delete From Departments where Name='{e.Name}'";
           using (Command = new SqlCommand(sqlQuery, Connection))
           {
               Command.ExecuteNonQuery();
           }
        }
    }
}
