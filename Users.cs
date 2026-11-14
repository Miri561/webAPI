    namespace MyProject
{
    public class Users
    {
       
            //Public properties are PascalCase in C#, e.g. FirstName. Don't rename them yet: the data file would stop loading. Use PropertyNameCaseInsensitive = true in the JSON options instead.
            public string firstName { get; set; }
            public string lastName { get; set; }
            
            public string useremail { get; set; }
            public string password { get; set; }
        public int id { get; set; }

    }
}
