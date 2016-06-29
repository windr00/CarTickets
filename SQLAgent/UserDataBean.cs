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


        public UserDataBean(string id, string name, int sex, string tele, string u_name, string u_pass)
        {
            this.user_id = id;
            user_real_name = name;
            this.sex = sex;
            tel = tele;
            user_name = u_name;
            user_pass = u_pass;
        }

    }
}
