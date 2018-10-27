using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FileReader.Controllers
{
    [Route("")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        //// GET
        [HttpGet()]
        public ActionResult<string> Get()
        {
            return "Welcome, please append your key to url to fetch corresponding value";
        }

        //// GET /id
        [HttpGet("{id}")]
        public ActionResult Get(string id)
        {
            ActionResult result;

            if (DataFetcher.numberKeyValuePairs.TryGetValue(id, out int value))
            {
                result = Ok(new { Key = id, Value = value });
            }
            else
            {
                result = NotFound();
            }

            return result;
        }
    }
}
