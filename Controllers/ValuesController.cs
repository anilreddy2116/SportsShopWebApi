using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SportsShopWebApi.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public HttpResponseMessage Get()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("CustomerName");
            dt.Columns.Add("CustomerPhoneNo");
            dt.Columns.Add("CustomerAddress");
            dt.Columns.Add("CustomerEmailId");

            dt.Rows.Add("Anil",9490009687,"Hyderabad","anil@gmail.com");

            return Request.CreateResponse(HttpStatusCode.OK,dt);

        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
