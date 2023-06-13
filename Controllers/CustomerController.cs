using Microsoft.AspNetCore.Mvc;
using FoodDelivery.EntityFramework.Entities;
using FoodDelivery.EntityFramework;
using FoodDelivery.Models;

namespace FoodDelivery.Controllers{
    [Route("api/[controller]")]
    [ApiController]
     public class CustomerController : ControllerBase
    {
        private FoodDelivery_DataContext _fd_DataContext;
        public CustomerController(FoodDelivery_DataContext fd_DataContext)
        {
            _fd_DataContext = fd_DataContext;
        }
        

        [HttpGet]
        [Route("GetCustomers")]
        public IActionResult Get()
        {
            ResponseType type = ResponseType.Success;
            try
            {
                List<CustomerModel> data = new List<CustomerModel>();
                var dataList = _fd_DataContext.Customers.ToList();
                dataList.ForEach(row => data.Add(new CustomerModel()
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
        [Route("GetCustomerById/{id}")]
        public IActionResult Get(int id)
        {
            ResponseType type = ResponseType.Success;
            try
            {
                var row = _fd_DataContext.Customers.Where(d=>d.Id.Equals(id)).FirstOrDefault();
                CustomerModel data = new CustomerModel() {
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