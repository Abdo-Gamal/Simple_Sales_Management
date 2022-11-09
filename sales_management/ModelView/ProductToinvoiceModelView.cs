using System.ComponentModel.DataAnnotations;

namespace sales_management.ModelView
{
    public class ProductToinvoiceModelView  //car
    {

        [Required]
        public int Id { get; set; }

        public double price { get; set; }
        [Required]
        public double quantity { get; set; }
        
        public int? productsId { get; set; }
        public int? invoiceId { get; set; }

    }
}
