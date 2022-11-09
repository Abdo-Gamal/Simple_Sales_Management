using System.ComponentModel.DataAnnotations;

namespace sales_management.Models
{
    public class Company_info
    {
        public int Id { get; set; }
        public string Company_name { get; set; }
        public string address { get; set; }
        public int phone_number { get; set; }
        public double Tax_Number { get; set; }
        public string E_mail { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public int Whatsapp { get; set; }
        public string Print_type { get; set; }
        public string Cloud_type { get; set; }
        public string note { get; set; }
        public int thermal_printing { get; set; }//
        public string logo { get; set; }//

        
    }
}
