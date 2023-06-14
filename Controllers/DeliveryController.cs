using Microsoft.AspNetCore.Mvc;
using FoodDelivery.EntityFramework.Entities;
using FoodDelivery.EntityFramework;
using FoodDelivery.Models;

namespace FoodDelivery.Controllers{
    [Route("api/[controller]")]
    [ApiController]
     public class DeliveryController : ControllerBase
    {
        private FoodDelivery_DataContext _fd_DataContext;
        public DeliveryController(FoodDelivery_DataContext fd_DataContext)
        {
            _fd_DataContext = fd_DataContext;
        }
        

        [HttpGet]
        public IActionResult Get()
        {
            ResponseType type = ResponseType.Success;
            try
            {
                List<DeliveryModel> data = new List<DeliveryModel>();
                var dataList = _fd_DataContext.Deliveries.ToList();
                dataList.ForEach(row => data.Add(new DeliveryModel()
                {
                    id = row.Id,
                    orderid = row.OrderId,
                    driverid = row.DriverId
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
                var row = _fd_DataContext.Deliveries.Where(d=>d.Id.Equals(id)).FirstOrDefault();
                DeliveryModel data = new DeliveryModel() {
                    id = row.Id,
                    orderid = row.OrderId,
                    driverid = row.DriverId
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
        public IActionResult AddDelivery([FromBody] DeliveryModel model)
        {
            try
            {
                ResponseType type = ResponseType.Success;
              
                 Delivery deliveryRow = new Delivery(){
                    Id = model.id,
                    OrderId = model.orderid,
                    DriverId = model.driverid
                };
                 _fd_DataContext.Deliveries.Add(deliveryRow);
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
                var delivery = _fd_DataContext.Deliveries.Where(d => d.Id.Equals(id)).FirstOrDefault();
            if (delivery != null)
            {
                _fd_DataContext.Deliveries.Remove(delivery);
                _fd_DataContext.SaveChanges();
                return Ok(ResponseHandler.GetAppResponse(type, "Delete Successfully"));
            }
            else
            {
                throw new CustomException("customer already exists");
            }
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }
    }
}