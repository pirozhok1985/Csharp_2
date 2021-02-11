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

       public static void InsertEmployee(Employee e)
       {
           throw new NotImplementedException();
       }

       public static void UpdateEmployee(Employee e)
       {
           throw new NotImplementedException();
       }

       public static void RemoveEmployee(Employee e)
       {
           throw new NotImplementedException();
       }

       public static void InsertDepartment(Department e)
       {
           throw new NotImplementedException();
       }

       public static void UpdateDepartment(Department e)
       {
           throw new NotImplementedException();
       }

       public static void RemoveDepartment(Department e)
       {
           throw new NotImplementedException();
       }
    }
}
