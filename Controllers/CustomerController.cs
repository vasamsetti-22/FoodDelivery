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
            this._fd_DataContext = fd_DataContext;
        }
        

        [HttpGet]
        public IActionResult ListCustomers()
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
        public IActionResult GetCustomer(int id)
        {
            ResponseType type = ResponseType.Success;
            try
            {
                var row = _fd_DataContext.Customers.Where(d=>d.Id.Equals(id)).FirstOrDefault();
                CustomerModel data = new CustomerModel() {
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
        public IActionResult AddCustomer([FromBody] CustomerModel model)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                var existingCustomerRow =_fd_DataContext.Customers.Where(d => d.Id.Equals(model.id)).FirstOrDefault();
                 if(existingCustomerRow==null){
                    Customer customerRow = new Customer(){
                    Id = model.id,
                    Name = model.name,
                    PostCode = model.postcode
                    };
                    _fd_DataContext.Customers.Add(customerRow);
                    _fd_DataContext.SaveChanges();
            
                    return Ok(ResponseHandler.GetAppResponse(type, model));
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

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                var customer = _fd_DataContext.Customers.Where(d => d.Id.Equals(id)).FirstOrDefault();
            if (customer != null)
            {
                _fd_DataContext.Customers.Remove(customer);
                _fd_DataContext.SaveChanges();
                return Ok(ResponseHandler.GetAppResponse(type, "Delete Successfully"));
             }
            else
            {
                throw new CustomException("customer not found");
            }
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }
        [HttpPut]
        public IActionResult Put([FromBody] CustomerModel model)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                var customerRow =_fd_DataContext.Customers.Where(d => d.Id.Equals(model.id)).FirstOrDefault();
                if(customerRow != null)
                {
                    customerRow.Name = model.name;
                    customerRow.PostCode = model.postcode;
                    _fd_DataContext.SaveChanges();
                    return Ok(ResponseHandler.GetAppResponse(type, model));
                }
                else
                {
                    throw new CustomException("customer not found");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }
    }
}