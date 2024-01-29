using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMesseger
{
    public class User
    {
        public int id;
        public string first_name;
        public string last_name;
        
        public User(int id, string first_name, string last_name)
        {
            this.id = id;
            this.first_name = first_name;
            this.last_name = last_name;
        }
    }
}
