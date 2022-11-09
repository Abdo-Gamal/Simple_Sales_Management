using System.ComponentModel.DataAnnotations;

namespace sales_management.ModelView
{
    public class CustomerModelView
    {

        [Required]

        public int Id { get; set; }
        [Required]
        public string Customer_name { get; set; }
   
        [Required]
        public string Trade_Name { get; set; }
        [Required, ]
        public string address { get; set; }
        [Required]
        public double Opening_balance { get; set; }
        [Required,DataType(DataType.PhoneNumber)]
        public int Phone_number { get; set; }
        [Required]
        public string Agent_code { get; set; }
        [Required]
        public int typeID { get; set; }


    }
}
