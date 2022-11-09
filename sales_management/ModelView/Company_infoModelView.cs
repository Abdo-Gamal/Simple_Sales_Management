using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sales_management.ModelView
{
    public class Company_infoModelView
    {
        public int Id { get; set; }
        [Required,]// RegularExpression(@"[a-z]+", ErrorMessage = "Name must be chachter")]
        public string Company_name { get; set; }
        [Required]
        public string address { get; set; }
        [Required, DataType(DataType.PhoneNumber)]
        public int phone_number { get; set; }
        [Required]
        public double Tax_Number { get; set; }
        [Required, DataType(DataType.EmailAddress)]
        public string E_mail { get; set; }
        [Required, DataType(DataType.Url)]
        public string Facebook { get; set; }
        [Required, DataType(DataType.Url)]
        public string Twitter { get; set; }
        [Required, DataType(DataType.PhoneNumber)]
        public int Whatsapp { get; set; }
        [Required]
        public string Print_type { get; set; }
        [Required]
        public string Cloud_type { get; set; }
        [Required, DataType(DataType.MultilineText)]
        public string note { get; set; }
        [Required,]
        public int thermal_printing { get; set; }//
        public string? logo { get; set; }//
        [NotMapped]
        [DisplayName("Upload image")]
        public IFormFile? imagefile { get; set; }
    }
}
