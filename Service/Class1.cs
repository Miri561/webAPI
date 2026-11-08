using Entities;
using Repository;
using System.Text.Json;
using Zxcvbn;

namespace Service
{
    public class Class1 : IServise
    {
        // GET: api/<UsersController>
        private IRepository _irepository;
        public Class1(IRepository irepository)
        {
            _irepository= irepository;
        }
        public IEnumerable<string> Get()
        {
            return new string[] { "China", "Japan", "Israel" };
        }

        // GET api/<UsersController>/5

        public Users Get(int id)
        {

            return _irepository.Get(id);
        }

        // POST api/<UsersController>
        static string FilePath = "User.txt";

        public Users Post(Users user)
        {

            return _irepository.Post(user);

        }


        public Users PostLogIn(Users user2)
        {

            return _irepository.PostLogIn(user2);

        }

        // PUT api/<UsersController>/5

        public void Put(int id, Users putuser)
        {
            _irepository.Put(id, putuser);
        }
        // DELETE api/<UsersController>/5

        public void Delete(int id)
        {
        }
    }


    public class Class3 : IService2
    {
        // GET: api/<Passwords>

        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<Passwords>/5

        public string Get(int id)
        {
            return "value";
        }

        // POST api/<Passwords>

        public int Post(string pass)
        {
            var re = Zxcvbn.Core.EvaluatePassword(pass);
            return re.Score;
        }

        // PUT api/<Passwords>/5

        public void Put(int id, string value)
        {
        }

        // DELETE api/<Passwords>/5

        public void Delete(int id)
        {
        }
    }
}

