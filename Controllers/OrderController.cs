using Microsoft.AspNetCore.Mvc;
using FoodDelivery.EntityFramework.Entities;
using FoodDelivery.EntityFramework;
using FoodDelivery.Models;
using Microsoft.AspNetCore.Authorization;

namespace FoodDelivery.Controllers{
    [Route("api/[controller]")]
    [ApiController]
     public class OrderController : ControllerBase
    {
        private FoodDelivery_DataContext _fd_DataContext;
        public OrderController(FoodDelivery_DataContext fd_DataContext)
        {
            _fd_DataContext = fd_DataContext;
        }
        

        [HttpGet]
        [Authorize(Roles = "Customer,RestaurantOwner")]
        public IActionResult Get()
        {
            ResponseType type = ResponseType.Success;
            try
            {
                List<OrderModel> data = new List<OrderModel>();
                var dataList = _fd_DataContext.Orders.ToList();
                dataList.ForEach(row => data.Add(new OrderModel()
                {
                    id = row.Id,
                    price = row.Price
                }));
                if (!data.Any())
                {
                    type = ResponseType.NotFound;
                }
                return Ok(ResponseHandler.GetAppResponse(type, data));
            }
            catch (Exception ex)
            { 
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        [HttpGet("{id}")] 
        [Authorize(Roles = "Customer,RestaurantOwner")]
        public IActionResult Get(int id)
        {
            ResponseType type = ResponseType.Success;
            try
            {
                var row = _fd_DataContext.Orders.Where(d=>d.Id.Equals(id)).FirstOrDefault();
                OrderModel data = new OrderModel() {
                    id = row.Id,
                    price = row.Price
                };

                if (data == null)
                {
                    type = ResponseType.NotFound;
                }
                return Ok(ResponseHandler.GetAppResponse(type, data));
            }
            catch (Exception ex)
            { 
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }
    }
}