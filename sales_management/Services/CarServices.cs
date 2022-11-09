using sales_management.Models;

namespace sales_management.Services
{
    public class CarServices : IServices<Car>
    {
        private readonly ApplicationDbContext Context;

        public CarServices(ApplicationDbContext _context)
        {
            Context = _context;
        }
        public int Add(Car Model)
        {
            Context.Car.Add(Model);
            Context.SaveChanges();
            return Model.Id;
        }

        public void Delete(int id)
        {
            Context.Car.Remove(
                         Context.Car.FirstOrDefault(
                             t => t.Id == id));
            Context.SaveChanges();
        }

        public List<Car> GetAll()
        {
            return Context.Car.ToList();
        }

        public Car GetDeatails(int id)
        {
            return Context.Car.FirstOrDefault(t => t.Id == id);
        }

        public void Update(int id, Car Model)
        {
            Car Old = Context.Car.
                           FirstOrDefault(t => t.Id == id);
           
            Old.price = Model.price;
            Old.quantity = Model.quantity;
            Old.quantity = Model.quantity;
            Context.SaveChanges();
        }
    }
}
