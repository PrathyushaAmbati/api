using DAL.Data;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Repository
{
    public class EmployeeRepository : IEmployeeRepo
    {
        ConnectionString _connection;
        public EmployeeRepository(ConnectionString connection)
        {
            _connection = connection;
        }
        public void AddEmploy(EmployDetails emp)
        {
            _connection.Employee.Add(emp);
            _connection.SaveChanges();
        }

        public void DeleteEmploy(int Id)
        {


            var EmpDetails = _connection.Employee.Find(Id);
            _connection.Employee.Remove(EmpDetails);
            _connection.SaveChanges();

        }

        public IEnumerable<EmployDetails> GetEmpDetails()
        {
            return _connection.Employee.ToList();
        }

        public EmployDetails GetEmpDetailsById(int Id)
        {
            return _connection.Employee.Find(Id);
        }

        public void UpdateEmploy(EmployDetails emp)
        {

            //var EmpDetails = _connection.Employee.Find(Id);
            _connection.Employee.Update(emp);
            _connection.SaveChanges();
        }
    }
}
