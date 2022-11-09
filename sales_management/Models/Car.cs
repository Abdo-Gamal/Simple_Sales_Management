using System.ComponentModel.DataAnnotations.Schema;

namespace sales_management.Models
{
    public class Car
    {
        public int Id { get; set; }

        public double price { get; set; }
        public double quantity { get; set; }


        [ForeignKey("invoice")]
        public int invoiceId { get; set; }
        public virtual invoice invoice { get; set; }

        [ForeignKey("products")]
        public int productsId { get; set; }
        public virtual products products { get; set; }

    }
}
