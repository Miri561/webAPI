using Entities;

namespace Repository
{
    public interface IRepository
    {
      abstract IEnumerable<string> Get();
        abstract Users Get(int id);
       abstract Users Post(Users user);
      abstract Users PostLogIn(Users user2);
      abstract void Put(int id, Users putuser);
    }
}