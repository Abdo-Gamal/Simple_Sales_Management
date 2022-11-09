namespace sales_management.Services
{
    public interface IServices<T>
    {
        //comman function all services shoud implemnt
        List<T> GetAll();
        T GetDeatails(int id);
        int Add(T Model);
        void Update(int id,T Model);
        void Delete(int id);
    }
}
