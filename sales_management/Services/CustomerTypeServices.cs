using sales_management.Models;

namespace sales_management.Services
{
    public class CustomerTypeServices : IServices<CustomerType>
    {

        //GetAll
        //GetDetails(int id)
        //insert(CustomerType st);
        //Update(CustomerType st,int id);
        //delete(int id);
        private readonly ApplicationDbContext Context;

        public CustomerTypeServices(ApplicationDbContext _context)
        {
            Context = _context;
        }


        public int Add(CustomerType Model)
        {
            Context.CustomerTypes.Add(Model);
            Context.SaveChanges();
            return Model.Id;
        }

        public void Delete(int id)
        {
            Context.CustomerTypes.Remove(
                        Context.CustomerTypes.FirstOrDefault(
                            t => t.Id == id));
            Context.SaveChanges();
        }

        public List<CustomerType> GetAll()
        {
            return Context.CustomerTypes.ToList();
        }

        public CustomerType GetDeatails(int id)
        {
            return Context.CustomerTypes.FirstOrDefault(t=>t.Id==id);
        }

        public void Update(int id, CustomerType Model)
        {
            CustomerType Oldtype=Context.CustomerTypes.
                FirstOrDefault(t => t.Id == id);
            Oldtype.type=Model.type;
            Context.SaveChanges();
        }
    }
}
