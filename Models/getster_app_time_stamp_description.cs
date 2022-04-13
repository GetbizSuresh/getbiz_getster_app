using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_getster_app.Models
{
    public class getster_app_time_stamp_description
    {
        public int id { get; set; }
        public string time { get; set; }
        public string title { get; set; }
        public string description { get; set; }
    }
     
    public class Root
    {
        public List<getster_app_time_stamp_description> data { get; set; }
    }
}
