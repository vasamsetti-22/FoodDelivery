using Microsoft.AspNetCore.Mvc;
using FoodDelivery.EntityFramework.Entities;
using FoodDelivery.EntityFramework;
using FoodDelivery.Models;
using Microsoft.AspNetCore.Authorization;

namespace FoodDelivery.Controllers{
    [Route("api/[controller]")]
    [Authorize(Roles = "Driver")]
    [ApiController]
     public class DriverController : ControllerBase
    {
        private FoodDelivery_DataContext _fd_DataContext;
        public DriverController(FoodDelivery_DataContext fd_DataContext)
        {
            _fd_DataContext = fd_DataContext;
        }
        

        [HttpGet]
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
                    postcode = row.PostCode
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
                var row = _fd_DataContext.Drivers.Where(d=>d.Id.Equals(id)).FirstOrDefault();
                DriverModel data = new DriverModel() {
                    id = row.Id,
                    name = row.Name,
                    postcode = row.PostCode
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
        public IActionResult AddDriver([FromBody] DriverModel model)
        {
            try
            {
                ResponseType type = ResponseType.Success;
              
                 Driver driverrRow = new Driver(){
                    Id = model.id,
                    Name = model.name,
                    PostCode = model.postcode
                };
                 _fd_DataContext.Drivers.Add(driverrRow);
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
                var driver = _fd_DataContext.Drivers.Where(d => d.Id.Equals(id)).FirstOrDefault();
            if (driver != null)
            {
                _fd_DataContext.Drivers.Remove(driver);
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