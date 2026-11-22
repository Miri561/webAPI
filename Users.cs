    namespace MyProject
{
    public class Users
    {
       
            //In C#, properties are written in PascalCase: FirstName. User.txt stores the current names: if you rename them, set PropertyNameCaseInsensitive = true in the JsonSerializerOptions, so the existing file still loads
            public string firstName { get; set; }
            public string lastName { get; set; }
            
            public string useremail { get; set; }
            public string password { get; set; }
        public int id { get; set; }

    }
}
