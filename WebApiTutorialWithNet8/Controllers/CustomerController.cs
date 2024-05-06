using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiTutorialWithNet8.Db;
using WebApiTutorialWithNet8.Model;

namespace WebApiTutorialWithNet8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly AppDbContext db;

        public CustomerController(AppDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        [Route("Insert Customer")]
        public IActionResult Get()
        {
            try
            {
                var customers = db.Customers.ToList();
                if (customers.Count == 0)
                {
                    return NotFound("Products not available...!!");
                }
                return Ok(customers);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{Id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var customers = db.Customers.Find(id);
                if (customers == null)
                {
                    return NotFound($"Products details not found with Id{id}");
                }
                return Ok(customers);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Insert Customer")]
        public IActionResult Post(Customer customer)
        {
            try
            {
                db.Add(customer);
                db.SaveChanges();
                return Ok("Customer has been created...");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("Update Customer")]
        public IActionResult Update(Customer customer)
        {
            if (customer == null || customer.CustomerId == 0)
            {
                return BadRequest("Customer Data is invalid..!!");
            }
            else if (customer.CustomerId == 0)
            {
                return BadRequest($"Customer Id{customer.CustomerId} is invalid..");
            }
            try
            {
                var Customer = db.Customers.Find(customer.CustomerId);
                if (customer == null)
                {
                    return NotFound($"Customer not found with Id{customer.CustomerId}");
                }
                Customer.CustomerName = customer.CustomerName;
                Customer.CustomerPhone = customer.CustomerPhone;
                Customer.CustomerEmail = customer.CustomerEmail;
                Customer.Age = customer.Age;
                Customer.Address = customer.Address;
                Customer.City = customer.City;

                db.SaveChanges();
                return Ok("Customer Details Updated..");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        [Route("Delete Customer")]
        public IActionResult Delete(int id)
        {
            try
            {
                var product = db.Customers.Find(id);
                if (product == null)
                {
                    return NotFound($"Customer not found with Id {id}");
                }
                db.Customers.Remove(product);
                db.SaveChanges();
                return Ok("Customer Deleted...");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
