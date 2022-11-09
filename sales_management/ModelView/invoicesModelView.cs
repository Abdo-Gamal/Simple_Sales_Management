using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using EnvDTE;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace sales_management.ModelView
{
    public class invoicesModelView
    {

        [Required]
        public int Id { get; set; }

        [ DataType(DataType.DateTime)]
        public DateTime Date { get; set; }
        public int customerId { get; set; }

    }
}
