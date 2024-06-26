using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CarsController : ControllerBase
    {
        ICarService _carService; 
        IPaymentService _paymentService;

        public CarsController(ICarService carService, IPaymentService paymentService)
        {
            _carService = carService;
            _paymentService = paymentService;
        }

        [HttpGet("getall")]
        
        public IActionResult GetAll()
        {
            var result = _carService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _carService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpGet("getbycategory")]
        public IActionResult GetByCategoryId(int categoryId)
        {
            var result = _carService.GetByCategoryId(categoryId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbybrand")]
        public IActionResult GetByBrandId([FromQuery] string brandId)
        {
            var result = _carService.GetByBrandId(brandId);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbycolor")]
        public IActionResult GetByColorId(int colorId)
        {
            var result = _carService.GetByColorId(colorId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getcarsbybrandandcolor")]
        public IActionResult GetCarsByBrandAndColor(int brandId, int colorId)
        {
            var result = _carService.GetCarsByBrandAndColor(brandId, colorId);

            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }



        [HttpGet("getdetails")]
        public IActionResult GetCarDetails(int carId)
        {
            var result = _carService.GetCarDetails(carId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }

        [HttpGet("getbycardetail")]
        public IActionResult GetByCarDetailId(int carId)
        {
            var result = _carService.GetByCarDetailId(carId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }

        [HttpPost("add")]
        public IActionResult Add(Car car)
        {
             
             int currentUserId = GetCurrentUserId();  // Mevcut kullanıcı kimliğini al
            var result = _carService.AddCar(currentUserId, car);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        private int GetCurrentUserId()
        {
            // Mevcut kullanıcı kimliğini HttpContext üzerinden al
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                

            // Kullanıcı kimliğini integer olarak dönüştür (örneğin)
            if (int.TryParse(userId, out int result))
            {
                return result;
            }

            // Dönüştürme başarısız olursa, varsayılan değer olarak -1 dön
            return -1;
        }
        [HttpPost("update")]
        public IActionResult Update(Car car)
        {
            var result = _carService.UpdateCar(car);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete(Car car)
        {
            var result = _carService.DeleteCar(car);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("payment")]
        public IActionResult Payment(Payment amount)
        {
            var result = _paymentService.MakePayment(amount);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }

}
