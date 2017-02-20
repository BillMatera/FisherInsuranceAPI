using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FisherInsuranceAPI.Models;
using FisherInsuranceAPI.Data;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace FisherInsuranceAPI.Controllers
{
    [Route("api/[controller]")]
    public class QuotesController : Controller
    {
        private IMemoryStore db;
        public QuotesController(IMemoryStore repo)
        {
            db = repo;
        }

        // GET: api/values
       

        [HttpGet]
        public IActionResult GetQuotes()
        {
            return Ok(db.RetrieveAllQuotes);
        }

        // GET api/quotes/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(db.RetrieveQuote(id));
        }

        // POST api/quote
        [HttpPost]
        public IActionResult Post([FromBody]Quote quote)
        {
            return Ok(db.CreateQuote(quote));
        }

        // PUT api/quotes/id
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Quote quote)
        {
            return Ok(db.UpdateQuote(quote));
        }

        // DELETE api/quotes/id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            db.DeleteQuote(id);
            return Ok();
        }
    }
}
