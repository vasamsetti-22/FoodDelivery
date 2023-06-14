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

        [HttpGet("{id}")] 
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
        [HttpPost]
        public IActionResult AddRestaurant([FromBody] RestaurantModel model)
        {
            try
            {
                ResponseType type = ResponseType.Success;
              
                 Restaurant restaurantRow = new Restaurant(){
                    Id = model.id,
                    Name = model.name,
                    PostalCode = model.postalcode
                };
                 _fd_DataContext.Restaurants.Add(restaurantRow);
                 _fd_DataContext.SaveChanges();
            
                return Ok(ResponseHandler.GetAppResponse(type, model));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                var restaurant = _fd_DataContext.Restaurants.Where(d => d.Id.Equals(id)).FirstOrDefault();
            if (restaurant != null)
            {
                _fd_DataContext.Restaurants.Remove(restaurant);
                _fd_DataContext.SaveChanges();
            }
                return Ok(ResponseHandler.GetAppResponse(type, "Delete Successfully"));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }


    }
}