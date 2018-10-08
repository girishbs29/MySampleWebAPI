using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MySampleWebAPI.Controllers
{
    public class CustomerController : ApiController
    {
        private static List<Customer> _customers = new List<Customer>(){
            new Customer() { Id = 1, Name = "Nell D. Michael" },
            new Customer() { Id = 2, Name = "Ciara G. Stanley" },
            new Customer() { Id = 3, Name = "Elton B. Ashley" }
        };

        // GET api/values
        [HttpGet]
        public HttpResponseMessage GetAllCustomers()
        {
            var response = Request.CreateResponse<List<Customer>>(HttpStatusCode.OK, _customers);
            return response;
        }

        // GET api/values/5
        [HttpGet]
        public Customer GetCustomer(int id)
        {
            var cust = _customers.SingleOrDefault(x => x.Id == id);
            return cust;
        }

        // POST api/values
        [HttpPost]
        public HttpResponseMessage AddCustomer([FromBody]string value)
        {
            var cust = new Customer() { Id = 4, Name = value };
            _customers.Add(cust);
            HttpResponseMessage mesg = Request.CreateResponse(HttpStatusCode.Created);
            mesg.Headers.Location = new Uri(Request.RequestUri + cust.Id.ToString());
            return mesg;
        }

        // PUT api/values/5
        [HttpPut]
        public void UpdateCustomer(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete]
        public void DeleteCustomer(int id)
        {

        }
    }

    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
