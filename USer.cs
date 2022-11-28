using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApplicationShulte
{
    public class User
    {
        public Guid id = Guid.Empty;
        public string login = string.Empty;
        public string name = string.Empty;
        public DateTime birthday = DateTime.Parse("01.01.1970");
        public string gender = string.Empty;
        public string user_type = string.Empty;
        public string passHash = string.Empty;
        
        public User() { }

        public User (Guid idCreat)
        {
            id = idCreat;   
        }
    }
}
