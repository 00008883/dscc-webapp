using MVC_DSCC_8883.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MVC_DSCC_8883.Controllers
{
    public class EmployeeController : Controller
    {
        // async Because we are connecting to API

        // Getting URL from ConnectionString class
        string Baseurl = ConnectionSettings.GetURL;

        // GET: Employee
        public async Task<ActionResult> Index()
        {
            List<Employee> EmpInfo = new List<Employee>();
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();

                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new
                MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource using HttpClient
                HttpResponseMessage Res = await client.GetAsync("api/employee");

                //Checking the response is successful or not which is sent HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var PrResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing the Product list
                    EmpInfo = JsonConvert.DeserializeObject<List<Employee>>(PrResponse);
                }
                //returning the Product list to view
                return View(EmpInfo);
            }
        }

        // GET: Employee/Details/5
        public async Task<ActionResult> Details(int id)
        {
            Employee emp = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                HttpResponseMessage Res = await client.GetAsync("api/Employee/" + id);
                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var PrResponse = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list
                    emp = JsonConvert.DeserializeObject<Employee>(PrResponse);
                }
                else
                    ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
            }

            return View(emp);
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        public async Task<ActionResult> Create(Employee emp)
        {
            try
            {

                // TODO: Add update logic here
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl);


                    //HTTP POST
                    var postTask = client.PostAsJsonAsync<Employee>("api/Employee", emp);
                    postTask.Wait();
                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }
                
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            Employee emp = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                HttpResponseMessage Res = await client.GetAsync("api/Employee/" + id);
                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var PrResponse = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Product list
                    emp = JsonConvert.DeserializeObject<Employee>(PrResponse);
                }
                else
                    ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
            }

            return View(emp);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, Employee emp)
        {
            try
            {

                // TODO: Add update logic here
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl);
                    HttpResponseMessage Res = await client.GetAsync("api/Employee/" + id);
                    Employee empone = null;
                    //Checking the response is successful or not which is sent using HttpClient
                    if (Res.IsSuccessStatusCode)
                    {
                        //Storing the response details recieved from web api
                        var PrResponse = Res.Content.ReadAsStringAsync().Result;
                        //Deserializing the response recieved from web api and storing into the Employee list
                        empone = JsonConvert.DeserializeObject<Employee>(PrResponse);
                    }

                    //HTTP POST
                    var postTask = client.PutAsJsonAsync<Employee>("api/Employee/" + emp.EmployeeID, emp);
                    postTask.Wait();
                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            Employee empone = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                HttpResponseMessage Res = await client.GetAsync("api/Employee/" + id);
                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var PrResponse = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Product list
                    empone = JsonConvert.DeserializeObject<Employee>(PrResponse);
                }
                else
                    ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
            }

            return View(empone);
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl);
                    //HTTP POST
                    // Deleting product with corresponding id
                    HttpResponseMessage Res = await client.DeleteAsync("api/Employee/" + id);
                    if (Res.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
        }
    }
}
