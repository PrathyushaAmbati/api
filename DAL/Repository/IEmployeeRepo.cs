using Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repository
{
    public interface IEmployeeRepo
    {
        void AddEmploy(EmployDetails emp);
        void UpdateEmploy(EmployDetails emp);
        void DeleteEmploy(int Id);
        EmployDetails GetEmpDetailsById(int Id);
        IEnumerable<EmployDetails> GetEmpDetails();
        
    }
}
