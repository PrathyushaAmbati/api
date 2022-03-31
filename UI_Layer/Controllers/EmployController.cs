//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace UI_Layer.Controllers
//{
//    public class EmployController : Controller
//    {
//        //public IActionResult Index()
//        //{
//        //    return View();
//        //}

//    }
//}

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

namespace NewsAdManagementSystem_UI.Controllers
{
    public class EmployController : Controller
    {
        private IConfiguration _configuration;
        public EmployController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        #region ShowEmployDetails
        public async Task<IActionResult> ShowEmployDetails()//Select*from EmployDetails
        {
            IEnumerable<EmployDetails> employResult = null;
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBaseUrl"] + "Employ/GetEmployDetails";
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        employResult = JsonConvert.DeserializeObject<IEnumerable<EmployDetails>>(result);
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

        public async Task<IActionResult> Register(EmployDetails employDetails)//Insertion into EmployDetails values
        {
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(employDetails), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiBaseUrl"] + "Employ/AddEmploy";
                using (var response = await client.PostAsync(endPoint, content))
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
            EmployDetails employDetails = null;
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBaseUrl"] + "Employ/GetEmployDetailsByID?EmpID=" + EmpID;
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        employDetails = JsonConvert.DeserializeObject<EmployDetails>(result);

                    }
                }
            }
            return View(employDetails);
        }

        //POST Method
        [HttpPost]
        public async Task<IActionResult> EditEmployDetails(EmployDetails employDetails)
        {
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(employDetails), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiBaseUrl"] + "Employ/UpdateEmploy";
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
                string endPoint = _configuration["WebApiBaseUrl"] + "Employ/DeleteEmploy?EmpID=" + EmpID;
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

        #region Login
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(EmployDetails employDetails)
        {
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(employDetails), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiBaseUrl"] + "Employ/Login";
                using (var response = await client.PostAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        return RedirectToAction("ShowEmployDetails");
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Wrong credentials!";
                    }
                }
            }
            return View();
        }
        #endregion Login
    }
}






