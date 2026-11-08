using Entities;

namespace Service
{
    public interface IServise
    {
        void Delete(int id);
        IEnumerable<string> Get();
        Users Get(int id);
        Users Post(Users user);
        Users PostLogIn(Users user2);
        void Put(int id, Users putuser);
    }
}