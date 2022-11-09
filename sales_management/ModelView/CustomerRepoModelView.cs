using System.ComponentModel.DataAnnotations;

namespace sales_management.ModelView
{
    public class CustomerRepoModelView
    {

        public int Id { get; set; }

        [Required]
        public string Customer_name { get; set; }

        [Required]
        public string Trade_Name { get; set; }

        [Required]
        public string address { get; set; }

      

    }
}
