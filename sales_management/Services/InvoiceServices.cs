using sales_management.Models;

namespace sales_management.Services
{
    public class InvoiceServices : IServices<invoice>
    {
        private readonly ApplicationDbContext Context;

        public InvoiceServices(ApplicationDbContext _context)
        {
            Context = _context;
        }
        public int Add(invoice Model)
        {
            Model.iscofirm = false;
            Context.invoices.Add(Model);
            Context.SaveChanges();
            return Model.Id;
        }

        public void Delete(int id)
        {
            Context.invoices.Remove(
                         Context.invoices.FirstOrDefault(
                             t => t.Id == id));
            Context.SaveChanges();
        }

        public List<invoice> GetAll()
        {
            return Context.invoices.ToList();
        }

        public invoice GetDeatails(int id)
        {
            return Context.invoices.FirstOrDefault(t => t.Id == id);
        }

        public void Update(int id, invoice Model)
        {
            invoice Old = Context.invoices.
                           FirstOrDefault(t => t.Id == id);
                Old.Date = DateTime.Now;
                    
            Old.customerId = Model.customerId;
            Context.SaveChanges();
        }
    }
}
