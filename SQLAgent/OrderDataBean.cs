using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlAgent
{
    public class OrderDataBean
    {
        public int order_id { get; private set; }

        public string user_id { get; private set; }

        public int line_id { get; private set; }

        public int seat_num { get; private set; }

        public OrderDataBean(int order, string user, int line, int seat)
        {
            order_id = order;
            user_id = user;
            line_id = line;
            seat_num = seat;
        }

    }
}
