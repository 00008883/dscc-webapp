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
    public class ProductController : Controller
    {
        // async Because we are connecting to API

        // Getting URL from ConnectionString class
        string Baseurl = ConnectionSettings.GetURL;

        // GET: Product
        public async Task<ActionResult> Index()
        {
            List<Product> ProdInfo = new List<Product>();
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();

                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new
                MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource using HttpClient
                HttpResponseMessage Res = await client.GetAsync("api/product");

                //Checking the response is successful or not which is sent HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var PrResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing the Product list
                    ProdInfo = JsonConvert.DeserializeObject<List<Product>>(PrResponse);
                }
                //returning the Product list to view
                return View(ProdInfo);
            }
        }


        // GET: Product/Details/5
        public async Task<ActionResult> Details (int id)
        {
             Product oneproduct = null;
             using (var client = new HttpClient())
             {
                 client.BaseAddress = new Uri(Baseurl);
                 HttpResponseMessage Res = await client.GetAsync("api/Product/" + id);
                 //Checking the response is successful or not which is sent using HttpClient
                 if (Res.IsSuccessStatusCode)
                 {
                     //Storing the response details recieved from web api
                     var PrResponse = Res.Content.ReadAsStringAsync().Result;
                     //Deserializing the response recieved from web api and storing into the Product list
                     oneproduct = JsonConvert.DeserializeObject<Product>(PrResponse);
                 }
                 else
                     ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
             }

             return View(oneproduct);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public async Task<ActionResult> Create(Product prod)
        {
            try
            {

                // TODO: Add update logic here
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl);
                    

                    //HTTP POST
                    var postTask = client.PostAsJsonAsync<Product>("api/Product", prod);
                    postTask.Wait();
                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }
                //ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
                //return View(student);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            Product oneproduct = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                HttpResponseMessage Res = await client.GetAsync("api/Product/" + id);
                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                    {
                        //Storing the response details recieved from web api
                        var PrResponse = Res.Content.ReadAsStringAsync().Result;
                        //Deserializing the response recieved from web api and storing into the Product list
                        oneproduct = JsonConvert.DeserializeObject<Product>(PrResponse);
                    }
                else
                    ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
            }

            return View(oneproduct);
        }

        // POST: Product/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, Product prod)
        {
            try
            {
                
                // TODO: Add update logic here
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl);
                    HttpResponseMessage Res = await client.GetAsync("api/Product/" + id);
                    Product oneproduct = null;
                    //Checking the response is successful or not which is sent using HttpClient
                    if (Res.IsSuccessStatusCode)
                    {
                        //Storing the response details recieved from web api
                        var PrResponse = Res.Content.ReadAsStringAsync().Result;
                        //Deserializing the response recieved from web api and storing into the Product list
                        oneproduct = JsonConvert.DeserializeObject<Product>(PrResponse);
                    }
                    
                    //HTTP POST
                    var postTask = client.PutAsJsonAsync<Product>("api/Product/" + prod.ProductID, prod);
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

        // GET: Product/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            Product oneproduct = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                HttpResponseMessage Res = await client.GetAsync("api/Product/" + id);
                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var PrResponse = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Product list
                    oneproduct = JsonConvert.DeserializeObject<Product>(PrResponse);
                }
                else
                    ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
            }

            return View(oneproduct);
        }

        // POST: Product/Delete/5
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
                    HttpResponseMessage Res = await client.DeleteAsync("api/Product/" + id);
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
