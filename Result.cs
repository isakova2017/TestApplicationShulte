using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApplicationShulte
{
    class Result
    {
        public Guid id = Guid.Empty;
        public string login = "";
        public DateTime dateCreated = DateTime.Parse("01.01.1970");
        public double workability = 0;
        public double mental_stab = 0;
    }
}
