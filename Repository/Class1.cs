using System.Text.Json;
using Entities;
namespace Repository
{


    public class Class2 : IRepository
    {
        public  IEnumerable<string> Get()
        {
            return new string[] { "China", "Japan", "Israel" };
        }

        // GET api/<UsersController>/5
        static string FilePath = "../Repository/User.txt";
        public Users Get(int id)
        {
            using (StreamReader reader = System.IO.File.OpenText(FilePath))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    Users user = JsonSerializer.Deserialize<Users>(currentUserInFile);
                    if (user.id == id)
                        return user;
                }
            }

            return null;
        }

        // POST api/<UsersController>


        public  Users Post(Users user)
        {

            int numberOfUsers = System.IO.File.ReadLines(FilePath).Count();
            user.id = numberOfUsers + 1;
            string userJson = JsonSerializer.Serialize(user);
            System.IO.File.AppendAllText(FilePath, userJson +
            Environment.NewLine);
            return user;

        }


        public  Users PostLogIn(Users user2)
        {
            using (StreamReader reader = System.IO.File.OpenText(FilePath))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    Users user =
                    JsonSerializer.Deserialize<Users>(currentUserInFile);
                    if (user.useremail == user2.useremail && user.password == user2.password)
                        return user;

                }
            }
            return null;

        }

        // PUT api/<UsersController>/5

        public  void Put(int id, Users putuser)
        {
            string textToReplace = string.Empty;
            using (StreamReader reader = System.IO.File.OpenText(FilePath))
            {
                string currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    Users user = JsonSerializer.Deserialize<Users>(currentUserInFile);
                    if (user.id == id)
                        textToReplace = currentUserInFile;
                }
            }
            if (textToReplace != string.Empty)
            {
                string text = System.IO.File.ReadAllText(FilePath);
                text = text.Replace(textToReplace, JsonSerializer.Serialize(putuser));
                System.IO.File.WriteAllText(FilePath, text);
            }
        }
    }
}
