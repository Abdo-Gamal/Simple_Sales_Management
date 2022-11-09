using System.ComponentModel.DataAnnotations;
namespace sales_management.Models
{
    public class CustomerType
    {
        public int Id { get; set; }
        public string type { get; set; }

        public virtual List<Customer> Customer { get; set;}
    }
}