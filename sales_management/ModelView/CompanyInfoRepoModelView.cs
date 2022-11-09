using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace sales_management.ModelView
{
    public class CompanyInfoRepoModelView
    {

        public string Company_name { get; set; }
        public string address { get; set; }
        public int phone_number { get; set; }
        public string note { get; set; }

        public string Whatsapp { get; set; }


    }
}
