using Microsoft.AspNetCore.Mvc;
using FoodDelivery.EntityFramework.Entities;
using FoodDelivery.EntityFramework;
using FoodDelivery.Models;

namespace FoodDelivery.Controllers{
    [Route("api/[controller]")]
    [ApiController]
     public class ItemController : ControllerBase
    {
        private FoodDelivery_DataContext _fd_DataContext;
        public ItemController(FoodDelivery_DataContext fd_DataContext)
        {
            _fd_DataContext = fd_DataContext;
        }
        

        [HttpGet]
        [Route("GetItems")]
        public IActionResult Get()
        {
            ResponseType type = ResponseType.Success;
            try
            {
                List<ItemModel> data = new List<ItemModel>();
                var dataList = _fd_DataContext.Items.ToList();
                dataList.ForEach(row => data.Add(new ItemModel()
                {
                    id = row.Id,
                    name = row.Name,
                    price = row.Price,
                    restaurantid = row.RestaurantId
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
        [Route("GetItemById/{id}")]
        public IActionResult Get(int id)
        {
            ResponseType type = ResponseType.Success;
            try
            {
                var row = _fd_DataContext.Items.Where(d=>d.Id.Equals(id)).FirstOrDefault();
                ItemModel data = new ItemModel() {
                    id = row.Id,
                    name = row.Name,
                    price = row.Price,
                    restaurantid = row.RestaurantId
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