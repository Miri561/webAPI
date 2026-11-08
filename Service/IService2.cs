namespace Service
{
    public interface IService2
    {
        void Delete(int id);
        IEnumerable<string> Get();
        string Get(int id);
        int Post(string pass);
        void Put(int id, string value);
    }
}