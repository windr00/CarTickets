using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlAgent
{
   public  class LineDataBean
    {
        public int id { get; private set; }

        public string trainNum { get; set; }

        public int depCity { get; set; }

        public int arrCity { get; set; }

        public float price { get; set; }

        public DateTime depDate { get; set; }

        public DateTime arrDate { get; set; }

        public uint remainSeat { get; set; }

        public LineDataBean(int id, string num, int dep, int arr, float pri, DateTime dept, DateTime arrt)
        {
            this.id = id;
            trainNum = num;
            depCity = dep;
            arrCity = arr;
            price = pri;
            depDate = dept;
            arrDate = arrt;
        }
    } 
}
