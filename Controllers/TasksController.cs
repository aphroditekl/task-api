using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using taskAPI.Model;

namespace taskAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        //define a variable to sending HTTP requests and receiving HTTP responses from a resource identified by a URI.
        static HttpClient client;

        //Main Constructor 
        public TasksController()
        {
            //Initialize HttpClient object and set necessary properties
            client = new HttpClient();
            client.BaseAddress = new Uri("http://admin.test.cloud.poly.stream/api/1.0/");
            //Clear headers before each request
            client.DefaultRequestHeaders.Clear();
            //Add headers for each request for the type of file returned 
            client.DefaultRequestHeaders.Add("Accept","application/json");
            //Add headers for user authorization
            client.DefaultRequestHeaders.Add("X-TEST-ID", "b6b877f6-cacb-4694-525a-08d65e96ce08");  
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Item>> Get(string Id)
        {
            Item task = new Item();
            //GET request to the specified Uri as an asynchronous operation
            var response = await client.GetAsync("tasks/" + Id);
            //return in json format the task or message for code 204 No content
            if (response.IsSuccessStatusCode)
            {
                task = JsonConvert.DeserializeObject<Item>(await response.Content.ReadAsStringAsync());
                return task;
            }
            return NotFound();
        }
    }
}