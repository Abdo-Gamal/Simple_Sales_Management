using Microsoft.EntityFrameworkCore;
using sales_management.ModelView;

namespace sales_management.Models
{
   
        public class ApplicationDbContext : DbContext
        {
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
            {
            }
        
       public DbSet<ProductCarRepoModelView> ProductCarRepoModelView { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public  DbSet<invoice> invoices  { get; set; }
        public  DbSet<CustomerType> CustomerTypes { get; set; }
        public  DbSet<Company_info> Company_infos { get; set; }
        public DbSet<Units> Units { get; set; }
        public DbSet<Car> Car { get; set; }

        public DbSet<Category> Category { get; set; }
        public DbSet<products> products { get; set; }
        public DbSet<sales_management.ModelView.DisplayInvoicsModelView> DisplayInvoicsModelView { get; set; }
       
      
    }

    
}
