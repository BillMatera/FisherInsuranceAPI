﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FisherInsuranceAPI.Models;
using FisherInsuranceAPI.Data;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace FisherInsuranceAPI.Controllers
{
    [Route("api/customer/claims")]
    public class ClaimsController : Controller
    {
        private IMemoryStore db;
        public ClaimsController(IMemoryStore repo)
        {
            db = repo;
        }

        // GET: api/values
        [HttpGet]
        public IActionResult GetClaims()
        {
            return Ok(db.RetrieveAllClaims);
        }

        // GET api/customer/claims/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(db.RetrieveClaim(id));
        }

        // POST api/customer/claims
        [HttpPost]
        public IActionResult Post([FromBody]Claim claim)
        {
            return Ok(db.CreateClaim(claim));
        }

        // PUT api/customer/claims/id
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Claim claim)
        {
            return Ok(db.UpdateClaim(claim));
        }

        // DELETE  api/customer/claims/id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            db.DeleteClaim(id);
            return Ok();
        }
    }
}
