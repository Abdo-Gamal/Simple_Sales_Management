using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sales_management.Models
{
    public class invoice
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }
        public double? Total { get; set; }
        public bool? iscofirm { get; set; }
        [ForeignKey("Customer")]
        public int customerId { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual List<Car> car { get; set; }
    }
}
