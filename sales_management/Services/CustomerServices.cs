using sales_management.Models;
using sales_management.ModelView;

namespace sales_management.Services
{
    public class CustomerServices : IServices<Customer>
    {
        private readonly ApplicationDbContext context;
        public CustomerServices(ApplicationDbContext _context)
        {
            context = _context;
        }

        public int Add(Customer Model)
        {
            context.Customers.Add(Model);
            context.SaveChanges();
            return Model.Id;
        }

        public void Delete(int id)
        {
            context.Customers.Remove(
                context.Customers.FirstOrDefault(c=>c.Id==id));
            context.SaveChanges();
        }

        public List<Customer> GetAll()
        {
            return context.Customers.ToList();
        }
    
        public Customer GetDeatails(int id)
        {
            return context.Customers.FirstOrDefault(c => c.Id == id);
        }

        public void Update(int id, Customer Model)
        {
            Customer ctm= context.Customers.FirstOrDefault(c => c.Id == id);
            ctm.Customer_name = Model.Customer_name;
            ctm.Trade_Name = Model.Trade_Name;
            ctm.address = Model.address;
            ctm.Phone_number = Model.Phone_number;
            ctm.Opening_balance= Model.Opening_balance;
            ctm.Agent_code = Model.Agent_code;
            ctm.typeID = Model.typeID;
            context.SaveChanges();
        }
    }
}
