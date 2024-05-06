
using System.ComponentModel.DataAnnotations;

namespace WebApiTutorialWithNet8.Model
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        [Required]
        public string CustomerName { get; set; }
        public int CustomerPhone { get; set; }
        [Required]
        public string CustomerEmail { get; set; }  
        public int Age { get; set; }  
        public string Address { get; set; } 
        public string City { get; set; }
    }
}
