using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sales_management.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Customer_name { get; set; }
   
        public string Trade_Name { get; set; }
        public string address { get; set; }
        public double Opening_balance { get; set; }
        public int Phone_number { get; set; }
        public string Agent_code { get; set; }


        [ForeignKey("CustomerType")]
        public  int typeID { get; set; }
        public virtual CustomerType CustomerType { get; set; }

        public virtual List<invoice> invoice { get; set; }
    }
}
