using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "China", "Japan", "Israel" };
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public ActionResult<Users> Get(int id)
        {
            using (StreamReader reader = System.IO.File.OpenText(FilePath))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    Users user =
                    JsonSerializer.Deserialize<Users>(currentUserInFile);
                    if (user.id == id)
                        return user;
                }
            }
            
            return NotFound();
        }

        // POST api/<UsersController>
        static string FilePath = "User.txt";
        [HttpPost]
        public ActionResult<Users> Post([FromBody] Users user)
        {
            
            int numberOfUsers = System.IO.File.ReadLines(FilePath).Count();
            user.id = numberOfUsers + 1;
            string userJson = JsonSerializer.Serialize(user);
            System.IO.File.AppendAllText(FilePath, userJson +
            Environment.NewLine);
            return CreatedAtAction(nameof(Get),new { id = user.id },user);

        }

       [HttpPost("Login")]
        public ActionResult<Users> PostLogIn([FromBody] Users user2)
        {
            using (StreamReader reader = System.IO.File.OpenText(FilePath))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    Users user =
                    JsonSerializer.Deserialize<Users>(currentUserInFile);
                    if (user.useremail == user2.useremail && user.password == user2.password)
                        return Ok(user);

                }
            }
            return NotFound();

        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Users putuser)
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
        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
