using System.ComponentModel.DataAnnotations.Schema;

namespace sales_management.Models
{
    public class products
    {

        public int Id { get; set; }
        public string Name  { get; set; }
        public double highestPrice { get; set; }
        public double lowestPrice { get; set; }


        [ForeignKey("Category")]
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }

        [ForeignKey("Units")]
        public int UnitsId { get; set; }
        public virtual Units Units { get; set; }

        public virtual List<Car> car { get; set; }

    }
}
