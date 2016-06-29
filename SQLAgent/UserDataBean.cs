using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlAgent
{
    public class UserDataBean
    {
        public string user_id { get; private set; }
        public string user_real_name { get; set; }

        public int sex { get; set; }

        public string tel { get; set; }

        public string user_name { get; set; }

        public string user_pass { get; set; }

    }
}
