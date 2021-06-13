using DapperAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository prodRepo;

        public ProductController(IProductRepository prodRepo)
        {
            this.prodRepo = prodRepo;
        }
        [HttpGet]
        public IActionResult Get()
        {
            
            return Ok(prodRepo.GetAll());
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(prodRepo.GetById(id));
        }
        [HttpPost]
        public IActionResult Post([FromBody]Product prod)
        {
            if (ModelState.IsValid)
                prodRepo.Add(prod);
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Product prod)
        {
            if(prod.ProductID != id) { return BadRequest(); }
            if (ModelState.IsValid)
                prodRepo.Update(prod);
            return Ok();
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            prodRepo.Delete(id);
            return Ok();
        }
    }
}
