using ContizaPizzaWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ContizaPizzaWebApi.Services;

namespace ContizaPizzaWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PizzaController : ControllerBase
    {
        public PizzaController() { }

        //getallaction
        [HttpGet]
        public ActionResult<List<Pizza>> GetAll() => PizzaService.GetAll();

        [HttpGet("{id}")]
        public ActionResult<Pizza> Get(int id)
        {

            var pizza = PizzaService.Get(id);
            if (pizza == null)
            return NotFound();
            return pizza;
        }
        [HttpPost]
        public IActionResult Create(Pizza pizza)
        { 
            PizzaService.Add(pizza);
            return CreatedAtAction(nameof(Get), pizza, pizza.Id);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, Pizza pizza)
        {
            if(id!=pizza.Id)
                return BadRequest();
            var pizzaToBeUpdated = PizzaService.Get(id);
            if (pizzaToBeUpdated is null)
                return NotFound(nameof(pizza));
            PizzaService.Update(pizzaToBeUpdated);
            return NoContent();

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            PizzaService.Delete(id);
            return NoContent();
        }
        

    }
    
}
