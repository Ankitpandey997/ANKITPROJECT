using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InsertingFormDataUsingWebAPI
{
    public class EmpController : ApiController
    {
        static EmpRepository repository = new EmpRepository();


        public string AddEmployees(Employee Emp)
        {
            //calling EmpRepository Class Method and storing Repsonse   
            var response = repository.AddEmployees(Emp);
            return response;

        }


        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}