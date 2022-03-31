using DAL.Repository;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BAL.Services
{
    public class EmployeeService
    {
        IEmployeeRepo _iEmployRepository;
        public EmployeeService(IEmployeeRepo employRepository)
        {
            _iEmployRepository = employRepository;
        }
        public void AddEmploy(EmployDetails employDetails)
        {
            _iEmployRepository.AddEmploy(employDetails);
        }
        public void UpdateEmploy(EmployDetails employDetails)
        {
            _iEmployRepository.UpdateEmploy(employDetails);
        }
        public void DeleteEmploy(int EmpID)
        {
            _iEmployRepository.DeleteEmploy(EmpID);
        }
        public EmployDetails GetEmpDetailsByID(int EmpID)
        {
            return _iEmployRepository.GetEmpDetailsById(EmpID);
        }
        public IEnumerable<EmployDetails> GetEmpDetails()
        {
            return _iEmployRepository.GetEmpDetails();
        }

        //public Emp_Model Login(Emp_Model employDetails)
        //{
        //    return _iEmployRepository.Login(employDetails);
        //}
    }
}

