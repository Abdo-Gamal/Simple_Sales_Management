using sales_management.Models;

namespace sales_management.Services
{
    public class Company_infoServies : IServices<Company_info>
    {

        private readonly ApplicationDbContext context;
        public Company_infoServies(ApplicationDbContext _context)
        {
            context = _context;

        }
        public int Add(Company_info Model)
        {
            context.Company_infos.Add(Model);
            context.SaveChanges();
            return Model.Id;
        }


        public void Delete(int id)
        {
            context.Company_infos.Remove(
               context.Company_infos.FirstOrDefault(c => c.Id == id));
            context.SaveChanges();
        }

        public List<Company_info> GetAll()
        {
            return context.Company_infos.ToList();
        }

        public Company_info GetDeatails(int id)
        {
            return context.Company_infos.FirstOrDefault(c => c.Id == id);
        }

        public void Update(int id, Company_info Model)
        {
            Company_info cpn = context.Company_infos.
                FirstOrDefault(c => c.Id == id);
            cpn.address = Model.address;
            cpn.E_mail = Model.E_mail;
            cpn.Facebook = Model.Facebook;
            cpn.Tax_Number = Model.Tax_Number;
            cpn.logo = Model.logo;
            cpn.Cloud_type = Model.Cloud_type;
            cpn.Company_name = Model.Company_name;
            cpn.phone_number = Model.phone_number;
            cpn.Twitter = Model.Twitter;
            cpn.Whatsapp = Model.Whatsapp;
            cpn.thermal_printing = Model.thermal_printing;
            cpn.note = Model.note;
            cpn.Print_type = Model.Print_type;

            context.SaveChanges();
        }
    }
}
