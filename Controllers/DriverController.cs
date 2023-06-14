using Microsoft.AspNetCore.Mvc;
using FoodDelivery.EntityFramework.Entities;
using FoodDelivery.EntityFramework;
using FoodDelivery.Models;

namespace FoodDelivery.Controllers{
    [Route("api/[controller]")]
    [ApiController]
     public class DriverController : ControllerBase
    {
        private FoodDelivery_DataContext _fd_DataContext;
        public DriverController(FoodDelivery_DataContext fd_DataContext)
        {
            _fd_DataContext = fd_DataContext;
        }
        

        [HttpGet]
        [Route("GetDrivers")]
        public IActionResult Get()
        {
            ResponseType type = ResponseType.Success;
            try
            {
                List<DriverModel> data = new List<DriverModel>();
                var dataList = _fd_DataContext.Drivers.ToList();
                dataList.ForEach(row => data.Add(new DriverModel()
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
        [Route("GetDriverById/{id}")]
        public IActionResult Get(int id)
        {
            ResponseType type = ResponseType.Success;
            try
            {
                var row = _fd_DataContext.Drivers.Where(d=>d.Id.Equals(id)).FirstOrDefault();
                DriverModel data = new DriverModel() {
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