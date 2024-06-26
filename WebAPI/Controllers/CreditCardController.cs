using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditCardController : ControllerBase
    {
        ICreditCardService _creditCardService;

        public CreditCardController(ICreditCardService creditCardService)
        {
            _creditCardService = creditCardService;
        }

        [HttpPost("add")]
        public IActionResult Add(CreditCard creditCard)
        {
            var result = _creditCardService.AddCard(creditCard);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(CreditCard creditCard)
        {
            var result = _creditCardService.UpdateCard(creditCard);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpPost("delete")]
        public IActionResult Delete(CreditCard creditCard)
        {
            var result = _creditCardService.DeleteCard(creditCard);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _creditCardService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getbycustomer")]
        public IActionResult GetByCustomer(int id)
        {
            var result = _creditCardService.GetByCustomer(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
