using Microsoft.AspNetCore.Mvc;
using FoodDelivery.EntityFramework.Entities;
using FoodDelivery.EntityFramework;
using FoodDelivery.Models;

namespace FoodDelivery.Controllers{
    [Route("api/[controller]")]
    [ApiController]
     public class RestaurantController : ControllerBase
    {
        private FoodDelivery_DataContext _fd_DataContext;
        public RestaurantController(FoodDelivery_DataContext fd_DataContext)
        {
            _fd_DataContext = fd_DataContext;
        }
        

        [HttpGet]
        [Route("GetRestaurants")]
        public IActionResult Get()
        {
            ResponseType type = ResponseType.Success;
            try
            {
                List<RestaurantModel> data = new List<RestaurantModel>();
                var dataList = _fd_DataContext.Restaurants.ToList();
                dataList.ForEach(row => data.Add(new RestaurantModel()
                {
                    id = row.Id,
                    name = row.Name,
                    postalcode = row.PostalCode
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

        [HttpGet]
        [Route("GetRestaurantById/{id}")]
        public IActionResult Get(int id)
        {
            ResponseType type = ResponseType.Success;
            try
            {
                var row = _fd_DataContext.Restaurants.Where(d=>d.Id.Equals(id)).FirstOrDefault();
                RestaurantModel data = new RestaurantModel() {
                    id = row.Id,
                    name = row.Name,
                    postalcode = row.PostalCode
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