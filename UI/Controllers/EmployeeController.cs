using Entity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace UI.Controllers
{
    public class EmployeeController : Controller
    {
        
        private IConfiguration _configuration;
        public EmployeeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        #region ShowEmployDetails
        public async Task<IActionResult> ShowEmployeeDetails()//Select*from EmployDetails
        {
            IEnumerable<Emp_Model> employResult = null;
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBaseUrl"] + "Employ/GetEmpDetails";
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        employResult = JsonConvert.DeserializeObject<IEnumerable<Emp_Model>>(result);
                    }
                }
            }
            return View(employResult);
        }
        #endregion ShowEmployDetails


        #region Register
        //GET Method
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Register(Emp_Model employDetails)//Insertion into EmployDetails values
        {
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(employDetails), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiBaseUrl"] + "Employ/AddEmploy";
                using (var response = await client .PostAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "Saved Successfully";
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Wrong Entries!";
                    }
                }
            }
            return View();
        }
        #endregion Register

        #region EditEmployDetails

        //GET Method
        [HttpGet]
        public async Task<IActionResult> EditEmployDetails(int EmpID)//Update EmployDetails 
        {
            Emp_Model employDetails = null;
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBaseUrl"] + "Employee/GetEmployDetailsByID?EmpID=" + EmpID;
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        employDetails = JsonConvert.DeserializeObject<Emp_Model>(result);

                    }
                }
            }
            return View(employDetails);
        }

        //POST Method
        [HttpPost]
        public async Task<IActionResult> EditEmployDetails(Emp_Model employDetails)
        {
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(employDetails), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiBaseUrl"] + "Employee/UpdateEmploy";
                using (var response = await client.PutAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "Updated Successfully";
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Wrong Entries!";
                    }
                }
            }
            return View(employDetails);
        }
        #endregion EditEmployDetails

        #region DeleteEmployDetails
        public async Task<IActionResult> DeleteEmployDetails(int EmpID)//Delete EmployDetails 
        {
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBaseUrl"] + "Employee/DeleteEmploy?EmpID=" + EmpID;
                using (var response = await client.DeleteAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        ViewBag.message = "Deleted Successfully";
                    }
                }
            }
            return RedirectToAction("ShowEmployDetails");

        }
        #endregion DeleteEmployDetails

    }
}
