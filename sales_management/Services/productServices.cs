using sales_management.Models;

namespace sales_management.Services
{
    public class productServices : IServices<products>
    {
        private readonly ApplicationDbContext Context;

        public productServices(ApplicationDbContext _context)
        {
            Context = _context;
        }

        public int Add(products Model)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<products> GetAll()
        {
            return Context.products.ToList();
        }

        public products GetDeatails(int id)
        {
            return Context.products.Where(p=>p.Id==id).SingleOrDefault();

        }

        public void Update(int id, products Model)
        {
            throw new NotImplementedException();
        }
    }
}
