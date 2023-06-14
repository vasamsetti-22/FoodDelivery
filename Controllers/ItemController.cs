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

        [HttpGet("{id}")] 
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
        [HttpPost]
        public IActionResult AddItem([FromBody] ItemModel model)
        {
            try
            {
                ResponseType type = ResponseType.Success;
              
                 Item itemRow = new Item(){
                    Id = model.id,
                    Name = model.name,
                    Price = model.price,
                    RestaurantId = model.restaurantid
                };
                 _fd_DataContext.Items.Add(itemRow);
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
                var item = _fd_DataContext.Items.Where(d => d.Id.Equals(id)).FirstOrDefault();
            if (item != null)
            {
                _fd_DataContext.Items.Remove(item);
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