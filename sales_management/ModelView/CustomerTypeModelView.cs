using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace sales_management.ModelView
{
    public class CustomerTypeModelView
    {
        [Required]

        public int Id { get; set; }

        [
       Required(ErrorMessage = "Category Type required "),
       Display(Name = " Customer Type "),
      // RegularExpression(@"^[a-zA-Z'\s]{1,100}$",
       // ErrorMessage = "you can use Characters, '-' only \n MinLength=1 \n, maxLength=100")
       ]
        //[Remote(action: "CheackType",
        //    controller: "CustomerType",
        //    AdditionalFields = "Id",
        //    ErrorMessage = "name eready exsit"),
        //    ]
        public string type { get; set; }


    }
}
